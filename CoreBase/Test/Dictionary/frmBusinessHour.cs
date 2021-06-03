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

namespace AusNail.Dictionary
{
    public partial class frmBusinessHour : CoreBase.WinForm.Dictionary.Dictionary
    {
        const string WORKSHIFT_CMDKEY = "BusinessHour";
        const string WORKSHIFT_ADD_CMDKEY = "BusinessHour_add";
        const string WORKSHIFT_DEL_CMDKEY = "BusinessHour_del";
        const string WORKSHIFT_EDIT_CMDKEY = "BusinessHour_edit";
        const string WORKSHIFT_LIST_CMDKEY = "BusinessHour_list";
        DataRow _dr;
        DataTable _BusinessHour;
        string _tableName = "zBusinessHour";
        string _Mode = "";
        string _idName = "BusinessID";
        int _postion = 0;
        DataTable _branch = new DataTable();
        public frmBusinessHour()
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
            if (!NailApp.lstPermission.Contains(WORKSHIFT_LIST_CMDKEY) && !NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            LoadData();
            base.BeforeFillData();
        }

        protected override void FillData()
        {
            if (!NailApp.lstPermission.Contains(WORKSHIFT_LIST_CMDKEY) && !NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            base.FillData();
            CreateBinding(cbobranchId);
            CreateBinding(txtDayOfWeek);
            CreateBinding(txtBusinessTo);
            CreateBinding(txtBusinessFrom);
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
                    if (!NailApp.lstPermission.Contains(WORKSHIFT_ADD_CMDKEY) && !NailApp.IsAdmin())
                    {
                        lblMessInfomation.Text = "Unauthorized";
                        return false;
                    }
                    return base.InsertData();
                }
                else
                {
                    if (!NailApp.lstPermission.Contains(WORKSHIFT_EDIT_CMDKEY) && !NailApp.IsAdmin())
                    {
                        lblMessInfomation.Text = "Unauthorized";
                        return false; 
                    }
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
            catch (Exception ex)
            {

            }
            return true;
        }

        protected override void InitForm()
        {
            this.zEditTableName = _tableName;
            this.zViewTableName = _tableName;
            this.Text += " BusinessHour"; 
            base.InitForm();
        }

        private void LoadData()
        {
            using (DictionaryDAL dal = new DictionaryDAL(_tableName))
                Bds.DataSource = _BusinessHour = dal.GetData();
            LoadGrid();
            _postion = 0;
        }

        private void LoadGrid()
        {
            GridDetail.DataSource = _BusinessHour;
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
            GridDetail.Columns["BusinessID"].Visible = false;
            //GridDetail.Columns["branchId"].HeaderText = "Branch";
            GridDetail.Columns["DayOfWeek"].HeaderText = "Day Of Week";
            GridDetail.Columns["BusinessFrom"].HeaderText = "Business From";
            GridDetail.Columns["BusinessFrom"].DefaultCellStyle.Format = "HH:mm:ss";
            GridDetail.Columns["BusinessTo"].HeaderText = "Business To";
            GridDetail.Columns["BusinessTo"].DefaultCellStyle.Format = "HH:mm:ss";
            GridDetail.Columns["Decriptions"].Visible = false;
            GridDetail.Columns["is_inactive"].HeaderText = "Inactive";
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
                    cbobranchId.SelectedValue = row.Cells["branchId"].Value.ToString();
                    txtDayOfWeek.Text = row.Cells["DayOfWeek"].Value.ToString();
                    txtBusinessFrom.Text = row.Cells["BusinessFrom"].Value.ToString();
                    txtBusinessTo.Text = row.Cells["BusinessTo"].Value.ToString();
                    txtDecriptions.Text = row.Cells["Decriptions"].Value.ToString();
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

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!NailApp.lstPermission.Contains(WORKSHIFT_DEL_CMDKEY) && !NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
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

        private void GridDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1) // 1 Day of week
            {
                int i;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    lblMessInfomation.Text = "Please enter numeric";
                }
                else if (int.TryParse(Convert.ToString(e.FormattedValue), out i) && i > 7)
                {
                    e.Cancel = true;
                    lblMessInfomation.Text = "Day Of Week cannot more than 7";
                }
                else
                {

                }
            }
            else if (e.ColumnIndex == 2 || e.ColumnIndex == 3) // From - TO
            {
                int rIndex = e.RowIndex;
                int cIndex = e.ColumnIndex;
                DateTime dt;
                if (DateTime.TryParse(Convert.ToString("01/01/1900 " +  e.FormattedValue), out dt))
                {
                    GridDetail[cIndex, rIndex].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");
                }
                else
                {
                    e.Cancel = true;
                    lblMessInfomation.Text = "Value invalid";
                }
            }
        }


    }
}
