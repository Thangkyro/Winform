using AusNail.Login;
using CoreBase;
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
    public partial class frmCheckPhone : Form
    {
        public int _branchId = 0;
        public int _UserId = 0;
        private DataTable _dtCustomer = null;
        private string sResult = "";
        private bool _firtRun = false;
        public frmCheckPhone()
        {
            InitializeComponent();
            txtPhone.Focus();
            this.Width = 370;
            this.Height = 500;
            this.pnSDT.Visible = true;
            lbSize.Text = "<<";
        }

        public frmCheckPhone(bool firtRun)
        {
            InitializeComponent();
            txtPhone.Focus();
            this.Width = 370;
            this.Height = 500;
            this.pnSDT.Visible = true;
            lbSize.Text = "<<";
            _firtRun = firtRun;
        }

        public frmCheckPhone(int branchId, int userId)
        {
            InitializeComponent();
            _branchId = branchId;
            _UserId = userId;
            txtPhone.Focus();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và các thao tác xóa, tiến lùi... Không nhập text.
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

            // Sự kiện bấm Enter
            if (e.KeyChar == 13)
            {
                btnConfirm_Click(sender, e);
            }
        }

        public string SendData()
        {
            return sResult;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text.Trim() == "")
            {
                MessageBox.Show("Please input phone number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

               // Kiểm tra tính hợp lệ của số điện thoại
                if (checkExiestCustomer(txtPhone.Text.Trim()))
                {
                    this.Visible = false;
                    this.ShowInTaskbar = false;
                    frmServiceAdd frm = new frmServiceAdd(_branchId, _UserId, _dtCustomer.Rows[0]["Name"].ToString(), txtPhone.Text.Trim());
                    frm.Activate();
                    frm.ShowDialog();
                    //sResult = txtPhone.Text.Trim() + "|" + _dtCustomer.Rows[0]["Name"].ToString();
                }
                else
                {
                    this.Visible = false;
                    this.ShowInTaskbar = false;
                    frmCusstomerAdd frm = new frmCusstomerAdd(_branchId, _UserId, txtPhone.Text.Trim());
                    frm.Activate();
                    frm.ShowDialog();
                    //sResult = txtPhone.Text.Trim();
                }
                txtPhone.Clear();
            }
            this.Close();
        }
        private bool checkExiestCustomer(string phoneNumber)
        {
            try
            {
                _dtCustomer = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zCustomerGetbyPhoneNum", phoneNumber);
            }
            catch
            {}
            return !(_dtCustomer == null || _dtCustomer.Rows.Count == 0);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            // Sự kiện bấm Enter
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm_Click(sender, e);
            }
        }

        private void frmCheckPhone_Load(object sender, EventArgs e)
        {
            if (_firtRun)
            {
                frmLogin lf = new frmLogin();
                if (lf.ShowDialog() != DialogResult.OK)
                {
                    Application.Exit();
                    return;
                }
                else
                {
                    _branchId = int.Parse(NailApp.BranchID);
                    _UserId = NailApp.CurrentUserId;

                    txtPhone.Focus();
                    txtPhone.Select();
                    //this.Width = 370;
                    //this.Height = 170;
                    //this.pnSDT.Visible = false;
                    //this.pnSDT.Visible = false;
                    this.Width = 370;
                    this.Height = 500;
                    this.pnSDT.Visible = true;
                    lbSize.Text = "<<";

                    ////Load permisson
                    NailApp.lstPermission = new List<string>();
                    NailApp.lstPermission = NailApp.PermissionUser.Split(',').ToList();
                }
            }
            else
            {
                _branchId = int.Parse(NailApp.BranchID);
                _UserId = NailApp.CurrentUserId;

                txtPhone.Focus();
                txtPhone.Select();
                //this.Width = 370;
                //this.Height = 170;
                //this.pnSDT.Visible = false;
                //this.pnSDT.Visible = false;
                this.Width = 370;
                this.Height = 500;
                this.pnSDT.Visible = true;
                lbSize.Text = "<<";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (lbSize.Text == ">>")
            {
                this.Width = 370;
                this.Height = 500;
                this.pnSDT.Visible = true;
                lbSize.Text = "<<";
            }
            else
            {
                this.Width = 370;
                this.Height = 170;
                this.pnSDT.Visible = false;
                lbSize.Text = ">>";
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = txtPhone.SelectionStart;
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "1" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = txtPhone.SelectionStart;
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "2" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = txtPhone.SelectionStart;
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "3" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = txtPhone.SelectionStart;
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "4" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = txtPhone.SelectionStart;
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "5" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = txtPhone.SelectionStart;
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "6" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = txtPhone.SelectionStart;
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "7" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = txtPhone.SelectionStart;
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "8" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = txtPhone.SelectionStart;
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "9" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = txtPhone.SelectionStart;
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "0" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                string strPhone = txtPhone.Text.Trim();
                int control = txtPhone.SelectionStart;
                if (control > 0)
                {
                    strPhone = strPhone.Substring(0, control - 1) + strPhone.Substring(control, strPhone.Length - control);
                    txtPhone.Text = strPhone;
                    txtPhone.SelectionStart = control - 1;
                }
            }
            catch (Exception ex)
            {
            }
            
        }
    }
}
