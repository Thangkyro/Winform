﻿using AusNail.Login;
using CoreBase;
using CoreBase.DataAccessLayer;
using CoreBase.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AusNail.Process
{
    public partial class frmCheckPhone : Form
    {
        public int _branchId = 0;
        public int _UserId = 0;
        private DataTable _dtCustomer = null;
        private string sResult = "";
        private bool _firtRun = false;
        private DataTable _dtBanner = null;
        private int _bannerCount = 1;
        private  System.Windows.Forms.Timer _MyTimer;
        private int _rePrintID = -1;
        private string sBillCode = "";

        public frmCheckPhone()
        {
            InitializeComponent();
            txtPhone.Focus();
            this.pnSDT.Visible = true;
        }

        public frmCheckPhone(bool firtRun)
        {
            InitializeComponent();
            txtPhone.Focus();
            this.pnSDT.Visible = true;
            _firtRun = firtRun;

            this.BackColor = NailApp.ColorUser.IsEmpty == true || NailApp.ColorUser.Name == "0" ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
        }

        public frmCheckPhone(int branchId, int userId)
        {
            InitializeComponent();
            _branchId = branchId;
            _UserId = userId;
            txtPhone.Focus();
            this.BackColor = NailApp.ColorUser.IsEmpty == true || NailApp.ColorUser.Name == "0" ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và các thao tác xóa, tiến lùi... Không nhập text.
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

            // Sự kiện bấm Enter
            if (e.KeyChar == 13)
            {
                btnConfirm_Click(sender, e);
            }
        }

        public string SendData()
        {
            return sResult;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text.Trim() == "")
            {
                MessageBox.Show("Please input phone number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhone.Clear();
                return;
            }
            else
            {

                // Check bill exist.
                if (txtPhone.Text.Trim() != "000" && checkExiestBill(_branchId, txtPhone.Text.Trim()))
                {
                    MessageBox.Show("Sorry, Bill existed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhone.Clear();
                    return;
                }

                // Kiểm tra tính hợp lệ của số điện thoại
                if (checkExiestCustomer(txtPhone.Text.Trim()))
                {
                    //this.Visible = false;
                    //this.ShowInTaskbar = false;
                    frmServiceAddVer1 frm = new frmServiceAddVer1(_branchId, _UserId, _dtCustomer.Rows[0]["Name"].ToString(), txtPhone.Text.Trim());
                    frm.ShowDialog();
                    sBillCode = frm.SendBillCode();
                }
                else
                {
                    //this.Visible = false;
                    //this.ShowInTaskbar = false;
                    frmCusstomerAdd frm = new frmCusstomerAdd(_branchId, _UserId, txtPhone.Text.Trim());
                    frm.ShowDialog();
                    //sResult = txtPhone.Text.Trim();
                }
                txtPhone.Clear();
            }
            //this.Close();
        }
        private bool checkExiestCustomer(string phoneNumber)
        {
            try
            {
                _dtCustomer = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zCustomerGetbyPhoneNum", phoneNumber);
                //if (_dtCustomer.Select("branchId = " + NailApp.BranchID, "").Length == 0)
                //{
                //    _dtCustomer.Rows.RemoveAt(0);
                //}
            }
            catch
            {}
            return !(_dtCustomer == null || _dtCustomer.Rows.Count == 0);
        }

        private bool checkExiestBill(int branchId, string phoneNumber)
        {
            try
            {
                _dtCustomer = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zCheckBillExists", branchId, phoneNumber, DateTime.Now.AddHours(NailApp.TimeConfig));
            }
            catch
            { }
            return !(_dtCustomer == null || _dtCustomer.Rows.Count == 0);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPhone.Clear();
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            // Sự kiện bấm Enter
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm_Click(sender, e);
            }
        }

        private void frmCheckPhone_Load(object sender, EventArgs e)
        {
            if (_firtRun)
            {
                frmLogin lf = new frmLogin();
                if (lf.ShowDialog() != DialogResult.OK)
                {
                    Application.Exit();
                    return;
                }
                else
                {
                    _branchId = int.Parse(NailApp.BranchID);
                    _UserId = NailApp.CurrentUserId;

                    txtPhone.Focus();
                    txtPhone.Select();
                    //this.Width = 370;
                    //this.Height = 170;
                    //this.pnSDT.Visible = false;
                    //this.pnSDT.Visible = false;
                    this.pnSDT.Visible = true;

                    ////Load permisson
                    NailApp.lstPermission = new List<string>();
                    NailApp.lstPermission = NailApp.PermissionUser.Split(',').ToList();
                }
            }
            else
            {
                _branchId = int.Parse(NailApp.BranchID);
                _UserId = NailApp.CurrentUserId;

                txtPhone.Focus();
                txtPhone.Select();
                //this.Width = 370;
                //this.Height = 170;
                //this.pnSDT.Visible = false;
                //this.pnSDT.Visible = false;
                this.pnSDT.Visible = true;
            }
            //this.BackColor = NailApp.ColorUser.IsEmpty == true || NailApp.ColorUser.Name == "0" ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
            
            loadBanner();
            lbText1.Text = NailApp.Titlebranch;

            Thread thread = new Thread(new ThreadStart(LoadBackgorund));
            thread.Start();

            _MyTimer = new System.Windows.Forms.Timer();
            _MyTimer.Interval = (int.Parse(txtSecond.Value.ToString()) * 1000); 
            _MyTimer.Tick += new EventHandler(MyTimer_Tick);
            _MyTimer.Start();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = 0;
            if (txtPhone.Text.Trim() != "")
            {
                lastControl = txtPhone.SelectionStart;
            }
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "1" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = 0;
            if (txtPhone.Text.Trim() != "")
            {
                lastControl = txtPhone.SelectionStart;
            }
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "2" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = 0;
            if (txtPhone.Text.Trim() != "")
            {
                lastControl = txtPhone.SelectionStart;
            }
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "3" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = 0;
            if (txtPhone.Text.Trim() != "")
            {
                lastControl = txtPhone.SelectionStart;
            }
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "4" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = 0;
            if (txtPhone.Text.Trim() != "")
            {
                lastControl = txtPhone.SelectionStart;
            }
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "5" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = 0;
            if (txtPhone.Text.Trim() != "")
            {
                lastControl = txtPhone.SelectionStart;
            }
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "6" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = 0;
            if (txtPhone.Text.Trim() != "")
            {
                lastControl = txtPhone.SelectionStart;
            }
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "7" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = 0;
            if (txtPhone.Text.Trim() != "")
            {
                lastControl = txtPhone.SelectionStart;
            }
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "8" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = 0;
            if (txtPhone.Text.Trim() != "")
            {
                lastControl = txtPhone.SelectionStart;
            }
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "9" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            string strleft = "";
            string strright = "";
            int lastControl = 0;
            if (txtPhone.Text.Trim() != "")
            {
                lastControl = txtPhone.SelectionStart;
            }
            string strPhone = txtPhone.Text.Trim();
            strleft = strPhone.Substring(0, lastControl);
            strright = strPhone.Substring(lastControl, strPhone.Length - lastControl);
            strPhone = strleft + "0" + strright;
            txtPhone.Text = strPhone;
            txtPhone.SelectionStart = lastControl + 1;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                string strPhone = txtPhone.Text.Trim();
                int control = txtPhone.SelectionStart;
                if (control > 0)
                {
                    strPhone = strPhone.Substring(0, control - 1) + strPhone.Substring(control, strPhone.Length - control);
                    txtPhone.Text = strPhone;
                    txtPhone.SelectionStart = control - 1;
                }
            }
            catch (Exception ex)
            {
            }
            
        }

        private void loadBanner()
        {
            try
            {
                _dtBanner = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGetBannerInfo", _branchId);
                _bannerCount = _dtBanner.Rows.Count;
            }
            catch
            { }
        }

        private void loadTextBanner()
        {
            // For banner
            // Set text2 voi banner co stt = 1
            // Set text3 voi banner co stt = 2
            // Set text4 voi banner co stt = 3
            // Kiem tra neu stt >  count(banner) thi reset stt = 1 nguoc lai se tang stt = stt + 1 
            // End for
            lbText1.Text = NailApp.Titlebranch;
            foreach (DataRow dr in _dtBanner.Rows)
            {
                if (dr["STT"].ToString() == "1")
                {
                    lblText2.Text = dr["BannerText"].ToString();
                }
                if (dr["STT"].ToString() == "2")
                {
                    lblText3.Text = dr["BannerText"].ToString();
                }
                if (dr["STT"].ToString() == "3")
                {
                    lblText4.Text = dr["BannerText"].ToString();
                }
                if (int.Parse(dr["STT"].ToString()) < _bannerCount)
                {
                    dr["STT"] = int.Parse(dr["STT"].ToString()) + 1;
                }
                else
                {
                    dr["STT"] = 1;
                }
            }

            //=>> dung ticker goi ham nay
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            loadTextBanner();
        }

        private void txtSecond_ValueChanged(object sender, EventArgs e)
        {
            if (txtSecond.Value < 1)
            {
                txtSecond.Value = 1;
            }
            _MyTimer.Interval = (int.Parse(txtSecond.Value.ToString()) * 1000);
        }

        private void txtSecond_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            txtSecond.Enabled = !txtSecond.Enabled;
        }

        private void LoadBackgorund()
        {
            // Load BackgroundImage
            byte[] getImg = new byte[0];
            getImg = (byte[])NailApp.Imagebranch;
            byte[] imgData = getImg;
            MemoryStream stream = new MemoryStream(imgData);
            this.BackgroundImage = Image.FromStream(stream);
        }

        private void frmCheckPhone_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmCheckPhone_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            int billID = 0;
            DataTable dtBill = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, "Select TOP 1 BillID From zBillMaster WITH(NOLOCK) Where BillCode = '" + sBillCode + "'");
            if (dtBill != null && dtBill.Rows.Count > 0)
            {
                billID = int.Parse(dtBill.Rows[0][0].ToString());
            }
            if (NailApp.IsAutoPrint())
            {
                DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillPrint", billID, int.Parse(NailApp.BranchID));
                DataSet dsData = new DataSet();
                dsData.Tables.Add(dataTable);
                if (dsData == null || dsData.Tables[0].Rows.Count == 0)
                {
                    return;
                }
                frmPrintNew f = new frmPrintNew(dsData, "rpt_bill.rpt", false, int.Parse(NailApp.BranchID), billID);
                f.ShowDialog();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want print review ?", "View Bill", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillPrint", billID, int.Parse(NailApp.BranchID));
                    DataSet dsData = new DataSet();
                    dsData.Tables.Add(dataTable);
                    if (dsData == null || dsData.Tables[0].Rows.Count == 0)
                    {
                        return;
                    }
                    frmPrintNew f = new frmPrintNew(dsData, "rpt_bill.rpt", true, int.Parse(NailApp.BranchID), billID);
                    f.ShowDialog();
                }
                else
                {
                    DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillPrint", billID, int.Parse(NailApp.BranchID));
                    DataSet dsData = new DataSet();
                    dsData.Tables.Add(dataTable);
                    if (dsData == null || dsData.Tables[0].Rows.Count == 0)
                    {
                        return;
                    }
                    frmPrintNew f = new frmPrintNew(dsData, "rpt_bill.rpt", false, int.Parse(NailApp.BranchID), billID);
                    f.ShowDialog();
                }
            }
        }
    }
}
