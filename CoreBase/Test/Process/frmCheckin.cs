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
    public partial class frmCheckin : Form
    {
        string _branchId = "";
        DataTable _dtCustomer = null;
        string _idCustomer = "CustId";
        string _idCustomerPhoneName1 = "PhoneNumber1";
        string _idCustomerPhoneName2 = "PhoneNumber2";
        string _tableNameCustomer = "zCustomer";
        public frmCheckin()
        {
            InitializeComponent();
        }

        public frmCheckin(string branchID)
        {
            InitializeComponent();
            _branchId = branchID;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và các thao tác xóa, tiến lùi... Không nhập text.
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void LoadTabCustomerInfor()
        {
            DataRow dr = _dtCustomer.Rows[0];
            txtPhoneNumber.Text = dr["PhoneNumber1"].ToString();
            txt_C_Name.Text = dr["Name"].ToString();
            txt_C_DateofBirth.Text = dr["DateOfBirth"].ToString();
            txt_C_Postcode.Text = dr["PostCode"].ToString();
        }

        private bool checkExiestCustomer(string phoneNumber)
        {
            using (DictionaryDAL dal = new DictionaryDAL(_tableNameCustomer))
            {
                // Check phone number 1
                _dtCustomer = dal.GetData(_idCustomerPhoneName1, txtPhoneNumber.Text.Trim());
                if (_dtCustomer == null || _dtCustomer.Rows.Count == 0)
                {
                    // Check phone number 2
                    _dtCustomer = dal.GetData(_idCustomerPhoneName2, txtPhoneNumber.Text.Trim());
                }
            }

            return !(_dtCustomer == null || _dtCustomer.Rows.Count == 0);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (checkExiestCustomer(txtPhoneNumber.Text.Trim()))
            {
                zCustomerGetList();
            }
            else
            {
                // Send data phone number qua ben tab customer infor.
                txt_C_PhoneNumber.Text = txtPhoneNumber.Text;
                // Hien nut Create and Register, An nut Edit Bocking
                btnCreate.Enabled = true;
                btnEditBooking.Enabled = false;
            }
        }

        private void zCustomerGetList()
        {
            // Load thong tin => Dua du lieu vao tab customer infor.
            LoadTabCustomerInfor();
            // Load thong tin boking xuong detail
            LoadBookingDetail();
            // An nut Create and Register, Hien nut Edit Bocking
            btnCreate.Enabled = false;
            btnEditBooking.Enabled = true;
        }

        private void LoadBookingDetail()
        {
        }

        private string GenCustomerCode()
        {
            string customerCode = "";
            DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGetNewCode", _tableNameCustomer, "CR", _idCustomer, 8, 0 , "");
            if (dt != null)
            {
                customerCode = dt.Rows[0][0].ToString();
            }
            return customerCode;
        }

        private void zCustomerInsert()
        {

            string PhoneNumber1 = this.txt_C_PhoneNumber.Text.Trim();
            string Name = this.txt_C_Name.Text.Trim() ;
            string Gender = this.cboGender.Text.Trim();
            string DateOfBirth = this.txt_C_DateofBirth.Text.Trim();
            string PostCode = this.txt_C_Postcode.Text.Trim();
            string CustomerCode = GenCustomerCode();
            string CreateBy = "";
            // kiem tra khong được đặt mã trùng
            try
            {
                int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zCustomerInsert", _branchId, CustomerCode, Name, Gender, PhoneNumber1, "", DateOfBirth, PostCode, 0, 0, null, 0, CreateBy, DateTime.Now.ToString(), CreateBy, DateTime.Now.ToString());

                if (ret == 0)
                { 

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            zCustomerInsert();
        }
    }
}
