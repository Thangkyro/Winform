using CoreBase.DataAccessLayer;
using CoreBase.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.Caching;

namespace CoreBase
{
    public static class NailCaching
    {

        public static object Get(string cachingKey)
        {
            if (MemoryCache.Default.Contains(cachingKey))
                return MemoryCache.Default.Get(cachingKey);
            return null;
        }
        public static void Add(string cachingKey, object value)
        {
            if (MemoryCache.Default.Contains(cachingKey))
                MemoryCache.Default.Remove(cachingKey);

            MemoryCache.Default.Add(cachingKey, value, GetExpiryDate());

        }
        #region Command caching

        public static DataRow GetCommandRow(string commandKey)
        {
            if (!NailApp.UseCaching)
                return GetCommandRowWithOutCaching(commandKey);

            string cachingKey = TranslateCachingKey("CommandInfo", commandKey);

            if (NailApp.UseCaching && MemoryCache.Default.Contains(cachingKey))
                return (DataRow)MemoryCache.Default.Get(cachingKey);

            DataRow row;
            try
            {
                using (ZenSiDAL ro = new ZenSiDAL())
                {
                    row = ro.GetCommandRow(commandKey);
                }
                if (row != null)
                    MemoryCache.Default.Add(cachingKey, row, GetExpiryDate());

                return row;
            }
            catch (Exception ex)
            {
                ErrorProcess.HandleException(ex);
                return null;
            }
        }



        private static DataRow GetCommandRowWithOutCaching(string commandKey)
        {
            DataRow row;
            using (ZenSiDAL ro = new ZenSiDAL())
            {
                row = ro.GetCommandRow(commandKey);
            }
            return row;
        }

        #endregion Command caching

        #region Lookup caching
        public static DataRow GetLookupRow(string lookupKey, bool useCaching)
        {
            DataRow row;
            using (ZenSiDAL ro = new ZenSiDAL())
            {
                row = ro.GetLookupRow(lookupKey);
            }
            return row;
        }
        public static DataRow GetLookupRow(string lookupKey)
        {
            if (!NailApp.UseCaching)
                return GetLookupRow(lookupKey, false);

            string cachingKey = TranslateCachingKey("LookupInfo", lookupKey);

            if (NailApp.UseCaching && MemoryCache.Default.Contains(cachingKey))
                return (DataRow)MemoryCache.Default.Get(cachingKey);

            DataRow row;
            try
            {
                using (ZenSiDAL ro = new ZenSiDAL())
                {
                    row = ro.GetLookupRow(lookupKey);
                }
                if (row != null)
                    MemoryCache.Default.Add(cachingKey, row, GetExpiryDate());

                return row;
            }
            catch (Exception ex)
            {
                ErrorProcess.HandleException(ex);
                return null;
            }
        }
        private static DataTable GetLookupTableWithOutCaching(string lookupKey, string where)
        {
            DataTable newTbl;
            using (ZenSiDAL zsd = new ZenSiDAL())
            {
                newTbl = zsd.GetLookupTable(lookupKey, where);
            }
            return newTbl;
        }
        public static DataTable GetLookupTable(string lookupKey)
        {
            return GetLookupTable(lookupKey, null);
        }
        public static DataTable GetLookupTable(string lookupKey, string where)
        {
            string cachingKey = TranslateCachingKey("LookupTable[" + where + "]", lookupKey);
            string cachingTs = TranslateCachingKey("LookupTableTs[" + where + "]", lookupKey);

            byte[] maxTs = (byte[])MemoryCache.Default.Get(cachingTs);

            DataTable newTbl;
            byte[] newMaxTs = maxTs;
            try
            {
                DataRow lookupRow = GetLookupRow(lookupKey);

                if (!lookupRow["is_caching"].zToBool())
                    return GetLookupTableWithOutCaching(lookupKey, where);

                string valueMember = lookupRow["value_member"].zToString();

                using (ZenSiDAL zsd = new ZenSiDAL())
                {
                    newTbl = zsd.GetLookupTable(lookupKey, where, maxTs, out newMaxTs);
                    DataColumn[] pk = new DataColumn[] { newTbl.Columns[valueMember] };
                    newTbl.PrimaryKey = pk;

                }

                if (MemoryCache.Default.Contains(cachingKey))
                {
                    DataTable oldTable = (DataTable)MemoryCache.Default.Get(cachingKey);

                    if (lookupRow["has_deleted"].zToBool())
                    {
                        foreach (DataRow r in newTbl.Rows)
                        {
                            // xử lý deleted:
                            if ((bool)r["is_deleted"])
                                r.Delete();
                        }
                    }

                    oldTable.Merge(newTbl);

                    return oldTable;
                }
                else
                {
                    MemoryCache.Default.Add(cachingKey, newTbl, GetExpiryDate());
                    MemoryCache.Default.Add(cachingTs, newMaxTs, GetExpiryDate());
                    return newTbl;
                }
            }
            catch (Exception ex)
            {
                ErrorProcess.HandleException(ex);
                return null;
            }
        }

