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
    public partial class frmCustomer : CoreBase.WinForm.Dictionary.Dictionary
    {
        const string CUSTOMER_CMDKEY = "frmCustomer";
        const string CUSTOMER_ADD_CMDKEY = "frmCustomer_add";
        const string CUSTOMER_DEL_CMDKEY = "frmCustomer_del";
        const string CUSTOMER_EDIT_CMDKEY = "frmCustomer_edit";
        const string CUSTOMER_LIST_CMDKEY = "frmCustomer_list";
        DataRow _dr;
        string _Mode = "";
        DataTable _Service;
        string _idName = "CustId";
        string _tableName = "zCustomer";
        int _postion = 0;
        DataTable _branch = new DataTable();
        public frmCustomer()
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
            if (!NailApp.lstPermission.Contains(CUSTOMER_LIST_CMDKEY))
            {
                lblMessInfomation.Text = "Unauthorized";
            }
            else
            {
                LoadData();
            }
            base.BeforeFillData();
        }
        protected override void FillData()
        {
            base.FillData();
            CreateBinding(cbobranchId);
            CreateBinding(txtCustomerCode);
            CreateBinding(txtName);
            CreateBinding(txtGender);
            CreateBinding(txtDateOfBirth);
            CreateBinding(txtPhoneNumber1);
            CreateBinding(txtPhoneSimple1);
            CreateBinding(txtPhoneNumber2);
            CreateBinding(txtPhoneSimple2);
            CreateBinding(txtPostCode);
            CreateBinding(txtDecriptions);
            CreateBinding(chkIsMerge, "IsMerge", "Checked");
            CreateBinding(chkis_inactive, "is_inactive", "Checked");
        }
        protected override bool InsertData()
        {
            
            try
            {
                LoadEditRow();
                if (_Mode == "Add")
                {
                    if (!NailApp.lstPermission.Contains(CUSTOMER_ADD_CMDKEY))
                    {
                        lblMessInfomation.Text = "Unauthorized";
                        return false;
                    }
                    return base.InsertData();
                }
                else
                {
                    if (!NailApp.lstPermission.Contains(CUSTOMER_EDIT_CMDKEY))
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
            this.Text += " Customer";
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

            GridDetail.Columns["CustId"].Visible = false;
            //GridDetail.Columns["branchId"].HeaderText = "Branch";
            GridDetail.Columns["CustomerCode"].HeaderText = "Customer Code";
            GridDetail.Columns["CustomerCode"].ReadOnly = true;
            GridDetail.Columns["Name"].HeaderText = "Name";
            GridDetail.Columns["Gender"].HeaderText = "Gender";
            GridDetail.Columns["PhoneNumber1"].HeaderText = "Phone Number 1";
            GridDetail.Columns["PhoneSimple1"].HeaderText = "Phone Simple 1";
            GridDetail.Columns["PhoneNumber2"].HeaderText = "Phone Number 2";
            GridDetail.Columns["PhoneSimple2"].HeaderText = "Phone Simple 2";
            GridDetail.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
            GridDetail.Columns["PostCode"].HeaderText = "Post Code";
            //GridDetail.Columns["Decriptions"].HeaderText = "Decriptions";
            GridDetail.Columns["IsMerge"].HeaderText = "IsMerge";
            GridDetail.Columns["CustIdMerge"].HeaderText = "Cust Id Merge";
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
                    txtCustomerCode.Text = row.Cells["CustomerCode"].Value.ToString();
                    txtName.Text = row.Cells["Name"].Value.ToString();
                    txtGender.Text = row.Cells["Gender"].Value.ToString();
                    txtPhoneNumber1.Text = row.Cells["PhoneNumber1"].Value.ToString();
                    txtPhoneSimple1.Text = row.Cells["PhoneSimple1"].Value.ToString();
                    txtPhoneNumber2.Text = row.Cells["PhoneNumber2"].Value.ToString();
                    txtPhoneSimple2.Text = row.Cells["PhoneSimple2"].Value.ToString();
                    txtDateOfBirth.Text = row.Cells["DateOfBirth"].Value.ToString();
                    txtPostCode.Text = row.Cells["PostCode"].Value.ToString();
                    txtDecriptions.Text = row.Cells["Decriptions"].Value.ToString();
                    chkIsMerge.Checked = bool.Parse(row.Cells["IsMerge"].Value.ToString());
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
                this.zEditRow["CustomerCode"] = GenCustomerCode();
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
            if (!NailApp.lstPermission.Contains(CUSTOMER_DEL_CMDKEY))
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

        private string GenCustomerCode()
        {
            string customerCode = "";
            try
            {
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGetNewCode", _tableName, "CR", _idName, 8);
                if (dt != null)
                {
                    customerCode = dt.Rows[0][0].ToString();
                }
            }
            catch
            { }
            return customerCode;
        }

        private void GridDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!NailApp.lstPermission.Contains(CUSTOMER_EDIT_CMDKEY))
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            if (e.ColumnIndex == 8) // From - TO
            {
                int rIndex = e.RowIndex;
                int cIndex = e.ColumnIndex;
                DateTime dt;
                string hehe = Convert.ToString(e.FormattedValue);
                if (DateTime.TryParse(Convert.ToString(e.FormattedValue), out dt))
                {

                }
                else
                {
                    GridDetail[cIndex, rIndex].Style.BackColor = Color.Red;
                    e.Cancel = true;
                    lblMessInfomation.Text = "Value invalid";
                }
            }
        }
    }
}
