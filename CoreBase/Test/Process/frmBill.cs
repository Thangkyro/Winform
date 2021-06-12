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

namespace AusNail.Process
{
    public partial class frmBill : Form
    {
        int _branchId = 2;
        int _UserId = 1;
        string _fromID = "";
        DataTable _dtCustomer = null;
        DataTable _dtService = null;
        string _idBranchName = "branchId";
        string _idCustomerName = "CustId";
        string _idCustomerPhoneName1 = "PhoneNumber1";
        string _idCustomerPhoneName2 = "PhoneNumber2";
        string _tableNameCustomer = "zCustomer";
        decimal _totalAmount = 0;
        int _serviceId = 0;
        int _bookingID = -1;
        int _billID = -1;
        public frmBill()
        {
            InitializeComponent();
            dgv_B_Service.Visible = false;
            loadHolidaysList(_branchId);
            _dtService = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zServiceGetList_byBranch", _branchId);
            EnableBookingInfor(false);
        }

        public frmBill(int branchID, int userId)
        {
            InitializeComponent();
            dgv_B_Service.Visible = false;
            _branchId = branchID;
            _UserId = userId;
            loadHolidaysList(_branchId);
            _dtService = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zServiceGetList_byBranch", _branchId);
            EnableBookingInfor(false);
        }

        /// <summary>
        /// Component 
        /// </summary>
        /// <param name="branchID"></param>
        /// <param name="userId"></param>
        /// <param name="FormId"> Bill -  Form bill; Book - From Booking</param>
        public frmBill(int branchID, int userId, string FormId)
        {
            InitializeComponent();
            dgv_B_Service.Visible = false;
            _fromID = FormId;
            if (_fromID == "Bill")
            {
                this.Text = "Form Bill";
                btnEditBooking.Text = "Edit Bill";
            }
            if (_fromID == "Book")
            {
                this.Text = "Form Checking";
                btnEditBooking.Text = "Edit Booking";
            }
            _branchId = branchID;
            _UserId = userId;
            loadHolidaysList(_branchId);
            _dtService = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zServiceGetList_byBranch", _branchId);
            EnableBookingInfor(false);
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và các thao tác xóa, tiến lùi... Không nhập text.
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

            // Sự kiện bấm Enter
            if (e.KeyChar == 13)
            {
                btnCheck_Click(sender, e);
            }
        }
        private void LoadTabCustomerInfor()
        {
            DataRow dr = _dtCustomer.Rows[0];
            txt_C_PhoneNumber.Text = dr["PhoneNumber1"].ToString();
            txt_C_Name.Text = dr["Name"].ToString();
            cboGender.Text = dr["Gender"].ToString();
            txt_C_DateofBirth.Text = dr["DateOfBirth"].ToString();
            txt_C_Postcode.Text = dr["PostCode"].ToString();
        }

        private void EnableBookingInfor(bool bol)
        {
            txt_B_Date.Enabled = bol;
            cb_B_StaftName.Enabled = bol;
            cb_B_StaftName.Text = "";
            txt_B_Service.Enabled = bol;
            txt_B_Service.Text = "";
            numSL.Enabled = bol;
            numSL.Value = 0;
            txt_B_note.Enabled = bol;
            txt_B_note.Text = "";
            btnAdd.Enabled = bol;
            txt_B_Discount.Text = "0";
            txt_B_Discount.Enabled = bol;
            gridRegister.Enabled = bol;
            dgv_B_Service.Visible = false;
        }

