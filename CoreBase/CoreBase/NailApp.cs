using CoreBase.DataAccessLayer;
using CoreBase.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBase
{
    public sealed class NailApp
    {
        /// <summary>
        /// Tham số sử dụng tính năng caching của core
        /// </summary>
        public static bool UseCaching = true;
        public static bool MultiUser = true;

        public static string BranchID = "0";
        public static DataRow CurrentUserRow = null;
        public static int TimeConfig = 0;
        public static DateTime BillDate = DateTime.Now;
        //public static DataRow CurrentDvcs
        //{
        //    get
        //    {
        //        return NailCaching.GetDvcsRow(BranchID);

        //    }
        //}
        public static DataRow OptionsRow
        {
            get
            {
                DataRow optionsRow = null;
                using (ReadOnlyDAL dal = new ReadOnlyDAL("zsioptions"))
                {
                    optionsRow = dal.ReadFirstRow(string.Format("ma_dvcs='{0}'", BranchID));
                }

                return optionsRow;
            }
        }
        public static Dictionary<string, DataRow> zDicCmds = new Dictionary<string, DataRow>();
        public static List<string> lstPermission = new List<string>();

        //public static string ZP_Ten_cty
        //{
        //    get
        //    {
        //        return CurrentDvcs["ten_cty"].zToString();
        //    }
        //}
        //public static string ZP_Dvcs_ten
        //{
        //    get
        //    {
        //        return CurrentDvcs["dvcs_ten"].zToString();
        //    }
        //}
        //public static string ZP_Dvcs_dia_chi
        //{
        //    get
        //    {
        //        return CurrentDvcs["dvcs_dia_chi"].zToString();
        //    }
        //}
        //public static string ZP_Dvcs_so_dt
        //{
        //    get
        //    {
        //        return CurrentDvcs["dvcs_so_dt"].zToString();
        //    }
        //}
        //public static string ZP_Dvcs_website
        //{
        //    get
        //    {
        //        return CurrentDvcs["dvcs_website"].zToString();
        //    }
        //}
        //public static string ZP_Dvcs_facebook
        //{
        //    get
        //    {
        //        return CurrentDvcs["dvcs_facebook"].zToString();
        //    }
        //}
        //public static string ZP_Dvcs_email
        //{
        //    get
        //    {
        //        return CurrentDvcs["dvcs_email"].zToString();
        //    }
        //}

        public static int CurrentUserId
        {
            get
            {
                if (CurrentUserRow == null)
                    return -1;

                return CurrentUserRow["Userid"].zToInt();
            }
        }

        public static string UserName
        {
            get
            {
                if (CurrentUserRow == null)
                    return "";

                return CurrentUserRow["user_name"].zToString();
            }
        }

        public static string FullName
        {
            get
            {
                if (CurrentUserRow == null)
                    return "";

                return CurrentUserRow["full_name"].zToString();
            }
        }

        public static bool IsAdmin()
        {
            if (CurrentUserRow == null)
                return false;
            else
                return NailApp.CurrentUserRow["is_admin"].zToBool();
        }

        public static bool IsAutoPrint()
        {
            if (CurrentUserRow == null)
                return false;
            else
                return NailApp.CurrentUserRow["IsAutoPrint"].zToBool();
        }

        public static string PermissionUser
        {
            get
            {
                if (CurrentUserRow == null)
                    return "";

                return CurrentUserRow["Permission"].zToString();
            }
        }

        public static int StaffId()
        {
            if (CurrentUserRow == null)
                return -1;
            else
                return NailApp.CurrentUserRow["StaffId"].zToInt();
        }

        //public static Color ColorUser
        //{
        //    get
        //    {
        //        if (CurrentUserRow == null)
        //        {

        //            return ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0); ;
        //        }
        //        else
        //        {
        //            return ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml(CurrentUserRow["ColorUser"].zToString()), 0);
        //        }
        //    }
        //}
        public static Color ColorUser
        {
            get;set;
        }

        public static decimal MaxPercen
        {
            get
            {
                if (CurrentUserRow == null)
                    return 0;

                return CurrentUserRow["MaxPercen"].zToInt();
            }
        }

        public static decimal MinApprovePercen
        {
            get
            {
                if (CurrentUserRow == null)
                    return 0;

                return CurrentUserRow["MinApprovePercen"].zToInt();
            }
        }

        public static decimal PercenPay
        {
            get
            {
                if (CurrentUserRow == null)
                    return 0;

                return CurrentUserRow["PercenPay"].zToInt();
            }
        }

        public static string website
        {
            get
            {
                if (CurrentUserRow == null)
                    return "";

                return CurrentUserRow["website"].zToString();
            }
        }

        public static string Titlebranch
        {
            get
            {
                if (CurrentUserRow == null)
                    return "";

                return CurrentUserRow["Titlebranch"].zToString();
            }
        }

        public static object Imagebranch
        {
            get
            {
                if (CurrentUserRow == null)
                    return "";

                return CurrentUserRow["Imagebranch"];
            }
        }


        //public string Password { get; set; }


        //public static string AppDll = "NaBiz";

        public static string PathOfRoot;
        public static string PathOfRpt;

        public static DateTime Ngay1 = DateTime.Now.Date;
        public static DateTime Ngay2 = DateTime.Now.Date;
        //public static DateTime Ngay_ks
        //{
        //    get
        //    {
        //        return Commons.GetNgay_ks(BranchID);
        //    }
        //}

    }
}
