using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreBase.WinForm
{
    public partial class DevopsAuth : Form
    {
        public DevopsAuth()
        {
            InitializeComponent();
        }

        private void DevopsAuth_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.DialogResult = DialogResult.No;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void DevopsAuth_Load(object sender, EventArgs e)
        {
            this.txtUsername.Select();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "DevopsAdmin" && txtPassword.Text == "123456aA@")
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                }
            }
            catch 
            {
                this.DialogResult = DialogResult.No;
            }
        }
    }
}
