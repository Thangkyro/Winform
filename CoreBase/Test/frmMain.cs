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
using AusNail.Dictionary;
using AusNail.Login;
using AusNail.Process;
using System.Globalization;

namespace AusNail
{
    public partial class frmMain : Form
    {
        private bool tabHistory = false;
        private int _billIDTemp = -1;
        private int _billIDTempOld = -1;
        private int _billIDHistory = -1;
        private int _billIDHistoryOld = -1;
        private int _branchID;
        private int _userID;
        private DataTable _Service = null;
        private DataTable _dtService = null;
        private DataTable _dtStaff = null;
        private decimal _totalAmount = 0;
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
                splitContainer1.BackColor = NailApp.ColorUser.IsEmpty == true ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
                splitContainer2.BackColor = NailApp.ColorUser.IsEmpty == true ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
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
                        note.Name = dr["BillID"].ToString();
                        note.Tag = dr["BillID"].ToString();
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
                        note.Name = dr["BillID"].ToString();
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


        void InitCommandOld()
        {
            InitCommandDm();
            //InitCommandCs();
            InitCommandPS();
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

            if (NailApp.lstPermission.Contains(Booking.Name) || NailApp.IsAdmin())
                Booking.Click += (s, e) => { frmBooking(); };
            else
                Booking.Visible = false;
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
                    ShowForm(frmBook);
                }
                
            }
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

        #region Event
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
                    if (cboColor.Items.Count == 0)
                    {
                        //foreach (string item in ThemeColor.ColorList)
                        //{
                        //    cboColor.Items.Add()
                        //}
                        cboColor.DataSource = ThemeColor.ColorList;
                    }
                    splitContainer1.BackColor = NailApp.ColorUser;
                    splitContainer2.BackColor = NailApp.ColorUser;
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
                splitContainer1.BackColor = NailApp.ColorUser;
                splitContainer2.BackColor = NailApp.ColorUser;

                LoadHistory();
                createTable();
                loadService();
                LoadGrid();

                //Process.frmCheckPhone frm = new Process.frmCheckPhone(int.Parse(NailApp.BranchID), NailApp.CurrentUserId);
                //frm.TopMost = true;
                //frm.Show();

                //Check Phone
                CheckService(true);
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
                    NailApp.ColorUser = color;
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
            //Process.frmCheckPhone frm = new Process.frmCheckPhone(int.Parse(NailApp.BranchID), NailApp.CurrentUserId);
            //frm.TopMost = true;
            //frm.Show();
            //Check Phone
            CheckService(true);
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
            //Process.frmCusstomerAdd frm = new Process.frmCusstomerAdd(int.Parse(NailApp.BranchID), NailApp.CurrentUserId, "");
            //frm.Show();

