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
    public partial class frmBanner : CoreBase.WinForm.Dictionary.Dictionary
    {
        const string BANNER_CMDKEY = "Banner";
        const string BANNER_ADD_CMDKEY = "Banner_add";
        const string BANNER_DEL_CMDKEY = "Banner_del";
        const string BANNER_EDIT_CMDKEY = "Banner_edit";
        const string BANNER_LIST_CMDKEY = "Banner_list";
        DataRow _dr;
        DataTable _Banner;
        string _tableName = "zBanner";
        string _Mode = "";
        string _idName = "BannerID";
        int _postion = 0;
        DataTable _branch = new DataTable();
        public frmBanner()
        {
            InitializeComponent();
            Load += UserForm_Load;
            this.BackColor = NailApp.ColorUser.IsEmpty == true || NailApp.ColorUser.Name == "0" ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
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

        }


        protected override void BeforeFillData()
        {
            if (!NailApp.lstPermission.Contains(BANNER_LIST_CMDKEY) && !NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            LoadData();
            base.BeforeFillData();
        }

        protected override void FillData()
        {
            if (!NailApp.lstPermission.Contains(BANNER_LIST_CMDKEY) && !NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            base.FillData();
            CreateBinding(cbobranchId);
            CreateBinding(txtBannerText);
            CreateBinding(txtNumberOrder);
            CreateBinding(txtDecriptions);
            CreateBinding(chkis_inactive, "is_inactive", "Checked");
        }
        protected override bool InsertData()
        {
            bool isSuccess = false;
            try
            {
                //LoadEditRow();
                if (_Mode == "Add")
                {
                    if (!NailApp.lstPermission.Contains(BANNER_ADD_CMDKEY) && !NailApp.IsAdmin())
                    {
                        lblMessInfomation.Text = "Unauthorized";
                        return false;
                    }
                    //isSuccess = base.InsertData();
                }
                else
                {
                    if (!NailApp.lstPermission.Contains(BANNER_EDIT_CMDKEY) && !NailApp.IsAdmin())
                    {
                        lblMessInfomation.Text = "Unauthorized";
                        return false;
                    }
                    //isSuccess = base.UpdateData();
                }

                txtBannerText.Focus();

                string listError = "";
                #region Đoạn này cho phép sửa hoặc add mới nhiều dòng cùng 1 lúc => Phải sửa lại
                DataTable changedRows = ((DataTable)(Bds.DataSource)).GetChanges();
                if (changedRows != null)
                {
                    foreach (DataRow dr in changedRows.Rows)
                    {
                        dr["created_by"] = NailApp.CurrentUserId;
                        dr["modified_by"] = NailApp.CurrentUserId;
                        if (dr[_idName].ToString() == "0" || dr[_idName].ToString() == "")
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
                            listError += "Save error BannerText: " + dr["BannerText"].ToString() + ". \n";
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
            this.Text += " Banner"; 
            base.InitForm();
        }

        private void LoadData()
        {
            using (DictionaryDAL dal = new DictionaryDAL(_tableName))
            {
                if (NailApp.IsAdmin())
                {
                    Bds.DataSource = _Banner = dal.GetData();
                }
                else
                {
                    _Banner = dal.GetData().Select("branchId = " + NailApp.BranchID, "").CopyToDataTable();
                    Bds.DataSource = _Banner;
                }
            }
            LoadGrid();
            _postion = 0;
        }


        private void LoadGrid()
        {
            _Banner.DefaultView.Sort = "BannerText";
            GridDetail.DataSource = _Banner;
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

            GridDetail.Columns["BannerID"].Visible = false;
            //GridDetail.Columns["branchId"].HeaderText = "Branch";
            GridDetail.Columns["BannerText"].HeaderText = "Banner Text";
            GridDetail.Columns["NumberOrder"].HeaderText = "Number Order";
            //GridDetail.Columns["Decriptions"].Visible = false;
            //GridDetail.Columns["created_by"].HeaderText = "Create by";
            GridDetail.Columns["created_by"].Visible = false;
            //GridDetail.Columns["created_at"].HeaderText = "Create at";
            GridDetail.Columns["created_at"].Visible = false;
            //GridDetail.Columns["modified_by"].HeaderText = "Modified by";
            GridDetail.Columns["modified_by"].Visible = false;
            //GridDetail.Columns["modified_at"].HeaderText = "Modified at";
            GridDetail.Columns["modified_at"].Visible = false;
            if (_Banner.Rows.Count > 0)
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
            if (!NailApp.lstPermission.Contains(BANNER_DEL_CMDKEY) && !NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            DialogResult result = MessNotifications("Notifications", "Do you want delete line?");
            if (result == DialogResult.Yes)
            {
                this.zDeleteRow = ((DataTable)Bds.DataSource).Rows[_postion];
                // Check use for bill or booking.
                //DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zCheckServiceExists", int.Parse(zDeleteRow["ServiceID"].ToString()));
                //if (dataTable != null && dataTable.Rows.Count > 0)
                //{
                //    MessageBox.Show("Service is already in use, cannot be deleted.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //else
                //{
                    bool flag = base.DeleteData();
                //}
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
                    txtBannerText.Text = row.Cells["BannerText"].Value.ToString();
                    txtNumberOrder.Text = row.Cells["NumberOrder"].Value.ToString();
                    txtDecriptions.Text = row.Cells["Decriptions"].Value.ToString();
                    chkis_inactive.Checked = bool.Parse(row.Cells["is_inactive"].Value.ToString());
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

        private void frmBanner_Load(object sender, EventArgs e)
        {

        }
    }
}
