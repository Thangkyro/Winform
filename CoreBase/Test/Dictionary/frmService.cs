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
        string _Mode = "";
        string _idName = "ServiceID";
        int _postion = 0;
        public frmService()
        {
            InitializeComponent();
        }

        protected override void BeforeFillData()
        {
            LoadData();
            base.BeforeFillData();
        }

        protected override void FillData()
        {
            base.FillData();
            CreateBinding(cbobranchId);
            CreateBinding(txtTitle);
            CreateBinding(txtEstimateTime);
            CreateBinding(txtPrice);
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
                    return base.InsertData();
                }
                else
                {
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
            this.Text += " Service"; 
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
            GridDetail.Columns["ServiceID"].Visible = false;
            GridDetail.Columns["branchId"].HeaderText = "Branch";
            GridDetail.Columns["Title"].HeaderText = "Title";
            GridDetail.Columns["EstimateTime"].HeaderText = "EstimateTime";
            GridDetail.Columns["Price"].HeaderText = "Price";
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
                    cbobranchId.SelectedValue = row.Cells["branchId"].Value.ToString();
                    txtTitle.Text = row.Cells["Title"].Value.ToString();
                    txtPrice.Text = row.Cells["Price"].Value.ToString();
                    txtEstimateTime.Text = row.Cells["EstimateTime"].Value.ToString();
                    txtDecriptions.Text = row.Cells["Decriptions"].Value.ToString();
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
