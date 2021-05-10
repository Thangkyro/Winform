using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CoreBase.Helpers;

namespace CoreBase.DataAccessLayer
{
    public class TransactionDAL : GenericDAL
    {
        public string zMasterTableNameView { get; private set; }
        public string zMasterTableName { get; private set; }
        public DataTable zMasterTable { get; private set; }
        public string zDetailTableNameView { get; private set; }
        public string zDetailTableName { get; private set; }
        public DataTable zDetailTable { get; private set; }

        #region ctors   
        public TransactionDAL() { }
        public TransactionDAL(string masterTable) : this(masterTable, null)
        {

        }

        public TransactionDAL(string masterTable, string detailTable) : this(masterTable, detailTable, masterTable, detailTable)
        {
        }
        public TransactionDAL(string masterTableView, string detailTableView, string masterTable, string detailTable) : base(masterTable)
        {
            zMasterTableName = masterTable;
            zMasterTableNameView = masterTableView;
            zDetailTableName = detailTable;
            zDetailTableNameView = detailTableView;

            zMasterTable = new DataTable(masterTable);
            base.buildSelectCommand("SelectSchema", null, null);
            base.fillData(zMasterTable, "SelectSchema");

            zDetailTable = new DataTable(detailTable);
            base.buildSelectCommand("SelectSchema", detailTable, null, null);
            base.fillData(zDetailTable, "SelectSchema");
        }
        #endregion

        #region Methods
        public DataSet GetData()
        {
            string sql = string.Format("select top 0 * from {0}; select top 0 * from {1};", zMasterTableNameView, zDetailTableNameView);
            DataSet ds = MsSqlHelper.ExecuteDataset(ZenDatabase.ConnectionString, CommandType.Text, sql);
            ds.Tables[0].TableName = zMasterTableNameView;
            MsSqlHelper.SetDefaultValueForTable(ds.Tables[0]);
            ds.Tables[1].TableName = zDetailTableNameView;
            MsSqlHelper.SetDefaultValueForTable(ds.Tables[1]);

            return ds;
        }
        public DataSet GetData(int id)
        {
            string sql = string.Format("select * from {1} where mid = {0}; select * from {2} where mid in (select mid from {1} where mid ={0});", id, zMasterTableNameView, zDetailTableNameView);
            DataSet ds = MsSqlHelper.ExecuteDataset(ZenDatabase.ConnectionString, CommandType.Text, sql);
            ds.Tables[0].TableName = zMasterTableNameView;
            MsSqlHelper.SetDefaultValueForTable(ds.Tables[0]);
            ds.Tables[1].TableName = zDetailTableNameView;
            MsSqlHelper.SetDefaultValueForTable(ds.Tables[1]);

            return ds;
        }

