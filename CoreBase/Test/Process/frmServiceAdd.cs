﻿using CoreBase.DataAccessLayer;
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
            dgvService.Columns["EstimateTime"].Width = 100;
            dgvService.Columns["EstimateTime"].ReadOnly = true;
            dgvService.Columns["Quantity"].HeaderText = "Quantity";
            dgvService.Columns["Quantity"].Width = 100;
            dgvService.Columns["Price"].HeaderText = "Price";
            dgvService.Columns["Price"].Width = 100;
            dgvService.Columns["Amount"].HeaderText = "Amount";
            dgvService.Columns["Amount"].ReadOnly = true;
            dgvService.Columns["Amount"].Width = 120;

            DataGridViewCheckBoxColumn dataGridViewImange = new DataGridViewCheckBoxColumn();
            dataGridViewImange.Name = "Check";
            dataGridViewImange.HeaderText = "";
            dataGridViewImange.Width = 20;
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
                int StaffId = int.Parse(_dtStaff.Rows[0]["StaffId"].ToString());
                if (dt != null)
                {
                    billCode = dt.Rows[0][0].ToString();
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
