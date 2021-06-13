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
    public partial class frmCusstomerAdd : Form
    {
        private string _idCustomerName = "CustId";
        private string _tableNameCustomer = "zCustomer";
        private int _branchId = 2;
        private int _UserId = 1;
        private string _phoneNumber = "";
        public frmCusstomerAdd()
        {
            InitializeComponent();
            txtPhoneNum.Focus();
        }

        public frmCusstomerAdd(int branchId, int userId)
        {
            InitializeComponent();
            _branchId = branchId;
            _UserId = userId;
            txtPhoneNum.Focus();
        }

        public frmCusstomerAdd(int branchId, int userId, string phonemuber)
        {
            InitializeComponent();
            _branchId = branchId;
            _UserId = userId;
            _phoneNumber = phonemuber;
            txtPhoneNum.Text = _phoneNumber;
            txtPhoneNum.Focus();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            zCustomerInsert();
        }
        private void zCustomerInsert()
        {
            try
            {
                string PhoneNumber1 = this.txtPhoneNum.Text.Trim();
                string Name = this.txtName.Text.Trim();
                string Gender = "Male";
                if (radFemale.Checked)
                {
                    Gender = "Female";
                }
                if (radOrder.Checked)
                {
                    Gender = "Order";
                }
                string DateOfBirth = this.txtDateofBirth.Text.Trim();
                string PostCode = this.txtPostcode.Text.Trim();
                string CustomerCode = GenCustomerCode();
                // kiem tra khong được đặt mã trùng
                int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zCustomerInsert", _branchId, CustomerCode, Name, Gender, PhoneNumber1, "", "", "", DateOfBirth, PostCode, 0, 0, "", 0, _UserId, DateTime.Now.ToString(), _UserId, DateTime.Now.ToString(), 0, "");

                if (ret > 0)
                {
                    string customerName = txtName.Text.Trim();
                    string phoneNumber = txtPhoneNum.Text.Trim();
                    this.Visible = false;
                    this.ShowInTaskbar = false;
                    Process.frmServiceAdd frm = new frmServiceAdd(_branchId, _UserId, customerName, phoneNumber);
                    frm.Activate();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Add customer not sucessful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenCustomerCode()
        {
            string customerCode = "";
            try
            {
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGetNewCode", _tableNameCustomer, "CR", _idCustomerName, 8);
                if (dt != null)
                {
                    customerCode = dt.Rows[0][0].ToString();
                }
            }
            catch
            { }
            return customerCode;
        }

        enum Gender
        {
            Male,
            Female,
            Order
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCusstomerAdd_Load(object sender, EventArgs e)
        {
            txtPhoneNum.Focus();
        }
    }
}