        public DataSet GetData(string masterWhere, string detailWhere)
        {
            string mw = "ma_cty = '" + CONFIG.Ma_dvcs + "'" + ((masterWhere == null) ? "" : " AND " + masterWhere);
            string dw = "ma_cty = '" + CONFIG.Ma_dvcs + "'" + ((detailWhere == null) ? "" : " AND " + detailWhere);
            string sqlMaster = "select * from " + zMasterTableNameView + " WHERE " + mw + " AND mid IN (select mid from " + zDetailTableNameView + " WHERE " + dw + ") order by mid desc";
            string sqlDetail = "select * from " + zDetailTableNameView + " WHERE " + dw + " AND mid IN (select mid from " + zMasterTableNameView + " WHERE " + mw + ") order by stt_id0 asc";
            string sql = sqlMaster + "; " + sqlDetail;

            DataSet ds = MsSqlHelper.ExecuteDataset(ZenDatabase.ConnectionString, CommandType.Text, sql);
            ds.Tables[0].TableName = zMasterTableNameView;
            MsSqlHelper.SetDefaultValueForTable(ds.Tables[0]);
            ds.Tables[1].TableName = zDetailTableNameView;
            MsSqlHelper.SetDefaultValueForTable(ds.Tables[1]);

            return ds;
        }
        public bool Insert(DataRow masterRow, DataRow[] detailRows)
        {
            int ret = 0;

            SqlConnection conn = new SqlConnection(ZenDatabase.ConnectionString);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            int oldId = masterRow["mid"].zToInt();
            try
            {
                string sql = "";// base.buildInsertCommand("Insert", zMasterTableName, zMasterTable, true);
                masterRow["modified_at"] = DateTime.Now;
                masterRow["ma_cty"] = CONFIG.Ma_dvcs;
                SqlParameter[] outPars;
                sql = base.buildInsertCommand("Insert", zMasterTableName, zMasterTable, masterRow, out outPars, true);
                //Thêm masterow
                var id = MsSqlHelper.ExecuteScalar(trans, CommandType.Text, sql, outPars);

                masterRow["mid"] = id;

                sql = base.buildSelectCommand("Select", zMasterTableNameView, null, string.Format("mid={0}", id));

                //Lấy dòng masterrow mới thêm
                DataTable tbl = MsSqlHelper.ExecuteDataTable(trans, CommandType.Text, sql);
                if (tbl == null || tbl.Rows.Count == 0)
                {
                    return false;
                }
                ApplyStt(id.zToInt(), masterRow, detailRows);

                //Lưu bảng detaul
                //sql = base.buildInsertCommand("Insert", zDetailTableName, zDetailTable, true);
                foreach (var row in detailRows)
                {

                    sql = base.buildInsertCommand("Insert", zDetailTableName, zDetailTable, row, out outPars, true);
                    id = MsSqlHelper.ExecuteScalar(trans, CommandType.Text, sql, outPars);
                    row["did"] = id;
                }
                trans.Commit();

                return true;
            }
            catch (SqlException sex)
            {
                trans.Rollback();
                RollBackDataTable(oldId, masterRow, detailRows);
                ret = sex.Number;
                throw new Exception(string.Format("DB{0}", sex.Number), sex);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                RollBackDataTable(oldId, masterRow, detailRows);
                ret = -1;
                throw new Exception("Error");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                trans.Dispose();
                conn.Dispose();
            }
        }

        public bool Update(DataRow masterRow)
        {
            int ret = 0;
            SqlConnection conn = new SqlConnection(ZenDatabase.ConnectionString);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                //Update Master
                SqlParameter[] outPars;
                //masterRow["modified_by"] = ZenApp.CurrentUserId;
                masterRow["modified_at"] = DateTime.Now;
                masterRow["ma_cty"] = CONFIG.Ma_dvcs;
                string sql = base.buildUpdateCommand("Update", zMasterTableName, zMasterTable, masterRow, out outPars);
                if (!string.IsNullOrEmpty(sql))
                    MsSqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, outPars);