        private bool checkExiestCustomer(string phoneNumber)
        {
            try
            {
                _dtCustomer = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zCustomerGetbyPhoneNum", txtPhoneNumber.Text.Trim());
            }
            catch
            {

            }
            return !(_dtCustomer == null || _dtCustomer.Rows.Count == 0);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text.Trim() == "")
            {
                MessageBox.Show("Please input phone number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                EnableBookingInfor(false);
                // Kiểm tra tính hợp lệ của số điện thoại
                ClearnCustomerInfor();
                if (checkExiestCustomer(txtPhoneNumber.Text.Trim()))
                {
                    zCustomerGetList();
                }
                else
                {
                    // Send data phone number qua ben tab customer infor.
                    txt_C_PhoneNumber.Text = txtPhoneNumber.Text;
                    // Hien nut Create and Register, An nut Edit Bocking
                    btnCreate.Enabled = true;
                    btnEditBooking.Enabled = false;
                    txt_C_Name.Focus();
                    treHistoryBook.Nodes.Clear();
                    TreeNode note = new TreeNode();
                    note.Text = "No historical data.";
                    note.Tag = "-1";
                    treHistoryBook.Nodes.Add(note);
                }
                txtPhoneNumber.Clear();
                txt_B_Date.Text = DateTime.Now.ToString();
                gridRegister.Rows.Clear();
            }
        }

        private void zCustomerGetList()
        {
            // Load thong tin => Dua du lieu vao tab customer infor.
            LoadTabCustomerInfor();
            // Load thong tin boking xuong detail
            LoadHistory();
            // An nut Create and Register, Hien nut Edit Bocking
            btnCreate.Enabled = false;
            btnEditBooking.Enabled = true;
        }

        private void LoadHistory()
        {
            try
            {
                treHistoryBook.Nodes.Clear();
                int customerid = int.Parse(_dtCustomer.Rows[0][_idCustomerName].ToString());
                DataTable dt = null;
                // Load booking
                dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBookingMasterGetList_byCustomer", customerid);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        treHistoryBook.ImageList = imageList1;
                        string infor = dr["BranchName"].ToString() + " - " + DateTime.Parse(dr["BookingDate"].ToString()).ToString("dd/MM/yyyy") + " - " + dr["Status"].ToString();
                        TreeNode note = new TreeNode();
                        note.Text = infor;
                        note.Tag = dr["BookID"].ToString();
                        treHistoryBook.Nodes.Add(note);
                    }
                }
                else
                {
                    TreeNode note = new TreeNode();
                    note.Text = "No historical data.";
                    note.Tag = "-1";
                    treHistoryBook.Nodes.Add(note);
                }

