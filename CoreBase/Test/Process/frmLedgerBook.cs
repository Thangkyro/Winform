using ClosedXML.Excel;
using CoreBase;
using CoreBase.DataAccessLayer;
using CoreBase.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;

namespace AusNail.Process
{
    public partial class frmLedgerBook : Form
    {
        DataTable _dtGroup1 = new DataTable();
        DataTable _dtGroup2 = new DataTable();
        DateTime _dtF;
        DateTime _dtT;
        string _Group1 = string.Empty;
        string _Group2 = string.Empty;
        string _paramQuery1 = string.Empty;
        DataTable _dtResult = new DataTable();
        DataTable _dtResultDetail = new DataTable();
        private bool _isView = false;
        private bool _isAdd = false;
        BindingSource _bs = new BindingSource();
        public frmLedgerBook()
        {
            InitializeComponent();
            Load += Form_Load;
            this.BackColor = NailApp.ColorUser.IsEmpty == true || NailApp.ColorUser.Name == "0" ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            _dtGroup1.Columns.Add("LedgerDate", typeof(DateTime));
            _dtGroup1.Columns.Add("CashIn", typeof(double));
            _dtGroup1.Columns.Add("RevenueCash", typeof(double));
            _dtGroup1.Columns.Add("RevenueBank", typeof(double));
            _dtGroup1.Columns.Add("RenenueVoucher", typeof(double));
            _dtGroup1.Columns.Add("ExpenseCash", typeof(double));
            _dtGroup1.Columns.Add("CashOut", typeof(double));
            _dtGroup1.Columns.Add("CheckedCash", typeof(double));
            _dtGroup1.Columns.Add("Locked", typeof(bool));
        }

       
        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmLedgerAdd frm = new frmLedgerAdd();
                double cashin = 0;
                double revenueCash = 0;
                double revenueBank = 0;
                double revenueVoucher = 0;
                double ExpenseCash = 0;
                double CashOut = 0;
                double CheckedCash = 0;
                bool Lock = false;
                DateTime LedgerDate;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    cashin = frm.Cashin;
                    revenueCash = frm.RevenueCash;
                    revenueBank = frm.RevenueBank;
                    revenueVoucher = frm.RevenueVoucher;
                    ExpenseCash = frm.ExpenseCash;
                    CashOut = frm.CashOut;
                    CheckedCash = frm.zCheckedCash;
                    Lock = frm.Lock;
                    LedgerDate = frm.LedgerDate;