                trans.Commit();
                return true;
            }
            catch (SqlException sex)
            {
                trans.Rollback();
                ret = sex.Number;
                Helpers.ErrorProcess.HandleException(sex);
                return false;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                ret = -1;
                Helpers.ErrorProcess.HandleException(ex);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                trans.Dispose();
                conn.Dispose();
            }
        }
        public bool Update(DataRow masterRow, DataRow[] detailRows)
        {
            int ret = 0;
            SqlConnection conn = new SqlConnection(ZenDatabase.ConnectionString);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                //Update Master
                SqlParameter[] outPars;
                //masterRow["modified_by"] = ZenApp.CurrentUserId;
                masterRow["modified_at"] = DateTime.Now;
                masterRow["ma_cty"] = CONFIG.Ma_dvcs;
                string sql = base.buildUpdateCommand("Update", zMasterTableName, zMasterTable, masterRow, out outPars);
                if (!string.IsNullOrEmpty(sql))
                    MsSqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, outPars);

                //string sql = base.buildUpdateCommand("Update", zMasterTableName, zMasterTable);
                //MsSqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, buildUpdateParamters(zMasterTable, masterRow));

                //MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, CommandType.Text, sql, base.buildUpdateParamters(zMasterTable, masterRow));

                //Delete Detail
                sql = string.Format("DELETE {1} WHERE mid = {0}", masterRow["mid"], zDetailTableName);
                MsSqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql);

                //Insert detail
                //sql = base.buildInsertCommand("Insert", zDetailTableName, zDetailTable, true);
                foreach (var row in detailRows)
                {
                    //row["modified_by"] = ZenApp.CurrentUserId;
                    row["modified_at"] = DateTime.Now;
                    row["mid"] = masterRow["mid"];
                    row["ma_cty"] = masterRow["ma_cty"];
                    sql = base.buildInsertCommand("Insert", zDetailTableName, zDetailTable, row, out outPars, true);
                    var id = MsSqlHelper.ExecuteScalar(trans, CommandType.Text, sql, outPars);
                    row["did"] = id;
                }
                trans.Commit();
                return true;
            }
            catch (SqlException sex)
            {
                trans.Rollback();
                ret = sex.Number;
                Helpers.ErrorProcess.HandleException(sex);
                return false;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                ret = -1;
                Helpers.ErrorProcess.HandleException(ex);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                trans.Dispose();
                conn.Dispose();
            }

        }

        public bool Delete(DataRow masterRow)
        {
            string sql = buildDeleteCommand("Delete", zMasterTableName, zMasterTable);
            int ret = 0;
            try
            {
                SqlParameter[] outPars;
                //masterRow["modified_by"] = ZenApp.CurrentUserId;
                masterRow["modified_at"] = DateTime.Now;
                string sqlUpd = base.buildUpdateCommand("Update", zMasterTableName, zMasterTable, masterRow, out outPars);
                if (!string.IsNullOrEmpty(sqlUpd))
                    MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, CommandType.Text, sql, outPars);

                MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, CommandType.Text, sql, base.buildDeleteParamters(zMasterTable, masterRow));
            }
            catch (SqlException sex)
            {
                ret = sex.Number;
                Helpers.ErrorProcess.HandleException(sex);
                return false;
            }
            catch (Exception ex)
            {
                ret = -1;
                Helpers.ErrorProcess.HandleException(ex);
                return false;
            }

            return true;
        }

        private void RollBackDataTable(int id, DataRow masterRow, DataRow[] detailRows)
        {
            ApplyStt(id, masterRow, detailRows);
        }
        private void ApplyStt(int id, DataRow masterRow, DataRow[] detailRows)
        {
            masterRow["mid"] = id;
            foreach (DataRow r in detailRows)
            {
                r["mid"] = id;
                r["ma_cty"] = masterRow["ma_cty"];
            }

        }

        public string GetSoCt(string maCt, DateTime ngayCt)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@_ma_dvcs", CONFIG.Ma_dvcs));
            pars.Add(new SqlParameter("@_ma_ct", maCt));
            pars.Add(new SqlParameter("@_ngay_ct", ngayCt));

            var soCt = MsSqlHelper.ExecuteScalar(ZenDatabase.ConnectionString, CommandType.StoredProcedure, "zUspGetSoCt", pars.ToArray());
            return soCt.zToString();
        }
        public DataTable Read(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                return null;
            string sql = string.Format("select * from {0};", tableName);

            return MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, sql);
        }

        public DataTable Read(string tableName, string where)
        {
            if (string.IsNullOrEmpty(tableName))
                return null;
            if (string.IsNullOrEmpty(where))
                return Read(tableName);

            string sql = string.Format("SELECT * FROM {0} WHERE {1};", tableName, where);

            return MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, sql);
        }

        public DataTable Read(string spName, params object[] parameterValues)
        {
            return MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, spName, parameterValues);
        }
        public DataTable Read(CommandType commandType, string commandText)
        {
            return MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, commandType, commandText);

        }
        public DataTable Read(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            return MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, commandType, commandText, commandParameters);
        }
        public DataSet ReadSet(string tableName, string where)
        {
            if (string.IsNullOrEmpty(tableName))
                return null;
            if (string.IsNullOrEmpty(where))
                return ReadSet(tableName);

            string sql = string.Format("SELECT * FROM {0} WHERE {1};", tableName, where);

            return MsSqlHelper.ExecuteDataset(ZenDatabase.ConnectionString, CommandType.Text, sql);
        }

        public DataSet ReadSet(string spName, params object[] parameterValues)
        {
            return MsSqlHelper.ExecuteDataset(ZenDatabase.ConnectionString, spName, parameterValues);
        }
        public DataSet ReadSet(CommandType commandType, string commandText)
        {
            return MsSqlHelper.ExecuteDataset(ZenDatabase.ConnectionString, commandType, commandText);

        }
        public DataSet ReadSet(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            return MsSqlHelper.ExecuteDataset(ZenDatabase.ConnectionString, commandType, commandText, commandParameters);
        }
        public object ReadScalar(string spName, params object[] parameterValues)
        {
            return MsSqlHelper.ExecuteScalar(ZenDatabase.ConnectionString, spName, parameterValues);
        }
        public object ReadScalar(CommandType cmdType, string cmdText)
        {
            return MsSqlHelper.ExecuteScalar(ZenDatabase.ConnectionString, cmdType, cmdText);
        }
        #endregion
    }
}
