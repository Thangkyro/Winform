using CoreBase.DataAccessLayer;
using CoreBase.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBase.DAL
{
    public class SecurityDAO : IDisposable
    {
        public int GetTimeConfig()
        {
            string sql = string.Format("select ValuesForm from [dbo].[zConfig] Where ConfigCode  = 'TimeZoneUse' ");
            DataTable t = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, sql);
            if (t == null || t.Rows.Count == 0)
                return 0;

            return int.Parse(t.Rows[0][0].ToString());
        }
        public DataRow GetUserRow(string userName, string password)
        {
            string sql = string.Format("select top 1 * from zUser WHERE user_name = '{0}' and password = '{1}' and is_inactive =0;", userName, password);
            DataTable t = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, sql);
            if (t == null || t.Rows.Count == 0)
                return null;

            return t.Rows[0];
        }

        public DataRow GetUserRow(int branchID, string userName, string password)
        {
            DataTable t = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zusp_user_by_branch", new object[] { branchID, userName, password });
            if (t == null || t.Rows.Count == 0)
                return null;

            return t.Rows[0];
        }

        public DataTable GetCmdForPermission(int userid)
        {
            DataTable t = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zUspSiGetCmdForPermission", userid);
            return t;
        }
        public DataTable GetDvcsForPermission(int userid)
        {
            DataTable t = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zUspSiGetDvcsForPermission", userid);
            return t;
        }
        public void Dispose()
        {

        }
        //internal void SetPassword(DataRow row)
        //{
        //    SetPassword(row[ZenDatabase.ID_COLUMN_NAME].zToInt(), row["password"].zToString());
        //}
        //internal void SetPassword(int userId, string password)
        //{
        //    string sql = string.Format("update zUser set password = '{0}' where id = {1}", password, userId);
        //    MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, CommandType.Text, sql);

        //}

        public void SetPassword(DataRow row)
        {
            SetPassword(row["Userid"].zToInt(), row["password"].zToString());
        }
        public void SetPassword(int userId, string password)
        {
            string sql = string.Format("update zUser set password = '{0}' where Userid = {1}", password, userId);
            MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, CommandType.Text, sql);

        }

        public bool SetPasswordNew(int userId, string password)
        {
            bool bResult = false;
            string sql = string.Format("update zUser set password = '{0}' where Userid = {1}", password, userId);
            int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, CommandType.Text, sql);
            if (ret > 0)
            {
                bResult = true;
            }
            return bResult;

        }

        public void UpdatePermission(int id, string cmdIds)
        {
            string sql = string.Format("update zUser set permission = '{0}' where Userid = {1}", cmdIds, id);
            MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, CommandType.Text, sql);
        }
        //internal void UpdateDvcsForUser(int id, string cmdIds)
        //{
        //    string sql = string.Format("update zUser set dvcs = '{0}' where id = {1}", cmdIds, id);
        //    MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, CommandType.Text, sql);
        //}
    }
}
