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
        DataTable _dtSo = new DataTable();
        private int iChange = 0;
        private int _num = 1;
        private string _sBillCode = "";

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
            loadDTSO();
            loadService();
            LoadGrid();
            this.BackColor = NailApp.ColorUser.IsEmpty == true ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
        }

        private void loadDTSO()
        {
            _dtSo.Columns.Add("key", typeof(int));
            _dtSo.Columns.Add("value", typeof(int));
            _dtSo.Rows.Add(new object[] { 1, 1 });
            _dtSo.Rows.Add(new object[] { 2, 2 });
            _dtSo.Rows.Add(new object[] { 3, 3 });
            _dtSo.Rows.Add(new object[] { 4, 4 });
            _dtSo.Rows.Add(new object[] { 5, 5 });
            _dtSo.Rows.Add(new object[] { 6, 6 });
            _dtSo.Rows.Add(new object[] { 7, 7 });
            _dtSo.Rows.Add(new object[] { 8, 8 });
            _dtSo.Rows.Add(new object[] { 9, 9 });
            _dtSo.Rows.Add(new object[] { 10, 10 });
            _dtSo.Rows.Add(new object[] { 11, 11 });
            _dtSo.Rows.Add(new object[] { 12, 12 });
            _dtSo.Rows.Add(new object[] { 13, 13 });
            _dtSo.Rows.Add(new object[] { 14, 14 });
            _dtSo.Rows.Add(new object[] { 15, 15 });
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
                    _Service.Columns.Add("Quantity", typeof(int));
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

        private void LoadGrid()
        {

            DataGridViewCheckBoxColumn dataGridCheckbox = new DataGridViewCheckBoxColumn();
            dataGridCheckbox.Name = "Check";
            dataGridCheckbox.HeaderText = "";
            dataGridCheckbox.Width = 40;
            dataGridCheckbox.ReadOnly = true;
            dgvService.Columns.Add(dataGridCheckbox);

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
            //NumericUpDownColumn numericUpDown = new NumericUpDownColumn();
            //numericUpDown.Name = "Quantity";
            //numericUpDown.DataPropertyName = "Quantity";
            //numericUpDown.CellTemplate.Value = 1;
            //numericUpDown.Width = 150;
            //dgvService.Columns.Add(numericUpDown);
            DataGridViewComboBoxColumn quantity = new DataGridViewComboBoxColumn();
            quantity.Name = "Quantity";
            quantity.HeaderText = "Quantity";
            quantity.DataPropertyName = "Quantity";
            quantity.ValueMember = "key";
            quantity.DisplayMember = "value";
            quantity.DataSource = _dtSo;
            quantity.Width = 150;
            quantity.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            dgvService.Columns.Add(quantity);

            dgvService.Columns["Price"].HeaderText = "Price";
            dgvService.Columns["Price"].Width = 200;
            dgvService.Columns["Price"].Visible = false;
            dgvService.Columns["Amount"].HeaderText = "Amount";
            dgvService.Columns["Amount"].ReadOnly = true;
            dgvService.Columns["Amount"].Width = 200;
            dgvService.Columns["Amount"].Visible = false;

            dgvService.RowTemplate.Height = 40;
            dgvService.AutoGenerateColumns = false;
            dgvService.AllowUserToAddRows = false;
            dgvService.AllowUserToDeleteRows = false;
        }

        private void dgvService_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && (e.ColumnIndex == 2 || e.ColumnIndex == 5))
                {
                    decimal Quantity = decimal.Parse(dgvService.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                    decimal Price = decimal.Parse(dgvService.Rows[e.RowIndex].Cells["Price"].Value.ToString());
                    // Update row num
                    dgvService.Rows[e.RowIndex].Cells["Amount"].Value = Quantity * Price;
                }

            }
            catch (Exception  ex)
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
                DataTable dt1 = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillNumber", _branchID, DateTime.Now.AddHours(NailApp.TimeConfig));
                if (dt1 != null)
                {
                    billnumber = int.Parse(dt1.Rows[0][0].ToString().Substring(0, dt1.Rows[0][0].ToString().IndexOf('.')));
                }

                _num = 1;

                for (int i = 0; i < dgvService.Rows.Count; i++)
                {
                    if ((bool)(dgvService.Rows[i].Cells["Check"].Value == null ? false : dgvService.Rows[i].Cells["Check"].Value) == true)
                    {
                        decimal Quantity = decimal.Parse(dgvService.Rows[i].Cells["Quantity"].Value.ToString());
                        int intQty = int.Parse(Quantity.ToString());
                        for (int j = 1; j < intQty + 1; j++)
                        {
                            string CustomerPhone = txtPhoneNumber.Text.Trim();
                            int ServiceID = int.Parse(dgvService.Rows[i].Cells["ServiceId"].Value.ToString());
                            decimal Price = decimal.Parse(dgvService.Rows[i].Cells["Price"].Value.ToString());
                            string Note = "";
                            DateTime billdate = DateTime.Now.AddHours(NailApp.TimeConfig);
                            int error = 0;
                            string errorMesg = "";

                            int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillInsert_Ver1", billdate, _branchID, billCode, CustomerPhone, _num, ServiceID, 1, Price, StaffId, Note, _userID, billnumber, error, errorMesg);

                            if (ret == 0)
                            {
                                flag = false;
                            }
                            else
                            {
                                _num++;
                            }
                        }
                    }
                }
                if (flag)
                {
                    _sBillCode = billCode;
                    //MessageBox.Show("Please press OK and wait for your ticket.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillPrint", billID, int.Parse(NailApp.BranchID));
                    DataSet dsData = new DataSet();
                    dsData.Tables.Add(dataTable);
                    if (dsData == null || dsData.Tables[0].Rows.Count == 0)
                    {
                        return;
                    }
                    frmPrintNew f = new frmPrintNew(dsData, "rpt_bill.rpt", false, int.Parse(NailApp.BranchID), billID);
                    f.ShowDialog();

                }
            }
            this.Close();
        }

        public int SendData()
        {
            return iResult;
        }

        public string SendBillCode()
        {
            return _sBillCode;
        }

        private void dgvService_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex == 2)
                //{
                //    e.CellStyle.Format = "N0";
                //}
                //if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
                //{
                //    e.CellStyle.Format = "N2";
                //}
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

        private void dgvService_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);
                ControlPaint.DrawCheckBox(e.Graphics, e.CellBounds.X + 1, e.CellBounds.Y + 1,
                    e.CellBounds.Width - 1, e.CellBounds.Height - 1,
                    (bool)e.FormattedValue ? ButtonState.Checked : ButtonState.Normal);
                e.Handled = true;
            }
        }

        private void dgvService_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Check
            {
                if ((bool)(dgvService.Rows[e.RowIndex].Cells["Check"].Value == null ? false : dgvService.Rows[e.RowIndex].Cells["Check"].Value) == true)
                {
                    //dgvService.Rows[e.RowIndex].Cells["Check"].Value = false;
                    dgvService.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    //dgvService.Rows[e.RowIndex].Cells["Check"].Value = true;
                    dgvService.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void dgvService_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvService_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Check
            {
                if ((bool)(dgvService.Rows[e.RowIndex].Cells["Check"].Value == null ? false : dgvService.Rows[e.RowIndex].Cells["Check"].Value) == true)
                {
                    //dgvService.Rows[e.RowIndex].Cells["Check"].Value = false;
                    dgvService.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    //dgvService.Rows[e.RowIndex].Cells["Check"].Value = true;
                    dgvService.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0) // Name
            {
                //Reference the GridView Row.
                DataGridViewRow row = dgvService.Rows[e.RowIndex];

                //Set the CheckBox selection.
                row.Cells["Check"].Value = !Convert.ToBoolean(row.Cells["Check"].EditedFormattedValue);
            }
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                if ((bool)(dgvService.Rows[e.RowIndex].Cells["Check"].Value == null ? false : dgvService.Rows[e.RowIndex].Cells["Check"].Value) == true)
                {
                    dgvService.Rows[e.RowIndex].Cells["Check"].Value = false;
                }
                else
                {
                    dgvService.Rows[e.RowIndex].Cells["Check"].Value = true;
                }
            }
        }
    }
}
