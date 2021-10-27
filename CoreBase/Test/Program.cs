using AusNail.Dictionary;
using AusNail.Login;
using CoreBase;
using CoreBase.DataAccessLayer;
using CoreBase.Helpers;
using Nail.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;

namespace AusNail
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Updater u = new Updater();
            //u.StartMonitoring();
            if (u.LocalConfig != null)
            {
                if (u.ZCheckUpdate())
                {
                    System.Windows.Forms.MessageBox.Show("Has a new version. The program will perform an update before proceeding further.", "Infomation");
                    System.Diagnostics.Process.Start("Nail.Update.exe");
                    return;
                }
            }

            // Check database setting
            //try
            //{
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                ConnectionStringSettings css = conf.ConnectionStrings.ConnectionStrings["DefaultConnectionString"];

                if (css != null)
                {
                    string connString = StringCipher.Decrypt(css.ConnectionString, ZenDatabase.DbCfgPassEncrypt);

                    ZenDbInfo dbinfo = ZenDatabase.GetDbInfo(connString);
                    if (ZenDatabase.TestConnection(ZenDatabase.GetConnectionString(dbinfo.ServerName, dbinfo.DatabaseName, dbinfo.UserName, dbinfo.Password)))
                    {
                        Application.Run(new frmMainParent());
                    }
                    else
                    {
                        Application.Run(new CoreBase.WinForm.frmDataBaseSetting());
                    }
                }
                else
                {
                    Application.Run(new CoreBase.WinForm.frmDataBaseSetting());
                }
            //}
            //catch 
            //{
            //    Application.Run(new CoreBase.WinForm.frmDataBaseSetting());
            //}
            
            
            
        }
    }
}
