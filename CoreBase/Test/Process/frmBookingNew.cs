using CoreBase;
using CoreBase.DataAccessLayer;
using CoreBase.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AusNail.Process
{
    public partial class frmBookingNew : Form
    {
        const string BOOKING_CMDKEY = "Booking";
        const string BOOKING_ADD_CMDKEY = "Booking_add";
        const string BOOKING_DEL_CMDKEY = "Booking_del";
        const string BOOKING_EDIT_CMDKEY = "Booking_edit";
        const string BOOKING_LIST_CMDKEY = "Booking_list";
        const string BILL_ADD_CMDKEY = "Bill_add";

        private int iResult = 0;
        private int _branchIDChoose = 0;
        private DateTime _dateFilter;
        private DataTable _dtHeader = new DataTable();
        private DataTable _dtDetail = new DataTable();
        private DataTable _dtGetList = new DataTable();
        private string _statusDetail = "";
        private int _timeDetail = -1;
        private string _tagsBookID = "";
        private string _tagsStatus = "";
        private ZenSqlNotification notificationNewBooking;

        [System.ComponentModel.Browsable(false)]
        public string DocumentText { get; set; }

        public frmBookingNew(DateTime dateFilter, int branchID)
        {
            InitializeComponent();
            panel4.BackColor = NailApp.ColorUser;
            _dateFilter = dateFilter;
            _branchIDChoose = branchID;
            //lblBookingDate.Text = "Date Booking: " + _dateFilter.ToString("dd/MM/yyyy");
            dtpDate.Value = _dateFilter;
            //Update Status
            int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBookingMaster_UpdateStatus", _branchIDChoose, DateTime.Now.AddHours(NailApp.TimeConfig), "Cancel", NailApp.CurrentUserId, 0, "");
            //LoadGridHeader();
            //LoadGridDetail("", _dateFilter, -1);
            this.BackColor = NailApp.ColorUser.IsEmpty == true || NailApp.ColorUser.Name == "0" ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;

        }

        #region Method


        private void LoadGridHeader()
        {
            ClearTextBox();
            _dtHeader = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBookingMasterGetList_GroupByDate_New", _dateFilter, _branchIDChoose);

            if (_dtHeader != null && _dtHeader.Rows.Count > 0)
            {
                foreach (DataRow dr in _dtHeader.Rows)
                {
                    SetTextBox(int.Parse(dr["BookID"].ToString()), dr["Status"].ToString(), dr["Short"].ToString(), dr["ShortDecriptions"].ToString(), int.Parse(dr["HourBook"].ToString()), int.Parse(dr["Slot"].ToString()));
                }
            }

            //if (_dtHeader != null)
            //{
            //    dgvHeader.BeginInvoke((MethodInvoker)delegate ()
            //    {
            //        dgvHeader.DataSource = null;
            //        dgvHeader.Rows.Clear();
            //        dgvHeader.Columns.Clear();
            //        dgvHeader.DataSource = _dtHeader;
            //        dgvHeader.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    
            //    });
            //}

        }

        private void SetTextBox(int bookID, string status, string shortDes1, string shortDes2, int hour, int slot)
        {
            try
            {
                switch (hour)
                {
                    #region Time 9
                    case 9:
                        {
                            switch (slot)
                            {
                                case 1:
                                    txt91.Clear();
                                    txt91.BackColor = Color.White;
                                    txt91.Tag = "";
                                    txt91.Tag = string.Concat(bookID.ToString(),"|",status);
                                    txt91.AppendText("\r\n" + shortDes1);
                                    txt91.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt91.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt91.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt91.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 2:
                                    txt92.Clear();
                                    txt92.BackColor = Color.White;
                                    txt92.Tag = "";
                                    txt92.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt92.AppendText("\r\n" + shortDes1);
                                    txt92.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt92.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt92.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt92.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 3:
                                    txt93.Clear();
                                    txt93.BackColor = Color.White;
                                    txt93.Tag = "";
                                    txt93.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt93.AppendText("\r\n" + shortDes1);
                                    txt93.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt93.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt93.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt93.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 4:
                                    txt94.Clear();
                                    txt94.BackColor = Color.White;
                                    txt94.Tag = "";
                                    txt94.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt94.AppendText("\r\n" + shortDes1);
                                    txt94.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt94.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt94.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt94.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 5:
                                    txt95.Clear();
                                    txt95.BackColor = Color.White;
                                    txt95.Tag = "";
                                    txt95.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt95.AppendText("\r\n" + shortDes1);
                                    txt95.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt95.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt95.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt95.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 6:
                                    txt96.Clear();
                                    txt96.BackColor = Color.White;
                                    txt96.Tag = "";
                                    txt96.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt96.AppendText("\r\n" + shortDes1);
                                    txt96.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt96.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt96.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt96.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 7:
                                    txt97.Clear();
                                    txt97.BackColor = Color.White;
                                    txt97.Tag = "";
                                    txt97.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt97.AppendText("\r\n" + shortDes1);
                                    txt97.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt97.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt97.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt97.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 8:
                                    txt98.Clear();
                                    txt98.BackColor = Color.White;
                                    txt98.Tag = "";
                                    txt98.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt98.AppendText("\r\n" + shortDes1);
                                    txt98.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt98.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt98.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt98.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 9:
                                    txt99.Clear();
                                    txt99.BackColor = Color.White;
                                    txt99.Tag = "";
                                    txt99.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt99.AppendText("\r\n" + shortDes1);
                                    txt99.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt99.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt99.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt99.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 10:
                                    txt910.Clear();
                                    txt910.BackColor = Color.White;
                                    txt910.Tag = "";
                                    txt910.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt910.AppendText("\r\n" + shortDes1);
                                    txt910.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt910.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt910.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt910.BackColor = Color.Yellow;
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion 

                    #region Time 10
                    case 10:
                        {
                            switch (slot)
                            {
                                case 1:
                                    txt101.Clear();
                                    txt101.BackColor = Color.White;
                                    txt101.Tag = "";
                                    txt101.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt101.AppendText("\r\n" + shortDes1);
                                    txt101.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt101.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt101.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt101.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 2:
                                    txt102.Clear();
                                    txt102.BackColor = Color.White;
                                    txt102.Tag = "";
                                    txt102.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt102.AppendText("\r\n" + shortDes1);
                                    txt102.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt102.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt102.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt102.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 3:
                                    txt103.Clear();
                                    txt103.BackColor = Color.White;
                                    txt103.Tag = "";
                                    txt103.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt103.AppendText("\r\n" + shortDes1);
                                    txt103.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt103.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt103.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt103.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 4:
                                    txt104.Clear();
                                    txt104.BackColor = Color.White;
                                    txt104.Tag = "";
                                    txt104.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt104.AppendText("\r\n" + shortDes1);
                                    txt104.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt104.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt104.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt104.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 5:
                                    txt105.Clear();
                                    txt105.BackColor = Color.White;
                                    txt105.Tag = "";
                                    txt105.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt105.AppendText("\r\n" + shortDes1);
                                    txt105.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt105.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt105.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt105.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 6:
                                    txt106.Clear();
                                    txt106.BackColor = Color.White;
                                    txt106.Tag = "";
                                    txt106.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt106.AppendText("\r\n" + shortDes1);
                                    txt106.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt106.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt106.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt106.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 7:
                                    txt107.Clear();
                                    txt107.BackColor = Color.White;
                                    txt107.Tag = "";
                                    txt107.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt107.AppendText("\r\n" + shortDes1);
                                    txt107.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt107.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt107.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt107.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 8:
                                    txt108.Clear();
                                    txt108.BackColor = Color.White;
                                    txt108.Tag = "";
                                    txt108.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt108.AppendText("\r\n" + shortDes1);
                                    txt108.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt108.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt108.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt108.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 9:
                                    txt109.Clear();
                                    txt109.BackColor = Color.White;
                                    txt109.Tag = "";
                                    txt109.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt109.AppendText("\r\n" + shortDes1);
                                    txt109.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt109.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt109.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt109.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 10:
                                    txt1010.Clear();
                                    txt1010.BackColor = Color.White;
                                    txt1010.Tag = "";
                                    txt1010.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt1010.AppendText("\r\n" + shortDes1);
                                    txt1010.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt1010.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt1010.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt1010.BackColor = Color.Yellow;
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region Time 11
                    case 11:
                        {
                            switch (slot)
                            {
                                case 1:
                                    txt111.Clear();
                                    txt111.BackColor = Color.White;
                                    txt111.Tag = "";
                                    txt111.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt111.AppendText("\r\n" + shortDes1);
                                    txt111.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt111.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt111.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt111.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 2:
                                    txt112.Clear();
                                    txt112.BackColor = Color.White;
                                    txt112.Tag = "";
                                    txt112.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt112.AppendText("\r\n" + shortDes1);
                                    txt112.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt112.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt112.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt112.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 3:
                                    txt113.Clear();
                                    txt113.BackColor = Color.White;
                                    txt113.Tag = "";
                                    txt113.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt113.AppendText("\r\n" + shortDes1);
                                    txt113.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt113.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt113.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt113.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 4:
                                    txt114.Clear();
                                    txt114.BackColor = Color.White;
                                    txt114.Tag = "";
                                    txt114.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt114.AppendText("\r\n" + shortDes1);
                                    txt114.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt114.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt114.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt114.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 5:
                                    txt115.Clear();
                                    txt115.BackColor = Color.White;
                                    txt115.Tag = "";
                                    txt115.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt115.AppendText("\r\n" + shortDes1);
                                    txt115.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt115.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt115.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt115.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 6:
                                    txt116.Clear();
                                    txt116.BackColor = Color.White;
                                    txt116.Tag = "";
                                    txt116.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt116.AppendText("\r\n" + shortDes1);
                                    txt116.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt116.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt116.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt116.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 7:
                                    txt117.Clear();
                                    txt117.BackColor = Color.White;
                                    txt117.Tag = "";
                                    txt117.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt117.AppendText("\r\n" + shortDes1);
                                    txt117.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt117.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt117.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt117.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 8:
                                    txt118.Clear();
                                    txt118.BackColor = Color.White;
                                    txt118.Tag = "";
                                    txt118.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt118.AppendText("\r\n" + shortDes1);
                                    txt118.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt118.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt118.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt118.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 9:
                                    txt119.Clear();
                                    txt119.BackColor = Color.White;
                                    txt119.Tag = "";
                                    txt119.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt119.AppendText("\r\n" + shortDes1);
                                    txt119.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt119.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt119.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt119.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 10:
                                    txt1110.Clear();
                                    txt1110.BackColor = Color.White;
                                    txt1110.Tag = "";
                                    txt1110.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt1110.AppendText("\r\n" + shortDes1);
                                    txt1110.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt1110.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt1110.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt1110.BackColor = Color.Yellow;
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region Time 12
                    case 12:
                        {
                            switch (slot)
                            {
                                case 1:
                                    txt121.Clear();
                                    txt121.BackColor = Color.White;
                                    txt121.Tag = "";
                                    txt121.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt121.AppendText("\r\n" + shortDes1);
                                    txt121.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt121.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt121.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt121.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 2:
                                    txt122.Clear();
                                    txt122.BackColor = Color.White;
                                    txt122.Tag = "";
                                    txt122.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt122.AppendText("\r\n" + shortDes1);
                                    txt122.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt122.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt122.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt122.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 3:
                                    txt123.Clear();
                                    txt123.BackColor = Color.White;
                                    txt123.Tag = "";
                                    txt123.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt123.AppendText("\r\n" + shortDes1);
                                    txt123.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt123.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt123.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt123.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 4:
                                    txt124.Clear();
                                    txt124.BackColor = Color.White;
                                    txt124.Tag = "";
                                    txt124.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt124.AppendText("\r\n" + shortDes1);
                                    txt124.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt124.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt124.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt124.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 5:
                                    txt125.Clear();
                                    txt125.BackColor = Color.White;
                                    txt125.Tag = "";
                                    txt125.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt125.AppendText("\r\n" + shortDes1);
                                    txt125.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt125.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt125.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt125.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 6:
                                    txt126.Clear();
                                    txt126.BackColor = Color.White;
                                    txt126.Tag = "";
                                    txt126.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt126.AppendText("\r\n" + shortDes1);
                                    txt126.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt126.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt126.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt126.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 7:
                                    txt127.Clear();
                                    txt127.BackColor = Color.White;
                                    txt127.Tag = "";
                                    txt127.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt127.AppendText("\r\n" + shortDes1);
                                    txt127.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt127.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt127.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt127.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 8:
                                    txt128.Clear();
                                    txt128.BackColor = Color.White;
                                    txt128.Tag = "";
                                    txt128.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt128.AppendText("\r\n" + shortDes1);
                                    txt128.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt128.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt128.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt128.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 9:
                                    txt129.Clear();
                                    txt129.BackColor = Color.White;
                                    txt129.Tag = "";
                                    txt129.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt129.AppendText("\r\n" + shortDes1);
                                    txt129.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt129.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt129.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt129.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 10:
                                    txt1210.Clear();
                                    txt1210.BackColor = Color.White;
                                    txt1210.Tag = "";
                                    txt1210.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt1210.AppendText("\r\n" + shortDes1);
                                    txt1210.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt1210.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt1210.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt1210.BackColor = Color.Yellow;
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region Time 13
                    case 13:
                        {
                            switch (slot)
                            {
                                case 1:
                                    txt131.Clear();
                                    txt131.BackColor = Color.White;
                                    txt131.Tag = "";
                                    txt131.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt131.AppendText("\r\n" + shortDes1);
                                    txt131.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt131.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt131.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt131.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 2:
                                    txt132.Clear();
                                    txt132.BackColor = Color.White;
                                    txt132.Tag = "";
                                    txt132.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt132.AppendText("\r\n" + shortDes1);
                                    txt132.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt132.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt132.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt132.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 3:
                                    txt133.Clear();
                                    txt133.BackColor = Color.White;
                                    txt133.Tag = "";
                                    txt133.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt133.AppendText("\r\n" + shortDes1);
                                    txt133.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt133.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt133.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt133.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 4:
                                    txt134.Clear();
                                    txt134.BackColor = Color.White;
                                    txt134.Tag = "";
                                    txt134.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt134.AppendText("\r\n" + shortDes1);
                                    txt134.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt134.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt134.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt134.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 5:
                                    txt135.Clear();
                                    txt135.BackColor = Color.White;
                                    txt135.Tag = "";
                                    txt135.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt135.AppendText("\r\n" + shortDes1);
                                    txt135.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt135.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt135.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt135.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 6:
                                    txt136.Clear();
                                    txt136.BackColor = Color.White;
                                    txt136.Tag = "";
                                    txt136.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt136.AppendText("\r\n" + shortDes1);
                                    txt136.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt136.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt136.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt136.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 7:
                                    txt137.Clear();
                                    txt137.BackColor = Color.White;
                                    txt137.Tag = "";
                                    txt137.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt137.AppendText("\r\n" + shortDes1);
                                    txt137.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt137.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt137.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt137.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 8:
                                    txt138.Clear();
                                    txt138.BackColor = Color.White;
                                    txt138.Tag = "";
                                    txt138.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt138.AppendText("\r\n" + shortDes1);
                                    txt138.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt138.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt138.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt138.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 9:
                                    txt139.Clear();
                                    txt139.BackColor = Color.White;
                                    txt139.Tag = "";
                                    txt139.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt139.AppendText("\r\n" + shortDes1);
                                    txt139.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt139.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt139.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt139.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 10:
                                    txt1310.Clear();
                                    txt1310.BackColor = Color.White;
                                    txt1310.Tag = "";
                                    txt1310.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt1310.AppendText("\r\n" + shortDes1);
                                    txt1310.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt1310.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt1310.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt1310.BackColor = Color.Yellow;
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region Time 14
                    case 14:
                        {
                            switch (slot)
                            {
                                case 1:
                                    txt141.Clear();
                                    txt141.BackColor = Color.White;
                                    txt141.Tag = "";
                                    txt141.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt141.AppendText("\r\n" + shortDes1);
                                    txt141.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt141.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt141.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt141.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 2:
                                    txt142.Clear();
                                    txt142.BackColor = Color.White;
                                    txt142.Tag = "";
                                    txt142.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt142.AppendText("\r\n" + shortDes1);
                                    txt142.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt142.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt142.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt142.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 3:
                                    txt143.Clear();
                                    txt143.BackColor = Color.White;
                                    txt143.Tag = "";
                                    txt143.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt143.AppendText("\r\n" + shortDes1);
                                    txt143.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt143.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt143.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt143.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 4:
                                    txt144.Clear();
                                    txt144.BackColor = Color.White;
                                    txt144.Tag = "";
                                    txt144.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt144.AppendText("\r\n" + shortDes1);
                                    txt144.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt144.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt144.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt144.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 5:
                                    txt145.Clear();
                                    txt145.BackColor = Color.White;
                                    txt145.Tag = "";
                                    txt145.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt145.AppendText("\r\n" + shortDes1);
                                    txt145.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt145.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt145.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt145.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 6:
                                    txt146.Clear();
                                    txt146.BackColor = Color.White;
                                    txt146.Tag = "";
                                    txt146.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt146.AppendText("\r\n" + shortDes1);
                                    txt146.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt146.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt146.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt146.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 7:
                                    txt147.Clear();
                                    txt147.BackColor = Color.White;
                                    txt147.Tag = "";
                                    txt147.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt147.AppendText("\r\n" + shortDes1);
                                    txt147.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt147.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt147.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt147.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 8:
                                    txt148.Clear();
                                    txt148.BackColor = Color.White;
                                    txt148.Tag = "";
                                    txt148.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt148.AppendText("\r\n" + shortDes1);
                                    txt148.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt148.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt148.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt148.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 9:
                                    txt149.Clear();
                                    txt149.BackColor = Color.White;
                                    txt149.Tag = "";
                                    txt149.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt149.AppendText("\r\n" + shortDes1);
                                    txt149.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt149.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt149.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt149.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 10:
                                    txt1410.Clear();
                                    txt1410.BackColor = Color.White;
                                    txt1410.Tag = "";
                                    txt1410.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt1410.AppendText("\r\n" + shortDes1);
                                    txt1410.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt1410.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt1410.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt1410.BackColor = Color.Yellow;
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region Time 15
                    case 15:
                        {
                            switch (slot)
                            {
                                case 1:
                                    txt151.Clear();
                                    txt151.BackColor = Color.White;
                                    txt151.Tag = "";
                                    txt151.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt151.AppendText("\r\n" + shortDes1);
                                    txt151.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt151.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt151.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt151.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 2:
                                    txt152.Clear();
                                    txt152.BackColor = Color.White;
                                    txt152.Tag = "";
                                    txt152.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt152.AppendText("\r\n" + shortDes1);
                                    txt152.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt152.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt152.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt152.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 3:
                                    txt153.Clear();
                                    txt153.BackColor = Color.White;
                                    txt153.Tag = "";
                                    txt153.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt153.AppendText("\r\n" + shortDes1);
                                    txt153.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt153.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt153.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt153.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 4:
                                    txt154.Clear();
                                    txt154.BackColor = Color.White;
                                    txt154.Tag = "";
                                    txt154.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt154.AppendText("\r\n" + shortDes1);
                                    txt154.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt154.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt154.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt154.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 5:
                                    txt155.Clear();
                                    txt155.BackColor = Color.White;
                                    txt155.Tag = "";
                                    txt155.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt155.AppendText("\r\n" + shortDes1);
                                    txt155.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt155.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt155.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt155.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 6:
                                    txt156.Clear();
                                    txt156.BackColor = Color.White;
                                    txt156.Tag = "";
                                    txt156.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt156.AppendText("\r\n" + shortDes1);
                                    txt156.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt156.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt156.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt156.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 7:
                                    txt157.Clear();
                                    txt157.BackColor = Color.White;
                                    txt157.Tag = "";
                                    txt157.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt157.AppendText("\r\n" + shortDes1);
                                    txt157.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt157.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt157.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt157.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 8:
                                    txt158.Clear();
                                    txt158.BackColor = Color.White;
                                    txt158.Tag = "";
                                    txt158.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt158.AppendText("\r\n" + shortDes1);
                                    txt158.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt158.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt158.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt158.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 9:
                                    txt159.Clear();
                                    txt159.BackColor = Color.White;
                                    txt159.Tag = "";
                                    txt159.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt159.AppendText("\r\n" + shortDes1);
                                    txt159.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt159.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt159.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt159.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 10:
                                    txt1510.Clear();
                                    txt1510.BackColor = Color.White;
                                    txt1510.Tag = "";
                                    txt1510.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt1510.AppendText("\r\n" + shortDes1);
                                    txt1510.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt1510.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt1510.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt1510.BackColor = Color.Yellow;
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region Time 16
                    case 16:
                        {
                            switch (slot)
                            {
                                case 1:
                                    txt161.Clear();
                                    txt161.BackColor = Color.White;
                                    txt161.Tag = "";
                                    txt161.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt161.AppendText("\r\n" + shortDes1);
                                    txt161.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt161.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt161.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt161.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 2:
                                    txt162.Clear();
                                    txt162.BackColor = Color.White;
                                    txt162.Tag = "";
                                    txt162.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt162.AppendText("\r\n" + shortDes1);
                                    txt162.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt162.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt162.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt162.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 3:
                                    txt163.Clear();
                                    txt163.BackColor = Color.White;
                                    txt163.Tag = "";
                                    txt163.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt163.AppendText("\r\n" + shortDes1);
                                    txt163.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt163.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt163.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt163.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 4:
                                    txt164.Clear();
                                    txt164.BackColor = Color.White;
                                    txt164.Tag = "";
                                    txt164.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt164.AppendText("\r\n" + shortDes1);
                                    txt164.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt164.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt164.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt164.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 5:
                                    txt165.Clear();
                                    txt165.BackColor = Color.White;
                                    txt165.Tag = "";
                                    txt165.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt165.AppendText("\r\n" + shortDes1);
                                    txt165.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt165.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt165.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt165.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 6:
                                    txt166.Clear();
                                    txt166.BackColor = Color.White;
                                    txt166.Tag = "";
                                    txt166.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt166.AppendText("\r\n" + shortDes1);
                                    txt166.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt166.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt166.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt166.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 7:
                                    txt167.Clear();
                                    txt167.BackColor = Color.White;
                                    txt167.Tag = "";
                                    txt167.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt167.AppendText("\r\n" + shortDes1);
                                    txt167.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt167.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt167.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt167.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 8:
                                    txt168.Clear();
                                    txt168.BackColor = Color.White;
                                    txt168.Tag = "";
                                    txt168.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt168.AppendText("\r\n" + shortDes1);
                                    txt168.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt168.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt168.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt168.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 9:
                                    txt169.Clear();
                                    txt169.BackColor = Color.White;
                                    txt169.Tag = "";
                                    txt169.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt169.AppendText("\r\n" + shortDes1);
                                    txt169.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt169.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt169.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt169.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 10:
                                    txt1610.Clear();
                                    txt1610.BackColor = Color.White;
                                    txt1610.Tag = "";
                                    txt1610.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt1610.AppendText("\r\n" + shortDes1);
                                    txt1610.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt1610.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt1610.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt1610.BackColor = Color.Yellow;
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region Time 17
                    case 17:
                        {
                            switch (slot)
                            {
                                case 1:
                                    txt171.Clear();
                                    txt171.BackColor = Color.White;
                                    txt171.Tag = "";
                                    txt171.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt171.AppendText("\r\n" + shortDes1);
                                    txt171.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt171.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt171.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt171.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 2:
                                    txt172.Clear();
                                    txt172.BackColor = Color.White;
                                    txt172.Tag = "";
                                    txt172.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt172.AppendText("\r\n" + shortDes1);
                                    txt172.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt172.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt172.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt172.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 3:
                                    txt173.Clear();
                                    txt173.BackColor = Color.White;
                                    txt173.Tag = "";
                                    txt173.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt173.AppendText("\r\n" + shortDes1);
                                    txt173.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt173.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt173.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt173.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 4:
                                    txt174.Clear();
                                    txt174.BackColor = Color.White;
                                    txt174.Tag = "";
                                    txt174.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt174.AppendText("\r\n" + shortDes1);
                                    txt174.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt174.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt174.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt174.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 5:
                                    txt175.Clear();
                                    txt175.BackColor = Color.White;
                                    txt175.Tag = "";
                                    txt175.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt175.AppendText("\r\n" + shortDes1);
                                    txt175.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt175.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt175.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt175.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 6:
                                    txt176.Clear();
                                    txt176.BackColor = Color.White;
                                    txt176.Tag = "";
                                    txt176.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt176.AppendText("\r\n" + shortDes1);
                                    txt176.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt176.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt176.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt176.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 7:
                                    txt177.Clear();
                                    txt177.BackColor = Color.White;
                                    txt177.Tag = "";
                                    txt177.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt177.AppendText("\r\n" + shortDes1);
                                    txt177.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt177.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt177.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt177.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 8:
                                    txt178.Clear();
                                    txt178.BackColor = Color.White;
                                    txt178.Tag = "";
                                    txt178.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt178.AppendText("\r\n" + shortDes1);
                                    txt178.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt178.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt178.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt178.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 9:
                                    txt179.Clear();
                                    txt179.BackColor = Color.White;
                                    txt179.Tag = "";
                                    txt179.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt179.AppendText("\r\n" + shortDes1);
                                    txt179.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt179.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt179.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt179.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 10:
                                    txt1710.Clear();
                                    txt1710.BackColor = Color.White;
                                    txt1710.Tag = "";
                                    txt1710.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt1710.AppendText("\r\n" + shortDes1);
                                    txt1710.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt1710.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt1710.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt1710.BackColor = Color.Yellow;
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region Time 18
                    case 18:
                        {
                            switch (slot)
                            {
                                case 1:
                                    txt181.Clear();
                                    txt181.BackColor = Color.White;
                                    txt181.Tag = "";
                                    txt181.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt181.AppendText("\r\n" + shortDes1);
                                    txt181.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt181.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt181.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt181.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 2:
                                    txt182.Clear();
                                    txt182.BackColor = Color.White;
                                    txt182.Tag = "";
                                    txt182.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt182.AppendText("\r\n" + shortDes1);
                                    txt182.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt182.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt182.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt182.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 3:
                                    txt183.Clear();
                                    txt183.BackColor = Color.White;
                                    txt183.Tag = "";
                                    txt183.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt183.AppendText("\r\n" + shortDes1);
                                    txt183.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt183.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt183.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt183.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 4:
                                    txt184.Clear();
                                    txt184.BackColor = Color.White;
                                    txt184.Tag = "";
                                    txt184.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt184.AppendText("\r\n" + shortDes1);
                                    txt184.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt184.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt184.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt184.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 5:
                                    txt185.Clear();
                                    txt185.BackColor = Color.White;
                                    txt185.Tag = "";
                                    txt185.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt185.AppendText("\r\n" + shortDes1);
                                    txt185.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt185.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt185.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt185.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 6:
                                    txt186.Clear();
                                    txt186.BackColor = Color.White;
                                    txt186.Tag = "";
                                    txt186.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt186.AppendText("\r\n" + shortDes1);
                                    txt186.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt186.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt186.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt186.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 7:
                                    txt187.Clear();
                                    txt187.BackColor = Color.White;
                                    txt187.Tag = "";
                                    txt187.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt187.AppendText("\r\n" + shortDes1);
                                    txt187.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt187.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt187.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt187.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 8:
                                    txt188.Clear();
                                    txt188.BackColor = Color.White;
                                    txt188.Tag = "";
                                    txt188.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt188.AppendText("\r\n" + shortDes1);
                                    txt188.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt188.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt188.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt188.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 9:
                                    txt189.Clear();
                                    txt189.BackColor = Color.White;
                                    txt189.Tag = "";
                                    txt189.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt189.AppendText("\r\n" + shortDes1);
                                    txt189.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt189.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt189.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt189.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 10:
                                    txt1810.Clear();
                                    txt1810.BackColor = Color.White;
                                    txt1810.Tag = "";
                                    txt1810.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt1810.AppendText("\r\n" + shortDes1);
                                    txt1810.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt1810.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt1810.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt1810.BackColor = Color.Yellow;
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region Time 19
                    case 19:
                        {
                            switch (slot)
                            {
                                case 1:
                                    txt191.Clear();
                                    txt191.BackColor = Color.White;
                                    txt191.Tag = "";
                                    txt191.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt191.AppendText("\r\n" + shortDes1);
                                    txt191.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt191.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt191.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt191.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 2:
                                    txt192.Clear();
                                    txt192.BackColor = Color.White;
                                    txt192.Tag = "";
                                    txt192.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt192.AppendText("\r\n" + shortDes1);
                                    txt192.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt192.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt192.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt192.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 3:
                                    txt193.Clear();
                                    txt193.BackColor = Color.White;
                                    txt193.Tag = "";
                                    txt193.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt193.AppendText("\r\n" + shortDes1);
                                    txt193.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt193.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt193.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt193.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 4:
                                    txt194.Clear();
                                    txt194.BackColor = Color.White;
                                    txt194.Tag = "";
                                    txt194.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt194.AppendText("\r\n" + shortDes1);
                                    txt194.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt194.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt194.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt194.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 5:
                                    txt195.Clear();
                                    txt195.BackColor = Color.White;
                                    txt195.Tag = "";
                                    txt195.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt195.AppendText("\r\n" + shortDes1);
                                    txt195.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt195.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt195.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt195.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 6:
                                    txt196.Clear();
                                    txt196.BackColor = Color.White;
                                    txt196.Tag = "";
                                    txt196.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt196.AppendText("\r\n" + shortDes1);
                                    txt196.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt196.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt196.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt196.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 7:
                                    txt197.Clear();
                                    txt197.BackColor = Color.White;
                                    txt197.Tag = "";
                                    txt197.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt197.AppendText("\r\n" + shortDes1);
                                    txt197.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt197.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt197.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt197.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 8:
                                    txt198.Clear();
                                    txt198.BackColor = Color.White;
                                    txt198.Tag = "";
                                    txt198.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt198.AppendText("\r\n" + shortDes1);
                                    txt198.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt198.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt198.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt198.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 9:
                                    txt199.Clear();
                                    txt199.BackColor = Color.White;
                                    txt199.Tag = "";
                                    txt199.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt199.AppendText("\r\n" + shortDes1);
                                    txt199.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt199.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt199.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt199.BackColor = Color.Yellow;
                                    }
                                    break;

                                case 10:
                                    txt1910.Clear();
                                    txt1910.BackColor = Color.White;
                                    txt1910.Tag = "";
                                    txt1910.Tag = string.Concat(bookID.ToString(), "|", status);
                                    txt1910.AppendText("\r\n" + shortDes1);
                                    txt1910.AppendText("\r\n" + shortDes2);
                                    if (status == "ToBill")
                                    {
                                        txt1910.BackColor = Color.LightGray;
                                    }
                                    else if (status == "Cancel")
                                    {
                                        txt1910.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        txt1910.BackColor = Color.Yellow;
                                    }
                                    break;
                            }
                        }
                        break;
                        #endregion

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ClearTextBox()
        {
            txt91.Clear();
            txt92.Clear();
            txt93.Clear();
            txt94.Clear();
            txt95.Clear();
            txt96.Clear();
            txt97.Clear();
            txt98.Clear();
            txt99.Clear();
            txt910.Clear();

            txt91.BackColor = Color.White;;
            txt92.BackColor = Color.White;;
            txt93.BackColor = Color.White;;
            txt94.BackColor = Color.White;;
            txt95.BackColor = Color.White;;
            txt96.BackColor = Color.White;;
            txt97.BackColor = Color.White;;
            txt98.BackColor = Color.White;;
            txt99.BackColor = Color.White;
            txt910.BackColor = Color.White;

            txt101.Clear();
            txt102.Clear();
            txt103.Clear();
            txt104.Clear();
            txt105.Clear();
            txt106.Clear();
            txt107.Clear();
            txt108.Clear();
            txt109.Clear();
            txt1010.Clear();

            txt101.BackColor = Color.White;
            txt102.BackColor = Color.White;
            txt103.BackColor = Color.White;
            txt104.BackColor = Color.White;
            txt105.BackColor = Color.White;
            txt106.BackColor = Color.White;
            txt107.BackColor = Color.White;
            txt108.BackColor = Color.White;
            txt109.BackColor = Color.White;
            txt1010.BackColor = Color.White;

            txt111.Clear();
            txt112.Clear();
            txt113.Clear();
            txt114.Clear();
            txt115.Clear();
            txt116.Clear();
            txt117.Clear();
            txt118.Clear();
            txt119.Clear();
            txt1110.Clear();

            txt111.BackColor = Color.White;
            txt112.BackColor = Color.White;
            txt113.BackColor = Color.White;
            txt114.BackColor = Color.White;
            txt115.BackColor = Color.White;
            txt116.BackColor = Color.White;
            txt117.BackColor = Color.White;
            txt118.BackColor = Color.White;
            txt119.BackColor = Color.White;
            txt1110.BackColor = Color.White;

            txt121.Clear();
            txt122.Clear();
            txt123.Clear();
            txt124.Clear();
            txt125.Clear();
            txt126.Clear();
            txt127.Clear();
            txt128.Clear();
            txt129.Clear();
            txt1210.Clear();

            txt121.BackColor = Color.White;
            txt122.BackColor = Color.White;
            txt123.BackColor = Color.White;
            txt124.BackColor = Color.White;
            txt125.BackColor = Color.White;
            txt126.BackColor = Color.White;
            txt127.BackColor = Color.White;
            txt128.BackColor = Color.White;
            txt129.BackColor = Color.White;
            txt1210.BackColor = Color.White;

            txt131.Clear();
            txt132.Clear();
            txt133.Clear();
            txt134.Clear();
            txt135.Clear();
            txt136.Clear();
            txt137.Clear();
            txt138.Clear();
            txt139.Clear();
            txt1310.Clear();

            txt131.BackColor = Color.White;
            txt132.BackColor = Color.White;
            txt133.BackColor = Color.White;
            txt134.BackColor = Color.White;
            txt135.BackColor = Color.White;
            txt136.BackColor = Color.White;
            txt137.BackColor = Color.White;
            txt138.BackColor = Color.White;
            txt139.BackColor = Color.White;
            txt1310.BackColor = Color.White;

            txt141.Clear();
            txt142.Clear();
            txt143.Clear();
            txt144.Clear();
            txt145.Clear();
            txt146.Clear();
            txt147.Clear();
            txt148.Clear();
            txt149.Clear();
            txt1410.Clear();

            txt141.BackColor = Color.White;
            txt142.BackColor = Color.White;
            txt143.BackColor = Color.White;
            txt144.BackColor = Color.White;
            txt145.BackColor = Color.White;
            txt146.BackColor = Color.White;
            txt147.BackColor = Color.White;
            txt148.BackColor = Color.White;
            txt149.BackColor = Color.White;
            txt1410.BackColor = Color.White;

            txt151.Clear();
            txt152.Clear();
            txt153.Clear();
            txt154.Clear();
            txt155.Clear();
            txt156.Clear();
            txt157.Clear();
            txt158.Clear();
            txt159.Clear();
            txt1510.Clear();

            txt151.BackColor = Color.White;
            txt152.BackColor = Color.White;
            txt153.BackColor = Color.White;
            txt154.BackColor = Color.White;
            txt155.BackColor = Color.White;
            txt156.BackColor = Color.White;
            txt157.BackColor = Color.White;
            txt158.BackColor = Color.White;
            txt159.BackColor = Color.White;
            txt1510.BackColor = Color.White;

            txt161.Clear();
            txt162.Clear();
            txt163.Clear();
            txt164.Clear();
            txt165.Clear();
            txt166.Clear();
            txt167.Clear();
            txt168.Clear();
            txt169.Clear();
            txt1610.Clear();

            txt161.BackColor = Color.White;
            txt162.BackColor = Color.White;
            txt163.BackColor = Color.White;
            txt164.BackColor = Color.White;
            txt165.BackColor = Color.White;
            txt166.BackColor = Color.White;
            txt167.BackColor = Color.White;
            txt168.BackColor = Color.White;
            txt169.BackColor = Color.White;
            txt1610.BackColor = Color.White;

            txt171.Clear();
            txt172.Clear();
            txt173.Clear();
            txt174.Clear();
            txt175.Clear();
            txt176.Clear();
            txt177.Clear();
            txt178.Clear();
            txt179.Clear();
            txt1710.Clear();

            txt171.BackColor = Color.White;
            txt172.BackColor = Color.White;
            txt173.BackColor = Color.White;
            txt174.BackColor = Color.White;
            txt175.BackColor = Color.White;
            txt176.BackColor = Color.White;
            txt177.BackColor = Color.White;
            txt178.BackColor = Color.White;
            txt179.BackColor = Color.White;
            txt1710.BackColor = Color.White;

            txt181.Clear();
            txt182.Clear();
            txt183.Clear();
            txt184.Clear();
            txt185.Clear();
            txt186.Clear();
            txt187.Clear();
            txt188.Clear();
            txt189.Clear();
            txt1810.Clear();

            txt181.BackColor = Color.White;
            txt182.BackColor = Color.White;
            txt183.BackColor = Color.White;
            txt184.BackColor = Color.White;
            txt185.BackColor = Color.White;
            txt186.BackColor = Color.White;
            txt187.BackColor = Color.White;
            txt188.BackColor = Color.White;
            txt189.BackColor = Color.White;
            txt1810.BackColor = Color.White;

            txt191.Clear();
            txt192.Clear();
            txt193.Clear();
            txt194.Clear();
            txt195.Clear();
            txt196.Clear();
            txt197.Clear();
            txt198.Clear();
            txt199.Clear();
            txt1910.Clear();

            txt191.BackColor = Color.White;
            txt192.BackColor = Color.White;
            txt193.BackColor = Color.White;
            txt194.BackColor = Color.White;
            txt195.BackColor = Color.White;
            txt196.BackColor = Color.White;
            txt197.BackColor = Color.White;
            txt198.BackColor = Color.White;
            txt199.BackColor = Color.White;
            txt1910.BackColor = Color.White;

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
            DateTime _zDateMax = new DateTime(_dateFilter.Year, _dateFilter.Month, _dateFilter.Day, 23, 59, 59);
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
            //LoadGridDetail(_statusDetail, _dateFilter, _timeDetail);
        }

        private void ActionBooking(int bookIDSelect, string action)
        {
            try
            {
                string headerText = action;
                if (headerText == "Edit")
                {
                    if (!NailApp.lstPermission.Contains(BOOKING_EDIT_CMDKEY) && !NailApp.IsAdmin())
                    {
                        MessageBox.Show("Unauthorized", "Information");
                        return;
                    }
                    Process.frmBookingAdd frmSerAdd = new Process.frmBookingAdd(int.Parse(NailApp.BranchID), "", "", bookIDSelect, "Edit", null);
                    frmSerAdd.ShowDialog();
                    int iResult = frmSerAdd.SendData();
                    if (iResult != 0)
                    {
                        LoadDataBoking();
                    }
                }
                else if (headerText == "ToBill")
                {
                    if (!NailApp.lstPermission.Contains(BILL_ADD_CMDKEY) && !NailApp.IsAdmin())
                    {
                        MessageBox.Show("Unauthorized", "Information");
                        return;
                    }
                    //DialogResult dialogResult = MessageBox.Show("Are you confirm ?", "Create Bill", MessageBoxButtons.YesNo);
                    //if (dialogResult == DialogResult.Yes)
                    //{
                    int bookID = bookIDSelect;
                    // Gen billCode
                    string billCode = "";
                    DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGetNewCode", "zBillMaster", "BL", "BillID", 8);
                    if (dt != null)
                    {
                        billCode = dt.Rows[0][0].ToString();
                    }
                    int error = 0;
                    string errorMesg = "";

                    // Get bill number
                    int billnumber = 1;
                    DataTable dt1 = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillNumber", _branchIDChoose, DateTime.Parse(DateTime.Now.AddHours(NailApp.TimeConfig).ToShortDateString()));
                    if (dt1 != null)
                    {
                        billnumber = int.Parse(dt1.Rows[0][0].ToString().Substring(0, dt1.Rows[0][0].ToString().IndexOf('.')));
                    }


                    //Insert Bill for getdate
                    int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillInsert_FromBooking", bookID, _branchIDChoose, NailApp.CurrentUserId, DateTime.Now.AddHours(NailApp.TimeConfig), billCode, billnumber, error, errorMesg);
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
                                    frmPrintNew f = new frmPrintNew(dsData, "rpt_bill.rpt", NailApp.IsAutoPrint(), int.Parse(NailApp.BranchID), int.Parse(dtBill.Rows[0][0].ToString()));
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
                    //}
                }
                else if (headerText == "Remove")
                {
                    if (!NailApp.lstPermission.Contains(BOOKING_DEL_CMDKEY) && !NailApp.IsAdmin())
                    {
                        MessageBox.Show("Unauthorized", "Information");
                        return;
                    }
                    DialogResult dialogResult = MessageBox.Show("Are you confirm ?", "Remove Booking", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int bookID = bookIDSelect;
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

        #endregion

        #region Event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            if (!NailApp.lstPermission.Contains(BOOKING_ADD_CMDKEY) && !NailApp.IsAdmin())
            {
                MessageBox.Show("Unauthorized", "Information");
                return;
            }
            CheckService(false);
        }

        private void btnNewBooking_Click(object sender, EventArgs e)
        {
            if (!NailApp.lstPermission.Contains(BOOKING_ADD_CMDKEY) && !NailApp.IsAdmin())
            {
                MessageBox.Show("Unauthorized", "Information");
                return;
            }
            CheckService(true);
        }


        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            int error = 0;
            string errorMesg = "";
            try
            {
                int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBookingMaster_UpdateStatus", _branchIDChoose, DateTime.Now.AddHours(NailApp.TimeConfig), "Cancel", NailApp.CurrentUserId, error, errorMesg);
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
                //if (!NailApp.lstPermission.Contains(BOOKING_LIST_CMDKEY) && !NailApp.IsAdmin())
                //{
                //    MessageBox.Show("Unauthorized", "Information");
                //    this.Close();
                //}

                LoadGridHeader();
                //LoadGridDetail("", _dateFilter, -1);
                SetDependencyBooking();
            }
            catch (Exception ex)
            {

            }

        }

        private void Text_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {

            }
        }

        private void TextBox_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                TextBox tb = sender as TextBox;
                if (tb.Tag != null)
                {
                    string[] tag = tb.Tag.ToString().Split('|');
                    _tagsBookID = tag[0];
                    _tagsStatus = tag[1];
                }
                else
                {
                    _tagsBookID = "";
                    _tagsStatus = "";
                }
            }
            catch (Exception ex)
            {
                _tagsBookID = "";
                _tagsStatus = "";
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string args = _tagsBookID;
                if (!string.IsNullOrWhiteSpace(_tagsBookID))
                {
                    if (_tagsStatus == "Temporary" || _tagsStatus == "Cancel")
                    {
                        ActionBooking(int.Parse(_tagsBookID), "Edit");

                    }
                    else
                    {
                        MessageBox.Show("Status different Temporary or Cancel cannot Edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void tobillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string args = _tagsBookID;
                if (!string.IsNullOrWhiteSpace(_tagsBookID))
                {
                    if (_tagsStatus == "Temporary" || _tagsStatus == "Cancel")
                    {
                        ActionBooking(int.Parse(_tagsBookID), "ToBill");

                    }
                    else
                    {
                        MessageBox.Show("Status different Temporary or Cancel cannot To Bill!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                string args = _tagsBookID;
                if (!string.IsNullOrWhiteSpace(_tagsBookID))
                {
                    if (_tagsStatus == "Temporary" || _tagsStatus == "Cancel")
                    {
                        ActionBooking(int.Parse(_tagsBookID), "Remove");

                    }
                    else
                    {
                        MessageBox.Show("Status different Temporary or Cancel cannot Remove!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
