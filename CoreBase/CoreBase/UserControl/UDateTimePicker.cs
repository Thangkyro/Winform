using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nail.Core
{
    public partial class UDateTimePicker : UserControl
    {
        public UDateTimePicker()
        {
            InitializeComponent();
            txtDate.ForeColor = Color.LightGray;
            txtDate.Text = "dd/MM/yyyy";
            this.txtDate.Leave += new System.EventHandler(this.txtDate_Leave);
            this.txtDate.Enter += new System.EventHandler(this.txtDate_Enter);

            txtTime.ForeColor = Color.LightGray;
            txtTime.Text = "HH:mm:ss";
            this.txtTime.Leave += new System.EventHandler(this.txtTime_Leave);
            this.txtTime.Enter += new System.EventHandler(this.txtTime_Enter);
        }

        private void UDateTimePicker_Load(object sender, EventArgs e)
        {
            dtPicker.Value = DateTime.UtcNow;
        }

        private void loadpickerbytext()
        {
            try
            {
                string day = "", month = "", year = "", hours = "", minute = "", second = "";
                string strdate = txtDate.Text.Trim();
                string strtime = txtTime.Text.Trim();
                // extra data date
                if (strdate != "dd/MM/yyyy" && strdate.Length > 1 && strdate.Length < 11)
                {
                    if (strdate.Length == 10)
                    {
                        day = strdate.Substring(0, 2);
                        month = strdate.Substring(3, 2);
                        year = strdate.Substring(6, 4);
                    }
                    else if (strdate.Length == 8)
                    {
                        if (strdate.IndexOf("/") == -1 && strdate.IndexOf("-") == -1)
                        {
                            day = strdate.Substring(0, 2);
                            month = strdate.Substring(2, 2);
                            year = strdate.Substring(4, 4);
                        }
                    }
                }
                else
                {
                    day = dtPicker.Value.Day.ToString().PadLeft(2, '0');
                    month = dtPicker.Value.Month.ToString().PadLeft(2, '0');
                    year = dtPicker.Value.Year.ToString().PadLeft(4, '0');
                }
                // extra data time
                if (strtime != "HH:mm:ss" && strtime.Length > 1 && strtime.Length < 9)
                {
                    if (strtime.Length == 8)
                    {
                        hours = strtime.Substring(0, 2);
                        minute = strtime.Substring(3, 2);
                        second = strtime.Substring(6, 2);
                    }
                    else if (strtime.Length == 6)
                    {
                        if (strtime.IndexOf(":") == -1)
                        {
                            hours = strtime.Substring(0, 2);
                            minute = strtime.Substring(2, 2);
                            second = strtime.Substring(4, 2);
                        }
                    }
                }
                else
                {
                    hours = dtPicker.Value.Hour.ToString().PadLeft(2, '0');
                    minute = dtPicker.Value.Minute.ToString().PadLeft(2, '0');
                    second = dtPicker.Value.Second.ToString().PadLeft(2, '0');
                }
                string srtDateTime = month.PadLeft(2, '0') + "/" + day.PadLeft(2, '0') + "/" + year.PadLeft(4, '0') + " " + hours.PadLeft(2, '0') + ":" + minute.PadLeft(2, '0') + ":" + second.PadLeft(2, '0');


                DateTime dDateTime = DateTime.ParseExact(srtDateTime, "MM/dd/yyyy HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
                if (dDateTime != null)
                {
                    dtPicker.Value = dDateTime;
                }
            }
            catch 
            {

            }
        }

        private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }


        private void txtDate_Leave(object sender, EventArgs e)
        {
            if (txtDate.Text == "")
            {
                txtDate.Text = "dd/MM/yyyy";
                txtDate.ForeColor = Color.Gray;
            }
        }

        private void txtDate_Enter(object sender, EventArgs e)
        {
            if (txtDate.Text == "dd/MM/yyyy")
            {
                txtDate.Text = "";
                txtDate.ForeColor = Color.Black;
            }
        }

        private void txtTime_Enter(object sender, EventArgs e)
        {
            if (txtTime.Text == "HH:mm:ss")
            {
                txtTime.Text = "";
                txtTime.ForeColor = Color.Black;
            }
        }

        private void txtTime_Leave(object sender, EventArgs e)
        {
            if (txtTime.Text == "")
            {
                txtTime.Text = "HH:mm:ss";
                txtTime.ForeColor = Color.Gray;
            }
        }

        private void txtDate_Validated(object sender, EventArgs e)
        {
            loadpickerbytext();           
            txtDate.Text = "dd/MM/yyyy";
            txtDate.ForeColor = Color.Gray;
            txtTime.Text = "HH:mm:ss";
            txtTime.ForeColor = Color.Gray;
        }

        private void txtTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ':')
            {
                e.Handled = true;
            }
        }
    }
}
