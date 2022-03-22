using CoreBase;
using CoreBase.DataAccessLayer;
using CoreBase.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            get { return _cashin; }
            set { _cashin = value;

                lblCashIn.Text = string.Format("{0:#,##0.00}", _cashin);
            }
        }
        private double _revenueCash = 0;
        public double RevenueCash
        {
            get { return _revenueCash; }
            set { _revenueCash = value;
                lblRevenueCash.Text = string.Format("{0:#,##0.00}", _revenueCash);
            }
        }
        private double _revenueBank = 0;
        public double RevenueBank
        {
            get { return _revenueBank; }
            set {
                _revenueBank = value;
                lblRevenueBank.Text = string.Format("{0:#,##0.00}", _revenueBank);
            }
        }
        private double _revenueVoucher = 0;
        public double RevenueVoucher
        {
            get { return _revenueVoucher; }
            set { _revenueVoucher = value;

                lblRenenueVoucher.Text = string.Format("{0:#,##0.00}", _revenueVoucher);
            }
        }
        private double _CashOut = 0;
        public double CashOut
        {
            get { return _CashOut; }
            set { _CashOut = value; }
        }

        private double _zCheckedCash = 0;
        public double zCheckedCash
        {
            get { return _zCheckedCash; }
            set { _zCheckedCash = value; }
        }

        private bool _modeEdit = false; //true = edit  false = add"


        public frmLedgerAdd()
        {
            InitializeComponent();
        }

        public frmLedgerAdd(int branchId)
        {
            InitializeComponent();
 
            createTable();
            loadVoucher();
           // LoadGrid();
            txtExpenseCash.Enabled = false;
            txtCashOut.Enabled = false;
            //dgvVoucher.Enabled = false;
        }

        private void frmPay_Load(object sender, EventArgs e)
        {
            //this.BackColor = NailApp.ColorUser.IsEmpty == true || NailApp.ColorUser.Name == "0" ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
            groupBox1.BackColor = NailApp.ColorUser.IsEmpty == true || NailApp.ColorUser.Name == "0" ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;

        }
   

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
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

        private void txtCard_Validated(object sender, EventArgs e)
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
                    //lblCheckedCash.Text = string.Format("{0:#,##0.00}", Lamtron((CashIn + RevenueCash - ExpenseCash - CashOut)));
                }
            }
            catch 
            {
            }
        }


        private void createTable()
        {
            //_dt = new DataTable();
            //_dt.Columns.Add("VoucherCode", typeof(string));
            //_dt.Columns.Add("Quantity", typeof(decimal));
            //_dt.Columns.Add("Amount", typeof(decimal));
        }

        private void loadVoucher()
        {
            //try
            //{
            //    _dtVoucher = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zVoucherGetListAvailable");
            //}
            //catch
            //{
            //}
        }
        private void chkCard_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkCash_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkCompire_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkLocked.Checked)
            //{
            //    txtExpenseCash.Enabled = true;
            //    txtCashOut.Enabled = true;
            //    radCash.Checked = radCard.Checked = false;
            //    dgvVoucher.Enabled = true;
            //}
            //else
            //{
            //    txtExpenseCash.Enabled = false;
            //    txtCashOut.Enabled = false;
            //    try
            //    {
            //        dgvVoucher.Rows.Clear();
            //    }
            //    catch 
            //    {
            //    }
            //    dgvVoucher.DataSource = null;
            //    dgvVoucher.Enabled = false;
            //    _totalVoucher = 0;
            //    _Receivable = _totalAmount ;
            //    radCard.Checked = true;
            //}
            //txtExpenseCash.Text = _Receivable.ToString();
            //txtCashOut.Text = "0";
            //_totalDiscount = 0;
            //lblRenenueVoucher.Text = _totalDiscount.ToString();
        }

        private void dgvVoucher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex < 0 || e.ColumnIndex < 0)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        if (e.ColumnIndex == 3) //Delete 
            //        {
            //            dgvVoucher.Rows.RemoveAt(e.RowIndex);
            //            Caculate();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void Caculate()
        {
            //try
            //{
            //    _totalVoucher = 0;
            //    // Total voucher
            //    for (int i = 0; i < dgvVoucher.Rows.Count; i++)
            //    {
            //        if (dgvVoucher.Rows[i].Cells["VoucherCode"].Value != null)
            //        {
            //            _totalVoucher += decimal.Parse(dgvVoucher.Rows[i].Cells["Amount"].Value.ToString());
            //        }
            //    }
            //    // Phai thanh toan
            //    _Receivable = _totalAmount - _totalVoucher;
            //    if (_Receivable < 0)
            //    {
            //        _Receivable = 0;
            //    }
            //    if (radCard.Checked)
            //    {
            //        txtExpenseCash.Text = string.Format("{0:#,##0.00}", _Receivable);
            //        txtCashOut.Text = "0";
            //    }
            //    if (radCash.Checked)
            //    {
            //        if (_Receivable  > _MinApprovePercen)
            //        {
            //            if (_Receivable * (1 - _PercenPay) > _MaxPercen && _MaxPercen != 0)
            //            {
            //                txtCashOut.Text = string.Format("{0:#,##0.00}", Lamtron((_Receivable - _MaxPercen)));
            //            }
            //            else
            //            {
            //                txtCashOut.Text = string.Format("{0:#,##0.00}", Lamtron(_Receivable * _PercenPay));
            //            }
            //        }
            //        else
            //        {
            //            txtCashOut.Text = string.Format("{0:#,##0.00}", Lamtron((_Receivable)));
            //        }
            //        txtExpenseCash.Text = "0";
            //    }
            //    if (chkLocked.Checked)
            //    {
            //        txtExpenseCash.Text = string.Format("{0:#,##0.00}", _Receivable);
            //        txtCashOut.Text = "0";
            //    }                
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private void dgvVoucher_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex > -1 && (e.ColumnIndex == 0 || e.ColumnIndex == 1))
            //    {
            //        string VoucherCode = dgvVoucher.Rows[e.RowIndex].Cells["VoucherCode"].Value.ToString();
            //        DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zVoucherCheckAvailable", VoucherCode, DateTime.Now.AddHours(NailApp.TimeConfig).ToString());
            //        if (dt != null && dt.Rows.Count > 0)
            //        {
            //            if (int.Parse(DateTime.Parse(dt.Rows[0]["VoucherFrom"].ToString()).ToString("yyyyMMdd")) > int.Parse(DateTime.Now.AddHours(NailApp.TimeConfig).ToString("yyyyMMdd")) || int.Parse(DateTime.Parse(dt.Rows[0]["VoucherTo"].ToString()).ToString("yyyyMMdd")) < int.Parse(DateTime.Now.AddHours(NailApp.TimeConfig).ToString("yyyyMMdd")))
            //            {
            //                MessageBox.Show("Expired Voucher. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                dgvVoucher.Rows[e.RowIndex].Cells["VoucherCode"].Value = "";
            //                dgvVoucher.Rows[e.RowIndex].Cells["Quantity"].Value = 0;
            //                dgvVoucher.Rows[e.RowIndex].Cells["Amount"].Value = 0;
            //            }
            //            else if (dt.Rows[0]["is_inactive"].ToString() == "1")
            //            {
            //                MessageBox.Show("Voucher not active.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                dgvVoucher.Rows[e.RowIndex].Cells["VoucherCode"].Value = "";
            //                dgvVoucher.Rows[e.RowIndex].Cells["Quantity"].Value = 0;
            //                dgvVoucher.Rows[e.RowIndex].Cells["Amount"].Value = 0;
            //            }
            //            else
            //            {
            //                decimal voucherAmount = decimal.Parse(dt.Rows[0]["AvailableAmount"].ToString());
            //                dgvVoucher.Rows[e.RowIndex].Cells["Quantity"].Value = 1;
            //                dgvVoucher.Rows[e.RowIndex].Cells["Amount"].Value = voucherAmount;
            //                dgvVoucher.AllowUserToAddRows = true;
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Invalid voucher code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            dgvVoucher.Rows[e.RowIndex].Cells["VoucherCode"].Value = "";
            //            dgvVoucher.Rows[e.RowIndex].Cells["Quantity"].Value = 0;
            //            dgvVoucher.Rows[e.RowIndex].Cells["Amount"].Value = 0;
            //            dgvVoucher.AllowUserToAddRows = false;
            //        }
            //        Caculate();
            //    }
            //}
            //catch
            //{
            //    dgvVoucher.Rows[e.RowIndex].Cells["Amount"].Value = 0;
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCash_Validated(object sender, EventArgs e)
        {
            //try
            //{
            //    decimal cashAmount = 0;
            //    cashAmount = decimal.Parse(txtCashOut.Text.Trim());
            //    if (cashAmount < 0)
            //    {
            //        MessageBox.Show("Cash amount must be greater than or equal to 0.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtCashOut.Text = "0";
            //        txtCashOut.Focus();
            //    }
            //    else
            //    {
            //        if (cashAmount > _Receivable)
            //        {
            //            txtCashOut.Text = string.Format("{0:#,##0.00}", Lamtron(_Receivable));
            //        }
            //        else
            //        {
            //            txtExpenseCash.Text = string.Format("{0:#,##0.00}", _Receivable - cashAmount);
            //        }
            //    }
            //}
            //catch
            //{
            //}
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

        private void radCash_CheckedChanged(object sender, EventArgs e)
        {
            //if (radCash.Checked && _totalDiscount == 0)
            //{
            //    txtExpenseCash.Text = "0";
            //    decimal del = 0;
            //    if (_Receivable >= _MinApprovePercen)
            //    {
            //        if (_Receivable * (1 - _PercenPay) > _MaxPercen && _MaxPercen != 0)
            //        {
            //            del = Lamtron((_Receivable - _MaxPercen));
            //            txtCashOut.Text = string.Format("{0:#,##0.00}", Lamtron((_Receivable - _MaxPercen)));
            //        }
            //        else
            //        {
            //            del = Lamtron(_Receivable * _PercenPay);
            //            txtCashOut.Text = string.Format("{0:#,##0.00}", Lamtron(_Receivable * _PercenPay));
            //        }
            //    }
            //    else
            //    {
            //        del = Lamtron((_Receivable));
            //        txtCashOut.Text = string.Format("{0:#,##0.00}", Lamtron((_Receivable)));
            //    }
            //    if (!_haveDiscount)
            //    {
            //        lblRenenueVoucher.Text = string.Format("{0:#,##0.00}", Lamtron(_totalAmount - del));
            //    }
            //    chkLocked.Checked = false;
            //    radCash.Checked = true;
            //}
            //else
            //{
            //    txtCashOut.Text = string.Format("{0:#,##0.00}", Lamtron((_Receivable)));
            //    txtExpenseCash.Text = "0";
            //}
        }

        private void radCard_CheckedChanged(object sender, EventArgs e)
        {
            //if (radCard.Checked)
            //{
            //    txtExpenseCash.Text = string.Format("{0:#,##0.00}", _Receivable);
            //    txtCashOut.Text = "0";
            //    _totalDiscount = 0;
            //    lblRenenueVoucher.Text = _totalDiscount.ToString();
            //    //chkCompire_CheckedChanged(sender, e);
            //    chkLocked.Checked = false;
            //}
        }

        private void dgvVoucher_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == 1)
            //    {
            //        e.CellStyle.Format = "N0";
            //    }
            //    if (e.ColumnIndex == 2)
            //    {
            //        e.CellStyle.Format = "N2";
            //    }
            //}
            //catch
            //{
            //}
        }

        private void txtCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private decimal Lamtron(decimal number)
        {
            decimal So = 0;
            decimal numberFloor = Math.Floor(number);
            decimal chenhlech = number - numberFloor;
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
    }

}
