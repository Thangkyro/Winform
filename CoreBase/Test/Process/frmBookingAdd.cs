using AltoControls;
using CoreBase;
using CoreBase.DataAccessLayer;
using CoreBase.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AusNail.Process
{
    public partial class frmBookingAdd : Form
    {
        private int _branchID = 0;
        private int _userID = 0;
        private int _bookID = 0;
        private DataTable _dtService = null;
        private DataTable _dtStaff = null;
        private DataTable _Service = null;
        private DataTable _dtBookingMaster = null;
        private DataTable _dtBookingDetail = null;
        private int iResult = 0;
        private string _action = "";
        private DateTime _dateChoose;
        private string _shortDes = "";

        private DataTable _dtSo = new DataTable();
        private DataTable _dtBillTemp = new DataTable();
        private DataTable _dtGroupService = null;

        public frmBookingAdd()
        {
            InitializeComponent();
        }

        public frmBookingAdd(int branchId, string customerName, string phoneNumber, int bookID, string action, DateTime? dateChoose)
        {
            InitializeComponent();
            this.BackColor = NailApp.ColorUser.IsEmpty == true || NailApp.ColorUser.Name == "0" ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
            try
            {
                panel1.BackColor = NailApp.ColorUser;
                panel2.BackColor = NailApp.ColorUser;
            }
            catch
            {
            }
            _bookID = bookID;
            _branchID = branchId;
            _userID = NailApp.CurrentUserId;
            txtName.Text = customerName;
            txtPhoneNumber.Text = phoneNumber;
            //_dateChoose = dateChoose ?? DateTime.Now;
            if (dateChoose.HasValue)
            {
                DateTime dt;
                DateTime.TryParseExact(dateChoose.Value.ToString("dd/MM/yyyy") + " " + DateTime.Now.AddHours(NailApp.TimeConfig).ToString("HH:mm"), "dd/MM/yyyy HH:mm",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out dt);

                dtpBookingDate.Value = dt;
                _dateChoose = dt;

            }
            LoadMaster();

            loadDTBillTemp();
            loadService();

            LoadGrid(_dtService);
            LoadGridBillTemp(_dtBillTemp);
            lblHeader.Text = action + " Booking";
            _action = action;
            if (action == "ReBook") // Nếu là ReBook thì sau khi load lại data theo ID cũ thì set lại = 0 đẻ Add New
            {
                _bookID = 0;
                //dtpBookingDate.Value = DateTime.MinValue;
                DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
                dtpBookingDate.Value = dt;
                dtBookingTime.Value = dt;
                dtpBookingDate.Select();
            }
            else if (action == "Edit")
            {
                dtBookingTime.Select();
            }
            else if (action == "Add")
            {
                DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00,00,00);
                dtBookingTime.Value = dt;
                dtBookingTime.Select();
            }
            //dtpBookingDate.Select();

            loadGroupService();
        }

        #region Method

        private void loadDTBillTemp()
        {
            _dtBillTemp.Columns.Add("Price", typeof(decimal));
            _dtBillTemp.Columns.Add("STT", typeof(int));
            _dtBillTemp.Columns.Add("ServiceID", typeof(int));
            _dtBillTemp.Columns.Add("ServiceName", typeof(string));
            _dtBillTemp.Columns.Add("Quantity", typeof(int));
            _dtBillTemp.Columns.Add("ShortDecriptions", typeof(string));
            _dtBillTemp.Columns.Add("Note", typeof(string));


            //Check if bookID != 0 then load detail from bookingdetail for grid
            if (_bookID != 0 && _dtBookingDetail != null && _dtBookingDetail.Rows.Count > 0)
            {
                foreach (DataRow item in _dtBookingDetail.Rows)
                {
                    //int ServiceID = int.Parse(item["ServiceId"].ToString());
                    //DataRow dr = _dtBookingDetail.Select(string.Format("ServiceId = {0}", ServiceID)).Count() == 1 ? _dtBookingDetail.Select(string.Format("ServiceId = {0}", ServiceID))[0] : null;
                    //if (dr != null)
                    //{
                    //decimal amount = decimal.Parse(item["Quantity"].ToString()) * decimal.Parse(item["EstimatePrice"].ToString());
                    DataRow dr = _dtBillTemp.NewRow();
                    dr["Price"] = item["EstimatePrice"].ToString();
                    dr["STT"] = item["OrderNumber"].ToString();
                    dr["ServiceID"] = item["ServiceID"].ToString();
                    dr["ServiceName"] = item["Title"].ToString();
                    dr["Quantity"] = item["Quantity"].ToString();
                    dr["ShortDecriptions"] = item["ShortDecriptions"].ToString();
                    dr["Note"] = item["Note"].ToString();
                    _dtBillTemp.Rows.Add(dr);
                    //}
                }
            }
        }

        private void LoadMaster()
        {
            if (_bookID != 0)
            {
                _dtBookingMaster = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBookingMaster_byBookID", _bookID);
                if (_dtBookingMaster != null && _dtBookingMaster.Rows.Count > 0)
                {
                    txtName.Text = _dtBookingMaster.Rows[0]["Name"].ToString();
                    txtPhoneNumber.Text = _dtBookingMaster.Rows[0]["CustomerPhone"].ToString();
                    lblTotalAmont.Text = string.Format("{0:#,##0.00}", decimal.Parse(_dtBookingMaster.Rows[0]["TotalEstimatePrice"].ToString()));
                    dtpBookingDate.Value = DateTime.Parse(_dtBookingMaster.Rows[0]["BookingDate"].ToString());
                    dtBookingTime.Value = DateTime.Parse(_dtBookingMaster.Rows[0]["BookingDate"].ToString());
                    txtDes.Text = _dtBookingMaster.Rows[0]["Decriptions"].ToString();
                    txtShortDes.Text = _dtBookingMaster.Rows[0]["ShortDecriptions"].ToString();
                    _shortDes = txtShortDes.Text;
                    //dtpBookingDate.Enabled = false;
                    _dtBookingDetail = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBookingDetail_byBookID", _bookID);
                }

                //Load dtDetail
            }
        }
        private void loadService()
        {
            try
            {
                _dtGroupService = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGroupServiceGetList_byBranch", _branchID);
                _dtService = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zServiceGetList_byBranch_Booking", _branchID);
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadGrid(DataTable dataTable)
        {
            try
            {

                dgvService1.DataSource = dataTable;
                dgvService1.Columns["ServiceID"].Visible = false;
                dgvService1.Columns["branchId"].Visible = false;
                dgvService1.Columns["Display"].Visible = false;
                dgvService1.Columns["EstimateTime"].Visible = false;
                dgvService1.Columns["GroupStt"].Visible = false;
                dgvService1.Columns["Price"].Visible = false;


                dgvService1.Columns["Title"].HeaderText = "Service Name";
                dgvService1.Columns["Title"].ReadOnly = true;
                dgvService1.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvService1.Columns["ShortDecriptions"].HeaderText = "Short Des";
                dgvService1.Columns["ShortDecriptions"].ReadOnly = true;
                dgvService1.Columns["ShortDecriptions"].Width = 70;
                //dgvService1.Columns["ShortDecriptions"].Visible = false;

                dgvService1.Columns["Quantity"].HeaderText = "Qty";
                dgvService1.Columns["Quantity"].Width = 50;
                dgvService1.Columns["Quantity"].ReadOnly = false;

                dgvService1.AutoGenerateColumns = false;
                dgvService1.AllowUserToAddRows = false;
                dgvService1.AllowUserToDeleteRows = false;

            }
            catch (Exception ex)
            {

            }

        }

        private void LoadGridBillTemp(DataTable dataTable)
        {
            dgvBillTem.DataSource = dataTable;
            dgvBillTem.Columns["Price"].Visible = false;
            dgvBillTem.Columns["STT"].Visible = false;
            dgvBillTem.Columns["ServiceID"].Visible = false;
            dgvBillTem.Columns["ShortDecriptions"].Visible = false;
            dgvBillTem.Columns["ServiceName"].HeaderText = "Service Name";
            dgvBillTem.Columns["ServiceName"].ReadOnly = true;
            dgvBillTem.Columns["ServiceName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBillTem.Columns["Quantity"].HeaderText = "QTy";
            dgvBillTem.Columns["Quantity"].Width = 50;
            dgvBillTem.Columns["Note"].HeaderText = "Note";
            dgvBillTem.Columns["Note"].Width = 50;
            DataGridViewButtonColumn delButton = new DataGridViewButtonColumn();
            delButton.Name = "delButton";
            //delButton.Text = "Delete";
            //delButton.UseColumnTextForButtonValue = true;
            delButton.HeaderText = "";
            delButton.Width = 50;
            int columnIndex = 7;
            if (dgvBillTem.Columns["delButton"] == null)
            {
                dgvBillTem.Columns.Insert(columnIndex, delButton);
            }


            dgvBillTem.RowTemplate.Height = 30;
            dgvBillTem.AutoGenerateColumns = false;
            dgvBillTem.AllowUserToAddRows = false;
            dgvBillTem.AllowUserToDeleteRows = false;

            caculateAmount();
            ShortDes();
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
                    bt.Width = 160;
                    bt.Height = 70;
                    bt.Active1 = Color.Cyan;
                    bt.Font = new Font("Constantia", 14, FontStyle.Bold);
                    bt.Location = new Point(3, i * 80);
                    bt.Click += new EventHandler(this.btnServiceGroup_Click);
                    flowLayoutPanel2.Controls.Add(bt);
                    if (_dtService != null && _dtService.Rows.Count > 0)
                    {
                        DataTable dataTable = _dtService.Select("GroupStt = '" + _dtGroupService.Rows[0]["ServiceGroupID"].ToString() + "'", "").CopyToDataTable();
                        LoadGrid(dataTable);
                    }
                }
            }
            else
            {
                AltoButton bt = new AltoButton();
                bt.Name = "AllService";
                bt.Text = "All Service";
                bt.Width = 160;
                bt.Height = 70;
                bt.Active1 = Color.Cyan;
                bt.Font = new Font("Constantia", 14, FontStyle.Bold);
                bt.Location = new Point(3, 0);
                bt.Click += new EventHandler(this.btnServiceGroup_Click);
                flowLayoutPanel2.Controls.Add(bt);
            }
        }

        public int SendData()
        {
            return iResult;
        }

        private void caculateAmount()
        {
            try
            {
                decimal _totalAmount = 0;
                for (int i = 0; i < dgvBillTem.Rows.Count; i++)
                {
                    if (dgvBillTem.Rows[i].Cells["serviceId"].Value != null && dgvBillTem.Rows[i].Cells["serviceId"].Value.ToString() != ""
                        /*&& (bool)(dgvBillTem.Rows[i].Cells["Check"].Value == null ? false : dgvBillTem.Rows[i].Cells["Check"].Value) == true*/)
                    {
                        _totalAmount += (decimal.Parse(dgvBillTem.Rows[i].Cells["Quantity"].Value.ToString()) * decimal.Parse(dgvBillTem.Rows[i].Cells["Price"].Value.ToString()));
                    }
                }
                lblTotalAmont.Text = string.Format("{0:#,##0.00}", _totalAmount);
            }
            catch
            {
            }
        }

        private void ShortDes()
        {
            try
            {
                string _shortD = string.Empty;
                List<string> lstCheck = new List<string>();
                for (int i = 0; i < dgvBillTem.Rows.Count; i++)
                {
                    if (!lstCheck.Contains(dgvBillTem.Rows[i].Cells["serviceId"].Value.ToString()))
                    {
                        DataRow[] rows;
                        rows = _dtBillTemp.Select("serviceId = " + dgvBillTem.Rows[i].Cells["serviceId"].Value.ToString());

                        //if (dgvBillTem.Rows[i].Cells["serviceId"].Value != null && dgvBillTem.Rows[i].Cells["serviceId"].Value.ToString() != "")
                        //    //&& (bool)(dgvService.Rows[i].Cells["Check"].Value == null ? false : dgvService.Rows[i].Cells["Check"].Value) == true)
                        //{
                        if (rows.Length > 1)
                        {
                            int qty = _dtBillTemp.Compute("Sum(Quantity)", "serviceId = " + dgvBillTem.Rows[i].Cells["serviceId"].Value.ToString()) != DBNull.Value ? Convert.ToInt32(_dtBillTemp.Compute("Sum(Quantity)", "serviceId = " + dgvBillTem.Rows[i].Cells["serviceId"].Value.ToString())) : 0;
                            _shortD = string.Concat(_shortD, " - ", string.Concat(qty.ToString(), "x", dgvBillTem.Rows[i].Cells["ShortDecriptions"].Value.ToString()));

                            lstCheck.Add(dgvBillTem.Rows[i].Cells["serviceId"].Value.ToString());
                        }
                        else
                        {
                            
                            _shortD = string.Concat(_shortD, " - ", string.Concat(dgvBillTem.Rows[i].Cells["Quantity"].Value.zToInt().ToString(), "x", dgvBillTem.Rows[i].Cells["ShortDecriptions"].Value.ToString()));
                        }
                    }
                   
                        
                    //}
                }

                if (!string.IsNullOrEmpty(_shortD))
                {
                    _shortDes = _shortD.Remove(0, 3);
                }
                else
                {
                    _shortDes = _shortD;
                }
                txtShortDes.Text = _shortDes;
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Event

        private void btnServiceGroup_Click(object sender, EventArgs e)
        {
            var button = (AltoButton)sender;
            if (button.Name == "AllService")
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


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtBook;

                DateTime.TryParseExact((dtpBookingDate.Value.ToString("dd/MM/yyyy") + " " + dtBookingTime.Value.ToString("HH:mm")), "dd/MM/yyyy HH:mm",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out dtBook);

                if (dtBookingTime.Value.ToString("HH:mm") == "00:00")
                {
                    MessageBox.Show("Time booking invaild !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtBookingTime.Focus();
                    return;
                }

                if (dtBook == DateTime.MinValue)
                {
                    MessageBox.Show("Date booking invaild !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpBookingDate.Focus();
                    return;
                }

                if (dtBook == null || dtBook <= DateTime.Now.AddHours(NailApp.TimeConfig))
                {
                    MessageBox.Show("Date booking cannot empty or less than current date !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpBookingDate.Focus();
                    return;
                }
                else if (dtBook.Year == 0001)
                {
                    MessageBox.Show("Date booking invaild !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpBookingDate.Focus();
                    return;
                }
                if (dgvBillTem.Rows.Count > 0)
                {
                    string descriptions = txtDes.Text.Trim();
                    int error = 0;
                    string errorMesg = "";
                    bool flag = true;

                    //Check exists 10 booking on this hour with phone number
                    //Check exists
                    DataTable dtCheckExists10Book = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBookingMaster_CheckExistsBooking", _branchID, dtBook, error, errorMesg);
                    if (dtCheckExists10Book != null && dtCheckExists10Book.Rows.Count > 0)
                    {
                        MessageBox.Show("10 bookings exist for this hour: " + dtBook.ToString("HH"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }


                    if (_bookID != 0) //Edit
                    {
                        //Delete detail
                        int retDelete = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBookingDetailDeleteByBookID", _bookID, _branchID, error, errorMesg);
                        if (retDelete > 0)
                        {
                            int k = 0;
                            for (int i = 0; i < dgvBillTem.Rows.Count; i++)
                            {
                                //if ((bool)(dgvService.Rows[i].Cells["Check"].Value == DBNull.Value ? false : dgvService.Rows[i].Cells["Check"].Value) == true)
                                //{
                                    string CustomerPhone = txtPhoneNumber.Text.Trim();
                                    int Num = k + 1;
                                    k++;
                                    int ServiceID = int.Parse(dgvBillTem.Rows[i].Cells["ServiceId"].Value.ToString());
                                    decimal Quantity = decimal.Parse(dgvBillTem.Rows[i].Cells["Quantity"].Value.ToString());
                                    decimal Price = decimal.Parse(dgvBillTem.Rows[i].Cells["Price"].Value.ToString());
                                    string Note = dgvBillTem.Rows[i].Cells["Note"].Value.ToString();

                                    
                                    int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBookingInsert_Ver1", _bookID, dtBook, _branchID, CustomerPhone, Num, ServiceID, Quantity, Price, Note, _userID, 1, descriptions, _shortDes, error, errorMesg);

                                    if (ret == 0)
                                    {
                                        flag = false;
                                    }
                                //}
                            }

                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    else //Add
                    {
                        //Check exists
                        DataTable dtCheckExistsBook = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBookingMaster_CheckByDate", _branchID, "Temporary", txtPhoneNumber.Text.Trim(), dtBook, error, errorMesg);
                        if (dtCheckExistsBook != null && dtCheckExistsBook.Rows.Count > 0)
                        {
                            MessageBox.Show("Exists Booking of Customer Phone at: " + dtBook.ToString("dd/MM/yyyy HH:mm"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        int isCheck = 0;
                        int j = 0;
                        for (int i = 0; i < dgvBillTem.Rows.Count; i++)
                        {
                            //if ((bool)(dgvService.Rows[i].Cells["Check"].Value == DBNull.Value ? false : dgvService.Rows[i].Cells["Check"].Value) == true)
                            //{
                                string CustomerPhone = txtPhoneNumber.Text.Trim();
                                int Num = j + 1;
                                j++;
                                int ServiceID = int.Parse(dgvBillTem.Rows[i].Cells["ServiceId"].Value.ToString());
                                decimal Quantity = decimal.Parse(dgvBillTem.Rows[i].Cells["Quantity"].Value.ToString());
                                decimal Price = decimal.Parse(dgvBillTem.Rows[i].Cells["Price"].Value.ToString());
                                string Note = dgvBillTem.Rows[i].Cells["Note"].Value.ToString();


                                int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBookingInsert_Ver1", _bookID, dtBook, _branchID, CustomerPhone, Num, ServiceID, Quantity, Price, Note, _userID, isCheck, descriptions, _shortDes, error, errorMesg);

                                if (ret == 0)
                                {
                                    flag = false;
                                }
                                else
                                {
                                    isCheck = 1;
                                }
                            //}
                        }
                    }

                    if (flag)
                    {
                        MessageBox.Show(_action + " Booking sucessfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        iResult = 1;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("There was an error in processing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void dgvService_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex == 2)
                //{
                //    e.CellStyle.Format = "N0";
                //}
                //if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
                //{
                //    e.CellStyle.Format = "N2";
                //}

                //if (_bookID != 0 && _dtBookingDetail != null && _dtBookingDetail.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dgvService.Rows.Count; i++)
                //    {
                //        int ServiceID = int.Parse(dgvService.Rows[i].Cells["ServiceId"].Value.ToString());
                //        DataRow dr = _dtBookingDetail.Select(string.Format("ServiceId = {0}", ServiceID)).Count() == 1 ? _dtBookingDetail.Select(string.Format("ServiceId = {0}", ServiceID))[0] : null;
                //        if (dr != null)
                //        {
                //            //dgvService.Rows[i].Cells["Check"].Value = true;
                //            dgvService.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                //        }
                //        else
                //        {
                //            //dgvService.Rows[e.RowIndex].Cells["Check"].Value = true;
                //            dgvService.Rows[i].DefaultCellStyle.BackColor = Color.White;
                //        }
                //    }
                //}
            }
            catch
            {
            }
        }

        #endregion

        private void dgvService_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            //    {
            //        DataGridView dgv = (DataGridView)sender;
            //        if (dgv.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            //        {
            //            e.PaintBackground(e.CellBounds, true);
            //            ControlPaint.DrawCheckBox(e.Graphics, e.CellBounds.X + 1, e.CellBounds.Y + 1,
            //                e.CellBounds.Width - 2, e.CellBounds.Height - 2,
            //                (bool)e.FormattedValue ? ButtonState.Checked : ButtonState.Normal);
            //            e.Handled = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void dgvService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    var senderGrid = (DataGridView)sender;
            //    string headerText = senderGrid.Columns[e.ColumnIndex].Name;
            //    //We make DataGridCheckBoxColumn commit changes with single click
            //    //use index of logout column
            //    if (senderGrid.Columns["Check"] is DataGridViewCheckBoxColumn && headerText == "Check")
            //        //if (e.ColumnIndex == 10 && e.RowIndex >= 0)
            //        //this.dgvService.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //    caculateAmount();
            //    ShortDes();
            //    ////Check the value of cell
            //    //if ((bool)this.dgvService.CurrentCell.Value == true)
            //    //{

            //    //}
            //    //else
            //    //{

            //    //}
            //}
            //catch (Exception)
            //{
            //}

        }

        #region Define Datagridview NumericUpDown
        public class NumericUpDownColumn : DataGridViewColumn
        {
            public NumericUpDownColumn()
                : base(new NumericUpDownCell(1, 1000))
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

        private void dgvService1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0) // Name
            {
                DataRow dr = _dtBillTemp.NewRow();
                int minLavel = _dtBillTemp.Compute("max([STT])", string.Empty) != DBNull.Value ? Convert.ToInt32(_dtBillTemp.Compute("max([STT])", string.Empty)) : 0;
                dr["STT"] = ++minLavel;
                dr["ServiceID"] = dgvService1.Rows[e.RowIndex].Cells["ServiceID"].Value.ToString();
                dr["ServiceName"] = dgvService1.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                dr["Quantity"] = 1;
                dr["Price"] = dgvService1.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                dr["ShortDecriptions"] = dgvService1.Rows[e.RowIndex].Cells["ShortDecriptions"].Value.ToString();
                dr["Note"] = "";
                _dtBillTemp.Rows.Add(dr);
                LoadGridBillTemp(_dtBillTemp);
            }
        }

        private void dgvBillTem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex >= 0) // Delete
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
            if (e.ColumnIndex == 7)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.DeleteRow1.Width;
                var h = Properties.Resources.DeleteRow1.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.DeleteRow1, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvBillTem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4 && e.RowIndex >= 0) // change quantity
                {
                    string stt = dgvBillTem.Rows[e.RowIndex].Cells["STT"].Value.ToString();
                    string Quantity = dgvBillTem.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
                    foreach (DataRow item in _dtBillTemp.Rows)
                    {
                        if (item["STT"].ToString() == stt)
                        {
                            item["Quantity"] = Quantity;
                            break;
                        }
                    }
                    //DataRow dr = _dtBillTemp.Select("STT = '" + stt + "'")[0];
                    //_dtBillTemp.Rows.Remove(dr);
                    LoadGridBillTemp(_dtBillTemp);

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dtpBookingDate_Leave(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
                dtBookingTime.Value = dt;
                dtBookingTime.Select();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
