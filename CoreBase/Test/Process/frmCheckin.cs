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
    public partial class frmCheckin : Form
    {
        int _branchId = 2;
        int _UserId = 1;
        DataTable _dtCustomer = null;
        DataTable _dtService = null;
        string _idBranchName = "branchId";
        string _idCustomerName = "CustId";
        string _idCustomerPhoneName1 = "PhoneNumber1";
        string _idCustomerPhoneName2 = "PhoneNumber2";
        string _tableNameCustomer = "zCustomer";
        decimal _totalAmount = 0;
        int _bookingID = -1;
        public frmCheckin()
        {
            InitializeComponent();
            loadHolidaysList(_branchId);
            _dtService = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zServiceGetList_byBranch", _branchId);
            EnableBookingInfor(false);
        }

        public frmCheckin(int branchID, int userId)
        {
            InitializeComponent();
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
            cb_B_ServiceName.Enabled = bol;
            cb_B_ServiceName.Text = "";
            numSL.Enabled = bol;
            numSL.Value = 0;
            txt_B_note.Enabled = bol;
            txt_B_note.Text = "";
            btnAdd.Enabled = bol;
            gridRegister.Enabled = bol;
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
                treHistory.Nodes.Clear();
                int customerid = int.Parse(_dtCustomer.Rows[0][_idCustomerName].ToString());
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBookingMasterGetList_byCustomer", customerid);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        treHistory.ImageList = imageList1;
                        string infor = dr["BranchName"].ToString() + " - " + DateTime.Parse(dr["BookingDate"].ToString()).ToString("dd/MM/yyyy") + " - " + dr["Status"].ToString();
                        TreeNode note = new TreeNode();
                        note.Text = infor;
                        note.Tag = dr["BookID"].ToString();
                        treHistory.Nodes.Add(note);
                    }
                }
                else
                {
                    TreeNode note = new TreeNode();
                    note.Text = "No historical data.";
                    note.Tag = "-1";
                    treHistory.Nodes.Add(note);
                }
            }
            catch 
            {}
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
            {}
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
                int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zCustomerInsert", _branchId, CustomerCode, Name, Gender, PhoneNumber1, "", "", "", DateOfBirth, PostCode, 0, 0, "", 0, CreateBy, DateTime.Now.ToString(), CreateBy, DateTime.Now.ToString(),0,"");

                if (ret > 0)
                {
                    // Check holidays of branch
                    checkHoliday(_branchId);
                    // Get list staft
                    loadStaftList(_branchId);
                    // Get list Service
                    loadServiceList(_branchId);

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
            // Get list Service
            loadServiceList(_branchId);
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

        private void loadGridDetail(int bookingId)
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
                    object[] row = { num, staffName, servicename, quantity, price, Amount, note, serviceId, staffId };
                    gridRegister.Rows.Add(row);
                }
            }
            _totalAmount = decimal.Parse(dt.Compute("Sum(Amout)", string.Empty).ToString());
            lbl_R_Total.Text = string.Format("{0:#,##0.00}", _totalAmount);
            btnRegister.Text = "Pay";
        }

        private void loadServiceList(int branchId)
        {
            try
            {
                cb_B_ServiceName.DataSource = _dtService;
                cb_B_ServiceName.ValueMember = "ServiceID";
                cb_B_ServiceName.DisplayMember = "Display";
            }
            catch
            {
            }
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
                bool fCheck = checkFreetimeStaff(_branchId, int.Parse(cb_B_StaftName.SelectedValue.ToString()), int.Parse(cb_B_ServiceName.SelectedValue.ToString()));
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
            if (cb_B_ServiceName.Text.Trim() == "")
            {
                flag = true;
                cb_B_ServiceName.Focus();
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
                string servicetext = cb_B_ServiceName.Text;
                string servicename = servicetext.Substring(0, servicetext.IndexOf('-') -1);
                string staffName = cb_B_StaftName.Text;
                string staffId = cb_B_StaftName.SelectedValue.ToString();
                decimal price = decimal.Parse(servicetext.Substring(servicetext.LastIndexOf('-') + 2, servicetext.Length - servicetext.LastIndexOf('-') - 2));
                decimal quantity = numSL.Value;
                decimal Amount = price * quantity;
                string serviceId = cb_B_ServiceName.SelectedValue.ToString();
                string note = txt_B_note.Text.Trim();
                object[] row = { num, staffName, servicename, quantity, price, Amount, note, serviceId, staffId };
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
                    if (gridRegister.Rows.Count > 0)
                    {
                        bool flag = true;
                        for (int i = 0; i < gridRegister.Rows.Count; i++)
                        {
                            string CustomerPhone = txt_C_PhoneNumber.Text.Trim();
                            int Num = int.Parse(gridRegister.Rows[i].Cells["col_R_Num"].Value.ToString());
                            int ServiceID = int.Parse(gridRegister.Rows[i].Cells["col_R_ServiceId"].Value.ToString());
                            decimal Quantity = decimal.Parse(gridRegister.Rows[i].Cells["ColQuantity"].Value.ToString());
                            decimal Price = decimal.Parse(gridRegister.Rows[i].Cells["col_R_Price"].Value.ToString());
                            int StaffId = int.Parse(gridRegister.Rows[i].Cells["Col_R_StaffId"].Value.ToString());
                            string Note = gridRegister.Rows[i].Cells["Col_R_Note"].Value.ToString();
                            int error = 0;
                            string errorMesg = "";
                            int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBookingInsert", _branchId, CustomerPhone, Num, ServiceID, Quantity, Price, StaffId, Note, _UserId, error, errorMesg);

                            if (ret == 0)
                            {
                                flag = false;
                            }
                        }
                        if (flag)
                        {
                            MessageBox.Show("Register sucessfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnRegister.Text = "Pay";
                            EnableBookingInfor(false);
                        }
                    }
                }
                else if(btnRegister.Text == "Pay")
                {
                    // Get booking id send to form Pay.
                    DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBookingMasterGetId", txt_C_PhoneNumber.Text.Trim(), txt_B_Date.Value, _branchId);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        _bookingID = int.Parse(dt.Rows[0][0].ToString());
                        // Send total Amount.
                        frmPay prn = new frmPay(_branchId, _bookingID, _totalAmount, _UserId);
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
                int bookingId = int.Parse(treHistory.SelectedNode.Tag.ToString());
                string str = treHistory.SelectedNode.Text.ToString();
                string date = str.Substring(str.IndexOf('-') + 2, str.LastIndexOf('-') - str.IndexOf('-') - 3);
                txt_B_Date.Value = DateTime.Parse(date);
                loadGridDetail(bookingId);               
            }
            catch
            {
            }
        }

        private void treHistory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                int bookingId = int.Parse(treHistory.SelectedNode.Tag.ToString());
                string str = treHistory.SelectedNode.Text.ToString();
                string date = str.Substring(str.IndexOf('-') + 2, str.LastIndexOf('-') - str.IndexOf('-') - 3);
                txt_B_Date.Value = DateTime.Parse(date);
                loadGridDetail(bookingId);
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
    }
}
