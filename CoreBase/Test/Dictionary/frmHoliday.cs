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
    public partial class frmHoliday : CoreBase.WinForm.Dictionary.Dictionary
    {
        const string HOLIDAY_CMDKEY = "Holiday";
        const string HOLIDAY_ADD_CMDKEY = "Holiday_add";
        const string HOLIDAY_DEL_CMDKEY = "Holiday_del";
        const string HOLIDAY_EDIT_CMDKEY = "Holiday_edit";
        const string HOLIDAY_LIST_CMDKEY = "Holiday_list";

        DataRow _dr;
        DataTable _Holidays;
        string _tableName = "zHolidays";

        string _Mode = "";
        string _idName = "HolidaysID";
        int _postion = 0;
        DataTable _branch = new DataTable();
        public frmHoliday()
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
            if (!NailApp.lstPermission.Contains(HOLIDAY_LIST_CMDKEY))
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            LoadData();
            base.BeforeFillData();
        }

        protected override void FillData()
        {
            base.FillData();
            CreateBinding(cbobranchId);
            CreateBinding(txtNames);
            CreateBinding(txtHolidaysTo);
            CreateBinding(txtHolidaysFrom);
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
                    if (!NailApp.lstPermission.Contains(HOLIDAY_ADD_CMDKEY))
                    {
                        lblMessInfomation.Text = "Unauthorized";
                        return false;
                    }
                    return base.InsertData();
                }
                else
                {
                    if (!NailApp.lstPermission.Contains(HOLIDAY_EDIT_CMDKEY))
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
            catch
            {

            }
            return true;
        }

        protected override void InitForm()
        {
            this.zEditTableName = _tableName;
            this.zViewTableName = _tableName;
            this.Text += " Holidays"; 
            base.InitForm();
        }

        private void LoadData()
        {
            using (DictionaryDAL dal = new DictionaryDAL(_tableName))
                Bds.DataSource = _Holidays = dal.GetData();
            LoadGrid();
            _postion = 0;
        }

        private void LoadGrid()
        {
            GridDetail.DataSource = _Holidays;
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

            GridDetail.Columns["HolidaysID"].Visible = false;
            //GridDetail.Columns["branchId"].HeaderText = "Branch";
            GridDetail.Columns["Names"].HeaderText = "Names";
            GridDetail.Columns["HolidaysFrom"].HeaderText = "Holidays From";
            GridDetail.Columns["HolidaysFrom"].DefaultCellStyle.Format = "MM/dd/yyyy";
            GridDetail.Columns["HolidaysTo"].HeaderText = "Holidays To";
            GridDetail.Columns["HolidaysTo"].DefaultCellStyle.Format = "MM/dd/yyyy";
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
                    cbobranchId.SelectedValue = row.Cells["branchId"].Value.ToString();
                    txtNames.Text = row.Cells["Names"].Value.ToString();
                    txtHolidaysFrom.Text = row.Cells["HolidaysFrom"].Value.ToString();
                    txtHolidaysTo.Text = row.Cells["HolidaysTo"].Value.ToString();
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
            if (!NailApp.lstPermission.Contains(HOLIDAY_DEL_CMDKEY))
            {
                lblMessInfomation.Text = "Unauthorized";
                return ;
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
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3) // From - TO
            {
                int rIndex = e.RowIndex;
                int cIndex = e.ColumnIndex;
                DateTime dt;
                if (DateTime.TryParse(Convert.ToString(e.FormattedValue), out dt))
                {
                    
                }
                else
                {
                    e.Cancel = true;
                    lblMessInfomation.Text = "Value invalid";
                }
            }


            if (e.ColumnIndex == 3)
            {
                int rIndex = e.RowIndex;
                int cIndex = 2;
                DateTime dt1;
                DateTime dt2;
                DateTime.TryParse(Convert.ToString(GridDetail[cIndex, rIndex].Value), out dt1);
                DateTime.TryParse(Convert.ToString(e.FormattedValue), out dt2);
                if (dt2 < dt1)
                {
                    e.Cancel = true;
                    lblMessInfomation.Text = "Holiday From cannot more than Holiday To";
                }

            }
        }
    }
}
