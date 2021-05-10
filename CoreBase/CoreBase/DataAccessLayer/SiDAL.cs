using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CoreBase.DataAccessLayer
{
    public class ZenSiDAL : IDisposable
    {
        public DataRow GetLookupRow(string lookupKey)
        {
            DataRow row;
            using (ReadOnlyDAL ro = new ReadOnlyDAL("zSiLookup"))
            {
                row = ro.ReadFirstRow("lookup_key='" + lookupKey + "'");
            }
            return row;
        }
        public DataRow GetCommandRow(string commandKey)
        {
            DataRow row = null;
            //using (ReadOnlyDAL ro = new ReadOnlyDAL("zSiCommand"))
            //{
            //    row = ro.ReadFirstRow("command_key='" + commandKey + "'");
            //}
            return row;
        }
        
        public void Dispose()
        {
        }

        internal DataTable GetLookupTable(string lookupKey, string where, byte[] maxTs, out byte[] newMaxTs)
        {
            DataSet ds = MsSqlHelper.ExecuteDataset(ZenDatabase.ConnectionString, "zUspSiGetLookupTable", new object[] {"Code", lookupKey, where, maxTs });
            newMaxTs = (byte[]) ds.Tables[1].Rows[0]["maxts"];
            return ds.Tables[0];
        }
        internal DataTable GetLookupTable(string lookupKey, string where)
        {
            DataSet ds = MsSqlHelper.ExecuteDataset(ZenDatabase.ConnectionString, "zUspSiGetLookupTable", new object[] {"Code", lookupKey, where, null});
            return ds.Tables[0];
        }
        internal DataTable GetLookupTable(string lookupKey)
        {
            return GetLookupTable(lookupKey, null);
        }
    }
}
