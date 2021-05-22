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
        public frmMain()
        {
            InitializeComponent();
            //Login.Login frm = new Login.Login();
            //ShowForm(frm);
            //splitContainer1.Panel1.Enabled = frm.loginTrue;
            LoadMenu();
        }

        public frmMain(bool loginTrue) : this()
        {
            txtSearchMenu.Text = loginTrue.ToString();
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
            CoreBase.WinForm.Dictionary.HashKey frm = new CoreBase.WinForm.Dictionary.HashKey();
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
