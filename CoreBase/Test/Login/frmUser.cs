using CoreBase;
using CoreBase.DAL;
using CoreBase.DataAccessLayer;
using CoreBase.Helpers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AusNail.Dictionary
{
    public partial class frmUser : CoreBase.WinForm.Dictionary.Dictionary
    {
        const string USER_CMDKEY = "User";
        const string USER_ADD_CMDKEY = "User_add";
        const string USER_DEL_CMDKEY = "User_del";
        const string USER_EDIT_CMDKEY = "User_edit";
        const string USER_LIST_CMDKEY = "User_list";
        DataRow _dr;
        DataTable _User;
        string _tableName = "zUser";
        string _Mode = "";
        string _idName = "Userid";
        int _postion = 0;
        DataTable _branch = new DataTable();
        DataTable _staff = new DataTable();
        public frmUser()
        {
            InitializeComponent();
            Load += UserForm_Load;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            using (ReadOnlyDAL dal = new ReadOnlyDAL("zBranch"))
            {
                _branch = dal.Read("is_inactive = 0");
            }

            _branch.DefaultView.Sort = "BranchCode";
            DataRow dr1 = _branch.NewRow();
            dr1["branchId"] = 0;
            dr1["BranchName"] = "";
            _branch.Rows.Add(dr1);

            cboBranchId.DisplayMember = "BranchName";
            cboBranchId.ValueMember = "branchId";
            cboBranchId.DataSource = _branch.DefaultView;

            using (ReadOnlyDAL dal = new ReadOnlyDAL("zStaff"))
            {
                _staff = dal.Read("is_inactive = 0");
            }

            _staff.DefaultView.Sort = "StaffCode";
            DataRow dr = _staff.NewRow();
            dr["StaffId"] = 0;
            dr["Name"] = "";
            _staff.Rows.Add(dr);



            cboStaffId.DisplayMember = "Name";
            cboStaffId.ValueMember = "StaffId";
            cboStaffId.DataSource = _staff.DefaultView;
        }

        protected override void BeforeFillData()
        {
            //if (!NailApp.lstPermission.Contains(USER_LIST_CMDKEY))
            //{
            //    lblMessInfomation.Text = "Unauthorized";
            //    return;
            //}
            LoadData();
            base.BeforeFillData();
        }

        protected override void FillData()
        {
            base.FillData();
            CreateBinding(cboBranchId);
            CreateBinding(txtUser_name);
            CreateBinding(txtFull_Name);
            CreateBinding(cboStaffId);
            CreateBinding(txtPassword);
            CreateBinding(txtDecriptions);
            CreateBinding(txtPermission);
            CreateBinding(chkIs_Admin, "is_Admin", "Checked");
            CreateBinding(chkis_inactive, "is_inactive", "Checked");
        }
        protected override bool InsertData()
        {
            try
            {
                bool isSuccess = false;
                //LoadEditRow();
                if (_Mode == "Add")
                {
                    //if (!NailApp.lstPermission.Contains(USER_ADD_CMDKEY))
                    //{
                    //    lblMessInfomation.Text = "Unauthorized";
                    //    return false; 
                    //}
                    //isSuccess = base.InsertData();
                    //if (isSuccess) // update lại password
                    //{
                    //    int userID = 0;
                    //    string sql = "Select UserID FROM  [dbo].[zUser] with(nolock) where user_name = '" + zEditRow["user_name"].ToString() + "'";
                    //    DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, sql);
                    //    if (dt != null && dt.Rows.Count > 0)
                    //    {
                    //        userID = int.Parse(dt.Rows[0][0].ToString()) + 1;
                    //        string passWord = Encryptor.MD5Hash("123456Aa") +
                    //                            //Encryptor.MD5Hash(this.zEditRow["branchId"].ToString()) +
                    //                            Encryptor.MD5Hash(userID.ToString()) +
                    //                            Encryptor.MD5Hash(this.zEditRow["user_name"].ToString());
                    //        sql = string.Format("update zUser set password = '{0}' where Userid = {1}", passWord, userID);
                    //        MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, CommandType.Text, sql);

                    //    }
                    //}
                }
                else
                {
                    //if (!NailApp.lstPermission.Contains(USER_EDIT_CMDKEY))
                    //{
                    //    lblMessInfomation.Text = "Unauthorized";
                    //    return false;
                    //}
                    //isSuccess = base.UpdateData();
                }

                txtFull_Name.Focus();
                string listError = "";
                #region Đoạn này cho phép sửa hoặc add mới nhiều dòng cùng 1 lúc => Phải sửa lại
                DataTable changedRows = ((DataTable)(Bds.DataSource)).GetChanges();

                if (changedRows != null)
                {
                    foreach (DataRow dr in changedRows.Rows)
                    {
                        dr["created_by"] = NailApp.CurrentUserId;
                        dr["modified_by"] = NailApp.CurrentUserId;
                        if (dr[_idName].ToString() == "0")
                        {
                            this.zEditRow = dr;
                            isSuccess = base.InsertData();
                            if (isSuccess) // update lại password
                            {
                                int userID = 0;
                                string sql = "Select UserID FROM  [dbo].[zUser] with(nolock) where user_name = '" + zEditRow["user_name"].ToString() + "'";
                                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, sql);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    userID = int.Parse(dt.Rows[0][0].ToString());
                                    string passWord = Encryptor.MD5Hash("123456Aa") +
                                                        Encryptor.MD5Hash(userID.ToString()) +
                                                        Encryptor.MD5Hash(this.zEditRow["user_name"].ToString());
                                    sql = string.Format("update zUser set password = '{0}' where Userid = {1}", passWord, userID);
                                    MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, CommandType.Text, sql);

                                }
                            }
                        }
                        else
                        {
                            this.zEditRow = dr;
                            isSuccess = base.UpdateData();
                        }

                        if (!isSuccess)
                        {
                            listError += "Save error User: " + dr["user_name"].ToString() + ". \n";
                        }
                    }

                }
                #endregion

                if (isSuccess)
                {
                    LoadData();
                }
                else
                {
                    LoadData();
                    lblMessInfomation.Text = listError;
                }
            }
            catch
            {

            }
            return true;
        }

        protected override void InitForm()
        {
            this.zEditTableName = _tableName;
            this.zViewTableName = _tableName;
            this.Text += " User";
            base.InitForm();
        }

        private void LoadData()
        {
            using (DictionaryDAL dal = new DictionaryDAL(_tableName))
                Bds.DataSource = _User = dal.GetData();
            LoadGrid();
            _postion = 0;
        }

        private void LoadGrid()
        {
            GridDetail.DataSource = _User;
            GridDetail.Columns.Remove("branchId");
            GridDetail.Columns.Remove("StaffId");

            DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
            dgvCmb.DataPropertyName = "BranchId";
            dgvCmb.HeaderText = "Branch";
            dgvCmb.Name = "BranchId";
            dgvCmb.DisplayMember = "BranchName";
            dgvCmb.ValueMember = "branchId";
            dgvCmb.DataSource = _branch;
            GridDetail.Columns.Add(dgvCmb);

            DataGridViewComboBoxColumn dgvCmb1 = new DataGridViewComboBoxColumn();
            dgvCmb1.DataPropertyName = "StaffId";
            dgvCmb1.HeaderText = "Staff";
            dgvCmb1.Name = "StaffId";
            dgvCmb1.DisplayMember = "Name";
            dgvCmb1.ValueMember = "StaffId";
            dgvCmb1.DataSource = _staff;
            GridDetail.Columns.Add(dgvCmb1);

            GridDetail.Columns["BranchId"].DisplayIndex = 0;

            GridDetail.Columns["StaffId"].DisplayIndex = 1;

            GridDetail.Columns["UserId"].Visible = false;
            //GridDetail.Columns["BranchId"].HeaderText = "Branch";
            GridDetail.Columns["user_name"].HeaderText = "User Name";
            GridDetail.Columns["Full_name"].HeaderText = "Full Name";
            //GridDetail.Columns["StaffId"].HeaderText = "Staff";
            GridDetail.Columns["Password"].HeaderText = "Password";
            GridDetail.Columns["Password"].ReadOnly = true;
            GridDetail.Columns["Permission"].HeaderText = "Permission";
            GridDetail.Columns["is_Admin"].HeaderText = "Is Admin";
            GridDetail.Columns["is_inactive"].HeaderText = "Inactive";
            GridDetail.Columns["Decriptions"].Visible = false;
            GridDetail.Columns["created_by"].HeaderText = "Create by";
            GridDetail.Columns["created_by"].Visible = false;
            GridDetail.Columns["created_at"].HeaderText = "Create at";
            GridDetail.Columns["created_at"].Visible = false;
            GridDetail.Columns["modified_by"].HeaderText = "Modified by";
            GridDetail.Columns["modified_by"].Visible = false;
            GridDetail.Columns["modified_at"].HeaderText = "Modified at";
            GridDetail.Columns["modified_at"].Visible = false;

        }

        private void GridDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    _postion = e.RowIndex;
                    DataGridViewRow row = this.GridDetail.Rows[e.RowIndex];
                    cboBranchId.SelectedValue = row.Cells["branchId"].Value.ToString();
                    txtUser_name.Text = row.Cells["user_name"].Value.ToString();
                    txtFull_Name.Text = row.Cells["full_name"].Value.ToString();
                    cboStaffId.SelectedValue = row.Cells["StaffId"].Value.ToString();
                    txtPassword.Text = row.Cells["password"].Value.ToString();
                    txtPermission.Text = row.Cells["permission"].Value.ToString();
                    txtDecriptions.Text = row.Cells["Decriptions"].Value.ToString();
                    chkIs_Admin.Checked = bool.Parse(row.Cells["is_admin"].Value.ToString());
                    chkis_inactive.Checked = bool.Parse(row.Cells["is_inactive"].Value.ToString());
                    txtUserId.Text = row.Cells["userid"].Value.ToString();

                    if (!string.IsNullOrWhiteSpace(txtUserId.Text) && txtUserId.Text != "0" && chkIs_Admin.Checked == false)
                    {
                        btnSetPermission.Enabled = true;
                    }
                    else
                    {
                        btnSetPermission.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        private void LoadEditRow()
        {

            if (((DataTable)Bds.DataSource).Select(string.Format("{0} = 0", _idName)).Count() == 1)
            {
                this.zEditRow = ((DataTable)Bds.DataSource).Select(string.Format("{0} = 0", _idName))[0];
                this.zEditRow["Password"] = Encryptor.MD5Hash("123456Aa") +
                    //Encryptor.MD5Hash(this.zEditRow["branchId"].ToString()) + 
                    Encryptor.MD5Hash(GetMaxUserID().ToString()) +
                    Encryptor.MD5Hash(this.zEditRow["user_name"].ToString());
                //Encryptor.MD5Hash("123456Aa" + this.zEditRow["branchId"].ToString() + GetMaxUserID() + this.zEditRow["user_name"].ToString());
                _Mode = "Add";
            }
            else
            {
                this.zEditRow = ((DataTable)Bds.DataSource).Rows[_postion];
                _Mode = "Update";
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            //if (!NailApp.lstPermission.Contains(USER_DEL_CMDKEY))
            //{
            //    lblMessInfomation.Text = "Unauthorized";
            //    return;
            //}
            DialogResult result = MessNotifications("Notifications", "Do you want delete line?");
            if (result == DialogResult.Yes)
            {
                this.zDeleteRow = ((DataTable)Bds.DataSource).Rows[_postion];
               // Check use for bill or booking.

               DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zUserCheckUse", int.Parse(zDeleteRow["UserId"].ToString()));
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("User is already in use, cannot be deleted.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    bool flag = base.DeleteData();
                    LoadData();
                }
            }
            else
            {

            }
        }

        private void RefeshListToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            LoadData();
        }

        private DialogResult MessNotifications(string title, string message)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            return result;
        }

        private void GridDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string headerText = GridDetail.Columns[e.ColumnIndex].Name;
            if (headerText.Equals("password") && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        private int CheckExistsUserName(string userName, int userID)
        {
            int id = 0;
            try
            {
                string sql = "";
                if (userID == 0)
                {
                    sql = "Select 1 FROM  [dbo].[zUser] with(nolock) where user_name = '" + userName + "'";

                }
                else
                {
                    sql = "Select 1 FROM  [dbo].[zUser] with(nolock) where user_name = '" + userName + "' and  Userid <> " + userID;

                }
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    id = 1;
                }

            }
            catch
            {

            }
            return id;
        }

        private void GridDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = GridDetail.Columns[e.ColumnIndex].Name;
            if (headerText.Equals("user_name")) // 2 User Name
            {
                //int i;
                int id = int.Parse(GridDetail["Userid", e.RowIndex].Value != DBNull.Value ? GridDetail["Userid", e.RowIndex].Value.ToString() : "0");

                if (CheckExistsUserName(Convert.ToString(e.FormattedValue), id) == 1)
                {
                    e.Cancel = true;
                    lblMessInfomation.Text = "User Name existed.";
                }
                else
                {

                }

            }
        }

        private int GetMaxUserID()
        {
            int id = 0;
            try
            {
                string sql = "Select ISNULL(UserID,0) MaxID FROM  [dbo].[zUser] with(nolock) ";
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, sql);
                if (dt != null)
                {
                    id = int.Parse(dt.Rows[0][0].ToString()) + 1;
                }

            }
            catch
            {

            }
            return id;
        }

        private void BtnResetPass_Click(object sender, EventArgs e)
        {
            if (!NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do You Want Reset Password ?", "Reset Password", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (txtUserId.Text != "0" && !string.IsNullOrWhiteSpace(txtUserId.Text))
                    {
                        int _userID = int.Parse(txtUserId.Text.Trim().ToString());
                        string _userName = txtUser_name.Text.ToString();

                        string password = Encryptor.MD5Hash("123456Aa") +
                                //Encryptor.MD5Hash(NailApp.BranchID) + 
                                Encryptor.MD5Hash(_userID.ToString()) +
                                Encryptor.MD5Hash(_userName);
                        using (SecurityDAO sDao = new SecurityDAO())
                        {
                            if (sDao.SetPasswordNew(_userID, password))
                            {
                                MessageBox.Show("Change Password Successfully");
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Change Password Failed");
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please Choose User!");
                    }
                }
            }
        }

        private void GridDetail_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells["BranchId"].Value = NailApp.BranchID;

            }
            catch (Exception ex)
            {

            }
        }

        private void btnSetPermission_Click(object sender, EventArgs e)
        {
            try
            {
                Login.frmSetPermission form = new Login.frmSetPermission(int.Parse(txtUserId.Text),txtUser_name.Text, txtFull_Name.Text);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
