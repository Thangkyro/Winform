using System;
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
            Login.frmLogin frm = new Login.frmLogin();
            ShowForm(frm);
            LoadMenu();
        }   
        private void GetMessage(int branchid, int userid)
        {
            _branchID = branchid;
            _userID = userid;
        }

        public frmMain(int branchID, int userId)
        {
            InitializeComponent();
            _branchID = branchID;
            _userID = userId;
            LoadMenu();
        }

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
            pnlForm.Controls.Add(frm);
            if (formBorderStyleToolStripMenuItem.Checked)
            {
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AusNail.Dictionary.frmUser frm = new AusNail.Dictionary.frmUser();
            ShowForm(frm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.frmCheckin frm = new Process.frmCheckin();
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
    }
}
