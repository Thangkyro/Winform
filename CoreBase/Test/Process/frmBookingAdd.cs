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
            loadService();
            LoadGrid();
            lblHeader.Text = action + " Booking";
            _action = action;
            dtpBookingDate.Focus();
            //dtpBookingDate.Select();

        }

        #region Method
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
                _dtService = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zServiceGetList_byBranch_Booking", _branchID);
                if (_dtService != null)
                {
                    _Service = _dtService.Copy();
                    //_Service.DefaultView.Sort = "Title";
                    _Service.Columns.Remove("branchId");
                    _Service.Columns.Remove("Display");
                    _Service.Columns.Remove("Decriptions");
                    _Service.Columns.Remove("is_inactive");
                    _Service.Columns.Remove("created_by");
                    _Service.Columns.Remove("created_at");
                    _Service.Columns.Remove("modified_by");
                    _Service.Columns.Remove("modified_at");
                    _Service.Columns.Remove("GroupStt");
                    _Service.Columns.Add("Quantity", typeof(decimal));
                    _Service.Columns.Add("Amount", typeof(decimal));
                    _Service.Columns.Add("OrderNumber", typeof(int));
                    _Service.Columns.Add("Note", typeof(string));
                    _Service.Columns.Add("Check", typeof(bool));
                    foreach (DataRow dr in _Service.Rows)
                    {
                        dr["OrderNumber"] = 0;
                        dr["Note"] = "";
                        dr["Quantity"] = 1;
                        dr["Check"] = false;
                        dr["Amount"] = decimal.Parse(dr["Quantity"].ToString()) * decimal.Parse(dr["Price"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadGrid()
        {
            try
            {
                //Check if bookID != 0 then load detail from bookingdetail for grid
                if (_bookID != 0 && _dtBookingDetail != null && _dtBookingDetail.Rows.Count > 0)
                {
                    foreach (DataRow item in _Service.Rows)
                    {
                        int ServiceID = int.Parse(item["ServiceId"].ToString());
                        DataRow dr = _dtBookingDetail.Select(string.Format("ServiceId = {0}", ServiceID)).Count() == 1 ? _dtBookingDetail.Select(string.Format("ServiceId = {0}", ServiceID))[0] : null;
                        if (dr != null)
                        {
                            decimal amount = decimal.Parse(dr["Quantity"].ToString()) * decimal.Parse(dr["EstimatePrice"].ToString());
                            item["OrderNumber"] = dr["OrderNumber"].ToString();
                            item["Quantity"] = dr["Quantity"].ToString();
                            item["Amount"] = amount.ToString();
                            item["Note"] = dr["Note"].ToString();
                            item["Check"] = true;
                            //dgvService.Rows[i].DefaultCellStyle.BackColor = Color.Cyan;
                        }
                    }
                }
                dgvService.DataSource = _Service;
                dgvService.Columns["ServiceID"].Visible = false;
                dgvService.Columns["OrderNumber"].Visible = false;
                dgvService.Columns["ServiceGroupName"].HeaderText = "Service Group";
                dgvService.Columns["ServiceGroupName"].ReadOnly = true;
                dgvService.Columns["ServiceGroupName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvService.Columns["Title"].HeaderText = "Service Name";
                dgvService.Columns["Title"].ReadOnly = true;
                dgvService.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvService.Columns["ShortDecriptions"].HeaderText = "Short Des";
                dgvService.Columns["ShortDecriptions"].ReadOnly = true;
                dgvService.Columns["ShortDecriptions"].Width = 80;
                dgvService.Columns["EstimateTime"].HeaderText = "Estimate Time";
                dgvService.Columns["EstimateTime"].Width = 75;
                dgvService.Columns["EstimateTime"].ReadOnly = true;
                dgvService.Columns["Quantity"].HeaderText = "Qty";
                dgvService.Columns["Quantity"].Width = 50;
                dgvService.Columns["Quantity"].ReadOnly = false;
                dgvService.Columns["Price"].HeaderText = "Price";
                dgvService.Columns["Price"].Width = 70;
                dgvService.Columns["Price"].ReadOnly = true;
                dgvService.Columns["Amount"].HeaderText = "Amount";
                dgvService.Columns["Amount"].Visible = false;
                dgvService.Columns["Amount"].Width = 120;
                dgvService.Columns["Note"].HeaderText = "Note";
                dgvService.Columns["Note"].Width = 50;

                DataGridViewCheckBoxColumn dataGridViewImange = new DataGridViewCheckBoxColumn();
                dataGridViewImange.Name = "Check";
                dataGridViewImange.HeaderText = "Choose";
                dataGridViewImange.Width = 20;
                //dataGridViewImange.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                var dgvC = dgvService.Columns["Check"];
                if (dgvC == null)
                {
                    dgvService.Columns.Add(dataGridViewImange);
                }

                dgvService.AutoGenerateColumns = false;
                dgvService.AllowUserToAddRows = false;
                dgvService.AllowUserToDeleteRows = false;

                //Check if bookID != 0 then load detail from bookingdetail for grid
                //if (_bookID != 0 && _dtBookingDetail != null && _dtBookingDetail.Rows.Count > 0)
                //{
                //    //for (int i = 0; i < dgvService.Rows.Count; i++)
                //    //{
                //    //    int ServiceID = int.Parse(dgvService.Rows[i].Cells["ServiceId"].Value.ToString());
                //    //    DataRow dr = _dtBookingDetail.Select(string.Format("ServiceId = {0}", ServiceID)).Count() == 1 ? _dtBookingDetail.Select(string.Format("ServiceId = {0}", ServiceID))[0] : null;
                //    //    if (dr != null)
                //    //    {
                //    //        dgvService.Rows[i].Cells["Check"].Value = true;
                //    //        dgvService.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                //    //    }
                //    //}
                //    //caculateAmount();
                //    //dgvService_Click(new object(), new EventArgs());
                //}
            }
            catch (Exception ex)
            {

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
                for (int i = 0; i < dgvService.Rows.Count; i++)
                {
                    if (dgvService.Rows[i].Cells["serviceId"].Value != null && dgvService.Rows[i].Cells["serviceId"].Value.ToString() != ""
                        && (bool)(dgvService.Rows[i].Cells["Check"].Value == null ? false : dgvService.Rows[i].Cells["Check"].Value) == true)
                    {
                        _totalAmount += decimal.Parse(dgvService.Rows[i].Cells["Amount"].Value.ToString());
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
                for (int i = 0; i < dgvService.Rows.Count; i++)
                {
                    if (dgvService.Rows[i].Cells["serviceId"].Value != null && dgvService.Rows[i].Cells["serviceId"].Value.ToString() != ""
                        && (bool)(dgvService.Rows[i].Cells["Check"].Value == null ? false : dgvService.Rows[i].Cells["Check"].Value) == true)
                    {
                        _shortD = string.Concat(_shortD, " - ", string.Concat(dgvService.Rows[i].Cells["Quantity"].Value.ToString(), "x",dgvService.Rows[i].Cells["ShortDecriptions"].Value.ToString()));
                    }
                }

                if (!string.IsNullOrEmpty(_shortD))
                {
                    _shortDes = _shortD.Remove(0, 3);
                }
                txtShortDes.Text = _shortDes;
            }
            catch
            {
            }
        }

        #endregion

        #region Event
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

                DataGridViewCheckBoxCell chkchecking = dgvService.Rows[e.RowIndex].Cells["Check"] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(chkchecking.Value) == true)
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
            try
            {
                //DialogResult dialogResult;
                //if (_action == "Add")
                //{
                //    dialogResult = MessageBox.Show("Are you confirm ?", "Create Booking", MessageBoxButtons.YesNo);
                //}
                //else
                //{
                //    dialogResult = MessageBox.Show("Are you confirm ?", "Edit Booking", MessageBoxButtons.YesNo);
                //}
                ////dialogResult = MessageBox.Show("Are you confirm ?", "Create Booking", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{
                DateTime dtBook;

                DateTime.TryParseExact((dtpBookingDate.Value.ToString("dd/MM/yyyy") + " " + dtBookingTime.Value.ToString("HH:mm")), "dd/MM/yyyy HH:mm",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out dtBook);

                if (dtBook == null || dtBook <= DateTime.Now.AddHours(NailApp.TimeConfig))
                {
                    MessageBox.Show("Date booking cannot empty or less than current date !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (dtBook.Year == 0001)
                {
                    MessageBox.Show("Date booking invaild !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dgvService.Rows.Count > 0)
                {
                    string descriptions = txtDes.Text.Trim();
                    int error = 0;
                    string errorMesg = "";
                    bool flag = true;
                    if (_bookID != 0) //Edit
                    {
                        //Delete detail
                        int retDelete = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBookingDetailDeleteByBookID", _bookID, _branchID, error, errorMesg);
                        if (retDelete > 0)
                        {
                            int k = 0;
                            for (int i = 0; i < dgvService.Rows.Count; i++)
                            {
                                if ((bool)(dgvService.Rows[i].Cells["Check"].Value == DBNull.Value ? false : dgvService.Rows[i].Cells["Check"].Value) == true)
                                {
                                    string CustomerPhone = txtPhoneNumber.Text.Trim();
                                    int Num = k + 1;
                                    k++;
                                    int ServiceID = int.Parse(dgvService.Rows[i].Cells["ServiceId"].Value.ToString());
                                    decimal Quantity = decimal.Parse(dgvService.Rows[i].Cells["Quantity"].Value.ToString());
                                    decimal Price = decimal.Parse(dgvService.Rows[i].Cells["Price"].Value.ToString());
                                    string Note = dgvService.Rows[i].Cells["Note"].Value.ToString();


                                    int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBookingInsert_Ver1", _bookID, dtBook, _branchID, CustomerPhone, Num, ServiceID, Quantity, Price, Note, _userID, 1, descriptions, _shortDes, error, errorMesg);

                                    if (ret == 0)
                                    {
                                        flag = false;
                                    }
                                }
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
                        for (int i = 0; i < dgvService.Rows.Count; i++)
                        {
                            if ((bool)(dgvService.Rows[i].Cells["Check"].Value == DBNull.Value ? false : dgvService.Rows[i].Cells["Check"].Value) == true)
                            {
                                string CustomerPhone = txtPhoneNumber.Text.Trim();
                                int Num = j + 1;
                                j++;
                                int ServiceID = int.Parse(dgvService.Rows[i].Cells["ServiceId"].Value.ToString());
                                decimal Quantity = decimal.Parse(dgvService.Rows[i].Cells["Quantity"].Value.ToString());
                                decimal Price = decimal.Parse(dgvService.Rows[i].Cells["Price"].Value.ToString());
                                string Note = dgvService.Rows[i].Cells["Note"].Value.ToString();


                                int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBookingInsert_Ver1", _bookID, dtBook, _branchID, CustomerPhone, Num, ServiceID, Quantity, Price, Note, _userID, isCheck, descriptions, _shortDes, error, errorMesg);

                                if (ret == 0)
                                {
                                    flag = false;
                                }
                                else
                                {
                                    isCheck = 1;
                                }
                            }
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

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    var senderGrid = (DataGridView)sender;
            //    string headerText = senderGrid.Columns[e.ColumnIndex].Name;
            //    if (senderGrid.Columns["Check"] is DataGridViewCheckBoxColumn && headerText == "Check")
            //    {
            //        //DataGridViewCheckBoxCell chkchecking = dgvService.Rows[e.RowIndex].Cells["Check"] as DataGridViewCheckBoxCell;
            //        //if (Convert.ToBoolean(chkchecking.Value) == true)
            //        //{
            //        //    //dgvService.Rows[e.RowIndex].Cells["Check"].Value = false;
            //        //    dgvService.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            //        //}
            //        //else
            //        //{
            //        //    //dgvService.Rows[e.RowIndex].Cells["Check"].Value = true;
            //        //    dgvService.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            //        //}
            //        caculateAmount();
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
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

                if (_bookID != 0 && _dtBookingDetail != null && _dtBookingDetail.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvService.Rows.Count; i++)
                    {
                        int ServiceID = int.Parse(dgvService.Rows[i].Cells["ServiceId"].Value.ToString());
                        DataRow dr = _dtBookingDetail.Select(string.Format("ServiceId = {0}", ServiceID)).Count() == 1 ? _dtBookingDetail.Select(string.Format("ServiceId = {0}", ServiceID))[0] : null;
                        if (dr != null)
                        {
                            //dgvService.Rows[i].Cells["Check"].Value = true;
                            dgvService.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        #endregion

        private void dgvService_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridView dgv = (DataGridView)sender;
                    if (dgv.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        e.PaintBackground(e.CellBounds, true);
                        ControlPaint.DrawCheckBox(e.Graphics, e.CellBounds.X + 1, e.CellBounds.Y + 1,
                            e.CellBounds.Width - 2, e.CellBounds.Height - 2,
                            (bool)e.FormattedValue ? ButtonState.Checked : ButtonState.Normal);
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;
                string headerText = senderGrid.Columns[e.ColumnIndex].Name;
                //We make DataGridCheckBoxColumn commit changes with single click
                //use index of logout column
                if (senderGrid.Columns["Check"] is DataGridViewCheckBoxColumn && headerText == "Check")
                    //if (e.ColumnIndex == 10 && e.RowIndex >= 0)
                    this.dgvService.CommitEdit(DataGridViewDataErrorContexts.Commit);
                caculateAmount();
                ShortDes();
                ////Check the value of cell
                //if ((bool)this.dgvService.CurrentCell.Value == true)
                //{

                //}
                //else
                //{

                //}
            }
            catch (Exception)
            {
            }
            
        }
    }
}
