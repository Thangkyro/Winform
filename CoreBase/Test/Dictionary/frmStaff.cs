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
        public frmStaff()
        {
            InitializeComponent();
        }

        protected override void BeforeFillData()
        {
            using (DictionaryDAL dal = new DictionaryDAL(_tableName))
                //Bds.DataSource = _Service = dal.GetData(string.Format("{0}=0", ZenDatabase.INACTIVE_COLUMN_NAME));
                Bds.DataSource = _Staff = dal.GetData();
            LoadGrid();
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
            DataRowView DRV = (DataRowView)Bds.Current;
            this.zEditRow = (DataRow)DRV.Row;
            return base.InsertData();
        }

        protected override void InitForm()
        {
            this.zEditTableName = _tableName;
            this.zViewTableName = _tableName;
            this.Text += " Staff"; 
            base.InitForm();
        }


        private void LoadGrid()
        {
            GridDetail.DataSource = Bds.DataSource;
            GridDetail.Columns["StaffId"].Visible = false;
            GridDetail.Columns["branchId"].HeaderText = "Branch";
            GridDetail.Columns["StaffCode"].HeaderText = "Staff Code";
            GridDetail.Columns["Name"].HeaderText = "Name";
            GridDetail.Columns["Gender"].HeaderText = "Gender";
            GridDetail.Columns["PhoneNumber1"].HeaderText = "Phone Number 1";
            GridDetail.Columns["PhoneSimple1"].HeaderText = "Phone Simple 1";
            GridDetail.Columns["PhoneNumber2"].HeaderText = "Phone Number 2";
            GridDetail.Columns["PhoneSimple2"].HeaderText = "Phone Simple 2";
            GridDetail.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
            GridDetail.Columns["TFN"].HeaderText = "Tax Number";
            GridDetail.Columns["BSB"].HeaderText = "BSB";
            GridDetail.Columns["Decriptions"].HeaderText = "Decriptions";
            GridDetail.Columns["is_inactive"].HeaderText = "Inactive";
            GridDetail.Columns["created_by"].HeaderText = "Create by";
            GridDetail.Columns["created_at"].HeaderText = "Create at";
            GridDetail.Columns["modified_by"].HeaderText = "Modified by";
            GridDetail.Columns["modified_at"].HeaderText = "Modified at";
            
        }

    }
}
