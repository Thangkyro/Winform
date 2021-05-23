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
