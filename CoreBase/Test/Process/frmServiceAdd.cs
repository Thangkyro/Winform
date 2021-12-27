using CoreBase;
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
    public partial class frmServiceAdd : Form
    {
        private int _branchID = 0;
        private int _userID = 0;
        private DataTable _dtService = null;
        private DataTable _dtStaff = null;
        private DataTable _Service = null;
        public delegate void DelSendMsg(string msg);
        private int iResult = 0;
        private int _num = 1;
        private DataTable _dtCustomer = null;

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
            dgvService.Columns["Quantity"].HeaderText = "Quantity";
            dgvService.Columns["Quantity"].Width = 75;
            dgvService.Columns["Price"].HeaderText = "Price";
            dgvService.Columns["Price"].Width = 70;
            dgvService.Columns["Amount"].HeaderText = "Amount";
            dgvService.Columns["Amount"].ReadOnly = true;
            dgvService.Columns["Amount"].Width = 120;
            dgvService.Columns["Amount"].Visible = false;

            DataGridViewCheckBoxColumn dataGridViewImange = new DataGridViewCheckBoxColumn();
            dataGridViewImange.Name = "Check";
            dataGridViewImange.HeaderText = "";
            dataGridViewImange.Width = 50;
            dgvService.Columns.Add(dataGridViewImange);

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

                for (int i = 0; i < dgvService.RowCount; i++)
                {
                    if ((bool)(dgvService.Rows[i].Cells["Check"].Value == null ? false : dgvService.Rows[i].Cells["Check"].Value) == true)
                    {
                        dgvService.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else
                    {
                        dgvService.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
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

        private bool checkExiestBill(int branchId, string phoneNumber)
        {
            try
            {
                _dtCustomer = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zCheckBillExists", branchId, phoneNumber, dtpDate.Value);
            }
            catch
            { }
            return !(_dtCustomer == null || _dtCustomer.Rows.Count == 0);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            // Check bill exist.
            if (txtPhoneNumber.Text.Trim() != "000" && checkExiestBill(_branchID, txtPhoneNumber.Text.Trim()))
            {
                MessageBox.Show("Sorry, Bill existed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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

                TimeSpan tm = DateTime.Now.TimeOfDay;
                DateTime billdate = NailApp.BillDate.Add(tm);
                if (dtpDate.Value.ToString("dd/MM/yyyy") != NailApp.BillDate.ToString("dd/MM/yyyy") && dtpDate.Value.ToString("dd/MM/yyyy") != DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    billdate = dtpDate.Value;
                }

                // Get bill number
                int billnumber = 1;
                DataTable dt1 = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillNumber", _branchID, billdate);
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
                    MessageBox.Show("Register sucessfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.DialogResult = DialogResult.OK;
                    //this.Visible = false;
                    //this.ShowInTaskbar = false;

                    //Get billID
                    //int billID = 0;
                    DataTable dtBill = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, "Select TOP 1 BillID From zBillMaster WITH(NOLOCK) Where BillCode = '" + billCode + "'");
                    if (dtBill != null && dtBill.Rows.Count > 0)
                    {
                        iResult = int.Parse(dtBill.Rows[0][0].ToString());
                        //frmMain frmM = new frmMain();
                        //frmM.LoadBillFormService(billID);
                        //SendMsg.Invoke(this, new LoadBillFormService());
                    }
                    //this.Close();
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
                if (e.ColumnIndex == 6 && e.RowIndex >= 0) 
                {
                    //Reference the GridView Row.
                    DataGridViewRow row = dgvService.Rows[e.RowIndex];

                    //Set the CheckBox selection.
                    row.Cells["Check"].Value = !Convert.ToBoolean(row.Cells["Check"].EditedFormattedValue);
                }
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

        private void frmServiceAdd_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now.AddHours(NailApp.TimeConfig);
        }
    }
}
