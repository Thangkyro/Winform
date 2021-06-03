using CoreBase.DataAccessLayer;
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
        private bool _applyVoucher = false; // Dùng để ràng buộc trường hợp dùng nhiều voucher
        private int _bookingID = -1;
        private decimal _totalAmount = 0;
        private decimal _Receivable = 0;
        private decimal _voucherAmount = 0;
        private decimal _discoutAmount = 0;
        private int _branchId = 0;
        private int _userId = 0;
        public frmPay()
        {
            InitializeComponent();
        }

        public frmPay(int branchId, int bookingID, decimal totalAmount, int userId)
        {
            InitializeComponent();
            _branchId = branchId;
            _bookingID = bookingID;
            _totalAmount = _Receivable = totalAmount;
            _userId = userId;
            lblTotalAmount.Text = string.Format("{0:#,##0.00}", _totalAmount);
            lblReceivable.Text = string.Format("{0:#,##0.00}", _Receivable);
        }

        private void frmPay_Load(object sender, EventArgs e)
        {

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtVoucherCode.Text.Trim() == "")
                {
                    MessageBox.Show("Voucher code is not empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!_applyVoucher)
                    {
                        DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zVoucherCheckAvailable", txtVoucherCode.Text.Trim(), DateTime.Now.ToString());
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            _voucherAmount = decimal.Parse(dt.Rows[0]["Amount"].ToString());
                            _Receivable = _totalAmount - _voucherAmount - _discoutAmount;
                            lblReceivable.Text = string.Format("{0:#,##0.00}", _Receivable);
                            _applyVoucher = true;
                        }
                        else
                        {
                            MessageBox.Show("Invalid voucher code..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtVoucherCode.Clear();
                            txtVoucherCode.Focus();
                        }
                    }
                    else
                    {
                        // trường hợp sử dụng nhiều voucher
                    }
                }
            }
            catch
            {
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và các thao tác xóa, tiến lùi... Không nhập text.
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

            // Sự kiện bấm Enter
            if (e.KeyChar == 13)
            {
                txtDiscount_Validated(sender, e);
            }
        }

        private void txtDiscount_Validated(object sender, EventArgs e)
        {
            try
            {
                if ( int.Parse(txtDiscount.Text.Trim()) < 0 || int.Parse(txtDiscount.Text.Trim()) > 100)
                {
                    MessageBox.Show("Discount must be between 0 and 100.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiscount.Text = "0";
                    txtDiscount.Focus();
                }
                else
                {
                    _discoutAmount = int.Parse(txtDiscount.Text.Trim()) * _totalAmount / 100;
                    lblDiscount.Text = string.Format("{0:#,##0.00}", _discoutAmount);
                    _Receivable = _totalAmount - _voucherAmount - _discoutAmount;
                    lblReceivable.Text = string.Format("{0:#,##0.00}", _Receivable);
                }
            }
            catch 
            {
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                btnCreateBill.Text = "Create Bill and Print";
            }
            else
            {
                btnCreateBill.Text = "Create Bill";
            }
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
                    // Update booking

                    // Update vouccher

                    // Post

                    // Update revenue
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
                decimal cashAmount = _Receivable - decimal.Parse(txtCard.Text.Trim());
                SaveBill(_bookingID, txtVoucherCode.Text.Trim(), _discoutAmount, decimal.Parse(txtCard.Text.Trim()), cashAmount);
                if (checkBox1.Checked)
                {
                    // In
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
                    lblCash.Text = string.Format("{0:#,##0.00}", _Receivable - cardAmount);
                }
            }
            catch 
            {
            }
        }

    }
}