                // Load temporary bill
                dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillMasterGetList_byCustomer", customerid);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        trHistoryBill.ImageList = imageList1;
                        string infor = dr["BranchName"].ToString() + " - " + DateTime.Parse(dr["BillDate"].ToString()).ToString("dd/MM/yyyy") + " - " + dr["Status"].ToString();
                        TreeNode note = new TreeNode();
                        note.Text = infor;
                        note.Tag = dr["BillID"].ToString();
                        trHistoryBill.Nodes.Add(note);
                    }
                }
                else
                {
                    TreeNode note = new TreeNode();
                    note.Text = "No historical data.";
                    note.Tag = "-1";
                    trHistoryBill.Nodes.Add(note);
                }

            }
            catch
            { }
        }

        private string GenCustomerCode()
        {
            string customerCode = "";
            try
            {
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGetNewCode", _tableNameCustomer, "CR", _idCustomerName, 8);
                if (dt != null)
                {
                    customerCode = dt.Rows[0][0].ToString();
                }
            }
            catch
            { }
            return customerCode;
        }

        private void zCustomerInsert()
        {
            try
            {
                string PhoneNumber1 = this.txt_C_PhoneNumber.Text.Trim();
                string Name = this.txt_C_Name.Text.Trim();
                string Gender = this.cboGender.Text.Trim();
                string DateOfBirth = this.txt_C_DateofBirth.Text.Trim();
                string PostCode = this.txt_C_Postcode.Text.Trim();
                string CustomerCode = GenCustomerCode();
                int CreateBy = 0;
                // kiem tra khong được đặt mã trùng
                int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zCustomerInsert", _branchId, CustomerCode, Name, Gender, PhoneNumber1, "", "", "", DateOfBirth, PostCode, 0, 0, "", 0, CreateBy, DateTime.Now.ToString(), CreateBy, DateTime.Now.ToString(), 0, "");

                if (ret > 0)
                {
                    // Check holidays of branch
                    checkHoliday(_branchId);
                    // Get list staft
                    loadStaftList(_branchId);

                    txt_B_Date.Focus();
                    btnCreate.Enabled = false;
                    EnableBookingInfor(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            zCustomerInsert();
            btnRegister.Text = "Save";
        }

        private void btnEditBooking_Click(object sender, EventArgs e)
        {
            // Check holidays of branch
            checkHoliday(_branchId);
            // Get list staft
            loadStaftList(_branchId);
            EnableBookingInfor(true);
            btnRegister.Text = "Save";
        }

        private void ClearnCustomerInfor()
        {
            txt_C_Name.Clear();
            txt_C_PhoneNumber.Clear();
            txt_C_Postcode.Clear();
            txt_C_DateofBirth.Value = DateTime.Now;
        }

        private void loadGridDetail_Booking(int bookingId)
        {
            gridRegister.Rows.Clear();
            DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBookingDetailGetList_History", bookingId, _branchId);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int num = i + 1;
                    string servicename = dt.Rows[i]["ServiceName"].ToString();
                    string staffName = dt.Rows[i]["StaffName"].ToString();
                    string staffId = dt.Rows[i]["StaffId"].ToString();
                    decimal price = decimal.Parse(dt.Rows[i]["Price"].ToString());
                    decimal quantity = decimal.Parse(dt.Rows[i]["Quantity"].ToString());
                    decimal Amount = decimal.Parse(dt.Rows[i]["Amout"].ToString());
                    string serviceId = dt.Rows[i]["ServiceID"].ToString();
                    string note = dt.Rows[i]["Note"].ToString();
                    decimal discount = 0;
                    object[] row = { num, staffName, servicename, quantity, price, Amount, discount, note, serviceId, staffId };
                    gridRegister.Rows.Add(row);
                }
            }
            _totalAmount = decimal.Parse(dt.Compute("Sum(Amout)", string.Empty).ToString());
            lbl_R_Total.Text = string.Format("{0:#,##0.00}", _totalAmount);
            btnRegister.Text = "Pay";
        }

        private void loadGridDetail_Bill(int billId)
        {
            gridRegister.Rows.Clear();
            DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillDetailGetList_History", billId, _branchId);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int num = i + 1;
                    string servicename = dt.Rows[i]["ServiceName"].ToString();
                    string staffName = dt.Rows[i]["StaffName"].ToString();
                    string staffId = dt.Rows[i]["StaffId"].ToString();
                    decimal price = decimal.Parse(dt.Rows[i]["Price"].ToString());
                    decimal quantity = decimal.Parse(dt.Rows[i]["Quantity"].ToString());
                    decimal Amount = decimal.Parse(dt.Rows[i]["Amout"].ToString());
                    string serviceId = dt.Rows[i]["ServiceID"].ToString();
                    string note = dt.Rows[i]["Note"].ToString();
                    decimal discount = decimal.Parse(dt.Rows[i]["Discount"].ToString());
                    object[] row = { num, staffName, servicename, quantity, price, Amount, discount, note, serviceId, staffId };
                    gridRegister.Rows.Add(row);
                }
            }
            _totalAmount = decimal.Parse(dt.Compute("Sum(Amout)", string.Empty).ToString());
            lbl_R_Total.Text = string.Format("{0:#,##0.00}", _totalAmount);
            btnRegister.Text = "Pay";
        }

        private void loadStaftList(int branchId)
        {
            try
            {
                cb_B_StaftName.DataSource = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zStaffGetList_byBrabch", _branchId);
                cb_B_StaftName.ValueMember = "StaffId";
                cb_B_StaftName.DisplayMember = "Name";
            }
            catch
            {
            }
        }

        private void checkHoliday(int branchId)
        {
            DateTime time = txt_B_Date.Value;
            foreach (DataRow dr in MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zHolidaysGetList", 0).Select(string.Format("{0} = {1}", _idBranchName, _branchId)))
            {
                if (time > DateTime.Parse(dr["HolidaysFrom"].ToString()) && time < DateTime.Parse(dr["HolidaysTo"].ToString()))
                {
                    MessageBox.Show("Current day is holiday. Please choose another date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void loadHolidaysList(int branchId)
        {
            try
            {
                gridHolidays.DataSource = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zHolidaysGetList", 0).Select(string.Format("{0} = {1}", _idBranchName, _branchId)).CopyToDataTable();
                gridHolidays.Columns["branchId"].Visible = false;
                gridHolidays.Columns["Names"].HeaderText = "Holiday";
                gridHolidays.Columns["Names"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                gridHolidays.Columns["Names"].ReadOnly = true;
                gridHolidays.Columns["HolidaysFrom"].HeaderText = "Holidays From";
                gridHolidays.Columns["HolidaysFrom"].ReadOnly = true;
                gridHolidays.Columns["HolidaysTo"].HeaderText = "Holidays To";
                gridHolidays.Columns["HolidaysTo"].ReadOnly = true;
                gridHolidays.Columns["Decriptions"].Visible = false;
                gridHolidays.Columns["is_inactive"].Visible = false;
                gridHolidays.Columns["created_by"].Visible = false;
                gridHolidays.Columns["created_at"].Visible = false;
                gridHolidays.Columns["modified_by"].Visible = false;
                gridHolidays.Columns["modified_at"].Visible = false;
            }
            catch
            {
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Check dữ liệu đầu vào.
                checkDataInput();
                // Check free time of staff
                bool fCheck = checkFreetimeStaff(_branchId, int.Parse(cb_B_StaftName.SelectedValue.ToString()), _serviceId);
                // Add dữ liệu vào lưới.
                if (fCheck)
                {
                    MessageBox.Show("Staff have not free time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    addGridBooking();

                    _totalAmount = 0;
                    for (int i = 0; i < gridRegister.Rows.Count; i++)
                    {
                        _totalAmount += decimal.Parse(gridRegister.Rows[i].Cells["col_R_Amount"].Value.ToString());
                    }
                    lbl_R_Total.Text = string.Format("{0:#,##0.00}", _totalAmount);
                    txt_B_note.Clear();
                    txt_B_Service.Clear();
                    numSL.Value = 0;
                    dgv_B_Service.Visible = false;
                    txt_B_Service.Focus();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private bool checkFreetimeStaff(int branchId, int staffId, int serviceId)
        {
            bool flag = false;
            DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zStaffCheckFreeTime", branchId, staffId, serviceId);
            if (dt != null)
            {
                flag = (dt.Rows[0][0].ToString() == "1");
            }
            return flag;
        }

        private void checkDataInput()
        {
            bool flag = false;
            // Check customer - phone
            if (txt_C_PhoneNumber.Text.Trim() == "")
            {
                flag = true;
                txt_C_PhoneNumber.Focus();
            }
            // Check Staff
            if (cb_B_StaftName.Text.Trim() == "")
            {
                flag = true;
                cb_B_StaftName.Focus();
            }
            // Check service - quantity
            if (txt_B_Service.Text.Trim() == "")
            {
                flag = true;
                txt_B_Service.Focus();
            }
            if (numSL.Value < 1)
            {
                flag = true;
                numSL.Focus();
            }
            if (flag)
            {
                MessageBox.Show("Please check data input.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void addGridBooking()
        {
            try
            {
                int num = gridRegister.Rows.Count + 1;
                string servicetext = txt_B_Service.Text;
                string servicename = servicetext.Substring(0, servicetext.IndexOf('-') - 1);
                string staffName = cb_B_StaftName.Text;
                string staffId = cb_B_StaftName.SelectedValue.ToString();
                decimal price = decimal.Parse(servicetext.Substring(servicetext.LastIndexOf('-') + 2, servicetext.Length - servicetext.LastIndexOf('-') - 2));
                decimal quantity = numSL.Value;
                decimal Amount = price * quantity;
                string serviceId = _serviceId.ToString();
                string note = txt_B_note.Text.Trim();
                decimal discount = decimal.Parse(txt_B_Discount.Text.Trim());
                object[] row = { num, staffName, servicename, quantity, price, Amount, discount, note, serviceId, staffId };
                // Check service exiests.
                for (int i = 0; i < gridRegister.Rows.Count; i++)
                {
                    if (gridRegister.Rows[i].Cells["col_R_ServiceId"].Value.ToString() == serviceId.ToString())
                    {
                        DialogResult dialogResult = MessageBox.Show("Service exists, update it now?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //Update quantity and Amount, staff infor
                            gridRegister.Rows[i].Cells["ColQuantity"].Value = quantity;
                            gridRegister.Rows[i].Cells["col_R_Amount"].Value = Amount;
                            gridRegister.Rows[i].Cells["Col_R_StaffName"].Value = staffName;
                            gridRegister.Rows[i].Cells["Col_R_StaffId"].Value = staffId;
                            gridRegister.Rows[i].Cells["Col_R_Note"].Value = note;
                            gridRegister.Rows[i].Cells["col_B_Discount"].Value = discount;
                            return;
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
                gridRegister.Rows.Add(row);
            }
            catch
            {
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnRegister.Text == "Save")
                {
                    if (_bookingID != -1 || (_bookingID == -1 && _billID == -1)) // insert mới
                    {
                        SaveBillbyBook(_bookingID, "");
                    }
                    if (_billID != -1) // update
                    {
                        int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillDetailDelete_Ver1", _billID, _branchId, 0, "");
                        SaveBill(_billID, "");
                    }
                    EnableBookingInfor(false);
                    LoadHistory();
                }
                else if (btnRegister.Text == "Pay")
                {
                    // Get booking id send to form Pay.
                    DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBookingMasterGetId", txt_C_PhoneNumber.Text.Trim(), txt_B_Date.Value, _branchId);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        _bookingID = int.Parse(dt.Rows[0][0].ToString());
                        // Send total Amount.
                        frmPay prn = new frmPay(_branchId, _bookingID, _billID, _totalAmount, _UserId);
                        prn.Show();
                    }
                    else
                    {
                        MessageBox.Show("Bill paid.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch
            {

            }
        }
        private void SaveBill(int billId, string voucherCode)
        {
            try
            {
                int error = 0;
                string errorMesg = "";
                bool flag = true;

                for (int i = 0; i < gridRegister.Rows.Count; i++)
                {
                    int Num = int.Parse(gridRegister.Rows[i].Cells["col_R_Num"].Value.ToString());
                    int ServiceID = int.Parse(gridRegister.Rows[i].Cells["col_R_ServiceId"].Value.ToString());
                    decimal Quantity = decimal.Parse(gridRegister.Rows[i].Cells["ColQuantity"].Value.ToString());
                    decimal Price = decimal.Parse(gridRegister.Rows[i].Cells["col_R_Price"].Value.ToString());
                    int StaffId = int.Parse(gridRegister.Rows[i].Cells["Col_R_StaffId"].Value.ToString());
                    decimal discount = decimal.Parse(gridRegister.Rows[i].Cells["co_B_Discount"].Value.ToString());
                    int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillDetailInsert_Ver1", _billID, _branchId, Num, ServiceID, Quantity, Price, discount, StaffId, _UserId, "", error, errorMesg);
                    if (ret == 0)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    MessageBox.Show("Bill Sucessfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    // call store dell bii moiws tao
                    MessageBox.Show("Bill Error.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                // call store dell bii moiws tao
                MessageBox.Show("Bill Error.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        private void SaveBillbyBook(int bookingid, string voucherCode)
        {
            try
            {
                int outBill = -1;
                int error = 0;
                string errorMesg = "";
                bool flag = true;
                string CustomerPhone = txt_C_PhoneNumber.Text.Trim();
                // Get billCode
                string billCode = "";
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGetNewCode", "zBillMaster", "BL", "BillID", 8);
                if (dt != null)
                {
                    billCode = dt.Rows[0][0].ToString();
                }
                int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillMasterInsert_Ver1", DateTime.Now, _branchId, billCode, CustomerPhone,_bookingID, voucherCode, _UserId, outBill, error, errorMesg);
                if (ret > 0)
                {
                    //get new id
                    dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillMasterGetId_Ver1", _branchId, billCode, error, errorMesg);
                    if (dt != null)
                    {
                        outBill = int.Parse(dt.Rows[0][0].ToString());
                    }
                    for (int i = 0; i < gridRegister.Rows.Count; i++)
                    {
                        int Num = int.Parse(gridRegister.Rows[i].Cells["col_R_Num"].Value.ToString());
                        int ServiceID = int.Parse(gridRegister.Rows[i].Cells["col_R_ServiceId"].Value.ToString());
                        decimal Quantity = decimal.Parse(gridRegister.Rows[i].Cells["ColQuantity"].Value.ToString());
                        decimal Price = decimal.Parse(gridRegister.Rows[i].Cells["col_R_Price"].Value.ToString());
                        int StaffId = int.Parse(gridRegister.Rows[i].Cells["Col_R_StaffId"].Value.ToString());
                        decimal discount = decimal.Parse(gridRegister.Rows[i].Cells["co_B_Discount"].Value.ToString());
                        ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillDetailInsert_Ver1", outBill, _branchId, Num, ServiceID, Quantity, Price, discount, StaffId, _UserId, error, errorMesg);
                        if (ret == 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                else
                {
                    flag = false;
                }
                if (flag)
                {
                    MessageBox.Show("Bill Sucessfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    // call store dell bii moiws tao
                    MessageBox.Show("Bill Error.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    gridRegister.Rows.Clear();
                    lbl_R_Total.Text = "0";
                }
            }
            catch (Exception ex)
            {
                // call store dell bii moiws tao
                MessageBox.Show("Bill Error.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void gridRegister_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                _totalAmount = 0;
                // Update row num
                for (int i = 0; i < gridRegister.Rows.Count; i++)
                {
                    //Update quantity and Amount
                    gridRegister.Rows[i].Cells["col_R_Num"].Value = i + 1;
                    _totalAmount += decimal.Parse(gridRegister.Rows[i].Cells["col_R_Amount"].Value.ToString());
                }
                lbl_R_Total.Text = string.Format("{0:#,##0.00}", _totalAmount);
            }
            catch
            {
            }
        }

        private void treHistory_Click(object sender, EventArgs e)
        {
            try
            {
                _billID = -1;
                _bookingID = int.Parse(treHistoryBook.SelectedNode.Tag.ToString());
                string str = treHistoryBook.SelectedNode.Text.ToString();
                string date = str.Substring(str.IndexOf('-') + 2, str.LastIndexOf('-') - str.IndexOf('-') - 3);
                txt_B_Date.Value = new DateTime(int.Parse(date.Substring(6, 4)), int.Parse(date.Substring(3, 2)), int.Parse(date.Substring(0, 2)));
                loadGridDetail_Booking(_bookingID);
            }
            catch
            {
            }
        }

        private void treHistory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                _billID = -1;
                _bookingID = int.Parse(treHistoryBook.SelectedNode.Tag.ToString());
                string str = treHistoryBook.SelectedNode.Text.ToString();
                string date = str.Substring(str.IndexOf('-') + 2, str.LastIndexOf('-') - str.IndexOf('-') - 3);
                txt_B_Date.Value = new DateTime(int.Parse(date.Substring(6, 4)), int.Parse(date.Substring(3, 2)), int.Parse(date.Substring(0, 2)));
                loadGridDetail_Booking(_bookingID);
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPrint prn = new frmPrint();
            prn.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridRegister_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 3)
            {
                decimal Quantity = decimal.Parse(gridRegister.Rows[e.RowIndex].Cells["ColQuantity"].Value.ToString());
                decimal Price = decimal.Parse(gridRegister.Rows[e.RowIndex].Cells["col_R_Price"].Value.ToString());
                // Update row num
                gridRegister.Rows[e.RowIndex].Cells["col_R_Amount"].Value = Quantity * Price;

                _totalAmount = 0;
                for (int i = 0; i < gridRegister.Rows.Count; i++)
                {
                    _totalAmount += decimal.Parse(gridRegister.Rows[i].Cells["col_R_Amount"].Value.ToString());
                }
                lbl_R_Total.Text = string.Format("{0:#,##0.00}", _totalAmount);
            }

        }

        private void txt_B_Service_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgv_B_Service.DataSource = _dtService.Select("Title like '%" + txt_B_Service.Text.Trim() + "%'", "").CopyToDataTable();
                dgv_B_Service.Columns["ServiceId"].Visible = false;
                dgv_B_Service.Columns["BranchId"].Visible = false;
                dgv_B_Service.Columns["Title"].HeaderText = "Service Name";
                dgv_B_Service.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv_B_Service.Columns["Title"].ReadOnly = true;
                dgv_B_Service.Columns["Display"].Visible = false;
                dgv_B_Service.Columns["Price"].HeaderText = "Price";
                dgv_B_Service.Columns["Price"].ReadOnly = true;
                dgv_B_Service.Columns["EstimateTime"].HeaderText = "Estimate Time";
                dgv_B_Service.Columns["EstimateTime"].ReadOnly = true;
                dgv_B_Service.Columns["Decriptions"].Visible = false;
                dgv_B_Service.Columns["is_inactive"].Visible = false;
                dgv_B_Service.Columns["created_by"].Visible = false;
                dgv_B_Service.Columns["created_at"].Visible = false;
                dgv_B_Service.Columns["modified_by"].Visible = false;
                dgv_B_Service.Columns["modified_at"].Visible = false;
                dgv_B_Service.Visible = true;
            }
            catch
            {
                dgv_B_Service.DataSource = null;
            }
            
        }

        private void dgv_B_Service_DoubleClick(object sender, EventArgs e)
            {
            try
            {
                _serviceId = int.Parse(dgv_B_Service.Rows[dgv_B_Service.CurrentRow.Index].Cells["ServiceId"].Value.ToString());
                txt_B_Service.Text = dgv_B_Service.Rows[dgv_B_Service.CurrentRow.Index].Cells["Display"].Value.ToString();
                dgv_B_Service.Visible = false;
            }
            catch
            {
            }
        }

        private void dgv_B_Service_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    _serviceId = int.Parse(dgv_B_Service.Rows[dgv_B_Service.CurrentRow.Index].Cells["ServiceId"].Value.ToString());
                    txt_B_Service.Text = dgv_B_Service.Rows[dgv_B_Service.CurrentRow.Index].Cells["Display"].Value.ToString();
                    dgv_B_Service.Visible = false; 
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void txt_B_Service_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgv_B_Service.Select();
            }
            if (e.KeyCode == Keys.F5)
            {
                txt_B_Service_TextChanged(sender, e);
            }
        }

        private void trHistoryBill_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                _bookingID = -1;
                _billID = int.Parse(trHistoryBill.SelectedNode.Tag.ToString());
                string str = trHistoryBill.SelectedNode.Text.ToString();
                string date = str.Substring(str.IndexOf('-') + 2, str.LastIndexOf('-') - str.IndexOf('-') - 3);
                txt_B_Date.Value = new DateTime(int.Parse(date.Substring(6, 4)), int.Parse(date.Substring(3, 2)), int.Parse(date.Substring(0, 2)));
                loadGridDetail_Bill(_billID);
            }
            catch (Exception ex)
            {
            }
        }

        private void trHistoryBill_Click(object sender, EventArgs e)
        {
            try
            {
                _bookingID = -1;
                _billID = int.Parse(trHistoryBill.SelectedNode.Tag.ToString());
                string str = trHistoryBill.SelectedNode.Text.ToString();
                string date = str.Substring(str.IndexOf('-') + 2, str.LastIndexOf('-') - str.IndexOf('-') - 3);
                txt_B_Date.Value = new DateTime(int.Parse(date.Substring(6, 4)), int.Parse(date.Substring(3, 2)), int.Parse(date.Substring(0, 2)));
                loadGridDetail_Bill(_billID);
            }
            catch
            {
            }
        }
    }
}