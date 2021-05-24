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
        DataTable _dtCustomer = null;
        DataTable _dtService = null;
        string _idBranchName = "branchId";
        string _idCustomerName = "CustId";
        string _idCustomerPhoneName1 = "PhoneNumber1";
        string _idCustomerPhoneName2 = "PhoneNumber2";
        string _tableNameCustomer = "zCustomer";
        public frmCheckin()
        {
            InitializeComponent();
            loadHolidaysList(_branchId);
            _dtService = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zServiceGetList_byBranch", _branchId);
        }

        public frmCheckin(int branchID)
        {
            InitializeComponent();
            _branchId = branchID;
            loadHolidaysList(_branchId);
            _dtService = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zServiceGetList_byBranch", _branchId);
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

        private bool checkExiestCustomer(string phoneNumber)
        {
            try
            {
                using (DictionaryDAL dal = new DictionaryDAL(_tableNameCustomer))
                {
                    // Check phone number 1
                    _dtCustomer = dal.GetData(_idCustomerPhoneName1, txtPhoneNumber.Text.Trim());
                    if (_dtCustomer == null || _dtCustomer.Rows.Count == 0)
                    {
                        // Check phone number 2
                        _dtCustomer = dal.GetData(_idCustomerPhoneName2, txtPhoneNumber.Text.Trim());
                    }
                }
            }
            catch 
            {
                
            }
            return !(_dtCustomer == null || _dtCustomer.Rows.Count == 0);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
             
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
                int customerid = int.Parse(_dtCustomer.Rows[0][_idCustomerName].ToString());
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBookingMasterGetList_byCustomer", customerid);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string infor = dr["BranchName"].ToString() + " - " + dr["BookingDate"].ToString() + " - " + dr["Status"].ToString();
                        TreeNode note = new TreeNode();
                        note.Text = infor;
                        note.Tag = dr["BookID"].ToString();
                        treHistory.Nodes.Add(note);
                    }
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

                if (ret == 1)
                {
                    // Check holidays of branch
                    checkHoliday(_branchId);
                    // Get list staft
                    loadStaftList(_branchId);
                    // Get list Service
                    loadServiceList(_branchId);

                    txt_B_Date.Focus();
                    btnCreate.Enabled = false;
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
        }

        private void btnEditBooking_Click(object sender, EventArgs e)
        {
            // Check holidays of branch
            checkHoliday(_branchId);
            // Get list staft
            loadStaftList(_branchId);
            // Get list Service
            loadServiceList(_branchId);
        }

        private void ClearnCustomerInfor()
        {
            txt_C_Name.Clear();
            txt_C_PhoneNumber.Clear();
            txt_C_Postcode.Clear();
            txt_C_DateofBirth.Value = DateTime.Now;
        }

        private void treHistory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                int bookingId = int.Parse(e.Node.Tag.ToString());               
                loadGridDetail(bookingId);
            }
            catch 
            {
            }
        }

        private void loadGridDetail(int bookingId)
        {
            gridRegister.DataSource = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBookingDetailGetList_History", bookingId, _branchId);
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
                cb_B_StaftName.ValueMember = "StaffCode";
                cb_B_StaftName.DisplayMember = "Display";
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
                gridHolidays.Columns["Names"].HeaderText = "Holiday Names";
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
            // Check dữ liệu đầu vào.
            checkDataInput();
            // Check free time of staff
            bool fCheck = checkFreetimeStaff(_branchId, int.Parse(cb_B_StaftName.Tag.ToString()), int.Parse(cb_B_ServiceName.Tag.ToString()));
            // Add dữ liệu vào lưới.
            if (fCheck)
            {
                MessageBox.Show("Staff have not free time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                addGridBooking();
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
            // Check customer - phone
            
            // Check Staff

            // Check service - quantity
        }

        private void addGridBooking()
        {
            throw new NotImplementedException();
        }
    }
}
