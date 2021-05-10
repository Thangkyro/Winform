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
        DataRow _dr;
        DataTable _Service;
        string _tableName = "zBranch";
        public frmBranch()
        {
            InitializeComponent();
        }
        protected override void BeforeFillData()
        {
            using (DictionaryDAL dal = new DictionaryDAL(_tableName))
                //Bds.DataSource = _Service = dal.GetData(string.Format("{0}=0", ZenDatabase.INACTIVE_COLUMN_NAME));
                Bds.DataSource = _Service = dal.GetData();
            LoadGrid();
            base.BeforeFillData();
        }
        protected override void FillData()
        {
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
            DataRowView DRV = (DataRowView)Bds.Current;
            this.zEditRow = (DataRow)DRV.Row;
            return base.InsertData();
        }

        protected override void InitForm()
        {
            this.zEditTableName = _tableName;
            this.zViewTableName = _tableName;
            this.Text += " Branch";
            base.InitForm();
        }

        private void GridDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadGrid()
        {
            GridDetail.DataSource = Bds.DataSource;
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
            GridDetail.Columns["created_at"].HeaderText = "Create at";
            GridDetail.Columns["modified_by"].HeaderText = "Modified by";
            GridDetail.Columns["modified_at"].HeaderText = "Modified at";

        }

        private void GridDetail_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
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
    }
}