                    int retIns = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zLedgerBook_InsertValue", int.Parse(NailApp.BranchID), LedgerDate.Date, cashin, revenueCash, revenueBank, revenueVoucher, ExpenseCash, CashOut, CheckedCash, Lock, NailApp.CurrentUserId);
                    if (retIns > 0)
                    {
                        LoadData();
                        MessageBox.Show("Sucessfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Add Error.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

      
        private void LoadData()
        {
            try
            {
                DateTime dtF;
                DateTime dtT;
                DateTime.TryParseExact(dtpFrom.Text.Trim().ToString(), "dd/MM/yyyy",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out dtF);
                DateTime.TryParseExact(dtpTo.Text.Trim().ToString(), "dd/MM/yyyy",
                              CultureInfo.InvariantCulture,
                              DateTimeStyles.None,
                              out dtT);
                if (dtF == null)
                {
                    MessageBox.Show("Please choose date filter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (dtF.Year == 0001)
                {
                    MessageBox.Show("Date from invaild !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dtT == null)
                {
                    MessageBox.Show("Please choose date filter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (dtT.Year == 0001)
                {
                    MessageBox.Show("Date to invaild !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (dtT < dtF)
                {
                    MessageBox.Show("Date From can't more than Date To.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _dtResultDetail = (DataTable)dgvReportDetail.DataSource;

                _dtF = dtF;
                _dtT = dtT;
               
                _dtResultDetail = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGet_LedgerBook",  int.Parse(NailApp.BranchID),_dtF, _dtT);
                if (_dtResultDetail != null)
                {
                    LoadGrid(_dtResultDetail, true);
                    dgvReportDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                _isView = true;
                _isAdd = false;
            }
            catch (Exception ex)
            {

            }
        }
      
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }    
     
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_Validated(object sender, EventArgs e)
        {
            //// Load dữ liệu theo ngày.
            //DateTime dtF;
            //DateTime.TryParseExact(dateTimePicker1.Text.Trim().ToString(), "dd/MM/yyyy",
            //                  CultureInfo.InvariantCulture,
            //                  DateTimeStyles.None,
            //                  out dtF);
            //if (dtF == null)
            //{
            //    MessageBox.Show("Please choose date filter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //else if (dtF.Year == 0001)
            //{
            //    MessageBox.Show("Date from invaild !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zLedgerBook_GetBill", dtF, int.Parse(NailApp.BranchID));

            //// Khai báo dữ liệu add grid.
            //double cashin = 0;
            //double revenueCash = 0;
            //double revenueBank = 0;
            //double revenueVoucher = 0;
            //double totalAmount = 0;
            //double totalDiscount = 0;

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    if (dt.Rows[0]["IsLock"].ToString() == "1")
            //    {
            //        MessageBox.Show("Ledger book is lock for date: " + dtF.Date, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }

            //    double.TryParse(dt.Rows[0]["CashOut"].ToString(), out cashin);
            //    double.TryParse(dt.Rows[0]["PaymentCash"].ToString(), out revenueCash);
            //    double.TryParse(dt.Rows[0]["PaymentCard"].ToString(), out revenueBank);
            //    double.TryParse(dt.Rows[0]["PaymentVoucher"].ToString(), out revenueVoucher);
            //    double.TryParse(dt.Rows[0]["TotalAmount"].ToString(), out totalAmount);
            //    double.TryParse(dt.Rows[0]["TotalDiscount"].ToString(), out totalDiscount);
            //}
            //_dtGroup1.Rows.Clear();
            //DataRow dr = _dtGroup1.NewRow();
            //dr["LedgerDate"] = dtF;
            //dr["CashIn"] = cashin;
            //dr["RevenueCash"] = revenueCash;
            //dr["RevenueBank"] = revenueBank;
            //dr["RenenueVoucher"] = revenueVoucher;
            //dr["ExpenseCash"] = 0;
            //dr["CashOut"] = 0;
            //dr["CheckedCash"] = 0;
            //dr["Locked"] = false;
            //_dtGroup1.Rows.Add(dr);
            //LoadGrid(_dtGroup1, false);
            //dgvReportDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //_isView = false;
            //_isAdd = true;
        }

        private void dgvReportDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 5 || e.ColumnIndex == 6) && dgvReportDetail.Rows.Count > 0)
            {
                double CheckedCash = 0, CashIn = 0, RevenueCash = 0, ExpenseCash = 0, CashOut = 0;
                double.TryParse(dgvReportDetail.Rows[0].Cells["CheckedCash"].Value.ToString(), out CheckedCash);
                double.TryParse(dgvReportDetail.Rows[0].Cells["CashIn"].Value.ToString(), out CashIn);
                double.TryParse(dgvReportDetail.Rows[0].Cells["RevenueCash"].Value.ToString(), out RevenueCash);
                double.TryParse(dgvReportDetail.Rows[0].Cells["ExpenseCash"].Value.ToString(), out ExpenseCash);
                double.TryParse(dgvReportDetail.Rows[0].Cells["CashOut"].Value.ToString(), out CashOut);
                CheckedCash = CashIn + RevenueCash - ExpenseCash - CashOut;
                dgvReportDetail.Rows[0].Cells["CheckedCash"].Value = CheckedCash;
            }
        }

        private void LoadGrid(DataTable dt, bool viewer)
        {
            dgvReportDetail.DataSource = dt;
            dgvReportDetail.Columns["LedgerID"].Visible = false;
            dgvReportDetail.Columns["LedgerDate"].HeaderText = "Ledger Date";
            dgvReportDetail.Columns["LedgerDate"].ReadOnly = true;
            dgvReportDetail.Columns["LedgerDate"].Width = 100;
            dgvReportDetail.Columns["CashIn"].HeaderText = "Cash In";
            dgvReportDetail.Columns["CashIn"].ReadOnly = true;
            dgvReportDetail.Columns["CashIn"].Width = 100;
            dgvReportDetail.Columns["RevenueCash"].HeaderText = "Revenue Cash";
            dgvReportDetail.Columns["RevenueCash"].ReadOnly = true;
            dgvReportDetail.Columns["RevenueCash"].Width = 100;

            dgvReportDetail.Columns["RevenueBank"].HeaderText = "Revenue Bank";
            dgvReportDetail.Columns["RevenueBank"].ReadOnly = true;
            dgvReportDetail.Columns["RevenueBank"].Width = 100;

            dgvReportDetail.Columns["RenenueVoucher"].HeaderText = "Revenue Voucher";
            dgvReportDetail.Columns["RenenueVoucher"].ReadOnly = true;
            dgvReportDetail.Columns["RenenueVoucher"].Width = 100;

            dgvReportDetail.Columns["ExpenseCash"].HeaderText = "ExpenseCash";
            dgvReportDetail.Columns["ExpenseCash"].ReadOnly = viewer;
            dgvReportDetail.Columns["ExpenseCash"].Width = 100;

            dgvReportDetail.Columns["CashOut"].HeaderText = "Cash Out";
            dgvReportDetail.Columns["CashOut"].ReadOnly = viewer;
            dgvReportDetail.Columns["CashOut"].Width = 100;

            dgvReportDetail.Columns["CheckedCash"].HeaderText = "Checked Cash";
            dgvReportDetail.Columns["CheckedCash"].ReadOnly = true;
            dgvReportDetail.Columns["CheckedCash"].Width = 100;

            dgvReportDetail.Columns["Locked"].ReadOnly = true;

            dgvReportDetail.AutoGenerateColumns = true;
        }

        private void delteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private DialogResult MessNotifications(string title, string message)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            return result;
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            // Khai báo dữ liệu Edit grid.
            double LedgerID = 0;
            double cashin = 0;
            double revenueCash = 0;
            double revenueBank = 0;
            double revenueVoucher = 0;
            double ExpenseCash = 0;
            double CashOut = 0;
            double CheckedCash = 0;
            bool Lock = false;
            DateTime LedgerDate;
            if (dgvReportDetail.SelectedCells.Count > 0)
            {
                //string id = gridview.SelectedCells[0].Value.ToString();
                double.TryParse(dgvReportDetail.SelectedRows[0].Cells["LedgerID"].Value.ToString(), out LedgerID);
                double.TryParse(dgvReportDetail.SelectedRows[0].Cells["CashIn"].Value.ToString(), out cashin);
                double.TryParse(dgvReportDetail.SelectedRows[0].Cells["RevenueCash"].Value.ToString(), out revenueCash);
                double.TryParse(dgvReportDetail.SelectedRows[0].Cells["RevenueBank"].Value.ToString(), out revenueBank);
                double.TryParse(dgvReportDetail.SelectedRows[0].Cells["RenenueVoucher"].Value.ToString(), out revenueVoucher);
                double.TryParse(dgvReportDetail.SelectedRows[0].Cells["ExpenseCash"].Value.ToString(), out ExpenseCash);
                double.TryParse(dgvReportDetail.SelectedRows[0].Cells["CashOut"].Value.ToString(), out CashOut);
                double.TryParse(dgvReportDetail.SelectedRows[0].Cells["CheckedCash"].Value.ToString(), out CheckedCash);
                DateTime.TryParse(dgvReportDetail.SelectedRows[0].Cells["LedgerDate"].Value.ToString(), out LedgerDate);
                if (dgvReportDetail.SelectedRows[0].Cells["Locked"].Value.ToString() == "True")
                {
                    Lock = true;
                }
                frmLedgerAdd frm = new frmLedgerAdd();
                frm.Cashin = cashin;
                frm.RevenueCash = revenueCash;
                frm.RevenueBank = revenueBank;
                frm.RevenueVoucher = revenueVoucher;
                frm.ExpenseCash = ExpenseCash;
                frm.CashOut = CashOut;
                frm.zCheckedCash = CheckedCash;
                frm.Lock = Lock;
                frm.LedgerDate = LedgerDate;
                frm.ModeEdit = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    cashin = frm.Cashin;
                    revenueCash = frm.RevenueCash;
                    revenueBank = frm.RevenueBank;
                    revenueVoucher = frm.RevenueVoucher;
                    ExpenseCash = frm.ExpenseCash;
                    CashOut = frm.CashOut;
                    CheckedCash = frm.zCheckedCash;
                    Lock = frm.Lock;
                    int error = 0;
                    string errorMesg = "";
                    int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zUpd_LedgerBook", LedgerID, int.Parse(NailApp.BranchID), cashin,
                        revenueCash, revenueBank, revenueVoucher, ExpenseCash, CashOut, CheckedCash, Lock, NailApp.CurrentUserId, error, errorMesg);
                    if (ret > 0)
                    {
                        LoadData();
                    }
                    else if (!string.IsNullOrEmpty(errorMesg))
                    {
                        MessageBox.Show(errorMesg, "Error");
                    }
                }
            }
        }
        private void Delete()
        {
            double LedgerID = 0;
            if (dgvReportDetail.SelectedCells.Count > 0)
            {
                double.TryParse(dgvReportDetail.SelectedRows[0].Cells["LedgerID"].Value.ToString(), out LedgerID);
            }
            if (LedgerID != 0)
            {
                DialogResult result = MessNotifications("Notifications", "Do you want delete line?");
                if (result == DialogResult.Yes)
                {
                    int error = 0;
                    string errorMesg = "";
                    //Delete LedgerBook
                    int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zDel_LedgerBook", LedgerID, int.Parse(NailApp.BranchID), error, errorMesg);
                    if (ret > 0)
                    {
                        LoadData();
                    }
                    else if (!string.IsNullOrEmpty(errorMesg))
                    {
                        MessageBox.Show(errorMesg, "Error");
                    }
                }
            }
        }
    }
}
