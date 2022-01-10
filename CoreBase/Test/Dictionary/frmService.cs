using CoreBase;
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

namespace AusNail.Dictionary
{
    public partial class frmService : CoreBase.WinForm.Dictionary.Dictionary
    {
        const string SERVICE_CMDKEY = "Service";
        const string SERVICE_ADD_CMDKEY = "Service_add";
        const string SERVICE_DEL_CMDKEY = "Service_del";
        const string SERVICE_EDIT_CMDKEY = "Service_edit";
        const string SERVICE_LIST_CMDKEY = "Service_list";
        DataRow _dr;
        DataTable _Service;
        string _tableName = "zService";
        string _Mode = "";
        string _idName = "ServiceID";
        int _postion = 0;
        DataTable _branch = new DataTable();
        DataTable _GroupSV = new DataTable();
        public frmService()
        {
            InitializeComponent();
            Load += UserForm_Load;
            this.BackColor = NailApp.ColorUser.IsEmpty == true ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            using (ReadOnlyDAL dal = new ReadOnlyDAL("zBranch"))
            {
                if (NailApp.IsAdmin())
                {
                    _branch = dal.Read("is_inactive = 0");
                }
                else
                {
                    _branch = dal.Read("is_inactive = 0 and branchId = " + NailApp.BranchID);
                }
            }

            _branch.DefaultView.Sort = "BranchCode";
            //DataRow dr1 = _branch.NewRow();
            //dr1["branchId"] = 0;
            //dr1["BranchName"] = "";
            //_branch.Rows.Add(dr1);

            cbobranchId.DisplayMember = "BranchName";
            cbobranchId.ValueMember = "branchId";
            cbobranchId.DataSource = _branch.DefaultView;


            using (ReadOnlyDAL dal = new ReadOnlyDAL("zServicegroup"))
            {
                if (NailApp.IsAdmin())
                {
                    _GroupSV = dal.Read("is_inactive = 0");
                }
                else
                {
                    _GroupSV = dal.Read("is_inactive = 0 and BranchId = " + NailApp.BranchID);
                }
            }

            _GroupSV.DefaultView.Sort = "ServiceGroupName";
            //DataRow dr2 = _GroupSV.NewRow();
            //dr2["ServiceGroupID"] = 0;
            //dr2["ServiceGroupName"] = "";
            //_GroupSV.Rows.Add(dr2);

            cboGroupSTT.DisplayMember = "ServiceGroupName";
            cboGroupSTT.ValueMember = "ServiceGroupID";
            cboGroupSTT.DataSource = _GroupSV.DefaultView;

        }


