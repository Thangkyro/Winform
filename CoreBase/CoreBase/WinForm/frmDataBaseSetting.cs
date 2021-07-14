using CoreBase.DataAccessLayer;
using CoreBase.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreBase.WinForm
{
    public partial class frmDataBaseSetting : Form
    {
        private string _rptConfig = "";
        public frmDataBaseSetting()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool zValidInfo()
        {
            if (txtServerName.Text == "")
            {
                txtServerName.Focus();
                MessageBox.Show("Server name empty!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                return false;
            }

            if (txtDatabaseName.Text == "")
            {
                txtDatabaseName.Focus();
                MessageBox.Show("Database name empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtUserName.Text == "")
            {
                txtUserName.Focus();
                MessageBox.Show("User name empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtServerName.Text == "")
            {
                txtServerName.Focus();
                MessageBox.Show("Password empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LoadConfig()
        {
            try
            {
                Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                ConnectionStringSettings css = conf.ConnectionStrings.ConnectionStrings["DefaultConnectionString"];

                if (css != null)
                {
                    string connString = StringCipher.Decrypt(css.ConnectionString, ZenDatabase.DbCfgPassEncrypt);

                    ZenDbInfo dbinfo = ZenDatabase.GetDbInfo(connString);

                    txtServerName.Text = dbinfo.ServerName;
                    txtDatabaseName.Text = dbinfo.DatabaseName;
                    txtUserName.Text = dbinfo.UserName;
                    txtPassword.Text = dbinfo.Password;

                }
            }
            catch 
            {

            }
        }

        private bool Saveconnect()
        {
            try
            {
                Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                conf.ConnectionStrings.ConnectionStrings.Remove("DefaultConnectionString");
                ZenDbInfo dbInfo = new ZenDbInfo()
                {
                    ServerName = txtServerName.Text.Trim(),
                    DatabaseName = txtDatabaseName.Text.Trim(),
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text
                };
                string connString = ZenDatabase.GetConnectionString(dbInfo);

                ZenDatabase.CurrentDbInfo = dbInfo;

                ConnectionStringSettings css = new ConnectionStringSettings("DefaultConnectionString", StringCipher.Encrypt(connString, ZenDatabase.DbCfgPassEncrypt));
                conf.ConnectionStrings.ConnectionStrings.Add(css);
                conf.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");


                return true;
            }
            catch (Exception ex)
            {
                ErrorProcess.HandleException(ex);

                return false;
            }

        }

        private void frmDataBaseSetting_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!zValidInfo())
                    return;

                if (ZenDatabase.TestConnection(ZenDatabase.GetConnectionString(txtServerName.Text, txtDatabaseName.Text, txtUserName.Text, txtPassword.Text)))
                {
                    MessageBox.Show("Connect success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Connect faill!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch 
            {
                MessageBox.Show("Connect faill!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool flag = Saveconnect();
            if (flag)
            {
                MessageBox.Show("Update success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void txtServerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
