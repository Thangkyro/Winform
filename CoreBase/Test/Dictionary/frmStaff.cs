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

namespace AusNail.Dictionary
{
    public partial class frmStaff : CoreBase.WinForm.Dictionary.Dictionary
    {
        DataRow _dr;
        DataTable _Staff;
        string _tableName = "zStaff";
        string _Mode = "";
        string _idName = "StaffId";
        int _postion = 0;
        DataTable _branch = new DataTable();
        public frmStaff()
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

            cbobranchId.DisplayMember = "BranchName";
            cbobranchId.ValueMember = "branchId";
            cbobranchId.DataSource = _branch.DefaultView;


        }


        protected override void BeforeFillData()
        {
            LoadData();
            base.BeforeFillData();
        }

        protected override void FillData()
        {
            base.FillData();
            CreateBinding(cbobranchId);
            CreateBinding(txtStaffCode);
            CreateBinding(txtName);
            CreateBinding(txtGender);
            CreateBinding(txtPhoneNumber1);
            CreateBinding(txtPhoneSimple1);
            CreateBinding(txtPhoneNumber2);
            CreateBinding(txtPhoneSimple2);
            CreateBinding(txtDateOfBirth);
            CreateBinding(txtTFN);
            CreateBinding(txtAcountNumber);
            CreateBinding(txtBSB);
            CreateBinding(txtDecriptions);
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
            this.Text += " Staff"; 
            base.InitForm();
        }

        private void LoadData()
        {
            using (DictionaryDAL dal = new DictionaryDAL(_tableName))
                Bds.DataSource = _Staff = dal.GetData();
            LoadGrid();
            _postion = 0;
        }

        private void LoadEditRow()
        {

            if (((DataTable)Bds.DataSource).Select(string.Format("{0} = 0", _idName)).Count() == 1)
            {
                this.zEditRow = ((DataTable)Bds.DataSource).Select(string.Format("{0} = 0", _idName))[0];
                this.zEditRow["StaffCode"] = GenStaffCode();
                _Mode = "Add";
            }
            else
            {
                this.zEditRow = ((DataTable)Bds.DataSource).Rows[_postion];
                _Mode = "Update";
            }
        }

        private void LoadGrid()
        {
            GridDetail.DataSource = Bds.DataSource;
            GridDetail.Columns.Remove("branchId");

            DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
            dgvCmb.DataPropertyName = "BranchId";
            dgvCmb.HeaderText = "Branch";
            dgvCmb.Name = "BranchId";
            dgvCmb.DisplayMember = "BranchName";
            dgvCmb.ValueMember = "branchId";
            dgvCmb.DataSource = _branch;
            GridDetail.Columns.Add(dgvCmb);
            GridDetail.Columns["BranchId"].DisplayIndex = 0;

            GridDetail.Columns["StaffId"].Visible = false;
            //GridDetail.Columns["branchId"].HeaderText = "Branch";
            GridDetail.Columns["StaffCode"].HeaderText = "Staff Code";
            GridDetail.Columns["StaffCode"].ReadOnly = true;
            GridDetail.Columns["Name"].HeaderText = "Name";
            GridDetail.Columns["Gender"].HeaderText = "Gender";
            GridDetail.Columns["PhoneNumber1"].HeaderText = "Phone Number 1";
            GridDetail.Columns["PhoneSimple1"].HeaderText = "Phone Simple 1";
            GridDetail.Columns["PhoneNumber2"].HeaderText = "Phone Number 2";
            GridDetail.Columns["PhoneSimple2"].HeaderText = "Phone Simple 2";
            GridDetail.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
            GridDetail.Columns["DateOfBirth"].DefaultCellStyle.Format = "MM/dd/yyyy";
            GridDetail.Columns["TFN"].HeaderText = "Tax Number";
            GridDetail.Columns["BSB"].HeaderText = "BSB";
            GridDetail.Columns["Decriptions"].Visible = false;
            GridDetail.Columns["is_inactive"].HeaderText = "Inactive";
            GridDetail.Columns["created_by"].HeaderText = "Create by";
            GridDetail.Columns["created_at"].HeaderText = "Create at";
            GridDetail.Columns["modified_by"].HeaderText = "Modified by";
            GridDetail.Columns["modified_at"].HeaderText = "Modified at";
            
        }

        private void GridDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    _postion = e.RowIndex;
                    DataGridViewRow row = this.GridDetail.Rows[e.RowIndex];
                    cbobranchId.SelectedValue = row.Cells["branchId"].Value.ToString();
                    txtStaffCode.Text = row.Cells["StaffCode"].Value.ToString();
                    txtName.Text = row.Cells["Name"].Value.ToString();
                    txtGender.Text = row.Cells["Gender"].Value.ToString();
                    txtDateOfBirth.Text = row.Cells["DateOfBirth"].Value.ToString();
                    txtPhoneNumber1.Text = row.Cells["PhoneNumber1"].Value.ToString();
                    txtPhoneNumber2.Text = row.Cells["PhoneNumber2"].Value.ToString();
                    txtPhoneSimple1.Text = row.Cells["PhoneSimple1"].Value.ToString();
                    txtPhoneSimple2.Text = row.Cells["PhoneSimple2"].Value.ToString();
                    txtTFN.Text = row.Cells["TFN"].Value.ToString();
                    txtAcountNumber.Text = row.Cells["AcountNumber"].Value.ToString();
                    txtBSB.Text = row.Cells["BSB"].Value.ToString();
                    txtDecriptions.Text = row.Cells["Decriptions"].Value.ToString();
                    chkis_inactive.Checked = bool.Parse(row.Cells["is_inactive"].Value.ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void RefeshListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private DialogResult MessNotifications(string title, string message)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            return result;
        }

        private string GenStaffCode()
        {
            string StaffCode = "";
            try
            {
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGetNewCode", _tableName, "ST", _idName, 8);
                if (dt != null)
                {
                    StaffCode = dt.Rows[0][0].ToString();
                }
            }
            catch
            {

            }
            return StaffCode;
        }
    }
}
