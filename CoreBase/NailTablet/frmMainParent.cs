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
            
        }

        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }   

        private void frmMainParent_Load(object sender, EventArgs e)
        {
            frmCheckPhone frm = new Process.frmCheckPhone(true);
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
