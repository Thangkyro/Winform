﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreBase;
using CoreBase.Helpers;
using CoreBase.DataAccessLayer;
using AusNail.Dictionary;
using AusNail.Login;

namespace AusNail
{
    public partial class frmMain : Form
    {
        private int _branchID;
        private int _userID;
        //public frmMain()
        //{
        //    InitializeComponent();
            
        //}

        public delegate void SendMessage(int branchid, int userid);
        public SendMessage Sender; public frmMain()
        {
            InitializeComponent();
            //Tạo con trỏ tới hàm GetMessage
            Sender = new SendMessage(GetMessage);
            //Hàm có nhiệm vụ lấy tham số truyền vào
            //Login.frmLogin frm = new Login.frmLogin();
            //ShowForm(frm);
            //LoadMenu();
            InitCommandOld();
        }   
        private void GetMessage(int branchid, int userid)
        {
            _branchID = branchid;
            _userID = userid;
        }

        //public frmMain()
        //{
        //    InitializeComponent();
        //    _branchID = branchID;
        //    _userID = userId;
        //    //LoadMenu();
        //}

        private void LoadMenu()
        {
            trvMenu.Nodes.Add("Customer");
            trvMenu.Nodes.Add("Employee");
            trvMenu.Nodes.Add("Holiday");
            trvMenu.Nodes.Add("Service");
            trvMenu.Nodes.Add("WorkShift");
        }

        public void ShowForm(Form frm)
        {
            //foreach (Form f in pnlForm.Controls)
            //{
            //    f.Close();
            //}
            frm.TopLevel = false;
            if (pnlForm.Controls.ContainsKey(frm.Name))
            {

            }
            else
            {
                pnlForm.Controls.Add(frm);
                if (formBorToolStripMenuItem.Checked)
                {
                    frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                }
                frm.Dock = DockStyle.Fill;
                frm.TopMost = true;
                frm.Show();
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AusNail.Dictionary.frmUser frm = new AusNail.Dictionary.frmUser();
            ShowForm(frm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.frmCheckin frm = new Process.frmCheckin(int.Parse(NailApp.BranchID), NailApp.CurrentUserId);
            ShowForm(frm);
        }

        private void txtSearchMenu_Leave(object sender, EventArgs e)
        {
            if (txtSearchMenu.Text == "")
            {
                txtSearchMenu.Text = "Please Enter Search Key";
                txtSearchMenu.ForeColor = Color.Gray;
            }
        }

        private void txtSearchMenu_Enter(object sender, EventArgs e)
        {
            if (txtSearchMenu.Text == "Please Enter Search Key")
            {
                txtSearchMenu.Text = "";
                txtSearchMenu.ForeColor = Color.Black;
            }
        }

        void InitCommandOld()
        {
            InitCommandDm();
            //InitCommandCs();
            //InitCommandPs();
            //InitCommandBc();
            //InitCommandSys();
            //InitCommandQuyDinh();

        }

        void InitCommandDm()
        {
            //category
            if (NailApp.lstPermission.Contains(Branch.Name) || NailApp.IsAdmin())
                Branch.Click += (s, e) => { frmBranch(); };
            else
                Branch.Visible = false;

            if (NailApp.lstPermission.Contains(Customer.Name) || NailApp.IsAdmin())
                Customer.Click += (s, e) => { frmCustomer(); };
            else
                Customer.Visible = false;


            if (NailApp.lstPermission.Contains(Service.Name) || NailApp.IsAdmin())
                Service.Click += (s, e) => { frmService(); };
            else
                Service.Visible = false;


            if (NailApp.lstPermission.Contains(Staff.Name) || NailApp.IsAdmin())
                Staff.Click += (s, e) => { frmStaff(); };
            else
                Staff.Visible = false;


            if (NailApp.lstPermission.Contains(Holiday.Name) || NailApp.IsAdmin())
                Holiday.Click += (s, e) => { frmHoliday(); };
            else
                Holiday.Visible = false;

            if (NailApp.lstPermission.Contains(Voucher.Name) || NailApp.IsAdmin())
                Voucher.Click += (s, e) => { frmVoucher(); };
            else
                Voucher.Visible = false;

            if (NailApp.lstPermission.Contains(BusinessHour.Name) || NailApp.IsAdmin())
                BusinessHour.Click += (s, e) => { frmBusinessHour(); };
            else
                BusinessHour.Visible = false;

        }

        void InitCommandPS()
        {
            //category
            if (NailApp.lstPermission.Contains(Booking.Name) || NailApp.IsAdmin())
                Booking.Click += (s, e) => { frmBooking(); };
            else
                Booking.Visible = false;

            //if (NailApp.lstPermission.Contains(Bill.Name) || NailApp.IsAdmin())
            //    Bill.Click += (s, e) => { frmBill(); };
            //else
            //    Bill.Visible = false;

            //if (NailApp.lstPermission.Contains(TimeKeeping.Name) || NailApp.IsAdmin())
            //    TimeKeeping.Click += (s, e) => { frmTimeKeeping(); };
            //else
            //    TimeKeeping.Visible = false;
        }


        #region Category
        void DoDmKhAdd()
        {
            if (!NailApp.lstPermission.Contains("Branch"))
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này.",MessageType.Warning.ToString(),MessageBoxButtons.OKCancel);
                return;
            }

            frmBranch frmBranch = new frmBranch();
            if (frmBranch.AddNew())
                MessageBox.Show(string.Format("Thêm thành công khách hàng [{0}].", frmBranch.zEditRow["ten_kh"]));
        }

        void frmBranch()
        {
            frmBranch f = new frmBranch();
            ShowForm(f);
            //f.ShowDialog();
        }

        void frmCustomer()
        {
            frmCustomer f = new frmCustomer();
            ShowForm(f);
            //f.ShowDialog();
        }

        void frmService()
        {
            frmService f = new frmService();
            ShowForm(f);
            //f.ShowDialog();
        }

        void frmStaff()
        {
            frmStaff f = new frmStaff();
            ShowForm(f);
            //f.ShowDialog();
        }

        void frmHoliday()
        {
            frmHoliday f = new frmHoliday();
            ShowForm(f);
            //f.ShowDialog();
        }

        void frmVoucher()
        {
            frmVoucher f = new frmVoucher();
            ShowForm(f);
            //f.ShowDialog();
        }

        void frmBusinessHour()
        {
            frmBusinessHour f = new frmBusinessHour();
            ShowForm(f);
            //f.ShowDialog();
        }
        #endregion

        #region Process
        void frmBooking()
        {
            //frmBooking f = new frmBranch();
            //ShowForm(f);
            //f.ShowDialog();
        }

        #endregion

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword f = new frmChangePassword();
            ShowForm(f);
        }

        private void checkingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Process.frmCheckin frm = new Process.frmCheckin(int.Parse(NailApp.BranchID), NailApp.CurrentUserId, "Book");
            ShowForm(frm);
        }

        private void Bill_Click(object sender, EventArgs e)
        {
            Process.frmCheckin frm = new Process.frmCheckin(int.Parse(NailApp.BranchID), NailApp.CurrentUserId, "Bill");
            ShowForm(frm);
        }
    }
}
