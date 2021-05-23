using CoreBase.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBase.Helpers
{
    public sealed class Commons
    {
        public static string GetSoCt(string maCt, DateTime ngayCt)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@_ma_dvcs", NailApp.BranchID));
            pars.Add(new SqlParameter("@_ma_ct", maCt));
            pars.Add(new SqlParameter("@_ngay_ct", ngayCt));

            var soCt = MsSqlHelper.ExecuteScalar(ZenDatabase.ConnectionString, CommandType.StoredProcedure, "zUspGetSoCt", pars.ToArray());
            return soCt.zToString();
        }

        public static DataTable GetDmLoai(string maNhLoai)
        {
            string sql = string.Format("SELECT id, ma_loai, ten_loai FROM zDmLoai WHERE ma_nh_loai='{0}'", maNhLoai);
            DataSet ds = MsSqlHelper.ExecuteDataset(ZenDatabase.ConnectionString, CommandType.Text, sql);
            return ds.Tables[0];

            //--nhap kho is
        }

        public static DateTime GetNgay_ks(string ma_dvcs)
        {
            string sql = string.Format("select ngay_ks from zSiOptions where ma_dvcs = '{0}'", ma_dvcs);
            try
            {
                var ngayKs = MsSqlHelper.ExecuteScalar(ZenDatabase.ConnectionString, CommandType.Text, sql);
                if (ngayKs == null)
                    return DateTime.Now;

                return (DateTime)ngayKs;
            }
            catch (Exception ex)
            {

                ErrorProcess.HandleException(ex);
                return DateTime.Now;
            }
        }
        public static string GetRptBillDefault(string ma_dvcs)
        {
            string sql = string.Format("SELECT rpt_bill_default FROM zsioptions WHERE ma_dvcs = '{0}'", ma_dvcs);
            try
            {
                var billName = MsSqlHelper.ExecuteScalar(ZenDatabase.ConnectionString, CommandType.Text, sql);
                if (billName == null)
                    return string.Empty;

                return billName.ToString();
            }
            catch (Exception ex)
            {

                ErrorProcess.HandleException(ex);
                return string.Empty;
            }
        }
        public static bool UpdateRptBillDefault(string bill, string ma_dvcs)
        {
            string sql = string.Format("UPDATE zsioptions SET rpt_bill_default = '{0}' " +
                "WHERE ma_dvcs='{1}'", bill, ma_dvcs);
            try
            {
                MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, CommandType.Text, sql);
                return true;
            }
            catch (Exception ex)
            {

                ErrorProcess.HandleException(ex);
                return false;
            }
        }

        public static void BrowseTable(DataTable table, string columnInfo = "", bool showSearch = false, string formTitle = "Browse Table", int formWidth = 0, int formHeight = 0)
        {
            //using (Zen.Core.Win.ZenFormBrowseTable fBrowse = new Win.ZenFormBrowseTable())
            //{
            //    fBrowse.Text = formTitle;
            //    fBrowse.zTable = table;
            //    fBrowse.zColumnInfo = columnInfo;
            //    fBrowse.zShowSearchPanel = showSearch;
            //    if (formHeight > 0)
            //        fBrowse.Height = formHeight;
            //    if (formWidth > 0)
            //        fBrowse.Width = formWidth;

            //    fBrowse.ShowDialog();
            //}


        }
    }
}
