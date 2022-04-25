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
                    SetTextBox(int.Parse(dr["BookID"].ToString()), dr["Status"].ToString(), dr["TimeBook"].ToString(), dr["Short"].ToString(), dr["ShortDecriptions"].ToString(), dr["Decriptions"].ToString(), int.Parse(dr["HourBook"].ToString()), int.Parse(dr["Slot"].ToString()));
                }
            }
        }

        //public void AppendText(this RichTextBox box, string text, Color color)
        //{
        //    box.SelectionStart = box.TextLength;
        //    box.SelectionLength = 0;

        //    box.SelectionColor = color;
        //    box.SelectionFont = new Font(box.Font, FontStyle.Bold);
        //    box.AppendText(text);
        //    box.SelectionColor = box.ForeColor;
        //}

        private void SetTextBoxNew(RichTextBox rtxt, int bookID, string status, string timeBook, string shortDes1, string shortDes2, string FullDecriptions, int hour, int slot)
        {
            try
            {
                rtxt.Clear();
                rtxt.BackColor = Color.White;
                rtxt.Tag = "";
                rtxt.Tag = string.Concat(bookID.ToString(), "|", status);

                rtxt.AppendText("\r\n");
                int length = rtxt.Text.Length;
                rtxt.AppendText(timeBook + shortDes1 + "\r\n");
                rtxt.Select(length, timeBook.Length);
                rtxt.SelectionFont = new Font(txt151.Font, FontStyle.Bold);
                rtxt.AppendText(shortDes2);
                rtxt.AppendText("\r\n" + FullDecriptions);
                rtxt.SelectAll();
                rtxt.SelectionAlignment = HorizontalAlignment.Center;
                rtxt.DeselectAll();
                if (status == "ToBill")
                {
                    rtxt.BackColor = Color.LightGray;
                }
                else if (status == "Cancel")
                {
                    rtxt.BackColor = Color.Red;
                }
                else
                {
                    rtxt.BackColor = Color.Yellow;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SetTextBox(int bookID, string status, string timeBook, string shortDes1, string shortDes2, string FullDecriptions, int hour, int slot)
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
                                    SetTextBoxNew(txt91, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 2:
                                    SetTextBoxNew(txt92, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 3:
                                    SetTextBoxNew(txt93, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 4:
                                    SetTextBoxNew(txt94, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 5:
                                    SetTextBoxNew(txt95, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 6:
                                    SetTextBoxNew(txt96, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 7:
                                    SetTextBoxNew(txt97, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 8:
                                    SetTextBoxNew(txt98, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 9:
                                    SetTextBoxNew(txt99, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 10:
                                    SetTextBoxNew(txt910, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
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
                                    SetTextBoxNew(txt101, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 2:
                                    SetTextBoxNew(txt102, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 3:
                                    SetTextBoxNew(txt103, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 4:
                                    SetTextBoxNew(txt104, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 5:
                                    SetTextBoxNew(txt105, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 6:
                                    SetTextBoxNew(txt106, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 7:
                                    SetTextBoxNew(txt107, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 8:
                                    SetTextBoxNew(txt108, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 9:
                                    SetTextBoxNew(txt109, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 10:
                                    SetTextBoxNew(txt1010, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
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
                                    SetTextBoxNew(txt111, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 2:
                                    SetTextBoxNew(txt112, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 3:
                                    SetTextBoxNew(txt113, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 4:
                                    SetTextBoxNew(txt114, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 5:
                                    SetTextBoxNew(txt115, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 6:
                                    SetTextBoxNew(txt116, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 7:
                                    SetTextBoxNew(txt117, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 8:
                                    SetTextBoxNew(txt118, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 9:
                                    SetTextBoxNew(txt119, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 10:
                                    SetTextBoxNew(txt1110, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
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
                                    SetTextBoxNew(txt121, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 2:
                                    SetTextBoxNew(txt122, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 3:
                                    SetTextBoxNew(txt123, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 4:
                                    SetTextBoxNew(txt124, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 5:
                                    SetTextBoxNew(txt125, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 6:
                                    SetTextBoxNew(txt126, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 7:
                                    SetTextBoxNew(txt127, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 8:
                                    SetTextBoxNew(txt128, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 9:
                                    SetTextBoxNew(txt129, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 10:
                                    SetTextBoxNew(txt1210, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
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
                                    SetTextBoxNew(txt131, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 2:
                                    SetTextBoxNew(txt132, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 3:
                                    SetTextBoxNew(txt133, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 4:
                                    SetTextBoxNew(txt134, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 5:
                                    SetTextBoxNew(txt135, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 6:
                                    SetTextBoxNew(txt136, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 7:
                                    SetTextBoxNew(txt137, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 8:
                                    SetTextBoxNew(txt138, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 9:
                                    SetTextBoxNew(txt139, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 10:
                                    SetTextBoxNew(txt1310, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
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
                                    SetTextBoxNew(txt141, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 2:
                                    SetTextBoxNew(txt142, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 3:
                                    SetTextBoxNew(txt143, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 4:
                                    SetTextBoxNew(txt144, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 5:
                                    SetTextBoxNew(txt145, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 6:
                                    SetTextBoxNew(txt146, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 7:
                                    SetTextBoxNew(txt147, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 8:
                                    SetTextBoxNew(txt148, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 9:
                                    SetTextBoxNew(txt149, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 10:
                                    SetTextBoxNew(txt1410, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
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
                                    SetTextBoxNew(txt151, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 2:
                                    SetTextBoxNew(txt152, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 3:
                                    SetTextBoxNew(txt153, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 4:
                                    SetTextBoxNew(txt154, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 5:
                                    SetTextBoxNew(txt155, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 6:
                                    SetTextBoxNew(txt156, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 7:
                                    SetTextBoxNew(txt157, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 8:
                                    SetTextBoxNew(txt158, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 9:
                                    SetTextBoxNew(txt159, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 10:
                                    SetTextBoxNew(txt1510, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
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
                                    SetTextBoxNew(txt161, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 2:
                                    SetTextBoxNew(txt162, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 3:
                                    SetTextBoxNew(txt163, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 4:
                                    SetTextBoxNew(txt164, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 5:
                                    SetTextBoxNew(txt165, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 6:
                                    SetTextBoxNew(txt166, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 7:
                                    SetTextBoxNew(txt167, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 8:
                                    SetTextBoxNew(txt168, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 9:
                                    SetTextBoxNew(txt169, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 10:
                                    SetTextBoxNew(txt1610, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
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
                                    SetTextBoxNew(txt171, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 2:
                                    SetTextBoxNew(txt172, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 3:
                                    SetTextBoxNew(txt173, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 4:
                                    SetTextBoxNew(txt174, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 5:
                                    SetTextBoxNew(txt175, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 6:
                                    SetTextBoxNew(txt176, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 7:
                                    SetTextBoxNew(txt177, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 8:
                                    SetTextBoxNew(txt178, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 9:
                                    SetTextBoxNew(txt179, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 10:
                                    SetTextBoxNew(txt1710, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
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
                                    SetTextBoxNew(txt181, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 2:
                                    SetTextBoxNew(txt182, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 3:
                                    SetTextBoxNew(txt183, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 4:
                                    SetTextBoxNew(txt184, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 5:
                                    SetTextBoxNew(txt185, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 6:
                                    SetTextBoxNew(txt186, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 7:
                                    SetTextBoxNew(txt187, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 8:
                                    SetTextBoxNew(txt188, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 9:
                                    SetTextBoxNew(txt189, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 10:
                                    SetTextBoxNew(txt1810, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
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
                                    SetTextBoxNew(txt191, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 2:
                                    SetTextBoxNew(txt192, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 3:
                                    SetTextBoxNew(txt193, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 4:
                                    SetTextBoxNew(txt194, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 5:
                                    SetTextBoxNew(txt195, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 6:
                                    SetTextBoxNew(txt196, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 7:
                                    SetTextBoxNew(txt197, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 8:
                                    SetTextBoxNew(txt198, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 9:
                                    SetTextBoxNew(txt199, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
                                    break;

                                case 10:
                                    SetTextBoxNew(txt1910, bookID, status, timeBook, shortDes1, shortDes2, FullDecriptions, hour, slot);
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

            txt91.BackColor = Color.White; ;
            txt92.BackColor = Color.White; ;
            txt93.BackColor = Color.White; ;
            txt94.BackColor = Color.White; ;
            txt95.BackColor = Color.White; ;
            txt96.BackColor = Color.White; ;
            txt97.BackColor = Color.White; ;
            txt98.BackColor = Color.White; ;
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
                    else //if (!string.IsNullOrEmpty(errorMesg))
                    {
                        MessageBox.Show("Exists bill of customer unpaid.", "Error");
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
                else if (headerText == "ReBook")
                {
                    if (!NailApp.lstPermission.Contains(BOOKING_ADD_CMDKEY) && !NailApp.IsAdmin())
                    {
                        MessageBox.Show("Unauthorized", "Information");
                        return;
                    }
                    Process.frmBookingAdd frmSerAdd = new Process.frmBookingAdd(int.Parse(NailApp.BranchID), "", "", bookIDSelect, "ReBook", null);
                    frmSerAdd.ShowDialog();
                    int iResult = frmSerAdd.SendData();
                    if (iResult != 0)
                    {
                        LoadDataBoking();
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

        private void TextBox_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                RichTextBox tb = sender as RichTextBox;
                if (tb == null)
                {
                    _tagsBookID = "";
                    _tagsStatus = "";
                }
                else if (tb.Tag != null)
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

        private void reBookMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string args = _tagsBookID;
                if (!string.IsNullOrWhiteSpace(_tagsBookID))
                {
                    //if (_tagsStatus == "Temporary" || _tagsStatus == "Cancel")
                    //{
                    ActionBooking(int.Parse(_tagsBookID), "ReBook");

                    //}
                    //else
                    //{
                    //    MessageBox.Show("Status different Temporary or Cancel cannot Edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
