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
            createTable();
            loadService();
            LoadGrid();
        }

        private void loadService()
        {
            try
            {
                _dtService = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zServiceGetList_byBranch", _branchID);
                _dtStaff = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zStaffGetList_byBrabch", _branchID);
            }
            catch 
            {
            }
        }

        private void dgvService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return;
                }
                else
                {
                    if (e.ColumnIndex == 5) //Delete 
                    {
                        dgvService.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void createTable()
        {
            _Service = new DataTable();
            _Service.Columns.Add("staffId", typeof(int));
            _Service.Columns.Add("serviceId", typeof(int));
            _Service.Columns.Add("Quantity", typeof(decimal));
            _Service.Columns.Add("Price", typeof(decimal));
            _Service.Columns.Add("Amount", typeof(decimal));
        }

        private void LoadGrid()
        {
            dgvService.DataSource = _Service;
            dgvService.Columns.Remove("staffId");
            DataGridViewComboBoxColumn dgvCmbStaff = new DataGridViewComboBoxColumn();
            dgvCmbStaff.DataPropertyName = "staffId";
            dgvCmbStaff.HeaderText = "Staff";
            dgvCmbStaff.Name = "staffId";
            dgvCmbStaff.DisplayMember = "Name";
            dgvCmbStaff.ValueMember = "staffId";
            dgvCmbStaff.DataSource = _dtStaff;
            dgvCmbStaff.Width = 180;
            dgvService.Columns.Add(dgvCmbStaff);
            dgvService.Columns["staffId"].DisplayIndex = 0;

            dgvService.Columns.Remove("serviceId");
            DataGridViewComboBoxColumn dgvCmbService = new DataGridViewComboBoxColumn();
            dgvCmbService.DataPropertyName = "serviceId";
            dgvCmbService.HeaderText = "Service";
            dgvCmbService.Name = "serviceId";
            dgvCmbService.DisplayMember = "Title";
            dgvCmbService.ValueMember = "serviceId";
            dgvCmbService.DataSource = _dtService;
            dgvCmbService.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvService.Columns.Add(dgvCmbService);
            dgvService.Columns["serviceId"].DisplayIndex = 0;

            dgvService.Columns["Quantity"].HeaderText = "Quantity";
            dgvService.Columns["Quantity"].Width = 100;
            dgvService.Columns["Price"].HeaderText = "Price";
            dgvService.Columns["Price"].Width = 100;
            dgvService.Columns["Amount"].HeaderText = "Amount";
            dgvService.Columns["Amount"].ReadOnly = true;
            dgvService.Columns["Amount"].Width = 120;

            DataGridViewImageColumn dataGridViewImange = new DataGridViewImageColumn();
            dataGridViewImange.Name = "Del";
            dataGridViewImange.HeaderText = "";
            dataGridViewImange.Width = 20;
            dataGridViewImange.Image = Properties.Resources.cancel;
            dgvService.Columns.Add(dataGridViewImange);

            dgvService.AutoGenerateColumns = false;
        }

        private void dgvService_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && (e.ColumnIndex == 0 || e.ColumnIndex == 1))
                {
                    decimal Quantity = decimal.Parse(dgvService.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                    decimal Price = decimal.Parse(dgvService.Rows[e.RowIndex].Cells["Price"].Value.ToString());
                    // Update row num
                    dgvService.Rows[e.RowIndex].Cells["Amount"].Value = Quantity * Price;
                }
                if (e.RowIndex > -1 && (e.ColumnIndex == 4))
                {
                    string serviceId = dgvService.Rows[e.RowIndex].Cells["serviceId"].Value.ToString();
                    decimal Price = decimal.Parse(_dtService.Select("serviceId = " + serviceId,"")[0]["Price"].ToString());
                    dgvService.Rows[e.RowIndex].Cells["Price"].Value = Price;
                    decimal Quantity = decimal.Parse(dgvService.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
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
                if (dt != null)
                {
                    billCode = dt.Rows[0][0].ToString();
                }
                for (int i = 0; i < dgvService.Rows.Count; i++)
                {
                    if (dgvService.Rows[i].Cells["ServiceId"].Value != null)
                    {
                        string CustomerPhone = txtPhoneNumber.Text.Trim();
                        int Num = i + 1;
                        int ServiceID = int.Parse(dgvService.Rows[i].Cells["ServiceId"].Value.ToString());
                        decimal Quantity = decimal.Parse(dgvService.Rows[i].Cells["Quantity"].Value.ToString());
                        decimal Price = decimal.Parse(dgvService.Rows[i].Cells["Price"].Value.ToString());
                        int StaffId = int.Parse(dgvService.Rows[i].Cells["StaffId"].Value.ToString());
                        string Note = "";
                        DateTime billdate = DateTime.Parse(DateTime.Now.ToShortDateString());
                        int error = 0;
                        string errorMesg = "";

                        int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillInsert_Ver1", billdate, _branchID, billCode, CustomerPhone, Num, ServiceID, Quantity, Price, StaffId, Note, _userID, error, errorMesg);

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
                }
            }
        }
    }
}
