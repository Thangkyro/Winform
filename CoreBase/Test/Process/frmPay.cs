﻿using CoreBase.DataAccessLayer;
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
        private decimal _Receivable = 0;
        private int _branchId = 0;
        private int _userId = 0;
        private DataTable _dtVoucher = null;
        private DataTable _dt = null;
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
            lblTotalAmount.Text = string.Format("{0:#,##0.00}", _totalAmount);
            createTable();
            loadVoucher();
            LoadGrid();
            txtCard.Enabled = false;
            txtCash.Enabled = false;
        }

        private void frmPay_Load(object sender, EventArgs e)
        {

        }
     


        private  void SaveBill(int bookingid, string voucherCode, decimal discountAmount, decimal cardAmount, decimal cashAmount)
        {
            try
            {
                int error = 0;
                string errorMesg = "";
                // Get billCode
                string billCode = "";
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGetNewCode", "zBillMaster", "BL", "BillID", 8);
                if (dt != null)
                {
                    billCode = dt.Rows[0][0].ToString();
                }  
                int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillInsert", _branchId, _bookingID, voucherCode, discountAmount, cardAmount, cashAmount, _userId, error, errorMesg);
                if (ret > 0)
                {
                    MessageBox.Show("Pay sucessfull.", "Question", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch 
            {
            }
            
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            try
            {
                decimal paymentCard = decimal.Parse(txtCard.Text.Trim());
                decimal paymentCash = decimal.Parse(txtCash.Text.Trim());
                // Update bill 
                int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillUpdate", _billId, _branchId, paymentCash, paymentCard, _totalVoucher, _userId, 0, "");
                if (ret > 0)
                {
                    //Update voucher
                }
                else
                {
                    MessageBox.Show("Pay faill.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
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
                        txtCash.Text = string.Format("{0:#,##0.00}", _Receivable - cardAmount);
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
            chkCard.Checked = true;
            txtCard.Enabled = true;
            chkCash.Checked = true;
            txtCash.Enabled = true;
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
                if (chkCard.Checked & !chkCash.Checked)
                {
                    txtCard.Text = string.Format("{0:#,##0.00}", _Receivable);
                }
                if (!chkCard.Checked & chkCash.Checked)
                {
                    txtCash.Text = string.Format("{0:#,##0.00}", _Receivable);
                }
                if (chkCompire.Checked)
                {
                    txtCard.Text = string.Format("{0:#,##0.00}", _Receivable);
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
                    DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zVoucherCheckAvailable", VoucherCode, DateTime.Now.ToString());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        decimal Quantity = decimal.Parse(dgvVoucher.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                        decimal voucherAmount = decimal.Parse(dt.Rows[0]["AvailableAmount"].ToString());
                        dgvVoucher.Rows[e.RowIndex].Cells["Amount"].Value = voucherAmount * Quantity;
                    }
                    else
                    {
                        MessageBox.Show("Invalid voucher code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvVoucher.Rows[e.RowIndex].Cells["VoucherCode"].Value = "";
                        dgvVoucher.Rows[e.RowIndex].Cells["Amount"].Value = 0;
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
                        txtCash.Text = string.Format("{0:#,##0.00}", _Receivable);
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
    }

}
