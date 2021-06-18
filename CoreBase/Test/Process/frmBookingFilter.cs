using CoreBase;
using CoreBase.DataAccessLayer;
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

namespace AusNail.Process
{
    public partial class frmBookingFilter : Form
    {
        private string sResult = "";
        DataTable _dtBranch = new DataTable();
        public frmBookingFilter()
        {
            InitializeComponent();
            dtpDate.Focus();
            try
            {
                panel1.BackColor = NailApp.ColorUser;
            }
            catch
            {
            }
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
            DateTime dt;
            //DateTime.TryParse(dtpDate.Text.Trim().ToString(), out dt);
            DateTime.TryParseExact(dtpDate.Text.Trim().ToString(), "dd/MM/yyyy",
                           CultureInfo.InvariantCulture,
                           DateTimeStyles.None,
                           out dt);
            if (dt == null)
            {
                MessageBox.Show("Please choose date filter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dt > DateTime.Now)
            {
                if (true)
                {
                    MessageBox.Show("Date filter can't more than To Day.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                sResult = dt.ToString("dd/MM/yyyy") + "|" + cboBranch.SelectedValue.ToString();
                this.Close();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            using (ReadOnlyDAL dal = new ReadOnlyDAL("zBranch"))
            {
                _dtBranch = dal.Read("is_inactive = 0");
            }

            _dtBranch.DefaultView.Sort = "BranchCode";
            //DataRow dr1 = _dtBranch.NewRow();
            //dr1["branchId"] = 0;
            //dr1["BranchName"] = "";
            //_dtBranch.Rows.Add(dr1);

            cboBranch.DisplayMember = "BranchName";
            cboBranch.ValueMember = "branchId";
            cboBranch.DataSource = _dtBranch.DefaultView;

            if (!NailApp.IsAdmin())
            {
                cboBranch.SelectedValue = NailApp.BranchID;
                cboBranch.Enabled = false;
            }
            else
            {
                cboBranch.SelectedValue = NailApp.BranchID;
            }

            dtpDate.Focus();
        }

    }
}
