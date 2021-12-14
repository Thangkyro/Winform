using CoreBase;
using CoreBase.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AusNail.Process
{
    public partial class frmCusstomerAdd : Form
    {
        private string _idCustomerName = "CustId";
        private string _tableNameCustomer = "zCustomer";
        private int _branchId = 2;
        private int _UserId = 1;
        private string _phoneNumber = "";
        private string sResult = "";
        public frmCusstomerAdd()
        {
            InitializeComponent();
            txtPhoneNum.Focus();
        }

        public frmCusstomerAdd(int branchId, int userId)
        {
            InitializeComponent();
            _branchId = branchId;
            _UserId = userId;
            txtPhoneNum.Focus();
        }

        public frmCusstomerAdd(int branchId, int userId, string phonemuber)
        {
            InitializeComponent();
            _branchId = branchId;
            _UserId = userId;
            _phoneNumber = phonemuber;
            txtPhoneNum.Text = _phoneNumber;
            txtPhoneNum.Focus();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtPhoneNum.Text.Trim() == "" || txtName.Text.Trim() == "")
            {
                MessageBox.Show("Phone number and Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                zCustomerInsert();
                //this.Close();
            }
        }
        private void zCustomerInsert()
        {
            try
            {
                string PhoneNumber1 = this.txtPhoneNum.Text.Trim();
                string Name = this.txtName.Text.Trim();
                string Gender = "Male";
                if (radFemale.Checked)
                {
                    Gender = "Female";
                }
                if (radOrder.Checked)
                {
                    Gender = "Order";
                }
                string sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                string DateOfBirth = this.txtDateofBirth.Value.ToShortDateString();
                string Date = DateOfBirth;
                if (sysUIFormat == "dd/MM/yyyy")
                {
                    Date = DateTime.ParseExact(DateOfBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                       .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }

                string PostCode = this.txtPostcode.Text.Trim();
                string CustomerCode = GenCustomerCode();
                // kiem tra khong được đặt mã trùng
                int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zCustomerInsert", _branchId, CustomerCode, Name, Gender, PhoneNumber1, "", "", "", Date, PostCode, 0, 0, "", 0, _UserId, DateTime.Now.AddHours(NailApp.TimeConfig).ToString(), _UserId, DateTime.Now.AddHours(NailApp.TimeConfig).ToString(), 0, "");

                if (ret > 0)
                {
                    string customerName = txtName.Text.Trim();
                    string phoneNumber = txtPhoneNum.Text.Trim();
                    this.Visible = false;
                    this.ShowInTaskbar = false;
                    Process.frmServiceAddVer1 frm = new frmServiceAddVer1(_branchId, _UserId, customerName, phoneNumber);
                    frm.Activate();
                    frm.ShowDialog();

                    sResult = phoneNumber + "|" + customerName;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Add customer not sucessful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public string SendData()
        {
            return sResult;
        }

        private string GenCustomerCode()
        {
            string customerCode = "";
            try
            {
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGetNewCode", _tableNameCustomer, "CR", _idCustomerName, 8);
                if (dt != null)
                {
                    customerCode = dt.Rows[0][0].ToString();
                }
            }
            catch
            { }
            return customerCode;
        }

        enum Gender
        {
            Male,
            Female,
            Order
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCusstomerAdd_Load(object sender, EventArgs e)
        {
            txtName.Focus();
            txtName.Select();
        }

        private void txtPhoneNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void frmCusstomerAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }

    public class MyDateTimePicker : DateTimePicker
    {
        private const int SWP_NOMOVE = 0x0002;
        private const int DTM_First = 0x1000;
        private const int DTM_GETMONTHCAL = DTM_First + 8;
        private const int MCM_GETMINREQRECT = DTM_First + 9;

        [DllImport("uxtheme.dll")]
        private static extern int SetWindowTheme(IntPtr hWnd, string appName, string idList);
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, ref RECT lParam);
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
        int X, int Y, int cx, int cy, int uFlags);
        [DllImport("User32.dll")]
        private static extern IntPtr GetParent(IntPtr hWnd);
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT { public int L, T, R, B; }
        protected override void OnDropDown(EventArgs eventargs)
        {
            var hwndCalendar = SendMessage(this.Handle, DTM_GETMONTHCAL, 0, 0);
            SetWindowTheme(hwndCalendar, string.Empty, string.Empty);
            var r = new RECT();
            SendMessage(hwndCalendar, MCM_GETMINREQRECT, 0, ref r);
            var hwndDropDown = GetParent(hwndCalendar);
            SetWindowPos(hwndDropDown, IntPtr.Zero, 0, 0,
                r.R - r.L + 36, r.B - r.T, SWP_NOMOVE);
            base.OnDropDown(eventargs);
        }
    }

    class MyRadioButton : RadioButton
    {
        public MyRadioButton()
        {
            this.TextAlign = ContentAlignment.MiddleRight;
        }
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = false; }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int h = this.ClientSize.Height;
            Rectangle rc = new Rectangle(new Point(-5, 0), new Size(h, h));
            ControlPaint.DrawRadioButton(e.Graphics, rc,
                this.Checked ? ButtonState.Checked : ButtonState.Normal);
        }
    }
}
