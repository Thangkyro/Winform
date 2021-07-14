using CoreBase;
using CoreBase.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace AusNail.Process
{
    public partial class frmBooking : Form
    {
        private int iResult = 0;
        private int _branchIDChoose = 0;
        private DateTime _dateFilter;
        private DataTable _dtHeader = new DataTable();
        private DataTable _dtDetail = new DataTable();
        private string _statusDetail = "";
        private int _timeDetail = -1;
        private ZenSqlNotification notificationNewBooking;

        public frmBooking(DateTime dateFilter, int branchID)
        {
            InitializeComponent();
            panel4.BackColor = NailApp.ColorUser;
            _dateFilter = dateFilter;
            _branchIDChoose = branchID;
            //lblBookingDate.Text = "Date Booking: " + _dateFilter.ToString("dd/MM/yyyy");
            dtpDate.Value = _dateFilter;
            //Update Status
            int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBookingMaster_UpdateStatus", _branchIDChoose, DateTime.Now, "Cancel", NailApp.CurrentUserId, 0, "");
            //LoadGridHeader();
            //LoadGridDetail("", _dateFilter, -1);
        }

        #region Method
        private void LoadGridHeader()
        {
            //try
            //{
            //Get data Header


            _dtHeader = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBookingMasterGetList_GroupByDate", _dateFilter, _branchIDChoose);

            if (_dtHeader != null)
            {
                //dgvHeader.Invoke(new Action(() =>
                //{
                dgvHeader.BeginInvoke((MethodInvoker)delegate ()
                {
                    dgvHeader.DataSource = null;
                    dgvHeader.Rows.Clear();
                    dgvHeader.Columns.Clear();
                        //dgvHeader.BeginInvoke((MethodInvoker)delegate ()
                        //{
                        dgvHeader.DataSource = _dtHeader;
                    dgvHeader.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvHeader.Columns["Status"].HeaderText = "Status Booking";

                    dgvHeader.Columns["OneAM"].HeaderText = "1 AM";
                    dgvHeader.Columns["TwoAM"].HeaderText = "2 AM";
                    dgvHeader.Columns["ThreeAM"].HeaderText = "3 AM";
                    dgvHeader.Columns["FourAM"].HeaderText = "4 AM";
                    dgvHeader.Columns["FiveAM"].HeaderText = "5 AM";
                    dgvHeader.Columns["SixAM"].HeaderText = "6 AM";
                    dgvHeader.Columns["SevenAM"].HeaderText = "7 AM";
                    dgvHeader.Columns["EightAM"].HeaderText = "8 AM";
                    dgvHeader.Columns["NineAM"].HeaderText = "9 AM";
                    dgvHeader.Columns["TenAM"].HeaderText = "10 AM";
                    dgvHeader.Columns["ElevenAM"].HeaderText = "11 AM";
                    dgvHeader.Columns["TwelvePM"].HeaderText = "12 PM";
                    dgvHeader.Columns["ThirteenPM"].HeaderText = "13 AM";
                    dgvHeader.Columns["FourteenPM"].HeaderText = "14 PM";
                    dgvHeader.Columns["FifteenPM"].HeaderText = "15 PM";
                    dgvHeader.Columns["SixteenPM"].HeaderText = "16 PM";
                    dgvHeader.Columns["SeventeenPM"].HeaderText = "17 PM";
                    dgvHeader.Columns["EighteenPM"].HeaderText = "18 PM";
                    dgvHeader.Columns["NineteenPM"].HeaderText = "19 PM";
                    dgvHeader.Columns["TwentyPM"].HeaderText = "20 PM";
                    dgvHeader.Columns["TwentyOnePM"].HeaderText = "21 PM";
                    dgvHeader.Columns["TwentyTwoPM"].HeaderText = "22 PM";
                    dgvHeader.Columns["TwentyThreePM"].HeaderText = "23 PM";
                    dgvHeader.Columns["TwentyFourPM"].HeaderText = "24 AM";
                    dgvHeader.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;

                    if (_dtHeader.Rows.Count > 0)
                    {
                        dgvHeader.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    }

                    dgvHeader.Columns["OneAM"].Visible = false;
                    dgvHeader.Columns["TwoAM"].Visible = false;
                    dgvHeader.Columns["ThreeAM"].Visible = false;
                    dgvHeader.Columns["FourAM"].Visible = false;
                    dgvHeader.Columns["FiveAM"].Visible = false;
                    dgvHeader.Columns["SixAM"].Visible = false;
                    dgvHeader.Columns["SevenAM"].Visible = false;
                    dgvHeader.Columns["EightAM"].Visible = false;
                    dgvHeader.Columns["EighteenPM"].Visible = false;
                    dgvHeader.Columns["NineteenPM"].Visible = false;
                    dgvHeader.Columns["TwentyPM"].Visible = false;
                    dgvHeader.Columns["TwentyOnePM"].Visible = false;
                    dgvHeader.Columns["TwentyTwoPM"].Visible = false;
                    dgvHeader.Columns["TwentyThreePM"].Visible = false;
                    dgvHeader.Columns["TwentyFourPM"].Visible = false;
                    dgvHeader.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        //});
                        //LoadGridDetail(_statusDetail, _dateFilter, _timeDetail);
                    });
            }
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.ToString(), "Error");
            //}
        }

        private void LoadGridDetail(string statusBook, DateTime dateView, int time)
        {
            //try
            //{
            if (time != -1)
            {
                grbDetail.BeginInvoke((MethodInvoker)delegate ()
                {
                    grbDetail.Text = "Time: " + time.ToString();
                });
            }

            //Get data Header
            //dgvDetail.DataSource = null;
            //dgvDetail.Refresh();
            _dtDetail = new DataTable();
            _dtDetail = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBookingMasterGetList_ByDateAndStatus", statusBook, dateView, time);

            if (_dtDetail != null)
            {
                //dgvDetail.Invoke(new Action(() =>
                //{
                dgvDetail.BeginInvoke((MethodInvoker)delegate ()
                {
                    dgvDetail.DataSource = null;
                    dgvDetail.Rows.Clear();
                    dgvDetail.Columns.Clear();
                    dgvDetail.DataSource = _dtDetail;
                    //dgvDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvDetail.Columns["BookID"].Visible = false;
                    dgvDetail.Columns["No"].HeaderText = "No.";
                    dgvDetail.Columns["No"].ReadOnly = true;
                    dgvDetail.Columns["No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    dgvDetail.Columns["BillNumber"].HeaderText = "Bill Number - Customer - Phone Number";
                    dgvDetail.Columns["BillNumber"].ReadOnly = true;
                    dgvDetail.Columns["BillNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    dgvDetail.Columns["TimeBooking"].HeaderText = "Time Booking";
                    dgvDetail.Columns["TimeBooking"].ReadOnly = true;
                    dgvDetail.Columns["TimeBooking"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                    dgvDetail.Columns["TimeService"].HeaderText = "Time Service";
                    dgvDetail.Columns["TimeService"].ReadOnly = true;
                    dgvDetail.Columns["TimeService"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    if (statusBook == "Temporary" || statusBook == "Cancel")
                    {
                        DataGridViewButtonColumn dgvE = new DataGridViewButtonColumn();
                        dgvE.HeaderText = "Edit";
                        dgvE.Name = "Edit";
                        dgvE.Text = "Edit";
                        dgvE.UseColumnTextForButtonValue = true;
                        dgvE.Width = 50;
                        dgvE.DefaultCellStyle.Padding = new Padding(1);
                        dgvE.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        //dgvE.Image = Properties.Resources.cancel;
                        var DataGridViewButtonColumn = dgvDetail.Columns["Edit"];
                        if (DataGridViewButtonColumn == null)
                        {
                            dgvDetail.Columns.Add(dgvE);
                        }

                        DataGridViewButtonColumn dgvT = new DataGridViewButtonColumn();
                        dgvT.HeaderText = "ToBill";
                        dgvT.Name = "ToBill";
                        dgvT.Text = "ToBill";
                        dgvT.UseColumnTextForButtonValue = true;
                        dgvT.Width = 50;
                        dgvT.DefaultCellStyle.Padding = new Padding(1);
                        dgvT.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        var dgvT1 = dgvDetail.Columns["ToBill"];
                        if (dgvT1 == null)
                        {
                            dgvDetail.Columns.Add(dgvT);
                        }

                        DataGridViewButtonColumn dgvR = new DataGridViewButtonColumn();
                        dgvR.HeaderText = "Remove";
                        dgvR.Name = "Remove";
                        dgvR.Text = "Remove";
                        dgvR.UseColumnTextForButtonValue = true;
                        dgvR.Width = 50;
                        dgvR.DefaultCellStyle.Padding = new Padding(1);
                        dgvR.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        var dgvR1 = dgvDetail.Columns["Remove"];
                        if (dgvR1 == null)
                        {
                            dgvDetail.Columns.Add(dgvR);
                        }
                    }
                });
            }

            _statusDetail = statusBook;
            _timeDetail = time;

            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.ToString(), "Error");
            //}
        }

        public int SendData()
        {
            return iResult;
        }

        private void CheckService(bool isCheckPhone)
        {
            if (isCheckPhone)
            {
                Process.frmCheckPhone form = new Process.frmCheckPhone(int.Parse(NailApp.BranchID), NailApp.CurrentUserId);
                form.ShowDialog();
                string sResult = form.SendData();
                List<string> lstResult = new List<string>();
                if (sResult != null && sResult.ToString() != "")
                {
                    lstResult = sResult.Split('|').ToList();
                }

                if (lstResult != null && lstResult.Count > 1) // Add Service
                {
                    DateTime dt;
                    DateTime.TryParseExact(dtpDate.Text.Trim().ToString(), "dd/MM/yyyy",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None,
                                   out dt);
                    if (dt == null)
                    {
                        MessageBox.Show("Please choose date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (dt.Year == 0001)
                    {
                        MessageBox.Show("Date booking invaild !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        Process.frmBookingAdd frmSerAdd = new Process.frmBookingAdd(int.Parse(NailApp.BranchID), lstResult[1].ToString().Trim(), lstResult[0].ToString().Trim(), 0, "Add", dt);
                        frmSerAdd.ShowDialog();
                        int iResult = frmSerAdd.SendData();
                        if (iResult != 0)
                        {
                            LoadDataBoking();
                        }
                    }

                }
                else if (lstResult != null && lstResult.Count == 1) //Add Customer
                {
                    Process.frmCusstomerAdd frmCusAdd = new Process.frmCusstomerAdd(int.Parse(NailApp.BranchID), NailApp.CurrentUserId, lstResult[0].ToString().Trim());
                    frmCusAdd.ShowDialog();
                    string addCusResult = frmCusAdd.SendData();
                    if (!string.IsNullOrWhiteSpace(addCusResult))
                    {
                        List<string> lstaddCusResult = new List<string>();
                        if (addCusResult != null)
                        {
                            lstaddCusResult = addCusResult.Split('|').ToList();
                        }

                        DateTime dt;
                        DateTime.TryParseExact(dtpDate.Text.Trim().ToString(), "dd/MM/yyyy",
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out dt);
                        if (dt == null)
                        {
                            MessageBox.Show("Please choose date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else if (dt.Year == 0001)
                        {
                            MessageBox.Show("Date booking invaild !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            Process.frmBookingAdd frmSerAdd = new Process.frmBookingAdd(int.Parse(NailApp.BranchID), lstaddCusResult[1].ToString().Trim(), lstaddCusResult[0].ToString().Trim(), 0, "Add", dt);
                            frmSerAdd.ShowDialog();
                            int iResult = frmSerAdd.SendData();
                            if (iResult != 0)
                            {
                                LoadDataBoking();
                            }
                        }
                    }
                }
            }
            else
            {
                Process.frmCusstomerAdd frmCusAdd = new Process.frmCusstomerAdd(int.Parse(NailApp.BranchID), NailApp.CurrentUserId, "");
                frmCusAdd.ShowDialog();
                string addCusResult = frmCusAdd.SendData();
                if (!string.IsNullOrWhiteSpace(addCusResult))
                {
                    List<string> lstaddCusResult = new List<string>();
                    if (addCusResult != null)
                    {
                        lstaddCusResult = addCusResult.Split('|').ToList();
                    }

                    DateTime dt;
                    DateTime.TryParseExact(dtpDate.Text.Trim().ToString(), "dd/MM/yyyy",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None,
                                   out dt);
                    if (dt == null)
                    {
                        MessageBox.Show("Please choose date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (dt.Year == 0001)
                    {
                        MessageBox.Show("Date booking invaild !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        Process.frmBookingAdd frmSerAdd = new Process.frmBookingAdd(int.Parse(NailApp.BranchID), lstaddCusResult[1].ToString().Trim(), lstaddCusResult[0].ToString().Trim(), 0, "Add", dt);
                        frmSerAdd.ShowDialog();
                        int iResult = frmSerAdd.SendData();
                        if (iResult != 0)
                        {
                            LoadDataBoking();
                        }
                    }
                }
            }
        }

        private void SetDependencyBooking()
        {
            DateTime _zDateMax = new DateTime(_dateFilter.Year, _dateFilter.Month, _dateFilter.Day,23,59,59);
            DateTime _zDateMin = new DateTime(_dateFilter.Year, _dateFilter.Month, _dateFilter.Day, 0, 0, 0);
            //";//

            string cmdNewBooking = "select BookID, branchId, BookingDate, Status from dbo.zBookingMaster where zBookingMaster.branchid " +
                    "= " + NailApp.BranchID + "  AND zBookingMaster.BookingDate BETWEEN @begin AND @End ";
            notificationNewBooking = new ZenSqlNotification(LoadDataBoking, cmdNewBooking, _zDateMin, _zDateMax);
            notificationNewBooking.LoadData();
        }
        private void LoadDataBoking()
        {
            LoadGridHeader();
            LoadGridDetail(_statusDetail, _dateFilter, _timeDetail);
        }
        private void LoadDataBoking2()
        {
            LoadGridDetail(_statusDetail, _dateFilter, _timeDetail);
        }

        #endregion

        #region Event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvHeader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //string columnName = dgvHeader.Columns[e.ColumnIndex].Name;
                int colIndex = e.ColumnIndex;
                int rowIndex = e.RowIndex; // 0-Temporary, 1-Tobill, 2-Cancel
                int time = colIndex == 24 ? 0 : colIndex;
                string status = dgvHeader["Status", e.RowIndex].Value.ToString();
                string value = dgvHeader[e.ColumnIndex, e.RowIndex].Value != DBNull.Value ? dgvHeader[e.ColumnIndex, e.RowIndex].Value.ToString() : null;
                if (colIndex != 0 && value != null) // col Status
                {
                    LoadGridDetail(status, _dateFilter, time);
                }
                else if (colIndex != 0)
                {
                    LoadGridDetail("", _dateFilter, 0);
                }

            }
            catch (Exception ex)
            {

            }
        }


        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;
                string headerText = senderGrid.Columns[e.ColumnIndex].Name;
                if (senderGrid.Columns["Edit"] is DataGridViewButtonColumn && dgvDetail["BookID", e.RowIndex].Value != DBNull.Value && headerText == "Edit")
                {
                    Process.frmBookingAdd frmSerAdd = new Process.frmBookingAdd(int.Parse(NailApp.BranchID), "", "", int.Parse(dgvDetail["BookID", e.RowIndex].Value.ToString()), "Edit", null);
                    frmSerAdd.ShowDialog();
                    int iResult = frmSerAdd.SendData();
                    if (iResult != 0)
                    {
                        LoadDataBoking();
                    }
                }
                else if (senderGrid.Columns["ToBill"] is DataGridViewButtonColumn && dgvDetail["BookID", e.RowIndex].Value != DBNull.Value && headerText == "ToBill")
                {
                    DialogResult dialogResult = MessageBox.Show("Are you confirm ?", "Create Bill", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int bookID = int.Parse(dgvDetail["BookID", e.RowIndex].Value.ToString());
                        // Gen billCode
                        string billCode = "";
                        DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGetNewCode", "zBillMaster", "BL", "BillID", 8);
                        if (dt != null)
                        {
                            billCode = dt.Rows[0][0].ToString();
                        }
                        int error = 0;
                        string errorMesg = "";
                        //Insert Bill for getdate
                        int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillInsert_FromBooking", bookID, _branchIDChoose, NailApp.CurrentUserId, DateTime.Now, billCode, error, errorMesg);
                        if (ret > 0)
                        {
                            //Update Status = ToBill
                            int ret1 = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBookingMasterCancel", bookID, _branchIDChoose, "ToBill", NailApp.CurrentUserId, error, errorMesg);
                            LoadDataBoking();
                            if (NailApp.IsAutoPrint())
                            {
                                DataTable dtBill = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, "Select BillID From zBillMaster with(nolock) Where BookID = " + bookID);
                                if (dtBill != null && dtBill.Rows.Count > 0)
                                {
                                    DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillPrint", int.Parse(dtBill.Rows[0][0].ToString()), int.Parse(NailApp.BranchID));
                                    DataSet dsData = new DataSet();
                                    dsData.Tables.Add(dataTable);
                                    frmPrintNew f = new frmPrintNew(dsData, "rpt_bill.rpt", false, int.Parse(NailApp.BranchID), int.Parse(dtBill.Rows[0][0].ToString()));
                                    f.ShowDialog();
                                }
                            }
                            else
                            {
                                DialogResult dialogResultPrint = MessageBox.Show("Do you want to print bill ?", "Print Bill", MessageBoxButtons.YesNo);
                                if (dialogResultPrint == DialogResult.Yes)
                                {
                                    DataTable dtBill = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, "Select BillID From zBillMaster with(nolock) Where BookID = " + bookID);
                                    if (dtBill != null && dtBill.Rows.Count > 0)
                                    {
                                        //Process.frmPrint frm = new Process.frmPrint(int.Parse(NailApp.BranchID), int.Parse(dtBill.Rows[0][0].ToString()), NailApp.CurrentUserId, 0);
                                        //frm.ShowDialog();

                                        DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillPrint", int.Parse(dtBill.Rows[0][0].ToString()), int.Parse(NailApp.BranchID));
                                        DataSet dsData = new DataSet();
                                        dsData.Tables.Add(dataTable);
                                        frmPrintNew f = new frmPrintNew(dsData, "rpt_bill.rpt", true, int.Parse(NailApp.BranchID), int.Parse(dtBill.Rows[0][0].ToString()));
                                        f.ShowDialog();
                                        //Print print = new Print();
                                        //print.Printer(dsData, "rpt_bill.rpt");
                                    }
                                }
                                //else
                                //{
                                //    DataTable dtBill = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, "Select BillID From zBillMaster with(nolock) Where BookID = " + bookID);
                                //    if (dtBill != null && dtBill.Rows.Count > 0)
                                //    {
                                //        DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillPrint", int.Parse(dtBill.Rows[0][0].ToString()), int.Parse(NailApp.BranchID));
                                //        DataSet dsData = new DataSet();
                                //        dsData.Tables.Add(dataTable);
                                //        frmPrintNew f = new frmPrintNew(dsData, "rpt_bill.rpt", false, int.Parse(NailApp.BranchID), int.Parse(dtBill.Rows[0][0].ToString()));
                                //        f.ShowDialog();
                                //    }
                                //}
                            }
                        }
                        else if (!string.IsNullOrEmpty(errorMesg))
                        {
                            MessageBox.Show(errorMesg, "Error");
                        }
                    }
                }
                else if (senderGrid.Columns["Remove"] is DataGridViewButtonColumn && dgvDetail["BookID", e.RowIndex].Value != DBNull.Value && headerText == "Remove")
                {
                    DialogResult dialogResult = MessageBox.Show("Are you confirm ?", "Remove Booking", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int bookID = int.Parse(dgvDetail["BookID", e.RowIndex].Value.ToString());
                        int error = 0;
                        string errorMesg = "";
                        //Delete Booking
                        int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBookingMasterDelete", bookID, _branchIDChoose, error, errorMesg);
                        if (ret > 0)
                        {
                            LoadDataBoking();
                        }
                        else if (!string.IsNullOrEmpty(errorMesg))
                        {
                            MessageBox.Show(errorMesg, "Error");
                        }
                    }


                }
            }
            catch (Exception ex)
            {

            }
        }


        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            CheckService(false);
        }

        private void btnNewBooking_Click(object sender, EventArgs e)
        {
            CheckService(true);
        }


        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            int error = 0;
            string errorMesg = "";
            try
            {
                int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBookingMaster_UpdateStatus", _branchIDChoose, DateTime.Now, "Cancel", NailApp.CurrentUserId, error, errorMesg);
                if (ret > 0)
                {
                    //Load grid
                    LoadDataBoking();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt;
                DateTime.TryParseExact(dtpDate.Text.Trim().ToString(), "dd/MM/yyyy",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out dt);
                if (dt == null)
                {
                    MessageBox.Show("Please choose date filter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (dt.Year == 0001)
                {
                    MessageBox.Show("Date booking invaild !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    _dateFilter = dt;
                }
                //Load grid
                LoadDataBoking();
                SetDependencyBooking();
            }
            catch (Exception ex)
            {

            }

        }

        private void frmBooking_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGridHeader();
                LoadGridDetail("", _dateFilter, -1);
                SetDependencyBooking();
            }
            catch (Exception ex)
            {

            }

        }
    }
}
