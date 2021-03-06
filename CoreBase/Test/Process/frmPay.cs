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
    public partial class frmPay : Form
    {
        private decimal _totalVoucher = 0;
        private int _billId;
        private int _bookingID = -1;
        private decimal _totalAmount = 0;
        private decimal _totalDiscount = 0;
        private decimal _Receivable = 0;
        private int _branchId = 0;
        private int _userId = 0;
        private DataTable _dtVoucher = null;
        private DataTable _dt = null;
        private decimal _PercenPay = 0;
        private decimal _MinApprovePercen = 0;
        private decimal _MaxPercen = 0;
        private bool _haveDiscount = false;
        public frmPay()
        {
            InitializeComponent();
        }

        public frmPay(int branchId, int bookingID, int billId, decimal totalAmount, int userId)
        {
            InitializeComponent();
            _branchId = branchId;
            _bookingID = bookingID;
            _billId = billId;
            _totalAmount = _Receivable = totalAmount;
            _userId = userId;
            _PercenPay = loadPercenPay(out _MinApprovePercen, out _MaxPercen);
            lblTotalAmount.Text = string.Format("{0:#,##0.00}", _totalAmount);
            txtCard.Text = string.Format("{0:#,##0.00}", _Receivable);
            createTable();
            loadVoucher();
            LoadGrid();
            txtCard.Enabled = false;
            txtCash.Enabled = false;
            dgvVoucher.Enabled = false;
        }

        public frmPay(int branchId, int bookingID, int billId, decimal totalAmount, decimal totalDiscount, int userId)
        {
            InitializeComponent();
            _branchId = branchId;
            _bookingID = bookingID;
            _billId = billId;
            _totalDiscount = totalDiscount;
            _haveDiscount = _totalDiscount > 0;
            _totalAmount = _Receivable = totalAmount;
            _userId = userId;
            _PercenPay = loadPercenPay(out _MinApprovePercen, out _MaxPercen);
            lblTotalAmount.Text = string.Format("{0:#,##0.00}", _totalAmount);
            lblTotalDiscount.Text = string.Format("{0:#,##0.00}", _totalDiscount);
            txtCard.Text = string.Format("{0:#,##0.00}", _Receivable);
            createTable();
            loadVoucher();
            LoadGrid();
            txtCard.Enabled = false;
            txtCash.Enabled = false;
            dgvVoucher.Enabled = false;
            this.BackColor = NailApp.ColorUser.IsEmpty == true || NailApp.ColorUser.Name == "0" ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
        }

        private void frmPay_Load(object sender, EventArgs e)
        {
            //this.BackColor = NailApp.ColorUser.IsEmpty == true || NailApp.ColorUser.Name == "0" ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
            groupBox1.BackColor = NailApp.ColorUser.IsEmpty == true || NailApp.ColorUser.Name == "0" ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;

        }
   

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                decimal paymentCard = decimal.Parse(txtCard.Text.Trim());
                decimal paymentCash = decimal.Parse(txtCash.Text.Trim());
                // Update bill 
                int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillUpdate", _billId, _branchId, paymentCash, paymentCard, _totalVoucher, _userId, 0, "");
                if (ret > 0)
                {
                    //Update voucher
                    decimal totalAmount = _totalAmount;
                    decimal voucherAmount = 0;
                    for (int i = 0; i < dgvVoucher.Rows.Count; i++)
                    {
                        if (dgvVoucher.Rows[i].Cells["VoucherCode"].Value != null && dgvVoucher.Rows[i].Cells["VoucherCode"].Value.ToString() != "")
                        {
                            voucherAmount = decimal.Parse(dgvVoucher.Rows[i].Cells["Amount"].Value.ToString());
                            if (totalAmount < voucherAmount)
                            {
                                voucherAmount = totalAmount;
                            }
                            int retIns = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zSaveVoucherBill", _billId, _branchId, i+1, dgvVoucher.Rows[i].Cells["VoucherCode"].Value.ToString(), voucherAmount, _userId, 0, "");
                            if (retIns > 0)
                            {
                                int retV = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zVoucherUpdateByBill", dgvVoucher.Rows[i].Cells["VoucherCode"].Value.ToString(), voucherAmount, _userId, 0, "");
                                if (retV > 0)
                                {
                                    totalAmount -= voucherAmount;
                                }
                                else
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            else
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    flag = true;
                }
                if (flag)
                {
                    MessageBox.Show("Pay faill.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.No;
                }
                else
                {
                    MessageBox.Show("Pay sucessfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
            }
            
        }

        private void txtCard_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal cardAmount = 0;
                cardAmount = decimal.Parse(txtCard.Text.Trim());
                if (cardAmount < 0)
                {
                    MessageBox.Show("Card amount must be greater than or equal to 0.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCard.Text = "0";
                    txtCard.Focus();
                }
                else
                {
                    if (cardAmount > _Receivable)
                    {
                        txtCard.Text = string.Format("{0:#,##0.00}", _Receivable);
                    }
                    else
                    {
                        if (_Receivable - cardAmount > _MinApprovePercen)
                        {
                            if ((_Receivable - cardAmount) * (1 - _PercenPay) > _MaxPercen && _MaxPercen != 0)
                            {
                                txtCash.Text = string.Format("{0:#,##0.00}", Lamtron((_Receivable - cardAmount - _MaxPercen)));
                            }
                            else
                            {
                                txtCash.Text = string.Format("{0:#,##0.00}", Lamtron((_Receivable - cardAmount) * _PercenPay));
                            }
                        }
                        else
                        {
                            txtCash.Text = string.Format("{0:#,##0.00}", Lamtron((_Receivable - cardAmount)));
                        }
                    }
                }
            }
            catch 
            {
            }
        }


        private void createTable()
        {
            _dt = new DataTable();
            _dt.Columns.Add("VoucherCode", typeof(string));
            _dt.Columns.Add("Quantity", typeof(decimal));
            _dt.Columns.Add("Amount", typeof(decimal));
        }

        private void loadVoucher()
        {
            try
            {
                _dtVoucher = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zVoucherGetListAvailable");
            }
            catch
            {
            }
        }

        private decimal loadPercenPay(out decimal MinApprovePercen, out decimal MaxPercen)
        {
            decimal result = 0;
            decimal result1 = 0;
            decimal result2 = 0;
            try
            {
                DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGetPercenPay", _branchId);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    result = decimal.Parse(dataTable.Rows[0]["PercenPay"].ToString());
                    result1 = decimal.Parse(dataTable.Rows[0]["MinApprovePercen"].ToString());
                    result2 = decimal.Parse(dataTable.Rows[0]["MaxPercen"].ToString());
                }
            }
            catch
            {
                result = 0;
                result1 = 0;
                result2 = 0;
            }
            MinApprovePercen = result1;
            MaxPercen = result2;
            return result;
        }

        private void LoadGrid()
        {
            dgvVoucher.DataSource = _dt;
            dgvVoucher.Columns["VoucherCode"].HeaderText = "Voucher Code";
            dgvVoucher.Columns["VoucherCode"].Width = 100;
            dgvVoucher.Columns["Quantity"].HeaderText = "Quantity";
            dgvVoucher.Columns["Quantity"].Width = 100;
            dgvVoucher.Columns["Amount"].HeaderText = "Amount";
            dgvVoucher.Columns["Amount"].ReadOnly = true;
            dgvVoucher.Columns["Amount"].Width = 120;

            DataGridViewImageColumn dataGridViewImange = new DataGridViewImageColumn();
            dataGridViewImange.Name = "Del";
            dataGridViewImange.HeaderText = "";
            dataGridViewImange.Width = 20;
            dataGridViewImange.Image = Properties.Resources.cancel;
            dgvVoucher.Columns.Add(dataGridViewImange);

            dgvVoucher.AutoGenerateColumns = false;
        }

        private void chkCard_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkCash_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkCompire_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCompire.Checked)
            {
                txtCard.Enabled = true;
                txtCash.Enabled = true;
                radCash.Checked = radCard.Checked = false;
                dgvVoucher.Enabled = true;
            }
            else
            {
                txtCard.Enabled = false;
                txtCash.Enabled = false;
                try
                {
                    dgvVoucher.Rows.Clear();
                }
                catch 
                {
                }
                dgvVoucher.DataSource = null;
                dgvVoucher.Enabled = false;
                _totalVoucher = 0;
                _Receivable = _totalAmount ;
                radCard.Checked = true;
            }
            txtCard.Text = _Receivable.ToString();
            txtCash.Text = "0";
            _totalDiscount = 0;
            lblTotalDiscount.Text = _totalDiscount.ToString();
        }

        private void dgvVoucher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return;
                }
                else
                {
                    if (e.ColumnIndex == 3) //Delete 
                    {
                        dgvVoucher.Rows.RemoveAt(e.RowIndex);
                        Caculate();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Caculate()
        {
            try
            {
                _totalVoucher = 0;
                // Total voucher
                for (int i = 0; i < dgvVoucher.Rows.Count; i++)
                {
                    if (dgvVoucher.Rows[i].Cells["VoucherCode"].Value != null)
                    {
                        _totalVoucher += decimal.Parse(dgvVoucher.Rows[i].Cells["Amount"].Value.ToString());
                    }
                }
                // Phai thanh toan
                _Receivable = _totalAmount - _totalVoucher;
                if (_Receivable < 0)
                {
                    _Receivable = 0;
                }
                if (radCard.Checked)
                {
                    txtCard.Text = string.Format("{0:#,##0.00}", _Receivable);
                    txtCash.Text = "0";
                }
                if (radCash.Checked)
                {
                    if (_Receivable  > _MinApprovePercen)
                    {
                        if (_Receivable * (1 - _PercenPay) > _MaxPercen && _MaxPercen != 0)
                        {
                            txtCash.Text = string.Format("{0:#,##0.00}", Lamtron((_Receivable - _MaxPercen)));
                        }
                        else
                        {
                            txtCash.Text = string.Format("{0:#,##0.00}", Lamtron(_Receivable * _PercenPay));
                        }
                    }
                    else
                    {
                        txtCash.Text = string.Format("{0:#,##0.00}", Lamtron((_Receivable)));
                    }
                    txtCard.Text = "0";
                }
                if (chkCompire.Checked)
                {
                    txtCard.Text = string.Format("{0:#,##0.00}", _Receivable);
                    txtCash.Text = "0";
                }                
            }
            catch (Exception ex)
            {
            }
        }

        private void dgvVoucher_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && (e.ColumnIndex == 0 || e.ColumnIndex == 1))
                {
                    string VoucherCode = dgvVoucher.Rows[e.RowIndex].Cells["VoucherCode"].Value.ToString();
                    DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zVoucherCheckAvailable", VoucherCode, DateTime.Now.AddHours(NailApp.TimeConfig).ToString());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (int.Parse(DateTime.Parse(dt.Rows[0]["VoucherFrom"].ToString()).ToString("yyyyMMdd")) > int.Parse(DateTime.Now.AddHours(NailApp.TimeConfig).ToString("yyyyMMdd")) || int.Parse(DateTime.Parse(dt.Rows[0]["VoucherTo"].ToString()).ToString("yyyyMMdd")) < int.Parse(DateTime.Now.AddHours(NailApp.TimeConfig).ToString("yyyyMMdd")))
                        {
                            MessageBox.Show("Expired Voucher. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvVoucher.Rows[e.RowIndex].Cells["VoucherCode"].Value = "";
                            dgvVoucher.Rows[e.RowIndex].Cells["Quantity"].Value = 0;
                            dgvVoucher.Rows[e.RowIndex].Cells["Amount"].Value = 0;
                        }
                        else if (dt.Rows[0]["is_inactive"].ToString() == "1")
                        {
                            MessageBox.Show("Voucher not active.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvVoucher.Rows[e.RowIndex].Cells["VoucherCode"].Value = "";
                            dgvVoucher.Rows[e.RowIndex].Cells["Quantity"].Value = 0;
                            dgvVoucher.Rows[e.RowIndex].Cells["Amount"].Value = 0;
                        }
                        else
                        {
                            decimal voucherAmount = decimal.Parse(dt.Rows[0]["AvailableAmount"].ToString());
                            dgvVoucher.Rows[e.RowIndex].Cells["Quantity"].Value = 1;
                            dgvVoucher.Rows[e.RowIndex].Cells["Amount"].Value = voucherAmount;
                            dgvVoucher.AllowUserToAddRows = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid voucher code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvVoucher.Rows[e.RowIndex].Cells["VoucherCode"].Value = "";
                        dgvVoucher.Rows[e.RowIndex].Cells["Quantity"].Value = 0;
                        dgvVoucher.Rows[e.RowIndex].Cells["Amount"].Value = 0;
                        dgvVoucher.AllowUserToAddRows = false;
                    }
                    Caculate();
                }
            }
            catch
            {
                dgvVoucher.Rows[e.RowIndex].Cells["Amount"].Value = 0;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCash_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal cashAmount = 0;
                cashAmount = decimal.Parse(txtCash.Text.Trim());
                if (cashAmount < 0)
                {
                    MessageBox.Show("Cash amount must be greater than or equal to 0.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCash.Text = "0";
                    txtCash.Focus();
                }
                else
                {
                    if (cashAmount > _Receivable)
                    {
                        txtCash.Text = string.Format("{0:#,##0.00}", Lamtron(_Receivable));
                    }
                    else
                    {
                        txtCard.Text = string.Format("{0:#,##0.00}", _Receivable - cashAmount);
                    }
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
                txtCard_Validated(sender, e);
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
                txtCash_Validated(sender, e);
            }
        }

        private void radCash_CheckedChanged(object sender, EventArgs e)
        {
            if (radCash.Checked && _totalDiscount == 0)
            {
                txtCard.Text = "0";
                decimal del = 0;
                if (_Receivable >= _MinApprovePercen)
                {
                    if (_Receivable * (1 - _PercenPay) > _MaxPercen && _MaxPercen != 0)
                    {
                        del = Lamtron((_Receivable - _MaxPercen));
                        txtCash.Text = string.Format("{0:#,##0.00}", Lamtron((_Receivable - _MaxPercen)));
                    }
                    else
                    {
                        del = Lamtron(_Receivable * _PercenPay);
                        txtCash.Text = string.Format("{0:#,##0.00}", Lamtron(_Receivable * _PercenPay));
                    }
                }
                else
                {
                    del = Lamtron((_Receivable));
                    txtCash.Text = string.Format("{0:#,##0.00}", Lamtron((_Receivable)));
                }
                if (!_haveDiscount)
                {
                    lblTotalDiscount.Text = string.Format("{0:#,##0.00}", Lamtron(_totalAmount - del));
                }
                chkCompire.Checked = false;
                radCash.Checked = true;
            }
            else
            {
                txtCash.Text = string.Format("{0:#,##0.00}", Lamtron((_Receivable)));
                txtCard.Text = "0";
            }
        }

        private void radCard_CheckedChanged(object sender, EventArgs e)
        {
            if (radCard.Checked)
            {
                txtCard.Text = string.Format("{0:#,##0.00}", _Receivable);
                txtCash.Text = "0";
                _totalDiscount = 0;
                lblTotalDiscount.Text = _totalDiscount.ToString();
                //chkCompire_CheckedChanged(sender, e);
                chkCompire.Checked = false;
            }
        }

        private void dgvVoucher_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    e.CellStyle.Format = "N0";
                }
                if (e.ColumnIndex == 2)
                {
                    e.CellStyle.Format = "N2";
                }
            }
            catch
            {
            }
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
