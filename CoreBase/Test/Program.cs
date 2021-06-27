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
                    System.Windows.Forms.MessageBox.Show("Has new version. The program will perform an update before proceeding further.", "Infomation");
                    System.Diagnostics.Process.Start("Nail.Update.exe");
                    return;
                }
            }
            


            ////Login
            //if (NailApp.MultiUser)
            //{
            //    frmLogin lf = new frmLogin();
            //    if (lf.ShowDialog() != DialogResult.OK)
            //        return;
            //    //Application.Run(lf);
            //}

            ////Load permisson
            //NailApp.lstPermission = new List<string>();
            //NailApp.lstPermission = NailApp.PermissionUser.Split(',').ToList();


            //frmMain main = new frmMain();
            Application.Run(new frmMain());

            
        }
    }
}
