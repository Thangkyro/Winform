using CoreBase.DataAccessLayer;
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
        public frmUser()
        {
            InitializeComponent();
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
            GridDetail.Columns["UserId"].Visible = false;
            DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
            dgvCmb.HeaderText = "BranchId";
            dgvCmb.Name = "BranchId";  
            DataTable dt  = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBranchGetList", 0);
            foreach (DataRow dr in dt.Rows)
            {
                dgvCmb.Items.Add(dr["BranchId"].ToString());
            }
            GridDetail.Columns.Add(dgvCmb);
            //for (int i = 0; i < list[0].Count; i++)
            //{
            //    int number = dataGridView1.Rows.Add();
            //    GridDetail.Rows[number].Cells[0].Value = list[3][i]; //list[3][1]=="Apples"
            //}
            GridDetail.Columns["BranchId"].HeaderText = "Branch";
            GridDetail.Columns["user_name"].HeaderText = "User Name";
            GridDetail.Columns["Full_name"].HeaderText = "Full Name";
            GridDetail.Columns["StaffId"].HeaderText = "Staff";
            GridDetail.Columns["Password"].HeaderText = "Password";
            GridDetail.Columns["Permission"].HeaderText = "Permission";
            GridDetail.Columns["is_Admin"].HeaderText = "Is Admin";
            GridDetail.Columns["is_inactive"].HeaderText = "Inactive";
            GridDetail.Columns["Decriptions"].Visible = false;
            GridDetail.Columns["created_by"].HeaderText = "Create by";
            GridDetail.Columns["created_by"].ReadOnly = true;
            GridDetail.Columns["created_at"].HeaderText = "Create at";
            GridDetail.Columns["created_at"].ReadOnly = true;
            GridDetail.Columns["modified_by"].HeaderText = "Modified by";
            GridDetail.Columns["modified_by"].ReadOnly = true;
            GridDetail.Columns["modified_at"].HeaderText = "Modified at";
            GridDetail.Columns["modified_at"].ReadOnly = true;

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
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadEditRow()
        {

            if (((DataTable)Bds.DataSource).Select(string.Format("{0} = 0", _idName)).Count() == 1)
            {
                this.zEditRow = ((DataTable)Bds.DataSource).Select(string.Format("{0} = 0", _idName))[0];
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


    }
}
