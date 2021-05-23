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
        DataRow _dr;
        DataTable _Voucher;
        string _tableName = "zVoucher";
        string _Mode = "";
        string _idName = "VoucherID";
        int _postion = 0;
        public frmVoucher()
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
            CreateBinding(txtVoucherCode);
            CreateBinding(txtAmount);
            CreateBinding(txtAvailableAmount);
            CreateBinding(txtIssueDate);
            CreateBinding(txtIssueBy);
            CreateBinding(txtVoucherFrom);
            CreateBinding(txtVoucherTo);
            CreateBinding(txtzPrintname);
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
            GridDetail.Columns["VoucherID"].Visible = false;
            GridDetail.Columns["VoucherCode"].HeaderText = "Voucher Code";
            GridDetail.Columns["Amount"].HeaderText = "Amount";
            GridDetail.Columns["AvailableAmount"].HeaderText = "Available Amount";
            GridDetail.Columns["IssueDate"].HeaderText = "Issue Date";
            GridDetail.Columns["IssueBy"].HeaderText = "Issue By";
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
                    txtIssueBy.Text = row.Cells["IssueBy"].Value.ToString();
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
                _Mode = "Add";
            }
            else
            {
                this.zEditRow = ((DataTable)Bds.DataSource).Rows[_postion];
                _Mode = "Update";
            }
        }
    }
}
