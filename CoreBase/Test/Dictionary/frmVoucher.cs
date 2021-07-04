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
    public partial class frmVoucher : CoreBase.WinForm.Dictionary.Dictionary
    {
        const string VOUCHER_CMDKEY = "Voucher";
        const string VOUCHER_ADD_CMDKEY = "Voucher_add";
        const string VOUCHER_DEL_CMDKEY = "Voucher_del";
        const string VOUCHER_EDIT_CMDKEY = "Voucher_edit";
        const string VOUCHER_LIST_CMDKEY = "Voucher_list";
        DataRow _dr;
        DataTable _Voucher;
        string _tableName = "zVoucher";
        string _Mode = "";
        string _idName = "VoucherID";
        int _postion = 0;
        DataTable _user = new DataTable();
        public frmVoucher()
        {
            InitializeComponent();
            Load += UserForm_Load;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            using (ReadOnlyDAL dal = new ReadOnlyDAL("zUser"))
            {
                _user = dal.Read("is_inactive = 0");
            }

            _user.DefaultView.Sort = "user_name";
            DataRow dr1 = _user.NewRow();
            dr1["Userid"] = 0;
            dr1["full_name"] = "";
            _user.Rows.Add(dr1);

            cboIssueBy.DisplayMember = "full_name";
            cboIssueBy.ValueMember = "Userid";
            cboIssueBy.DataSource = _user.DefaultView;

        }


        protected override void BeforeFillData()
        {
            if (!NailApp.lstPermission.Contains(VOUCHER_LIST_CMDKEY) && !NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            LoadData();
            base.BeforeFillData();
        }

        protected override void FillData()
        {
            if (!NailApp.lstPermission.Contains(VOUCHER_LIST_CMDKEY) && !NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            base.FillData();
            CreateBinding(txtVoucherCode);
            CreateBinding(txtAmount);
            CreateBinding(txtAvailableAmount);
            CreateBinding(txtIssueDate);
            CreateBinding(cboIssueBy);
            CreateBinding(txtVoucherFrom);
            CreateBinding(txtVoucherTo);
            CreateBinding(txtzPrintname);
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
                    if (!NailApp.lstPermission.Contains(VOUCHER_ADD_CMDKEY) && !NailApp.IsAdmin())
                    {
                        lblMessInfomation.Text = "Unauthorized";
                        return false;
                    }
                    ///isSuccess = base.InsertData();
                }
                else
                {
                    if (!NailApp.lstPermission.Contains(VOUCHER_EDIT_CMDKEY) && !NailApp.IsAdmin())
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
                        listError += "Save error voucher: " + dr["VoucherCode"].ToString() + ". \n";
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
            this.Text += " Voucher"; 
            base.InitForm();
        }

        private void LoadData()
        {
            using (DictionaryDAL dal = new DictionaryDAL(_tableName))
                Bds.DataSource = _Voucher = dal.GetData();
            LoadGrid();
            _postion = 0;
        }


        private void LoadGrid()
        {
            GridDetail.DataSource = _Voucher;
            //GridDetail.Columns.Remove("IssueBy");

            //DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
            //dgvCmb.DataPropertyName = "IssueBy";
            //dgvCmb.HeaderText = "IssueBy";
            //dgvCmb.Name = "IssueBy";
            //dgvCmb.DisplayMember = "full_name";
            //dgvCmb.ValueMember = "Userid";
            //dgvCmb.DataSource = _user;
            //GridDetail.Columns.Add(dgvCmb);

            //GridDetail.Columns["IssueBy"].DisplayIndex = 0;
            GridDetail.Columns["VoucherID"].Visible = false;
            GridDetail.Columns["VoucherCode"].HeaderText = "Voucher Code";
            GridDetail.Columns["VoucherCode"].ReadOnly = true;
            GridDetail.Columns["VoucherCode"].DefaultCellStyle.BackColor = Color.Silver;
            GridDetail.Columns["Amount"].HeaderText = "Amount";
            GridDetail.Columns["AvailableAmount"].HeaderText = "Available Amount";
            GridDetail.Columns["AvailableAmount"].ReadOnly = true;
            GridDetail.Columns["AvailableAmount"].DefaultCellStyle.BackColor = Color.Silver;
            GridDetail.Columns["IssueDate"].HeaderText = "Issue Date";
            //GridDetail.Columns["IssueBy"].HeaderText = "Issue By";
            GridDetail.Columns["IssueBy"].Visible = false;
            GridDetail.Columns["VoucherFrom"].HeaderText = "Voucher From";
            GridDetail.Columns["VoucherTo"].HeaderText = "Voucher To";
            GridDetail.Columns["zPrintname"].HeaderText = "Print Name";
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

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!NailApp.lstPermission.Contains(VOUCHER_DEL_CMDKEY) && !NailApp.IsAdmin())
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

        private void GridDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    _postion = e.RowIndex;
                    DataGridViewRow row = this.GridDetail.Rows[e.RowIndex];
                    txtVoucherCode.Text = row.Cells["VoucherCode"].Value.ToString();
                    txtAmount.Text = row.Cells["Amount"].Value.ToString();
                    txtAvailableAmount.Text = row.Cells["AvailableAmount"].Value.ToString();
                    txtIssueDate.Text = row.Cells["IssueDate"].Value.ToString();
                    //txtIssueBy.Text = row.Cells["IssueBy"].Value.ToString();
                    cboIssueBy.SelectedValue = row.Cells["IssueBy"].Value.ToString();
                    txtVoucherFrom.Text = row.Cells["VoucherFrom"].Value.ToString();
                    txtVoucherTo.Text = row.Cells["VoucherTo"].Value.ToString();
                    txtzPrintname.Text = row.Cells["zPrintname"].Value.ToString();
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
                this.zEditRow["VoucherCode"] = GenVoucherCode();
                this.zEditRow["IssueBy"] = NailApp.CurrentUserId;
                this.zEditRow["AvailableAmount"] = this.zEditRow["Amount"] != DBNull.Value ? this.zEditRow["Amount"] : 0;
                _Mode = "Add";
            }
            else
            {
                this.zEditRow = ((DataTable)Bds.DataSource).Rows[_postion];
                _Mode = "Update";
            }
        }

        private string GenVoucherCode()
        {
            string voucherCode = "";
            try
            {
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGetNewCode", _tableName, "VR", _idName, 8);
                if (dt != null)
                {
                    voucherCode = dt.Rows[0][0].ToString();
                }
            }
            catch
            {

            }
            return voucherCode;
        }

        private void GridDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = GridDetail.Columns[e.ColumnIndex].Name;
            if (headerText.Equals("IssueDate") || headerText.Equals("VoucherFrom") || headerText.Equals("VoucherTo")) // Date
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
                    GridDetail[cIndex,rIndex].Style.BackColor = Color.Red;
                    e.Cancel = true;
                    lblMessInfomation.Text = "Value invalid";
                }
            }
        }

        private void txtVoucherCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
