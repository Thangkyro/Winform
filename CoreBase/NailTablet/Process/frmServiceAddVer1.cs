using AltoControls;
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
    public partial class frmServiceAddVer1 : Form
    {
        private int _branchID = 0;
        private int _userID = 0;
        private DataTable _dtGroupService = null;
        private DataTable _dtService = null;
        private DataTable _dtStaff = null;
        public delegate void DelSendMsg(string msg);
        private int iResult = 0;
        private DataTable _dtSo = new DataTable();
        private DataTable _dtBillTemp = new DataTable();
        private int _num = 1;
        private string _sBillCode = "";

        //khạ báo biến kiểu delegate
        public DelSendMsg SendMsg;

        public frmServiceAddVer1()
        {
            InitializeComponent();
        }

        public frmServiceAddVer1(int branchId, int userId, string customerName, string phoneNumber)
        {
            InitializeComponent();
            _branchID = branchId;
            _userID = userId;
            txtName.Text = customerName;
            txtPhoneNumber.Text = phoneNumber;
            loadDTSO();
            loadDTBillTemp();
            loadService();
            LoadGrid(_dtService);
            LoadGridBillTemp(_dtBillTemp);
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

        private void loadDTBillTemp()
        {
            _dtBillTemp.Columns.Add("Price", typeof(decimal));
            _dtBillTemp.Columns.Add("STT", typeof(int));
            _dtBillTemp.Columns.Add("ServiceID", typeof(int));
            _dtBillTemp.Columns.Add("ServiceName", typeof(string));
            _dtBillTemp.Columns.Add("Quantity", typeof(int));
        }

        private void loadService()
        {
            try
            {
                _dtGroupService = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGroupServiceGetList_byBranch", _branchID);
                _dtService = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zServiceGetList_byBranch", _branchID);
                _dtStaff = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zStaffGetList_byBrabch", _branchID);
            }
            catch
            {
            }
        }

        private void LoadGrid( DataTable dataTable)
        {
            dgvService.DataSource = dataTable;
            dgvService.Columns["ServiceID"].Visible = false;
            dgvService.Columns["branchId"].Visible = false;
            dgvService.Columns["Title"].HeaderText = "Service Name";
            dgvService.Columns["Title"].ReadOnly = true;
            dgvService.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvService.Columns["Display"].Visible = false;
            dgvService.Columns["EstimateTime"].Visible = false;
            dgvService.Columns["GroupStt"].Visible = false;
            dgvService.Columns["Price"].Visible = false;
            dgvService.Columns["Decriptions"].Visible = false;
            dgvService.Columns["is_inactive"].Visible = false;
            dgvService.Columns["created_by"].Visible = false;
            dgvService.Columns["created_at"].Visible = false;
            dgvService.Columns["modified_by"].Visible = false;
            dgvService.Columns["modified_at"].Visible = false;
            


            dgvService.RowTemplate.Height = 60;
            dgvService.AutoGenerateColumns = false;
            dgvService.AllowUserToAddRows = false;
            dgvService.AllowUserToDeleteRows = false;
        }

        private void LoadGridBillTemp(DataTable dataTable)
        {
            dgvBillTem.DataSource = dataTable;
            dgvBillTem.Columns["Price"].Visible = false;
            dgvBillTem.Columns["STT"].Visible = false;
            dgvBillTem.Columns["ServiceID"].Visible = false;
            dgvBillTem.Columns["ServiceName"].HeaderText = "Service Name";
            dgvBillTem.Columns["ServiceName"].ReadOnly = true;
            dgvBillTem.Columns["ServiceName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBillTem.Columns["Quantity"].HeaderText = "QTy";
            dgvBillTem.Columns["Quantity"].Width = 70;
            DataGridViewButtonColumn delButton = new DataGridViewButtonColumn();
            delButton.Name = "delButton";
            //delButton.Text = "Delete";
            //delButton.UseColumnTextForButtonValue = true;
            delButton.HeaderText = "";
            int columnIndex = 5;
            if (dgvBillTem.Columns["delButton"] == null)
            {
                dgvBillTem.Columns.Insert(columnIndex, delButton);
            }


            dgvBillTem.RowTemplate.Height = 60;
            dgvBillTem.AutoGenerateColumns = false;
            dgvBillTem.AllowUserToAddRows = false;
            dgvBillTem.AllowUserToDeleteRows = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_dtBillTemp.Rows.Count > 0)
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

                for (int i = 0; i < _dtBillTemp.Rows.Count; i++)
                {
                    string CustomerPhone = txtPhoneNumber.Text.Trim();
                    int ServiceID = int.Parse(_dtBillTemp.Rows[i]["ServiceId"].ToString());
                    decimal Price = decimal.Parse(_dtBillTemp.Rows[i]["Price"].ToString());
                    string Note = "";
                    DateTime billdate = DateTime.Now.AddHours(NailApp.TimeConfig);
                    int error = 0;
                    string errorMesg = "";

                    int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillInsert_Ver1", billdate, _branchID, billCode, CustomerPhone, i + 1, ServiceID, 1, Price, StaffId, Note, _userID, billnumber, error, errorMesg);

                    if (ret == 0)
                    {
                        flag = false;
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
            else
            {
                MessageBox.Show("Please choose service for your ticket.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //this.Close();
        }

        public int SendData()
        {
            return iResult;
        }

        public string SendBillCode()
        {
            return _sBillCode;
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

        private void dgvService_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0) // Name
            {
                DataRow dr = _dtBillTemp.NewRow();
                dr["STT"] = _dtBillTemp.Rows.Count + 1;
                dr["ServiceID"] = dgvService.Rows[e.RowIndex].Cells["ServiceID"].Value.ToString();
                dr["ServiceName"] = dgvService.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                dr["Quantity"] = 1;
                dr["Price"] = dgvService.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                _dtBillTemp.Rows.Add(dr);
                LoadGridBillTemp(_dtBillTemp);
            }
        }

        private void loadGroupService()
        {
            // Load list group service

            // Add group in Pannel
            if (_dtGroupService != null && _dtGroupService.Rows.Count > 0)
            {
                for (int i = 0; i < _dtGroupService.Rows.Count; i++)
                {
                    AltoButton bt = new AltoButton();
                    bt.Name = _dtGroupService.Rows[i]["ServiceGroupID"].ToString();
                    bt.Text = _dtGroupService.Rows[i]["ServiceGroupName"].ToString();
                    bt.Width = 195;
                    bt.Height = 80;
                    bt.Active1 = Color.Cyan;
                    bt.Font = new Font("Constantia", 14, FontStyle.Bold);
                    bt.Location = new Point(3, i * 80);
                    bt.Click += new EventHandler(this.btnServiceGroup_Click);
                    flowLayoutPanel2.Controls.Add(bt);
                }
            }
            else
            {
                AltoButton bt = new AltoButton();
                bt.Name = "AllService";
                bt.Text = "All Service";
                bt.Width = 195;
                bt.Height = 80;
                bt.Active1 = Color.Cyan;
                bt.Font = new Font("Constantia", 14, FontStyle.Bold);
                bt.Location = new Point(3, 0);
                bt.Click += new EventHandler(this.btnServiceGroup_Click);
                flowLayoutPanel2.Controls.Add(bt);
            }
        }

        private void btnServiceGroup_Click(object sender, EventArgs e)
        {
            var button = (AltoButton)sender;
            if (button.Name == "AllService" )
            {
                LoadGrid(_dtService);
            }
            else
            {
                if (_dtService != null && _dtService.Rows.Count > 0)
                {
                    DataTable dataTable = _dtService.Select("GroupStt = '" + button.Name.ToString() + "'", "").CopyToDataTable();
                    LoadGrid(dataTable);
                }
            }
        }

        private void frmServiceAddVer1_Load(object sender, EventArgs e)
        {
            loadGroupService();
        }

        private void dgvBillTem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0) // Delete
            {
                string stt = dgvBillTem.Rows[e.RowIndex].Cells["STT"].Value.ToString();
                DataRow dr = _dtBillTemp.Select("STT = '" + stt + "'")[0];
                _dtBillTemp.Rows.Remove(dr);
                LoadGridBillTemp(_dtBillTemp);
            }
        }

        private void dgvBillTem_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.icons8_delete_50.Width;
                var h = Properties.Resources.icons8_delete_50.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.icons8_delete_50, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }
    }
}
