using CoreBase;
using CoreBase.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AusNail.Process
{
    public partial class frmBillDetail : Form
    {
        private int _branchID = 0;
        private int _userID = 0;
        private int _billID = 0;
        private DataTable _dtService = null;
        private DataTable _dtStaff = null;
        private DataTable _Service = null;
        private DataTable _dtBookingMaster = null;
        private DataTable _dtBookingDetail = null;
        private DateTime _dateChoose;

        public frmBillDetail(int billID, int branchID)
        {
            InitializeComponent();
            try
            {
                panel1.BackColor = NailApp.ColorUser;
                panel2.BackColor = NailApp.ColorUser;
            }
            catch
            {
            }

            _billID = billID;
            _branchID = branchID;
            _userID = NailApp.CurrentUserId;
            LoadMaster();
            LoadGrid();
        }

        #region Method

        private void LoadMaster()
        {
            try
            {
                if (_billID != 0)
                {
                    _dtBookingMaster = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillMasterGetInfor", _billID, _branchID);
                    if (_dtBookingMaster != null && _dtBookingMaster.Rows.Count > 0)
                    {
                        txtBillCode.Text = _dtBookingMaster.Rows[0]["BillCode"].ToString();
                        txtBillDate.Text = DateTime.Parse(_dtBookingMaster.Rows[0]["BillDate"].ToString()).ToString("dd/MM/yyyy");
                        txtCustomerName.Text = _dtBookingMaster.Rows[0]["Cusstomername"].ToString();
                        txtCustomerPhone.Text = _dtBookingMaster.Rows[0]["CustomerPhone"].ToString();
                        txtDes.Text = _dtBookingMaster.Rows[0]["Decriptions"].ToString();

                        decimal _Cash = decimal.Parse(_dtBookingMaster.Rows[0]["PaymentCash"].ToString());
                        lblCash.Text = string.Format("{0:#,##0.00}", _Cash);
                        lblCard.Text = string.Format("{0:#,##0.00}", decimal.Parse(_dtBookingMaster.Rows[0]["PaymentCard"].ToString()));
                        lblVoucher.Text = string.Format("{0:#,##0.00}", decimal.Parse(_dtBookingMaster.Rows[0]["PaymentVoucher"].ToString()));
                        //lblTotalAmont.Text = string.Format("{0:#,##0.00}", decimal.Parse(_dtBookingMaster.Rows[0]["TotalEstimatePrice"].ToString()));
                        //lblTotalDiscount.Text = string.Format("{0:#,##0.00}", decimal.Parse(_dtBookingMaster.Rows[0]["TotalDiscount"].ToString()));
                        //dtpBookingDate.Enabled = false;
                        _dtBookingDetail = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillDetailGetList_History", _billID, _branchID);
                        decimal _totalAmount = decimal.Parse(_dtBookingDetail.Compute("sum(Amout)", "").ToString());
                        lblTotalAmont.Text = string.Format("{0:#,##0.00}", _totalAmount);
                        lblTotalDiscount.Text = string.Format("{0:#,##0.00}", _totalAmount - _Cash);
                    }

                }

            }
            catch (Exception)
            {

            }
        }
        private void LoadGrid()
        {
            try
            {
                if (_dtBookingDetail != null && _dtBookingDetail.Rows.Count > 0)
                {
                    dgvService.DataSource = _dtBookingDetail;
                    dgvService.Columns["ServiceName"].HeaderText = "Service Name";
                    dgvService.Columns["ServiceName"].DisplayIndex = 0;
                    dgvService.Columns["ServiceName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvService.Columns["StaffName"].HeaderText = "Staff";
                    dgvService.Columns["StaffName"].DisplayIndex = 1;
                    dgvService.Columns["Quantity"].HeaderText = "Quantity";
                    dgvService.Columns["Quantity"].DisplayIndex = 2;
                    dgvService.Columns["Price"].HeaderText = "Price";
                    dgvService.Columns["Price"].DisplayIndex = 3;
                    dgvService.Columns["Discount"].HeaderText = "Discount";
                    dgvService.Columns["Discount"].DisplayIndex = 4;
                    dgvService.Columns["Amout"].HeaderText = "Amout";
                    dgvService.Columns["Amout"].DisplayIndex = 5;
                    dgvService.Columns["Note"].HeaderText = "Note";
                    dgvService.Columns["Note"].DisplayIndex = 6;

                    dgvService.Columns["BillDTID"].Visible = false;
                    dgvService.Columns["BillID"].Visible = false;
                    dgvService.Columns["OrderNumber"].Visible = false;
                    dgvService.Columns["branchId"].Visible = false;
                    dgvService.Columns["ServiceID"].Visible = false;
                    dgvService.Columns["EstimateTime"].Visible = false;
                    dgvService.Columns["StaffId"].Visible = false;
                    dgvService.Columns["created_by"].Visible = false;
                    dgvService.Columns["created_at"].Visible = false;


                    //dgvService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvService.AutoGenerateColumns = false;
                    dgvService.AllowUserToAddRows = false;
                    dgvService.AllowUserToDeleteRows = false;
                }

            }
            catch (Exception ex)
            {

            }

        }


        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (NailApp.IsAutoPrint())
                {
                    if (_billID != 0)
                    {
                        DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillPrint", _billID, _branchID);
                        DataSet dsData = new DataSet();
                        dsData.Tables.Add(dataTable);
                        frmPrintNew f = new frmPrintNew(dsData, "rpt_bill.rpt", false, _branchID, _billID);
                        f.ShowDialog();
                    }
                }
                else
                {
                    DialogResult dialogResultPrint = MessageBox.Show("Do you want to print bill ?", "Print Bill", MessageBoxButtons.YesNo);
                    if (dialogResultPrint == DialogResult.Yes)
                    {
                        if (_billID != 0)
                        {
                            DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillPrint", _billID, _branchID);
                            DataSet dsData = new DataSet();
                            dsData.Tables.Add(dataTable);
                            frmPrintNew f = new frmPrintNew(dsData, "rpt_bill.rpt", NailApp.IsAutoPrint(), _branchID, _billID);
                            f.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

    }
}
