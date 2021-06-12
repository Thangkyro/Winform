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
        private int _billID;
        private int _branchID;
        private int _userID;
        //public frmMain()
        //{
        //    InitializeComponent();

        //}

        public delegate void SendMessage(int branchid, int userid);
        public frmMain()
        {
            InitializeComponent();
            try
            {
                splitContainer1.BackColor = NailApp.ColorUser;
            }
            catch 
            {
            }
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
           
        }

        public void LoadHistory()
        {
            try
            {
                trHistoryBill.Nodes.Clear();
                DataTable dt = null;
                // Load booking
                dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillMasterGetList_AllComplete", int.Parse(NailApp.BranchID));
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        trHistoryBill.ImageList = imageList1;
                        string infor = dr["BillCode"].ToString() + " - " + dr["CustomerPhone"].ToString();
                        TreeNode note = new TreeNode();
                        note.Text = infor;
                        note.Tag = dr["BookID"].ToString();
                        trHistoryBill.Nodes.Add(note);
                    }
                }
                else
                {
                    TreeNode note = new TreeNode();
                    note.Text = "No historical data.";
                    note.Tag = "-1";
                    trHistoryBill.Nodes.Add(note);
                }

                // Load temporary bill
                trTemporaryBill.Nodes.Clear();
                dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillMasterGetList_AllTemporaty", int.Parse(NailApp.BranchID));
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        trTemporaryBill.ImageList = imageList1;
                        string infor = dr["BillCode"].ToString() + " - " + dr["CustomerPhone"].ToString();
                        TreeNode note = new TreeNode();
                        note.Text = infor;
                        note.Tag = dr["BillID"].ToString();
                        trTemporaryBill.Nodes.Add(note);
                    }
                }
                else
                {
                    TreeNode note = new TreeNode();
                    note.Text = "No historical data.";
                    note.Tag = "-1";
                    trTemporaryBill.Nodes.Add(note);
                }

            }
            catch
            { }
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
                //pnlForm.Controls.Clear();
                if (pnlForm.Controls.Count > 0)
                {
                    foreach (Form item in pnlForm.Controls)
                    {
                        if (!item.Name.Equals(frm.Name))
                        {
                            item.WindowState = FormWindowState.Minimized;

                        }
                        else
                        {
                            item.WindowState = FormWindowState.Maximized;
                            item.Dock = DockStyle.Fill;
                            item.TopMost = true;
                            item.Show();
                        }
                    }
                    //frm.Show();
                }
            }
            else
            {
                if (pnlForm.Controls.Count > 0)
                {
                    //foreach (Form item in pnlForm.Controls)
                    //{
                    //    //item.TopMost = false;
                    //    item.WindowState = FormWindowState.Minimized;
                    //}
                }
                pnlForm.Controls.Add(frm);
                if (formBorToolStripMenuItem.Checked)
                {
                    frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                }
                frm.Dock = DockStyle.Fill;
                frm.WindowState = FormWindowState.Maximized;
                frm.TopMost = true;
                frm.Show();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AusNail.Dictionary.frmUser frm = new AusNail.Dictionary.frmUser();
            //ShowForm(frm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.frmCheckin frm = new Process.frmCheckin(int.Parse(NailApp.BranchID), NailApp.CurrentUserId);
            ShowForm(frm);
        }

        private void txtSearchMenu_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtSearchMenu_Enter(object sender, EventArgs e)
        {
           
        }

        void InitCommandOld()
        {
            InitCommandDm();
            //InitCommandCs();
            //InitCommandPs();
            //InitCommandBc();
            //InitCommandSys();
            //InitCommandQuyDinh();
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
            //category
            //if (NailApp.lstPermission.Contains(Booking.Name) || NailApp.IsAdmin())
            //    Booking.Click += (s, e) => { frmBooking(); };
            //else
            //    Booking.Visible = false;

            //if (NailApp.lstPermission.Contains(Bill.Name) || NailApp.IsAdmin())
            //    Bill.Click += (s, e) => { frmBill(); };
            //else
            //    Bill.Visible = false;

            //if (NailApp.lstPermission.Contains(TimeKeeping.Name) || NailApp.IsAdmin())
            //    TimeKeeping.Click += (s, e) => { frmTimeKeeping(); };
            //else
            //    TimeKeeping.Visible = false;
        }

        void InitCommandST()
        {
            //category
            if (NailApp.IsAdmin())
                User.Click += (s, e) => { frmUser(); };
            else
                User.Visible = false;

        }


        #region Category
        void DoDmKhAdd()
        {
            if (!NailApp.lstPermission.Contains("Branch"))
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này.", MessageType.Warning.ToString(), MessageBoxButtons.OKCancel);
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

        #region Setting
        void frmUser()
        {
            frmUser f = new frmUser();
            ShowForm(f);
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
            Process.frmBill frm = new Process.frmBill(int.Parse(NailApp.BranchID), NailApp.CurrentUserId);
            ShowForm(frm);
        }

        private void LogoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure ?", "Logoff", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (pnlForm.Controls.Count > 0)
                {
                    //foreach (var item in pnlForm.Controls.OfType<Form>())
                    //{
                    //    item.Close();
                    //}
                    pnlForm.Controls.Clear();
                }

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

        private void FrmMain_Load(object sender, EventArgs e)
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

                //Load colorList for combobox
                if (cboColor.Items.Count == 0)
                {
                    //foreach (string item in ThemeColor.ColorList)
                    //{
                    //    cboColor.Items.Add()
                    //}
                    cboColor.DataSource = ThemeColor.ColorList;
                }

                LoadHistory();

                Process.frmCheckPhone frm = new Process.frmCheckPhone(int.Parse(NailApp.BranchID), NailApp.CurrentUserId);
                frm.TopMost = true;
                frm.Show();

            }
        }

        private void BtnSetColor_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you wanna change theme color ?", "Change Theme Color", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (cboColor.SelectedValue != null)
                {
                    Color color = ColorTranslator.FromHtml(cboColor.SelectedValue.ToString());
                    splitContainer1.BackColor = color;
                    splitContainer2.BackColor = color;
                    txtColor.Br = color;
                    //Update color for user
                    string sql = "UPDATE zUser SET ColorUser = '" + cboColor.SelectedValue.ToString() + "' WHERE Userid = " + NailApp.CurrentUserId;
                    int i = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, CommandType.Text, sql);
                }
            }
        }

        private void CboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboColor.SelectedValue != null)
            {
                Color color = ColorTranslator.FromHtml(cboColor.SelectedValue.ToString());
                //splitContainer1.BackColor = color;
                txtColor.Br = color;
            }
        }

        private void butCheckphone_Click(object sender, EventArgs e)
        {
            Process.frmCheckPhone frm = new Process.frmCheckPhone(int.Parse(NailApp.BranchID), NailApp.CurrentUserId);
            frm.TopMost = true;
            frm.Show();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Process.frmCheckPhone frm = new Process.frmCheckPhone(int.Parse(NailApp.BranchID), NailApp.CurrentUserId);
                frm.TopMost = true;
                frm.Show();
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Process.frmCusstomerAdd frm = new Process.frmCusstomerAdd(int.Parse(NailApp.BranchID), NailApp.CurrentUserId, "");
            frm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void loadBillInfor(int billID)
        {
            try
            {
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillMasterGetInfor", billID, int.Parse(NailApp.BranchID));
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtBillCode.Text = dt.Rows[0]["BillCode"].ToString();
                    txtBilDate.Text = DateTime.Parse(dt.Rows[0]["BillDate"].ToString()).ToString("dd/MM/yyyy");
                    txtCustomerName.Text = dt.Rows[0]["Cusstomername"].ToString();
                    txtPhone.Text = dt.Rows[0]["CustomerPhone"].ToString();
                    txtGenden.Text = dt.Rows[0]["Gender"].ToString();
                }
            }
            catch
            {
            }
        }
        private void loadGridDetail_Bill(int billId)
        {
            dgvService.Rows.Clear();
            DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillDetailGetList_History", billId, int.Parse(NailApp.BranchID));
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int num = i + 1;
                    string servicename = dt.Rows[i]["ServiceName"].ToString();
                    string staffName = dt.Rows[i]["StaffName"].ToString();
                    string staffId = dt.Rows[i]["StaffId"].ToString();
                    decimal price = decimal.Parse(dt.Rows[i]["Price"].ToString());
                    decimal quantity = decimal.Parse(dt.Rows[i]["Quantity"].ToString());
                    decimal Amount = decimal.Parse(dt.Rows[i]["Amout"].ToString());
                    string serviceId = dt.Rows[i]["ServiceID"].ToString();
                    string note = dt.Rows[i]["Note"].ToString();
                    decimal discount = decimal.Parse(dt.Rows[i]["Discount"].ToString());
                    object[] row = { num, staffName, servicename, quantity, price, Amount, discount, note, serviceId, staffId };
                    dgvService.Rows.Add(row);
                }
            }
            //_totalAmount = decimal.Parse(dt.Compute("Sum(Amout)", string.Empty).ToString());
            //lbl_R_Total.Text = string.Format("{0:#,##0.00}", _totalAmount);
            //btnRegister.Text = "Pay";
        }
        private void trTemporaryBill_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                _billID = int.Parse(trTemporaryBill.SelectedNode.Tag.ToString());
                loadBillInfor(_billID);
                loadGridDetail_Bill(_billID);
            }
            catch (Exception ex)
            {
            }
        }

        private void trTemporaryBill_Click(object sender, EventArgs e)
        {
            try
            {
                _billID = int.Parse(trTemporaryBill.SelectedNode.Tag.ToString());
                loadBillInfor(_billID);
                loadGridDetail_Bill(_billID);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
