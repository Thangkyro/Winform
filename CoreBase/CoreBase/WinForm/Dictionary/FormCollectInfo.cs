using CoreBase.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreBase.WinForm.Dictionary
{
    public partial class FormCollectInfo : DicBase
    {
        string strMessInfor = "";
        Timer t = new Timer();
        public FormCollectInfo()
        {
            InitializeComponent();
            t.Interval = 1000;  //in milliseconds

            t.Tick += new EventHandler(this.t_Tick);

            t.Start();  //this will use t_Tick() method
        }

        protected virtual bool zValidInfo()
        {
            return true;
        }
        protected virtual bool zDoBeforeReturn()
        {
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (zValidInfo() && zDoBeforeReturn())
                DialogResult = DialogResult.OK;
        }

        private void t_Tick(object sender, EventArgs e)
        {
            //get current time
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            //time
            string time = "";

            //padding leading zero
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            //update label
            lblTime.Text = time;
        }

        public void LoadMess()
        {
            lblMessInfomation.Text = strMessInfor;
        }

    }
}