            CheckService(false);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void trTemporaryBill_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                tabHistory = false;
                _billIDTemp = int.Parse(trTemporaryBill.SelectedNode.Tag.ToString());
                loadBillInfor(_billIDTemp);
                loadGridDetail_Bill(_billIDTemp, true);
                btnSave.Enabled = true;
                TreeNode[] tns = trTemporaryBill.Nodes.Find(_billIDTemp.ToString(), true);
                if (tns.Length > 0)
                {
                    tns[0].BackColor = Color.LightSkyBlue;
                }
                if (_billIDTempOld != -1)
                {
                    TreeNode[] tnsOld = trTemporaryBill.Nodes.Find(_billIDTempOld.ToString(), true);
                    if (tnsOld.Length > 0)
                    {
                        tnsOld[0].BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void trTemporaryBill_Click(object sender, EventArgs e)
        {
            try
            {
                tabHistory = true;
                _billIDTemp = int.Parse(trTemporaryBill.SelectedNode.Tag.ToString());
                _billIDTempOld = int.Parse(trTemporaryBill.SelectedNode.Tag.ToString());
                loadBillInfor(_billIDTemp);
                loadGridDetail_Bill(_billIDTemp, true);
                btnSave.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void dgvService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return;
                }
                else
                {
                    if (e.ColumnIndex == 7 && dgvService.Enabled == true) //Delete 
                    {
                        dgvService.Rows.RemoveAt(e.RowIndex);
                        caculateAmount();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvService_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnPrint.Enabled = false;
                if (e.RowIndex > -1 && (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2))
                {
                    decimal Discount = 0;
                    decimal Quantity = 0;

                    decimal Price = 0;
                    try
                    {
                        Price = decimal.Parse(dgvService.Rows[e.RowIndex].Cells["Price"].Value.ToString());
                    }
                    catch
                    {
                        Price = 0;
                        dgvService.Rows[e.RowIndex].Cells["Price"].Value = 0;
                    }
                    try
                    {
                        Quantity = decimal.Parse(dgvService.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                    }
                    catch
                    {
                        Quantity = 0;
                        dgvService.Rows[e.RowIndex].Cells["Quantity"].Value = 0;
                    }
                    // Update row num
                    try
                    {
                        Discount = decimal.Parse(dgvService.Rows[e.RowIndex].Cells["Discount"].Value.ToString());
                    }
                    catch
                    {
                        Discount = 0;
                        dgvService.Rows[e.RowIndex].Cells["Discount"].Value = 0;
                    }
                    dgvService.Rows[e.RowIndex].Cells["Amount"].Value = Quantity * Price - Discount;
                }
                if (e.RowIndex > -1 && (e.ColumnIndex == 6))
                {
                    decimal Discount = 0;
                    string serviceId = dgvService.Rows[e.RowIndex].Cells["serviceId"].Value.ToString();
                    decimal Price = decimal.Parse(_dtService.Select("serviceId = " + serviceId, "")[0]["Price"].ToString());
                    dgvService.Rows[e.RowIndex].Cells["Price"].Value = Price;
                    dgvService.Rows[e.RowIndex].Cells["Quantity"].Value = 1;
                    // Update row num
                    try
                    {
                        Discount = decimal.Parse(dgvService.Rows[e.RowIndex].Cells["Discount"].Value.ToString());
                    }
                    catch
                    {
                        Discount = 0;
                        dgvService.Rows[e.RowIndex].Cells["Discount"].Value = 0;
                    }
                    dgvService.Rows[e.RowIndex].Cells["Amount"].Value = Price - Discount;
                }
                caculateAmount();
            }
            catch
            {
                dgvService.Rows[e.RowIndex].Cells["Amount"].Value = 0;
            }
            finally
            {
                try
                {
                    for (int i = 0; i < dgvService.RowCount - 1; i++)
                    {
                        if (dgvService.Rows[i].Cells["serviceId"].Value.ToString() == "")
                        {
                            dgvService.Rows.RemoveAt(i);
                        }
                    }
                    caculateAmount();
                }
                catch
                {
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillDetailDelete_Ver1", _billIDTemp, int.Parse(NailApp.BranchID), 0, "");
                SaveBill(_billIDTemp, "");
                btnPrint.Enabled = true;
            }
            catch
            {
            }

        }

        private void deeteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want delete bill?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillMasterDelete", _billIDTemp, int.Parse(NailApp.BranchID), 0, "");
                if (ret > 0)
                {
                    LoadHistory();
                    txtBilDate.Clear();
                    txtBillCode.Clear();
                    txtCustomerName.Clear();
                    txtPhone.Clear();
                    txtGenden.Clear();
                    dgvService.DataSource = null;
                }
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnPay.Text == "Pay")
                {
                    decimal totalAmount = 0;
                    for (int i = 0; i < dgvService.Rows.Count; i++)
                    {
                        if (dgvService.Rows[i].Cells["ServiceId"].Value != null)
                        {
                            totalAmount += decimal.Parse(dgvService.Rows[i].Cells["Amount"].Value.ToString());
                        }
                    }
                    Process.frmPay frm = new Process.frmPay(int.Parse(NailApp.BranchID), -1, _billIDTemp, totalAmount, NailApp.CurrentUserId);
                    frm.Activate();
                    frm.ShowDialog();

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        LoadHistory();
                        txtBilDate.Clear();
                        txtBillCode.Clear();
                        txtCustomerName.Clear();
                        txtPhone.Clear();
                        txtGenden.Clear();
                        _totalAmount = 0;
                        lblTotalAmont.Text = "0";
                        dgvService.DataSource = null;

                        _billIDHistory = _billIDHistoryOld = _billIDTemp;
                        TreeNode[] tns = trHistoryBill.Nodes.Find(_billIDHistory.ToString(), true);
                        if (tns.Length > 0)
                        {
                            tns[0].BackColor = Color.LightSkyBlue;
                        }
                        trTemporaryBill.SelectedNode = trTemporaryBill.Nodes[0];
                        _billIDTempOld = _billIDTemp;
                        TreeNode[] tns1 = trTemporaryBill.Nodes.Find(_billIDTemp.ToString(), true);
                        if (tns1.Length > 0)
                        {
                            tns1[0].BackColor = Color.LightSkyBlue;
                        }
                    }
                }
                else // UnPaid
                {
                    int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillUnPaidUpdate", _billIDHistory, int.Parse(NailApp.BranchID), NailApp.CurrentUserId, 0, "");
                    if (ret > 0)
                    {
                        LoadHistory();
                        txtBilDate.Clear();
                        txtBillCode.Clear();
                        txtCustomerName.Clear();
                        txtPhone.Clear();
                        txtGenden.Clear();
                        _totalAmount = 0;
                        lblTotalAmont.Text = "0";
                        dgvService.DataSource = null;
                        
                        _billIDTemp = _billIDTempOld = _billIDHistory;
                        TreeNode[] tns = trTemporaryBill.Nodes.Find(_billIDTemp.ToString(), true);
                        if (tns.Length > 0)
                        {
                            tns[0].BackColor = Color.LightSkyBlue;
                        }
                        trHistoryBill.SelectedNode = trHistoryBill.Nodes[0];
                        _billIDHistoryOld = _billIDHistory;
                        TreeNode[] tns1 = trHistoryBill.Nodes.Find(_billIDHistory.ToString(), true);
                        if (tns1.Length > 0)
                        {
                            tns1[0].BackColor = Color.LightSkyBlue;
                        }
                    }
                    else
                    {
                        MessageBox.Show("UnPaid faill.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void trHistoryBill_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                tabHistory = true;
                _billIDHistory = int.Parse(trHistoryBill.SelectedNode.Tag.ToString());
                loadBillInfor(_billIDHistory);
                loadGridDetail_Bill(_billIDHistory, false);
                btnSave.Enabled = false;
                TreeNode[] tns = trHistoryBill.Nodes.Find(_billIDHistory.ToString(), true);
                if (tns.Length > 0)
                {
                    tns[0].BackColor = Color.LightSkyBlue;
                }
                if (_billIDHistoryOld != -1)
                {
                    TreeNode[] tnsOld = trHistoryBill.Nodes.Find(_billIDHistoryOld.ToString(), true);
                    if (tnsOld.Length > 0)
                    {
                        tnsOld[0].BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void trHistoryBill_Click(object sender, EventArgs e)
        {
            try
            {
                tabHistory = true;
                _billIDHistory = int.Parse(trHistoryBill.SelectedNode.Tag.ToString());
                _billIDHistoryOld = int.Parse(trHistoryBill.SelectedNode.Tag.ToString());
                loadBillInfor(_billIDHistory);
                loadGridDetail_Bill(_billIDHistory, false);
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int temtorarybill = 0;
            int billID = -1;
            if (tabHistory)
            {
                billID = _billIDHistory;
            }
            else
            {
                billID = _billIDTemp;
            }
            if (btnSave.Enabled == true)
            {
                temtorarybill = 1;
            }
            Process.frmPrint frm = new Process.frmPrint(int.Parse(NailApp.BranchID), billID, NailApp.CurrentUserId, temtorarybill);
            frm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            deeteToolStripMenuItem_Click(sender, e);
        }

        private void dgvService_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3 || e.ColumnIndex == 1 || e.ColumnIndex == 2)
                {
                    e.CellStyle.Format = "N2";
                }
                if (e.ColumnIndex == 0)
                {
                    e.CellStyle.Format = "N0";
                }
            }
            catch
            {
            }

        }

        #endregion

        #region Method

        private void LoadAll(int billID)
        {
            LoadHistory();
            //createTable();
            //loadService();
            //LoadGrid();
            loadBillInfor(billID);
            loadGridDetail_Bill(billID, true);
            btnPay.Enabled = true;
            btnSave.Enabled = true;
            TreeNode[] tns = trTemporaryBill.Nodes.Find(billID.ToString(), true);
            if (tns.Length > 0)
            {
                trTemporaryBill.SelectedNode = tns[0];
                trTemporaryBill.SelectedNode.EnsureVisible();  //scroll if necessary
                trTemporaryBill.Focus();
            }
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
                    Process.frmServiceAdd frmSerAdd = new Process.frmServiceAdd(int.Parse(NailApp.BranchID), NailApp.CurrentUserId, lstResult[1].ToString().Trim(), lstResult[0].ToString().Trim());
                    frmSerAdd.ShowDialog();
                    int iResult = frmSerAdd.SendData();
                    if (iResult != 0)
                    {
                        LoadAll(iResult);
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

                        //Show form AddService
                        Process.frmServiceAdd frmSerAdd =
                            new Process.frmServiceAdd(int.Parse(NailApp.BranchID),
                            NailApp.CurrentUserId, lstaddCusResult[1] != null ? lstaddCusResult[1].ToString().Trim() : "",
                            lstaddCusResult[0] != null ? lstaddCusResult[0].ToString().Trim() : "");
                        frmSerAdd.ShowDialog();
                        int iResult = frmSerAdd.SendData();
                        if (iResult != 0)
                        {
                            LoadAll(iResult);
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

                    //Show form AddService
                    Process.frmServiceAdd frmSerAdd =
                        new Process.frmServiceAdd(int.Parse(NailApp.BranchID),
                        NailApp.CurrentUserId, lstaddCusResult[1] != null ? lstaddCusResult[1].ToString().Trim() : "",
                        lstaddCusResult[0] != null ? lstaddCusResult[0].ToString().Trim() : "");
                    frmSerAdd.ShowDialog();
                    int iResult = frmSerAdd.SendData();
                    if (iResult != 0)
                    {
                        LoadAll(iResult);
                    }
                }
            }
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
        private void loadGridDetail_Bill(int billId, bool temporarybill)
        {
            DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillDetailGetList_History", billId, int.Parse(NailApp.BranchID));
            if (dt != null)
            {
                _Service.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = _Service.NewRow();
                    dr["StaffId"] = dt.Rows[i]["StaffId"].ToString();
                    dr["Price"] = decimal.Parse(dt.Rows[i]["Price"].ToString());
                    dr["Quantity"] = decimal.Parse(dt.Rows[i]["Quantity"].ToString());
                    dr["Amount"] = decimal.Parse(dt.Rows[i]["Amout"].ToString());
                    dr["ServiceID"] = dt.Rows[i]["ServiceID"].ToString();
                    dr["Note"] = dt.Rows[i]["Note"].ToString();
                    dr["Discount"] = decimal.Parse(dt.Rows[i]["Discount"].ToString());
                    _Service.Rows.Add(dr);
                }
                dgvService.DataSource = _Service;
            }
            dgvService.AllowUserToAddRows = temporarybill;
            dgvService.AllowUserToDeleteRows = temporarybill;
            dgvService.AllowUserToOrderColumns = temporarybill;
            dgvService.Enabled = temporarybill;
            caculateAmount();
        }

        private void createTable()
        {
            _Service = new DataTable();
            _Service.Columns.Add("staffId", typeof(int));
            _Service.Columns.Add("serviceId", typeof(int));
            _Service.Columns.Add("Quantity", typeof(decimal));
            _Service.Columns.Add("Price", typeof(decimal));
            _Service.Columns.Add("Discount", typeof(decimal));
            _Service.Columns.Add("Amount", typeof(decimal));
            _Service.Columns.Add("Note", typeof(string));
        }

        private void loadService()
        {
            try
            {
                _dtService = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zServiceGetList_byBranch", int.Parse(NailApp.BranchID));
                _dtStaff = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zStaffGetList_byBrabch", int.Parse(NailApp.BranchID));
                if (_dtStaff != null)
                {
                    DataRow dr = _dtStaff.NewRow();
                    dr["StaffId"] = -1;
                    dr["StaffCode"] = "";
                    dr["Name"] = "";
                    _dtStaff.Rows.Add(dr);
                }
            }
            catch
            {
            }
        }

        private void LoadGrid()
        {
            dgvService.DataSource = _Service;
            dgvService.Columns.Remove("staffId");
            DataGridViewComboBoxColumn dgvCmbStaff = new DataGridViewComboBoxColumn();
            dgvCmbStaff.DataPropertyName = "staffId";
            dgvCmbStaff.HeaderText = "Staff";
            dgvCmbStaff.Name = "staffId";
            dgvCmbStaff.DisplayMember = "Name";
            dgvCmbStaff.ValueMember = "staffId";
            dgvCmbStaff.DataSource = _dtStaff;
            dgvCmbStaff.Width = 180;
            dgvService.Columns.Add(dgvCmbStaff);
            dgvService.Columns["staffId"].DisplayIndex = 0;

            dgvService.Columns.Remove("serviceId");
            DataGridViewComboBoxColumn dgvCmbService = new DataGridViewComboBoxColumn();
            dgvCmbService.DataPropertyName = "serviceId";
            dgvCmbService.HeaderText = "Service";
            dgvCmbService.Name = "serviceId";
            dgvCmbService.DisplayMember = "Title";
            dgvCmbService.ValueMember = "serviceId";
            dgvCmbService.DataSource = _dtService;
            dgvCmbService.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvService.Columns.Add(dgvCmbService);
            dgvService.Columns["serviceId"].DisplayIndex = 0;

            dgvService.Columns["Quantity"].HeaderText = "Quantity";
            dgvService.Columns["Quantity"].Width = 100;
            dgvService.Columns["Price"].HeaderText = "Price";
            dgvService.Columns["Price"].Width = 100;
            dgvService.Columns["Discount"].HeaderText = "Discount";
            dgvService.Columns["Discount"].Width = 100;
            dgvService.Columns["Amount"].HeaderText = "Amount";
            dgvService.Columns["Amount"].ReadOnly = true;
            dgvService.Columns["Amount"].Width = 120;
            dgvService.Columns["Note"].HeaderText = "Note";
            dgvService.Columns["Note"].Width = 180;


            DataGridViewImageColumn dataGridViewImange = new DataGridViewImageColumn();
            dataGridViewImange.Name = "Del";
            dataGridViewImange.HeaderText = "";
            dataGridViewImange.Width = 20;
            dataGridViewImange.Image = Properties.Resources.cancel;
            dgvService.Columns.Add(dataGridViewImange);

            dgvService.AutoGenerateColumns = false;
        }

        private void caculateAmount()
        {
            try
            {
                _totalAmount = 0;
                for (int i = 0; i < dgvService.Rows.Count; i++)
                {
                    if (dgvService.Rows[i].Cells["serviceId"].Value != null && dgvService.Rows[i].Cells["serviceId"].Value.ToString() != "")
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

        private void SaveBill(int billId, string voucherCode)
        {
            try
            {
                int error = 0;
                string errorMesg = "";
                bool flag = true;

                for (int i = 0; i < dgvService.Rows.Count; i++)
                {
                    if (dgvService.Rows[i].Cells["ServiceId"].Value != null && dgvService.Rows[i].Cells["ServiceId"].Value.ToString() != "")
                    {
                        int Num = i + 1;
                        int ServiceID = int.Parse(dgvService.Rows[i].Cells["ServiceId"].Value.ToString());
                        decimal Quantity = decimal.Parse(dgvService.Rows[i].Cells["Quantity"].Value.ToString());
                        decimal Price = decimal.Parse(dgvService.Rows[i].Cells["Price"].Value.ToString());
                        int StaffId = -1;
                        try
                        {
                            StaffId = int.Parse(dgvService.Rows[i].Cells["StaffId"].Value.ToString());
                        }
                        catch
                        {
                        }

                        decimal discount = decimal.Parse(dgvService.Rows[i].Cells["Discount"].Value.ToString());
                        string Note = dgvService.Rows[i].Cells["Note"].Value.ToString();
                        int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zBillDetailInsert_Ver1", _billIDTemp, int.Parse(NailApp.BranchID), Num, ServiceID, Quantity, Price, discount, StaffId, NailApp.CurrentUserId, Note, error, errorMesg);
                        if (ret == 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                }

                if (flag)
                {
                    MessageBox.Show("Bill Sucessfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Bill Error.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                // call store dell bii moiws tao
                MessageBox.Show("Bill Error.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }



        #endregion

        private void dgvService_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                loadBillInfor(_billIDHistory);
                loadGridDetail_Bill(_billIDHistory, false);
                btnSave.Enabled = false;
                btnPay.Enabled = true;
                btnPay.Text = "UnPaid";
                tabHistory = true;
            }
            if (tabControl1.SelectedIndex == 0)
            {
                loadBillInfor(_billIDTemp);
                loadGridDetail_Bill(_billIDTemp, true);
                btnSave.Enabled = true;
                btnPay.Enabled = true;
                btnPay.Text = "Pay";
                tabHistory = false;
            }
        }
    }
}