        #endregion

        #region Transaction State caching
        public static Dictionary<int, TransactionState> GetTrangThai(string ma_ct)
        {
            string cachingKey = "TransactionState[" + ma_ct + "]";

            if (NailApp.UseCaching && MemoryCache.Default.Contains(cachingKey))
                return (Dictionary<int, TransactionState>)MemoryCache.Default.Get(cachingKey);
            //AND is_inactive = 0
            string sql = string.Format("SELECT * FROM zDmTrangThai WHERE ma_ct='{0}' ORDER BY trang_thai", ma_ct);
            DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, sql);
            Dictionary<int, TransactionState> lts = new Dictionary<int, TransactionState>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string c = row["color"].zToString();
                    Color cl = Color.White;

                    if (!string.IsNullOrEmpty(c))
                    {
                        //int argb = int.Parse("ff" + c.Substring(1, c.Length - 1), NumberStyles.HexNumber);
                        cl = cl.zFromHex(c);// = System.Drawing.Color.FromArgb(argb); //)System.Windows.Media.ColorConverter.ConvertFromString(c);
                    }
                    TransactionState ts = new TransactionState()
                    {
                        ma_ct = ma_ct,
                        trang_thai = row["trang_thai"].zToInt(),
                        ten_trang_thai = row["ten_trang_thai"].zToString(),
                        color = cl,
                        to_gl = (bool)row["to_gl"],
                        to_in = (bool)row["to_in"],
                        is_inactive = (bool)row["is_inactive"],
                        is_cancelled = (bool)row["is_cancelled"],
                        is_lock = (bool)row["is_lock"],
                        allow_print = (bool)row["allow_print"],
                        allow_delete = (bool)row["allow_delete"]
                    };

                    string allows = row["to_allows"].zToString();
                    ts.to_allows = new List<int>();

                    if (!string.IsNullOrEmpty(allows))
                    {
                        string[] strs = allows.Split(',');
                        foreach (var s in strs)
                            ts.to_allows.Add(s.zToInt());
                    }

                    lts.Add(ts.trang_thai, ts);
                }
            }

            if (NailApp.UseCaching)
                MemoryCache.Default.Add(cachingKey, lts, GetExpiryDate());

            return lts;

        }
        #endregion
        internal static DataRow GetDvcsRow(string ma_dvcs)
        {
            string cachingKey = "Dvcs[" + ma_dvcs + "]";
            if (NailApp.UseCaching && MemoryCache.Default.Contains(cachingKey))
                return (DataRow)MemoryCache.Default.Get(cachingKey);

            DataRow dvcsRow = null;
            using (ReadOnlyDAL dal = new ReadOnlyDAL("zSiDvcs"))
            {
                dvcsRow = dal.ReadFirstRow(string.Format("ma_dvcs='{0}'", ma_dvcs));
            }
            if (NailApp.UseCaching)
                MemoryCache.Default.Add(cachingKey, dvcsRow, GetExpiryDate());

            return dvcsRow;
        }

        #region Helpers
        private static string TranslateCachingKey(string pfx, string key)
        {
            return string.Format("{0}_{1}", pfx, key);
        }
        private static DateTimeOffset GetExpiryDate()
        {
            DateTime d = DateTime.Now.AddDays(1);
            return new DateTimeOffset(d);
        }
        #endregion

    }
}