        protected override void BeforeFillData()
        {
            if (!NailApp.lstPermission.Contains(SERVICE_LIST_CMDKEY) && !NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            LoadData();
            base.BeforeFillData();
        }

        protected override void FillData()
        {
            if (!NailApp.lstPermission.Contains(SERVICE_LIST_CMDKEY) && !NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            base.FillData();
            CreateBinding(cbobranchId);
            CreateBinding(cboGroupSTT);
            CreateBinding(txtTitle);
            CreateBinding(txtEstimateTime);
            CreateBinding(txtPrice);
            CreateBinding(txtDecriptions);
            CreateBinding(chkis_inactive, "is_inactive", "Checked");
            CreateBinding(chkis_discount, "is_discount", "Checked");
        }
        protected override bool InsertData()
        {
            bool isSuccess = false;
            try
            {
                //LoadEditRow();
                if (_Mode == "Add")
                {
                    if (!NailApp.lstPermission.Contains(SERVICE_ADD_CMDKEY) && !NailApp.IsAdmin())
                    {
                        lblMessInfomation.Text = "Unauthorized";
                        return false;
                    }
                    //isSuccess = base.InsertData();
                }
                else
                {
                    if (!NailApp.lstPermission.Contains(SERVICE_EDIT_CMDKEY) && !NailApp.IsAdmin())
                    {
                        lblMessInfomation.Text = "Unauthorized";
                        return false;
                    }
                    //isSuccess = base.UpdateData();
                }

                txtTitle.Focus();

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
                        }
                        else
                        {
                            this.zEditRow = dr;
                            isSuccess = base.UpdateData();
                        }

                        if (!isSuccess)
                        {
                            listError += "Save error Title: " + dr["Title"].ToString() + ". \n";
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
            return isSuccess;
        }

        protected override void InitForm()
        {
            this.zEditTableName = _tableName;
            this.zViewTableName = _tableName;
            this.Text += " Service"; 
            base.InitForm();
        }

        private void LoadData()
        {
            using (DictionaryDAL dal = new DictionaryDAL(_tableName))
            {
                if (NailApp.IsAdmin())
                {
                    Bds.DataSource = _Service = dal.GetData();
                }
                else
                {
                    _Service = dal.GetData().Select("branchId = " + NailApp.BranchID, "").CopyToDataTable();
                    Bds.DataSource = _Service;
                }
            }
                
            LoadGrid();
            _postion = 0;
        }


        private void LoadGrid()
        {
            _Service.DefaultView.Sort = "Title";
            GridDetail.DataSource = _Service;
            GridDetail.Columns.Remove("branchId");
            GridDetail.Columns.Remove("GroupStt");

            DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
            dgvCmb.DataPropertyName = "BranchId";
            dgvCmb.HeaderText = "Branch";
            dgvCmb.Name = "BranchId";
            dgvCmb.DisplayMember = "BranchName";
            dgvCmb.ValueMember = "branchId";
            dgvCmb.DataSource = _branch;
            GridDetail.Columns.Add(dgvCmb);
            GridDetail.Columns["BranchId"].DisplayIndex = 0;

            DataGridViewComboBoxColumn dgvCmb1 = new DataGridViewComboBoxColumn();
            dgvCmb1.DataPropertyName = "GroupStt";
            dgvCmb1.HeaderText = "ServiceGroupName";
            dgvCmb1.Name = "GroupStt";
            dgvCmb1.DisplayMember = "ServiceGroupName";
            dgvCmb1.ValueMember = "ServiceGroupID";
            dgvCmb1.DataSource = _GroupSV;
            GridDetail.Columns.Add(dgvCmb1);
            GridDetail.Columns["GroupStt"].DisplayIndex = 1;

            GridDetail.Columns["ServiceID"].Visible = false;
            //GridDetail.Columns["branchId"].HeaderText = "Branch";
            GridDetail.Columns["Title"].HeaderText = "Title";
            GridDetail.Columns["EstimateTime"].HeaderText = "EstimateTime";
            GridDetail.Columns["Price"].HeaderText = "Price";
            //GridDetail.Columns["Decriptions"].Visible = false;
            //GridDetail.Columns["created_by"].HeaderText = "Create by";
            GridDetail.Columns["created_by"].Visible = false;
            //GridDetail.Columns["created_at"].HeaderText = "Create at";
            GridDetail.Columns["created_at"].Visible = false;
            //GridDetail.Columns["modified_by"].HeaderText = "Modified by";
            GridDetail.Columns["modified_by"].Visible = false;
            //GridDetail.Columns["modified_at"].HeaderText = "Modified at";
            GridDetail.Columns["modified_at"].Visible = false;
            if (_Service.Rows.Count > 0)
            {
                GridDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            if (!NailApp.lstPermission.Contains(SERVICE_DEL_CMDKEY) && !NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            DialogResult result = MessNotifications("Notifications", "Do you want delete line?");
            if (result == DialogResult.Yes)
            {
                this.zDeleteRow = ((DataTable)Bds.DataSource).Rows[_postion];
                // Check use for bill or booking.
                DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zCheckServiceExists", int.Parse(zDeleteRow["ServiceID"].ToString()));
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Service is already in use, cannot be deleted.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    bool flag = base.DeleteData();
                }
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

        private void GridDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    _postion = e.RowIndex;
                    DataGridViewRow row = this.GridDetail.Rows[e.RowIndex];
                    cbobranchId.SelectedValue = row.Cells["branchId"].Value.ToString();
                    if (NailApp.IsAdmin())
                    {
                        DataTable dt = _GroupSV.Select("BranchId = " + row.Cells["branchId"].Value.ToString(), "").CopyToDataTable();
                        var comboCell = (DataGridViewComboBoxCell)GridDetail.Rows[e.RowIndex].Cells["GroupStt"];
                        comboCell.DataSource = dt;
                    }

                    txtTitle.Text = row.Cells["Title"].Value.ToString();
                    txtPrice.Text = row.Cells["Price"].Value.ToString();
                    txtEstimateTime.Text = row.Cells["EstimateTime"].Value.ToString();
                    txtDecriptions.Text = row.Cells["Decriptions"].Value.ToString();
                    chkis_inactive.Checked = row.Cells["is_inactive"].Value.ToString() == "" ? false : bool.Parse(row.Cells["is_inactive"].Value.ToString());
                    chkis_discount.Checked = row.Cells["is_discount"].Value.ToString() ==""? false : bool.Parse(row.Cells["is_discount"].Value.ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GridDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void cbobranchId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
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

        private void GridDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
