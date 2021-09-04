using AusNail.Dictionary;
using AusNail.Login;
using AusNail.Process;
using CoreBase;
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

namespace AusNail
{
    public partial class frmMainParent : Form
    {
        public frmMainParent()
        {
            InitializeComponent();
        }

        private void frmMainParent_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
                tabForms.Visible = false; // If no any child form, hide tabControl
            else
            {
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized; // Child form always maximized

                // If child form is new and no has tabPage, create new tabPage
                if (this.ActiveMdiChild.Tag == null)
                {

                    // Add a tabPage to tabControl with child form caption
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = tabForms;
                    tabForms.SelectedTab = tp;
                    this.ActiveMdiChild.Tag = tp;

                    this.ActiveMdiChild.FormClosed += new FormClosedEventHandler(ActiveMdiChild_FormClosed);
                }

                if (!tabForms.Visible) tabForms.Visible = true;
            }
        }

        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        private void tabForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((tabForms.SelectedTab != null) && (tabForms.SelectedTab.Tag != null))
                    (tabForms.SelectedTab.Tag as Form).Select();
            }
            catch 
            {
            }
        }

        private void frmMainParent_Load(object sender, EventArgs e)
        {
            frmLogin lf = new frmLogin();
            if (lf.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
                return;
            }
            else
            {
                ////Load permisson
                NailApp.lstPermission = new List<string>();
                NailApp.lstPermission = NailApp.PermissionUser.Split(',').ToList();
                InitCommandOld();

                frmMain f1 = new frmMain();
                f1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                f1.MdiParent = this;
                f1.Show();

            }
        }

        void InitCommandOld()
        {
            InitCommandDm();
            InitCommandPS();
            InitCommandST();
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

            if (NailApp.lstPermission.Contains(Booking.Name) || NailApp.IsAdmin())
                Booking.Click += (s, e) => { frmBooking(); };
            else
                Booking.Visible = false;
        }

        void InitCommandST()
        {
            if (NailApp.IsAdmin())
                User.Click += (s, e) => { frmUser(); };
            else
                User.Visible = false;

        }

        void frmUser()
        {
            frmUser f1 = new frmUser();
            if (!checkForm(f1))
            {
                f1.MdiParent = this;
                f1.Show();
            }
        }

        void frmBooking()
        {
            frmBookingFilter form = new frmBookingFilter();
            form.ShowDialog();
            string sResult = form.SendData();

            List<string> lstResult = new List<string>();
            if (sResult != null && !string.IsNullOrWhiteSpace(sResult))
            {
                lstResult = sResult.Split('|').ToList();
            }

            if (lstResult != null && lstResult.Count > 1) // Add Service
            {
                DateTime dt;
                //DateTime.TryParse(lstResult[0].ToString().Trim(), out dt);
                DateTime.TryParseExact(lstResult[0].ToString(), "dd/MM/yyyy",
                           CultureInfo.InvariantCulture,
                           DateTimeStyles.None,
                           out dt);
                if (dt != null)
                {
                    frmBooking frmBook = new frmBooking(dt, int.Parse(lstResult[1].ToString().Trim()));
                    if (!checkForm(frmBook))
                    {
                        frmBook.MdiParent = this;
                        frmBook.Show();
                    }
                }

            }
        }

        void frmBranch()
        {
            frmBranch f = new frmBranch();
            if (!checkForm(f))
            {
                f.MdiParent = this;
                f.Show();
            }
        }

        void frmCustomer()
        {
            frmCustomer f = new frmCustomer();
            if (!checkForm(f))
            {
                f.MdiParent = this;
                f.Show();
            }
        }

        void frmService()
        {
            frmService f = new frmService();
            if (!checkForm(f))
            {
                f.MdiParent = this;
                f.Show();
            }
        }

        void frmStaff()
        {
            frmStaff f = new frmStaff();
            if (!checkForm(f))
            {
                f.MdiParent = this;
                f.Show();
            }
        }

        void frmHoliday()
        {
            frmHoliday f = new frmHoliday();
            if (!checkForm(f))
            {
                f.MdiParent = this;
                f.Show();
            }
        }

        void frmVoucher()
        {
            frmVoucher f = new frmVoucher();
            if (!checkForm(f))
            {
                f.MdiParent = this;
                f.Show();
            }
        }

        void frmBusinessHour()
        {
            frmBusinessHour f = new frmBusinessHour();
            if (!checkForm(f))
            {
                f.MdiParent = this;
                f.Show();
            }
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword f = new frmChangePassword();
            if (!checkForm(f))
            {
                f.MdiParent = this;
                f.Show();
            }
        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure ?", "Logoff", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                frmLogin lf = new frmLogin();
                if (lf.ShowDialog() != DialogResult.OK)
                {
                    Application.Exit();
                    return;
                }
                else
                {
                    ////Load permisson
                    NailApp.lstPermission = new List<string>();
                    NailApp.lstPermission = NailApp.PermissionUser.Split(',').ToList();
                    InitCommandOld();
                }

            }
        }

        private void dBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoreBase.WinForm.DevopsAuth devopsAuth = new CoreBase.WinForm.DevopsAuth();
            devopsAuth.ShowDialog();
            if (devopsAuth.DialogResult == DialogResult.OK)
            {
                CoreBase.WinForm.frmDataBaseSetting frm = new CoreBase.WinForm.frmDataBaseSetting();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You are not Devops.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private bool checkForm(Form f)
        {
            bool flag = false;
            for (int i = 0; i < tabForms.TabCount; i++)
            {
                if (tabForms.TabPages[i].Text.Contains(f.Text))
                {
                    flag = true;
                    tabForms.SelectedIndex = i;
                }
            }
            return flag;
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain f1 = new frmMain();
            if (!checkForm(f1))
            {
                f1.MdiParent = this;
                f1.Show();
            }
        }
    }
}
