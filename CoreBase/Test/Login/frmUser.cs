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
                LoadEditRow();
                if (_Mode == "Add")
                {
                    return base.InsertData();
                }
                else
                {
                    return base.UpdateData();
                }

                #region Đoạn này cho phép sửa hoặc add mới nhiều dòng cùng 1 lúc => Phải sửa lại
                //DataTable changedRows = ((DataTable)(Bds.DataSource)).GetChanges();

                //foreach (DataRow dr in changedRows.Rows)
                //{
                //    if (dr[_idName].ToString() == "0")
                //    {
                //        this.zEditRow = dr;
                //        return base.InsertData();
                //    }
                //    else
                //    {
                //        this.zEditRow = dr;
                //        return base.UpdateData();
                //    }
                //}
                //return true;
                #endregion
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
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void LoadEditRow()
        {

            if (((DataTable)Bds.DataSource).Select(string.Format("{0} = 0", _idName)).Count() == 1)
            {
                this.zEditRow = ((DataTable)Bds.DataSource).Select(string.Format("{0} = 0", _idName))[0];
                this.zEditRow["Password"] = Encryptor.MD5Hash("123456Aa" + this.zEditRow["user_name"].ToString());
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
            DialogResult result = MessNotifications("Notifications", "Do you want delete line?");
            if (result == DialogResult.Yes)
            {
                this.zDeleteRow = ((DataTable)Bds.DataSource).Rows[_postion];
                bool flag = base.DeleteData();
                LoadData();
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
            if (e.ColumnIndex == 4 && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        private int CheckExistsUserName(string userName)
        {
            int id = 0;
            try
            {
                string sql = "Select 1 FROM  [dbo].[zUser] with(nolock) where user_name = '" + userName + "'";
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, sql);
                if (dt != null)
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
            if (e.ColumnIndex == 1) // 1 User Name
            {
                //int i;
                //string value = Convert.ToString(e.FormattedValue);
                if (CheckExistsUserName(Convert.ToString(e.FormattedValue)) == 1)
                {
                    e.Cancel = true;
                    lblMessInfomation.Text = "User Name exists.";
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

    }
}
