using CoreBase.DataAccessLayer;
using CoreBase.Helpers;
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
    public partial class HashKey : Form
    {
        public HashKey()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = StringCipher.Decrypt(textBox1.Text, ZenDatabase.DbCfgPassEncrypt);
            }
            catch
            {
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = StringCipher.Encrypt(textBox2.Text, ZenDatabase.DbCfgPassEncrypt);
            }
            catch 
            {
            }
            
        }
    }
}
