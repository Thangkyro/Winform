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
        DataTable _dmdvcs = new DataTable();
        public frmLogin()
        {
            InitializeComponent();
            Load += LoginForm_Load;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            using (ReadOnlyDAL dal = new ReadOnlyDAL("zBranch"))
            {
                _dmdvcs = dal.Read("is_inactive = 0");
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
            DataRow userRow = null;
            Cursor = Cursors.WaitCursor;
            string branchID = cboBranch.SelectedValue.ToString();

            using (SecurityDAO sDAO = new SecurityDAO())
            {
                userRow = sDAO.GetUserRow(branchID, txtUsername.Text, Encryptor.MD5Hash(txtPassword.Text.Trim()));
            }
            Cursor = Cursors.Default;

            if (userRow == null)
                return false;

            NailApp.CurrentUserRow = userRow;
            NailApp.BranchID = branchID;

            return true;
        }
    }
}
