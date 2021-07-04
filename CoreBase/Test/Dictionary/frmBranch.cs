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
    public partial class frmBranch : CoreBase.WinForm.Dictionary.Dictionary
    {
        const string BRANCH_CMDKEY = "Branch";
        const string BRANCH_ADD_CMDKEY = "Branch_add";
        const string BRANCH_DEL_CMDKEY = "Branch_del";
        const string BRANCH_EDIT_CMDKEY = "Branch_edit";
        const string BRANCH_LIST_CMDKEY = "Branch_list";

        string _Mode = "";
        DataTable _Service;
        string _idName = "branchId";
        string _tableName = "zBranch";
        int _postion = 0;
        public frmBranch()
        {
            InitializeComponent();
        }
        protected override void BeforeFillData()
        {
            if (!NailApp.lstPermission.Contains(BRANCH_LIST_CMDKEY) && !NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            LoadData();
            base.BeforeFillData();
        }
        protected override void FillData()
        {
            if (!NailApp.lstPermission.Contains(BRANCH_LIST_CMDKEY) && !NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            base.FillData();
            CreateBinding(txtBranchCode);
            CreateBinding(txtBranchName);
            CreateBinding(txtLocated);
            CreateBinding(txtPhoneNumber);
            CreateBinding(txtFacebook);
            CreateBinding(txtEmail);
            CreateBinding(txtWebsite);
            CreateBinding(txtSMSText);
            CreateBinding(txtNumberBill);
            CreateBinding(txtNoontime);
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
                    if (!NailApp.lstPermission.Contains(BRANCH_ADD_CMDKEY) && !NailApp.IsAdmin())
                    {
                        lblMessInfomation.Text = "Unauthorized";
                        return false;
                    }
                   // isSuccess = base.InsertData();
                }
                else
                {
                    if (!NailApp.lstPermission.Contains(BRANCH_EDIT_CMDKEY) && !NailApp.IsAdmin())
                    {
                        lblMessInfomation.Text = "Unauthorized";
                        return false;
                    }
                    //isSuccess = base.UpdateData();
                }

                string listError = "";
                #region Đoạn này cho phép sửa hoặc add mới nhiều dòng cùng 1 lúc => Phải sửa lại
                DataTable changedRows = ((DataTable)(Bds.DataSource)).GetChanges();

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
                        listError += "Save error branch: " + dr["BranchName"].ToString() + ". \n";
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
            catch (Exception ex)
            {

            }
            return isSuccess;
        }

        //protected override bool UpdateData()
        //{
        //    LoadEditRow();
        //    if (_Mode == "Update")
        //    {
        //        return base.UpdateData();
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        protected override void InitForm()
        {
            this.zEditTableName = _tableName;
            this.zViewTableName = _tableName;
            this.Text += " Branch";
            base.InitForm();
        }

        private void LoadData()
        {
            using (DictionaryDAL dal = new DictionaryDAL(_tableName))
                Bds.DataSource = _Service = dal.GetData();
            LoadGrid();
            _postion = 0;
        }
        private void LoadGrid()
        {
            GridDetail.DataSource = _Service;
            GridDetail.Columns["branchId"].Visible = false;
            GridDetail.Columns["BranchCode"].HeaderText = "Branch code";
            GridDetail.Columns["BranchName"].HeaderText = "Branch name";
            GridDetail.Columns["Located"].HeaderText = "Located";
            GridDetail.Columns["PhoneNumber"].HeaderText = "Phone number";
            GridDetail.Columns["Facebook"].HeaderText = "Facebook";
            GridDetail.Columns["Email"].HeaderText = "Email";
            GridDetail.Columns["Website"].HeaderText = "Website";
            GridDetail.Columns["SMSText"].HeaderText = "SMS text";
            GridDetail.Columns["NumberBill"].HeaderText = "Number bill";
            GridDetail.Columns["Noontime"].HeaderText = "Noon time";
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
                    txtBranchCode.Text = row.Cells["BranchCode"].Value.ToString();
                    txtBranchName.Text = row.Cells["BranchName"].Value.ToString();
                    txtLocated.Text = row.Cells["Located"].Value.ToString();
                    txtPhoneNumber.Text = row.Cells["PhoneNumber"].Value.ToString();
                    txtFacebook.Text = row.Cells["Facebook"].Value.ToString();
                    txtEmail.Text = row.Cells["Email"].Value.ToString();
                    txtWebsite.Text = row.Cells["Website"].Value.ToString();
                    txtSMSText.Text = row.Cells["SMSText"].Value.ToString();
                    txtNumberBill.Text = row.Cells["NumberBill"].Value.ToString();
                    txtNoontime.Text = row.Cells["Noontime"].Value.ToString();
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!NailApp.lstPermission.Contains(BRANCH_DEL_CMDKEY) && !NailApp.IsAdmin())
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

        private void refeshListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private DialogResult MessNotifications(string title, string message)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            return result;
        }

        private void txtBranchCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
