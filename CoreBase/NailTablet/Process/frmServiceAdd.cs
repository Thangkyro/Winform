using CoreBase;
using CoreBase.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AusNail.Process
{
    public partial class frmServiceAdd : Form
    {
        private int _branchID = 0;
        private int _userID = 0;
        private DataTable _dtService = null;
        private DataTable _dtStaff = null;
        private DataTable _Service = null;
        public delegate void DelSendMsg(string msg);
        private int iResult = 0;

        //khạ báo biến kiểu delegate
        public DelSendMsg SendMsg;

        public frmServiceAdd()
        {
            InitializeComponent();
        }

        public frmServiceAdd(int branchId, int userId, string customerName, string phoneNumber)
        {
            InitializeComponent();
            _branchID = branchId;
            _userID = userId;
            txtName.Text = customerName;
            txtPhoneNumber.Text = phoneNumber;
            loadService();
            LoadGrid();
        }

        private void loadService()
        {
            try
            {
                _dtService = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zServiceGetList_byBranch", _branchID);
                _dtStaff = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zStaffGetList_byBrabch", _branchID);
                if (_dtService != null)
                {
                    _Service = _dtService.Copy();
                    _Service.Columns.Remove("branchId");
                    _Service.Columns.Remove("Display");
                    _Service.Columns.Remove("Decriptions");
                    _Service.Columns.Remove("is_inactive");
                    _Service.Columns.Remove("created_by");
                    _Service.Columns.Remove("created_at");
                    _Service.Columns.Remove("modified_by");
                    _Service.Columns.Remove("modified_at");
                    _Service.Columns.Add("Quantity", typeof(decimal));
                    _Service.Columns.Add("Amount", typeof(decimal));
                    foreach (DataRow dr in _Service.Rows)
                    {
                        dr["Quantity"] = 1;
                        dr["Amount"] = decimal.Parse(dr["Quantity"].ToString()) * decimal.Parse(dr["Price"].ToString());
                    }
                }
            }
            catch
            {
            }
        }

        private void dgvService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadGrid()
        {


            dgvService.DataSource = _Service;
            dgvService.Columns["ServiceID"].Visible = false;
            dgvService.Columns["Title"].HeaderText = "Service Name";
            dgvService.Columns["Title"].ReadOnly = true;
            dgvService.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvService.Columns["EstimateTime"].HeaderText = "Estimate Time";
            dgvService.Columns["EstimateTime"].Width = 75;
            dgvService.Columns["EstimateTime"].ReadOnly = true;
            dgvService.Columns["EstimateTime"].Visible = false;
            //dgvService.Columns["Quantity"].HeaderText = "Quantity";
            //dgvService.Columns["Quantity"].Width = 75;
            dgvService.Columns.Remove("Quantity");
            NumericUpDownColumn numericUpDown = new NumericUpDownColumn();
            numericUpDown.Name = "Quantity";
            numericUpDown.DataPropertyName = "Quantity";
            numericUpDown.CellTemplate.Value = 1;
            numericUpDown.Width = 150;
            dgvService.Columns.Add(numericUpDown);
            dgvService.Columns["Quantity"].DisplayIndex = 3;

            dgvService.Columns["Price"].HeaderText = "Price";
            dgvService.Columns["Price"].Width = 200;
            dgvService.Columns["Price"].Visible = false;
            dgvService.Columns["Amount"].HeaderText = "Amount";
            dgvService.Columns["Amount"].ReadOnly = true;
            dgvService.Columns["Amount"].Width = 200;
            dgvService.Columns["Amount"].Visible = false;

            DataGridViewCheckBoxColumn dataGridViewImange = new DataGridViewCheckBoxColumn();
            dataGridViewImange.Name = "Check";
            dataGridViewImange.HeaderText = "";
            dataGridViewImange.Width = 100;
            dgvService.Columns.Add(dataGridViewImange);


            dgvService.RowTemplate.Height = 50;
            dgvService.AutoGenerateColumns = false;
            dgvService.AllowUserToAddRows = false;
            dgvService.AllowUserToDeleteRows = false;
        }

        private void dgvService_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && (e.ColumnIndex == 2 || e.ColumnIndex == 4))
                {
                    decimal Quantity = decimal.Parse(dgvService.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                    decimal Price = decimal.Parse(dgvService.Rows[e.RowIndex].Cells["Price"].Value.ToString());
                    // Update row num
                    dgvService.Rows[e.RowIndex].Cells["Amount"].Value = Quantity * Price;
                }

            }
            catch
            {
                dgvService.Rows[e.RowIndex].Cells["Amount"].Value = 0;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvService.Rows.Count > 0)
            {
                bool flag = true;
                // Get billCode
                string billCode = "";
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGetNewCode", "zBillMaster", "BL", "BillID", 8);
                int StaffId = -1;
                if (dt != null)
                {
                    billCode = dt.Rows[0][0].ToString();
                }

                // Get bill number
                int billnumber = 1;
                DataTable dt1 = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillNumber", _branchID, DateTime.Parse(DateTime.Now.ToShortDateString()));
                if (dt1 != null)
                {
                    billnumber = int.Parse(dt1.Rows[0][0].ToString().Substring(0, dt1.Rows[0][0].ToString().IndexOf('.')));
                }

                for (int i = 0; i < dgvService.Rows.Count; i++)
                {
                    if ((bool)(dgvService.Rows[i].Cells["Check"].Value == null ? false : dgvService.Rows[i].Cells["Check"].Value) == true)
                    {
                        string CustomerPhone = txtPhoneNumber.Text.Trim();
                        int Num = i + 1;
                        int ServiceID = int.Parse(dgvService.Rows[i].Cells["ServiceId"].Value.ToString());
                        decimal Quantity = decimal.Parse(dgvService.Rows[i].Cells["Quantity"].Value.ToString());
                        decimal Price = decimal.Parse(dgvService.Rows[i].Cells["Price"].Value.ToString());
                        string Note = "";
                        DateTime billdate = DateTime.Parse(DateTime.Now.ToShortDateString());
                        int error = 0;
                        string errorMesg = "";

                        int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillInsert_Ver1", billdate, _branchID, billCode, CustomerPhone, Num, ServiceID, Quantity, Price, StaffId, Note, _userID, billnumber, error, errorMesg);

                        if (ret == 0)
                        {
                            flag = false;
                        }
                    }
                }
                if (flag)
                {
                    MessageBox.Show("Register sucessfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Visible = false;
                    this.ShowInTaskbar = false;

                    //In bill temp
                    //Get billID
                    int billID = 0;
                    DataTable dtBill = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, "Select TOP 1 BillID From zBillMaster WITH(NOLOCK) Where BillCode = '" + billCode + "'");
                    if (dtBill != null && dtBill.Rows.Count > 0)
                    {
                        billID = int.Parse(dtBill.Rows[0][0].ToString());
                    }
                    if (NailApp.IsAutoPrint())
                    {
                        DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillPrint", billID, int.Parse(NailApp.BranchID));
                        DataSet dsData = new DataSet();
                        dsData.Tables.Add(dataTable);
                        frmPrintNew f = new frmPrintNew(dsData, "rpt_bill.rpt", false, int.Parse(NailApp.BranchID), billID);
                        f.ShowDialog();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want print review ?", "View Bill", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillPrint", billID, int.Parse(NailApp.BranchID));
                            DataSet dsData = new DataSet();
                            dsData.Tables.Add(dataTable);

                            frmPrintNew f = new frmPrintNew(dsData, "rpt_bill.rpt", true, int.Parse(NailApp.BranchID), billID);
                            f.ShowDialog();
                        }
                        else
                        {
                            DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillPrint", billID, int.Parse(NailApp.BranchID));
                            DataSet dsData = new DataSet();
                            dsData.Tables.Add(dataTable);
                            frmPrintNew f = new frmPrintNew(dsData, "rpt_bill.rpt", false, int.Parse(NailApp.BranchID), billID);
                            f.ShowDialog();
                        }
                    }

                    //Process.frmCheckPhone frm = new Process.frmCheckPhone(false);
                    //frm.ShowDialog();
                    
                }
            }
            this.Close();
        }

        public int SendData()
        {
            return iResult;
        }

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6) // Check
                {
                    if ((bool)(dgvService.Rows[e.RowIndex].Cells["Check"].Value == null ? false : dgvService.Rows[e.RowIndex].Cells["Check"].Value) == true)
                    {
                        dgvService.Rows[e.RowIndex].Cells["Check"].Value = false;
                        dgvService.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        dgvService.Rows[e.RowIndex].Cells["Check"].Value = true;
                        dgvService.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvService_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    e.CellStyle.Format = "N0";
                }
                if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
                {
                    e.CellStyle.Format = "N2";
                }
            }
            catch
            {
            }
        }

        #region Define Datagridview NumericUpDown
        public class NumericUpDownColumn : DataGridViewColumn
        {
            public NumericUpDownColumn()
                : base(new NumericUpDownCell(1,1000))
            {
            }

            public override DataGridViewCell CellTemplate
            {
                get { return base.CellTemplate; }
                set
                {
                    if (value != null && !value.GetType().IsAssignableFrom(typeof(NumericUpDownCell)))
                    {
                        throw new InvalidCastException("Must be a NumericUpDownCell");
                    }
                    base.CellTemplate = value;
                }
            }
        }

        public class NumericUpDownCell : DataGridViewTextBoxCell
        {
            private decimal min;
            private decimal max;

            public NumericUpDownCell()
                : base()
            {
                Style.Format = "F0";
            }
            public NumericUpDownCell(decimal min, decimal max)
                : base()
            {
                this.min = min;
                this.max = max;
                Style.Format = "F0";
            }

            public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
            {
                base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
                NumericUpDownEditingControl ctl = DataGridView.EditingControl as NumericUpDownEditingControl;
                ctl.Minimum = 1; //this.min;
                ctl.Maximum = 1000;// this.max;
                try
                {
                    ctl.Value = Convert.ToDecimal(this.Value);
                }
                catch (Exception)
                {
                    ctl.Value = 1;
                }
                
            }

            public override Type EditType
            {
                get { return typeof(NumericUpDownEditingControl); }
            }

            public override Type ValueType
            {
                get { return typeof(Decimal); }
            }

            public override object DefaultNewRowValue
            {
                get { return null; } 
            }
        }

        public class NumericUpDownEditingControl : NumericUpDown, IDataGridViewEditingControl
        {
            private DataGridView dataGridViewControl;
            private bool valueIsChanged = false;
            private int rowIndexNum;

            public NumericUpDownEditingControl()
                : base()
            {
                this.DecimalPlaces = 0;
            }

            public DataGridView EditingControlDataGridView
            {
                get { return dataGridViewControl; }
                set { dataGridViewControl = value; }
            }

            public object EditingControlFormattedValue
            {
                get { return this.Value.ToString("F0"); }
                set { this.Value = Decimal.Parse(value.ToString()); }
            }
            public int EditingControlRowIndex
            {
                get { return rowIndexNum; }
                set { rowIndexNum = value; }
            }
            public bool EditingControlValueChanged
            {
                get { return valueIsChanged; }
                set { valueIsChanged = value; }
            }

            public Cursor EditingPanelCursor
            {
                get { return base.Cursor; }
            }

            public bool RepositionEditingControlOnValueChange
            {
                get { return false; }
            }

            public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
            {
                this.Font = dataGridViewCellStyle.Font;
                this.ForeColor = dataGridViewCellStyle.ForeColor;
                this.BackColor = dataGridViewCellStyle.BackColor;
            }

            public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
            {
                return (keyData == Keys.Left || keyData == Keys.Right ||
                    keyData == Keys.Up || keyData == Keys.Down ||
                    keyData == Keys.Home || keyData == Keys.End ||
                    keyData == Keys.PageDown || keyData == Keys.PageUp);
            }

            public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
            {
                return this.Value.ToString();
            }

            public void PrepareEditingControlForEdit(bool selectAll)
            {
            }

            protected override void OnValueChanged(EventArgs e)
            {
                valueIsChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnValueChanged(e);
            }
        }
        #endregion
    }
}
