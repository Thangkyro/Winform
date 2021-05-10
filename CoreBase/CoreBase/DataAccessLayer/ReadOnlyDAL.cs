using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CoreBase.DataAccessLayer
{
    public class ReadOnlyDAL : IDisposable
    {
        public string zTableName {get;set;}
        public ReadOnlyDAL() :this(null)
        {

        }
        public ReadOnlyDAL(string tableName)
        {
            zTableName = tableName;

        }

        public object ReadScalar(string spName, params object[] parameterValues)
        {
            return MsSqlHelper.ExecuteScalar(ZenDatabase.ConnectionString, spName, parameterValues);
        }
        public object ReadScalar(CommandType cmdType, string cmdText)
        {
            return MsSqlHelper.ExecuteScalar(ZenDatabase.ConnectionString, cmdType, cmdText);
        }
        public DataTable Read()
        {
            if (string.IsNullOrEmpty(zTableName))
                return null;
            string sql = string.Format("select * from {0};",zTableName);

            return MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, sql);
        }

        public DataTable Read(CommandType cmdType, string cmdText)
        {
            return MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, cmdText);
        }

        public DataTable Read(string where)
        {
            if (string.IsNullOrEmpty(zTableName))
                return null;
            if (string.IsNullOrEmpty(where))
                return Read();

            string sql = string.Format("SELECT * FROM {0} WHERE {1};", zTableName, where);

            return MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, sql);
        }
        public DataTable Read(string spName, params object[] parameterValues)
        {
            return MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, spName, parameterValues);
        }
        public DataRow ReadFirstRow()
        {
            if (string.IsNullOrEmpty(zTableName))
                return null;
            string sql = string.Format("select TOP 1 * from {0};", zTableName);

            DataTable t = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, sql);
            if (t != null && t.Rows.Count > 0)
                return t.Rows[0];

            return null;
        }

        public DataRow ReadFirstRow(string where)
        {
            if (string.IsNullOrEmpty(zTableName))
                return null;
            if (string.IsNullOrEmpty(where))
                return ReadFirstRow();

            string sql = string.Format("SELECT TOP 1 * FROM {0} WHERE {1};", zTableName, where);

            DataTable t = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, sql);
            if (t != null && t.Rows.Count > 0)
                return t.Rows[0];

            return null;
        }
        public DataRow ReadFirstRow(string spName, params object[] parameterValues)
        {
            DataTable t = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, spName, parameterValues);
            if (t != null && t.Rows.Count > 0)
                return t.Rows[0];

            return null;
        }

        public DataSet ReadDataSet(string spName, params object[] parameterValues)
        {   
            return MsSqlHelper.ExecuteDataset(ZenDatabase.ConnectionString, spName, parameterValues);
        }

        public void Dispose()
        {
            
        }
    }
}
