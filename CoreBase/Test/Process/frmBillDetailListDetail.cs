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
    public partial class frmBillDetailListDetail : Form
    {
        private int _branchID = 0;
        private string _group1 = string.Empty;
        private string _paramChoose1 = string.Empty;
        private string _group2 = string.Empty;
        private string _paramChoose2 = string.Empty;
        private DateTime _dtF;
        private DateTime _dtT;

        private int _userID = 0;
        private int _billID = 0;
        private DataTable _dtService = null;
        private DataTable _dtStaff = null;
        private DataTable _Service = null;
        private DataTable _dtBookingMaster = null;
        private DataTable _dtBookingDetail = null;
        private DateTime _dateChoose;

        public frmBillDetailListDetail(int branchID, string group1, string group2, string paramChoose1, string paramChoose2, DateTime dtF, DateTime dtT)
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

            _branchID = branchID;
            _userID = NailApp.CurrentUserId;
            _group1 = group1;
            _group2 = group2;
            _paramChoose1 = paramChoose1;
            _paramChoose2 = paramChoose2;
            _dtF = dtF;
            _dtT = dtT;
            LoadGrid();
        }

        #region Method

        private void LoadGrid()
        {
            try
            {
                _dtBookingDetail = new DataTable();
                _dtBookingDetail = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillDetailList_GetByGroup", _dtF, _dtT, _group1, _group2, _paramChoose1, _paramChoose2, _branchID, "List");
                if (_dtBookingDetail != null && _dtBookingDetail.Rows.Count > 0)
                {
                    dgvService.DataSource = _dtBookingDetail;
                    //dgvService.Columns["ServiceName"].HeaderText = "Service Name";
                    //dgvService.Columns["ServiceName"].DisplayIndex = 0;
                    //dgvService.Columns["ServiceName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //dgvService.Columns["StaffName"].HeaderText = "Staff";
                    //dgvService.Columns["StaffName"].DisplayIndex = 1;
                    //dgvService.Columns["Quantity"].HeaderText = "Quantity";
                    //dgvService.Columns["Quantity"].DisplayIndex = 2;
                    //dgvService.Columns["Price"].HeaderText = "Price";
                    //dgvService.Columns["Price"].DisplayIndex = 3;
                    //dgvService.Columns["Discount"].HeaderText = "Discount";
                    //dgvService.Columns["Discount"].DisplayIndex = 4;
                    //dgvService.Columns["Amout"].HeaderText = "Amout";
                    //dgvService.Columns["Amout"].DisplayIndex = 5;
                    //dgvService.Columns["Note"].HeaderText = "Note";
                    //dgvService.Columns["Note"].DisplayIndex = 6;

                    //dgvService.Columns["BillDTID"].Visible = false;
                    //dgvService.Columns["BillID"].Visible = false;
                    //dgvService.Columns["OrderNumber"].Visible = false;
                    //dgvService.Columns["branchId"].Visible = false;
                    //dgvService.Columns["ServiceID"].Visible = false;
                    //dgvService.Columns["EstimateTime"].Visible = false;
                    //dgvService.Columns["StaffId"].Visible = false;
                    //dgvService.Columns["created_by"].Visible = false;
                    //dgvService.Columns["created_at"].Visible = false;


                    dgvService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvService.AutoGenerateColumns = false;
                    dgvService.AllowUserToAddRows = false;
                    dgvService.AllowUserToDeleteRows = false;

                    decimal _totalAmount = decimal.Parse(_dtBookingDetail.Compute("sum(TotalAmount)", "").ToString());
                    lblTotalAmont.Text = string.Format("{0:#,##0.00}", _totalAmount);
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

    }
}
