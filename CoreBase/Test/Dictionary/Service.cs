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
    public partial class frmService : CoreBase.WinForm.Dictionary.Dictionary
    {
        DataRow _dr;
        DataTable _Service;
        string _tableName = "zService";
        public frmService()
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
            CreateBinding(cbobranchId);
            CreateBinding(txtTitle);
            CreateBinding(txtEstimateTime);
            CreateBinding(txtPrice);
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
            this.Text += " Service"; 
            base.InitForm();
        }

        private void GridDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void LoadGrid()
        {
            GridDetail.DataSource = Bds.DataSource;
            GridDetail.Columns["ServiceID"].Visible = false;
            GridDetail.Columns["branchId"].HeaderText = "Branch";
            GridDetail.Columns["Title"].HeaderText = "Title";
            GridDetail.Columns["EstimateTime"].HeaderText = "EstimateTime";
            GridDetail.Columns["Price"].HeaderText = "Price";
            GridDetail.Columns["Decriptions"].Visible = false;
            GridDetail.Columns["is_inactive"].HeaderText = "Inactive";
            GridDetail.Columns["created_by"].HeaderText = "Create by";
            GridDetail.Columns["created_at"].HeaderText = "Create at";
            GridDetail.Columns["modified_by"].HeaderText = "Modified by";
            GridDetail.Columns["modified_at"].HeaderText = "Modified at";
            
        }
    }
}
