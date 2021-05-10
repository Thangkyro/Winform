using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoreBase.DataAccessLayer
{
    public partial class DatabaseSettingForm : Form
    {
        string _serverName;
        string _databaseName;
        string _userName;
        string _password;

        public DatabaseSettingForm()
        {
            InitializeComponent();

            this.Load += (s, e) =>
              {
                  LoadConfig();
              };
            this.btnTryConnect.Click += (s, e) =>
            {
                if (!zValidInfo())
                    return;

                if (ZenDatabase.TestConnection(ZenDatabase.GetConnectionString(txtServerName.Text, txtDatabaseName.Text, txtUserName.Text, txtPassword.Text)))
                {
                    //ZenMessage.Show("Kết nối thành công.", ZenMessageType.Infomation);
                }
            };
        }

        protected override bool Va
        {
            if (!base.ValidInfo())
                return false;

            if (txtServerName.Text == "")
            {
                txtServerName.Focus();
                ZenMessage.Show("Chưa nhập Tên máy chủ.", ZenMessageType.Warning);
                return false;
            }

            if (txtDatabaseName.Text == "")
            {
                txtDatabaseName.Focus();
                ZenMessage.Show("Chưa nhập Tên cơ sở dữ liệu", ZenMessageType.Warning);
                return false;
            }

            if (txtUserName.Text == "")
            {
                txtUserName.Focus();
                ZenMessage.Show("Chưa nhập Tên đăng nhập", ZenMessageType.Warning);
                return false;
            }

            if (txtServerName.Text == "")
            {
                txtServerName.Focus();
                ZenMessage.Show("Chưa nhập mật khẩu", ZenMessageType.Warning);
                return false;
            }

            return true;
        }

        protected override bool zDoBeforeReturn()
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

        private void LoadConfig()
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
    }
}
