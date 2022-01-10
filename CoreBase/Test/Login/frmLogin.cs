using CoreBase;
using CoreBase.DAL;
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

namespace AusNail.Login
{
    public partial class frmLogin : CoreBase.WinForm.Dictionary.FormCollectInfo
    {
        public static int _userID;
        DataTable _dmdvcs = new DataTable();
        public frmLogin()
        {
            InitializeComponent();
            Load += LoginForm_Load;
            this.BackColor = NailApp.ColorUser.IsEmpty == true ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void loadCbBranch(string user)
        {
            bool admin = true;
            string branch = "";
            string sqlGetInfo = "Select is_admin, branchId From zUser with(nolock) Where user_name = '" + user + "'";
            DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, sqlGetInfo);
            if (dt != null)
            {
                admin = bool.Parse(dt.Rows[0][0].ToString());
                branch = dt.Rows[0][1].ToString();
            }
            using (ReadOnlyDAL dal = new ReadOnlyDAL("zBranch"))
            {
                if (admin)
                {
                    _dmdvcs = dal.Read("is_inactive = 0");
                }
                else
                {
                    _dmdvcs = dal.Read("is_inactive = 0 and branchId = " + branch);
                }
            }

            _dmdvcs.DefaultView.Sort = "BranchCode";

            cboBranch.DisplayMember = "BranchName";
            cboBranch.ValueMember = "branchId";
            cboBranch.DataSource = _dmdvcs.DefaultView;
            //cboBranch.SelectedValue = "A02";
        }

        protected override bool zValidInfo()
        {
            if (!base.zValidInfo())
                return false;

            if (txtUsername.Text == "")
            {
                MessageBox.Show("Please input user name.", "Warning");
                txtUsername.Focus();
                return false;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please input Password.", "Warning");
                txtPassword.Focus();
                return false;
            }
            if (cboBranch.SelectedValue == null)
            {
                MessageBox.Show("Please choose Branch.", "Warning");
                cboBranch.Focus();
                return false;
            }

            if (!CheckUser())
            {
                MessageBox.Show("User Name or Password is invalid", "Warning");
                txtUsername.Focus();
                return false;
            }

            return true;
        }

        private bool CheckUser()
        {
            try
            {
                bool bResult = false;
                _userID = 0;
                string sqlGetInfo = "Select UserID From zUser with(nolock) Where user_name = '" + txtUsername.Text + "'";
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, sqlGetInfo);
                if (dt != null)
                {
                    _userID = int.Parse(dt.Rows[0][0].ToString());
                }
                if (_userID != 0)
                {
                    DataRow userRow = null;
                    int TimeConfig = 0;
                    Cursor = Cursors.WaitCursor;
                    string branchID = cboBranch.SelectedValue.ToString();

                    using (SecurityDAO sDAO = new SecurityDAO())
                    {
                        userRow = sDAO.GetUserRow(int.Parse(branchID), txtUsername.Text, 
                            Encryptor.MD5Hash("123456Aa") + 
                            //Encryptor.MD5Hash(branchID) + 
                            Encryptor.MD5Hash(_userID.ToString()) + 
                            Encryptor.MD5Hash(txtPassword.Text.Trim()));
                        //userRow = sDAO.GetUserRow(int.Parse(branchID), txtUsername.Text, txtPassword.Text);

                        TimeConfig = sDAO.GetTimeConfig(); 
                    }
                    Cursor = Cursors.Default;

                    if (userRow == null)
                    {
                        return false;
                    }
                    else
                    {
                        bResult = true;
                    }

                    NailApp.CurrentUserRow = userRow;
                    NailApp.BranchID = branchID;
                    NailApp.TimeConfig = TimeConfig;
                    NailApp.ColorUser = ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml(userRow["ColorUser"].zToString()), 0);
                    NailApp.BillDate = txtbillDate.Value.Date;

                }
                else
                {
                    bResult = false;
                }
                return bResult;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtbillDate.Value = DateTime.Now;
            txtUsername.Focus();
        }

        private void txtUsername_Validated(object sender, EventArgs e)
        {
            loadCbBranch(txtUsername.Text.Trim());
        }

        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    //this.Close();
        //}

        //private void btnOk_Click(object sender, EventArgs e)
        //{
        //    //if (DialogResult == DialogResult.OK)
        //    //{
        //    //    frmMain frm = new frmMain();
        //    //    frm.Sender(int.Parse(cboBranch.SelectedValue.ToString()), _userID);
        //    //    this.Close();
        //    //}
        //}

    }
}
