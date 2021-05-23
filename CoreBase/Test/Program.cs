using AusNail.Login;
using CoreBase;
using CoreBase.DataAccessLayer;
using CoreBase.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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


            //Login
            if (NailApp.MultiUser)
            {
                frmLogin lf = new frmLogin();
                if (lf.ShowDialog() != DialogResult.OK)
                    return;
            }

            //Load permisson
            //DataTable tblCmds = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zUspSiGetCmdByUser", NailApp.CurrentUserId);
            //if (tblCmds == null)
            //    return;
            //NailApp.zDicCmds = new Dictionary<string, DataRow>();
            //foreach (DataRow row in tblCmds.Rows)
            //{
            //    string cmdKey = row["cmd_key"].zToString();
            //    if (!NailApp.zDicCmds.ContainsKey(cmdKey))
            //    {
            //        NailApp.zDicCmds.Add(cmdKey, row);
            //    }
            //}

            frmMain main = new frmMain();

            Application.Run(main);
        }
    }
}
