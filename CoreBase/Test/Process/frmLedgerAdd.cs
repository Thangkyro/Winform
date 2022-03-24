using CoreBase;
using CoreBase.DataAccessLayer;
using CoreBase.Helpers;
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
    public partial class frmLedgerAdd : Form
    {

        private double _cashin = 0;
        public double Cashin
        {
            get { return double.Parse(lblCashIn.Text.Trim()) ; }
            set { _cashin = value;
                lblCashIn.Text = string.Format("{0:#,##0.00}", _cashin);
            }
        }
        private double _revenueCash = 0;
        public double RevenueCash
        {
            get { return double.Parse(lblRevenueCash.Text.Trim()); }
            set { _revenueCash = value;
                lblRevenueCash.Text = string.Format("{0:#,##0.00}", _revenueCash);
            }
        }
        private double _revenueBank = 0;
        public double RevenueBank
        {
            get { return double.Parse(lblRevenueBank.Text.Trim()); }
            set {
                _revenueBank = value;
                lblRevenueBank.Text = string.Format("{0:#,##0.00}", _revenueBank);
            }
        }
        private double _revenueVoucher = 0;
        public double RevenueVoucher
        {
            get { return double.Parse(lblRenenueVoucher.Text.Trim()); }
            set { _revenueVoucher = value;
                lblRenenueVoucher.Text = string.Format("{0:#,##0.00}", _revenueVoucher);
            }
        }
        private double _CashOut = 0;
        public double CashOut
        {
            get { return double.Parse(txtCashOut.Text.Trim()); }
            set { _CashOut = value;
                txtCashOut.Text = string.Format("{0:#,##0.00}", _CashOut);
            }
        }

        private double _ExpenseCash = 0;
        public double ExpenseCash
        {
            get { return double.Parse(txtExpenseCash.Text.Trim()); }
            set { _ExpenseCash = value;
                txtExpenseCash.Text = string.Format("{0:#,##0.00}", _ExpenseCash);
            }
        }

        private double _zCheckedCash = 0;
        public double zCheckedCash
        {
            get { return double.Parse(lblCheckedCash.Text.Trim()); }
            set { _zCheckedCash = value;
                lblCheckedCash.Text = string.Format("{0:#,##0.00}", _zCheckedCash);
            }
        }

        private bool _lock = false;
        public bool Lock
        {
            get { return chkLocked.Checked; }
            set { _lock = value;
                chkLocked.Checked = value;
            }
        }

        private DateTime _LedgerDate;
        public System.DateTime LedgerDate
        {
            get { return dtpDate.Value; }
            set { _LedgerDate = value;
                dtpDate.Value = value;
            }
        }

        private bool _modeEdit = false; //true = edit  false = add"
        public bool ModeEdit
        {
            get { return _modeEdit; }
            set { _modeEdit = value; }
        }

        public frmLedgerAdd()
        {
            InitializeComponent();
            
        }

        private void frmPay_Load(object sender, EventArgs e)
        {
            //this.BackColor = NailApp.ColorUser.IsEmpty == true || NailApp.ColorUser.Name == "0" ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
            groupBox1.BackColor = NailApp.ColorUser.IsEmpty == true || NailApp.ColorUser.Name == "0" ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
            if (ModeEdit)
            {
                btnRefresh.Visible = true;
            }
            else
            {
                btnRefresh.Visible = false;
                dtpDate.Enabled = true;
                LoadData();
            }
            txtExpenseCash.Focus();
        }
   

        private void btnCreateBill_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
            //try
            //{
            //    bool flag = false;
            //    decimal paymentCard = decimal.Parse(txtExpenseCash.Text.Trim());
            //    decimal paymentCash = decimal.Parse(txtCashOut.Text.Trim());
            //    // Update bill 
            //    int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillUpdate", _billId, _branchId, paymentCash, paymentCard, _totalVoucher, _userId, 0, "");
            //    if (ret > 0)
            //    {
            //        //Update voucher
            //        decimal totalAmount = _totalAmount;
            //        decimal voucherAmount = 0;
            //        for (int i = 0; i < dgvVoucher.Rows.Count; i++)
            //        {
            //            if (dgvVoucher.Rows[i].Cells["VoucherCode"].Value != null && dgvVoucher.Rows[i].Cells["VoucherCode"].Value.ToString() != "")
            //            {
            //                voucherAmount = decimal.Parse(dgvVoucher.Rows[i].Cells["Amount"].Value.ToString());
            //                if (totalAmount < voucherAmount)
            //                {
            //                    voucherAmount = totalAmount;
            //                }
            //                int retIns = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zSaveVoucherBill", _billId, _branchId, i+1, dgvVoucher.Rows[i].Cells["VoucherCode"].Value.ToString(), voucherAmount, _userId, 0, "");
            //                if (retIns > 0)
            //                {
            //                    int retV = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zVoucherUpdateByBill", dgvVoucher.Rows[i].Cells["VoucherCode"].Value.ToString(), voucherAmount, _userId, 0, "");
            //                    if (retV > 0)
            //                    {
            //                        totalAmount -= voucherAmount;
            //                    }
            //                    else
            //                    {
            //                        flag = true;
            //                        break;
            //                    }
            //                }
            //                else
            //                {
            //                    flag = true;
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        flag = true;
            //    }
            //    if (flag)
            //    {
            //        MessageBox.Show("Pay faill.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        this.DialogResult = DialogResult.No;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Pay sucessfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.DialogResult = DialogResult.OK;
            //        this.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //}

        }

        private void txtExpenseCash_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal cardAmount = 0;
                cardAmount = decimal.Parse(txtExpenseCash.Text.Trim());
                if (cardAmount < 0)
                {
                    MessageBox.Show("Card amount must be greater than or equal to 0.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtExpenseCash.Text = "0";
                    txtExpenseCash.Focus();
                }
                else
                {
                    CallMoney();
                }
            }
            catch 
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtCash_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal cashAmount = 0;
                cashAmount = decimal.Parse(txtCashOut.Text.Trim());
                if (cashAmount < 0)
                {
                    MessageBox.Show("Cash amount must be greater than or equal to 0.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCashOut.Text = "0";
                    txtCashOut.Focus();
                }
                else
                {
                    CallMoney();
                }
            }
            catch
            {
            }
        }

        private void txtCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và các thao tác xóa, tiến lùi... Không nhập text.
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

            // Sự kiện bấm Enter
            if (e.KeyChar == 13)
            {
                //txtCard_Validated(sender, e);
            }
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và các thao tác xóa, tiến lùi... Không nhập text.
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

            // Sự kiện bấm Enter
            if (e.KeyChar == 13)
            {
                //txtCash_Validated(sender, e);
            }
        }

        private void txtCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private double Lamtron(double number)
        {
            double So = 0;
            double numberFloor = Math.Floor(number);
            double chenhlech = number - numberFloor;
            if (double.Parse(chenhlech.ToString()) >= 0.5)
            {
                So = numberFloor + 1;
            }
            else
            {
                So = numberFloor;
            }
            return So;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Load dữ liệu theo ngày.
            DateTime dtF;
            DateTime.TryParseExact(dtpDate.Text.Trim().ToString(), "dd/MM/yyyy",
                              CultureInfo.InvariantCulture,
                              DateTimeStyles.None,
                              out dtF);
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
            DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zLedgerBook_GetBill", dtF, int.Parse(NailApp.BranchID));           

            if (dt != null && dt.Rows.Count > 0)
            {
                //if (dt.Rows[0]["IsLock"].ToString() == "1")
                //{
                //    MessageBox.Show("Ledger book is lock for date: " + dtF.Date, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
               
                //txtCashOut.Text = "0";
                //txtExpenseCash.Text = "0";
                lblCashIn.Text = dt.Rows[0]["CashOut"].ToString();
                //lblCheckedCash.Text = "0";
                lblRenenueVoucher.Text = dt.Rows[0]["PaymentVoucher"].ToString();
                lblRevenueBank.Text = dt.Rows[0]["PaymentCard"].ToString();
                lblRevenueCash.Text = dt.Rows[0]["PaymentCash"].ToString();
                CallMoney();
                chkLocked.Checked = false;
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // Load dữ liệu theo ngày.
            DateTime dtF;
            DateTime.TryParseExact(dtpDate.Text.Trim().ToString(), "dd/MM/yyyy",
                              CultureInfo.InvariantCulture,
                              DateTimeStyles.None,
                              out dtF);
            if (dtF == null)
            {
                MessageBox.Show("Please choose date filter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (dtF.Year == 0001)
            {
                //MessageBox.Show("Date from invaild !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _LedgerDate = dtF.Date;

            DataTable dtCheck = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zLedgerBook_CheckDate", dtF, int.Parse(NailApp.BranchID));
            if (dtCheck != null && dtCheck.Rows.Count > 0)
            {
                if (dtCheck.Rows[0]["IsExist"].ToString() == "1")
                {
                    MessageBox.Show("Ledger book exsist for date : " + dtF.Date, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zLedgerBook_GetBill", dtF, int.Parse(NailApp.BranchID));

            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["IsLock"].ToString() == "1")
                {
                    MessageBox.Show("Ledger book is lock for date: " + dtF.Date, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                txtCashOut.Text = "0";
                txtExpenseCash.Text = "0";
                lblCashIn.Text = dt.Rows[0]["CashOut"].ToString();
                //lblCheckedCash.Text = "0";
                lblRenenueVoucher.Text = dt.Rows[0]["PaymentVoucher"].ToString();
                lblRevenueBank.Text = dt.Rows[0]["PaymentCard"].ToString();
                lblRevenueCash.Text = dt.Rows[0]["PaymentCash"].ToString();
                CallMoney();
                chkLocked.Checked = false;
            }
        }
        private void CallMoney()
        {
            double CashIn = double.Parse(lblCashIn.Text.Trim());
            lblCheckedCash.Text = string.Format("{0:#,##0.00}", Lamtron((CashIn + RevenueCash + RevenueBank + RevenueVoucher - ExpenseCash - CashOut)));
        }
        }

}
