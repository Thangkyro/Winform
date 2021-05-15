using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CoreBase.Helpers;

namespace CoreBase.DataAccessLayer
{
    public class DictionaryDAL : GenericDAL
    {
        public string zEditTableName { get; private set; }
        public string zViewTableName { get; private set; }

        private DataTable _schemaTable;
        protected DataTable zSchemaTable
        {
            get
            {
                if (_schemaTable == null)
                {
                    base.buildSelectCommand("SelectSchema", null, null);
                    _schemaTable = new DataTable(zEditTableName);
                    base.fillData(_schemaTable, "SelectSchema");
                }
                return _schemaTable;
            }
        }
        
        public DictionaryDAL(string viewTableName, string editTableName) : base(editTableName)
        {
            zEditTableName = editTableName;
            zViewTableName = viewTableName;
        }

        public DictionaryDAL(string tableName) : this(tableName, tableName)
        {
        }

        public DataTable GetEmptyViewTable()
        {
            base.buildSelectCommand("SelectEmpty", zViewTableName, null, null);
            DataTable retTable = new DataTable(zViewTableName);
            base.fillData(retTable, "SelectEmpty");
            
            MsSqlHelper.SetDefaultValueForTable(retTable);
            return retTable;
        }
        public DataTable GetData()
        {
            string where = "";
            if (zSchemaTable.Columns.Contains(ZenDatabase.IS_DELETED_COLNAME))
                where = string.Format("{0}=0", ZenDatabase.IS_DELETED_COLNAME);

            if (zSchemaTable.Columns.Contains(ZenDatabase.MA_DVCS_COLUMN_NAME))
                where = string.Format("{0}='{1}'", ZenDatabase.MA_DVCS_COLUMN_NAME, CONFIG.Ma_dvcs);

            string sql = base.buildSelectCommand("Select", zViewTableName, null, where);//)  string.Format("SELECT * FROM {0}", _tableName);

            DataSet ds = MsSqlHelper.ExecuteDataset(ZenDatabase.ConnectionString, CommandType.Text, sql);

            if (ds == null || ds.Tables.Count < 0)
                return null;
            ds.Tables[0].TableName = zViewTableName;
            MsSqlHelper.SetDefaultValueForTable(ds.Tables[0]);
            return ds.Tables[0];
        }
        public DataTable GetData(int id)
        {
            string where = string.Format("id={0}",id);
            if (zSchemaTable.Columns.Contains(ZenDatabase.IS_DELETED_COLNAME))
                where += string.Format(" AND {0}=0", ZenDatabase.IS_DELETED_COLNAME);

            string sql = base.buildSelectCommand("Select", zViewTableName, null, where);//)  string.Format("SELECT * FROM {0}", _tableName);

            DataSet ds = MsSqlHelper.ExecuteDataset(ZenDatabase.ConnectionString, CommandType.Text, sql);

            if (ds == null || ds.Tables.Count < 0)
                return null;
            ds.Tables[0].TableName = zViewTableName;
            MsSqlHelper.SetDefaultValueForTable(ds.Tables[0]);
            return ds.Tables[0];
        }
        public DataTable GetData(string where)
        {
            
            string sWhere = where;

            if (zSchemaTable.Columns.Contains(ZenDatabase.IS_DELETED_COLNAME))
                sWhere += string.Format(" AND {0}=0", ZenDatabase.IS_DELETED_COLNAME);

            if (zSchemaTable.Columns.Contains(ZenDatabase.MA_DVCS_COLUMN_NAME))
                sWhere += string.Format(" AND {0}='{1}'", ZenDatabase.MA_DVCS_COLUMN_NAME, CONFIG.Ma_dvcs);

            string sql = base.buildSelectCommand("Select", zViewTableName, null, sWhere);
            DataSet ds = MsSqlHelper.ExecuteDataset(ZenDatabase.ConnectionString, CommandType.Text, sql);

            if (ds == null || ds.Tables.Count < 0)
                return null;
            ds.Tables[0].TableName = zViewTableName;
            MsSqlHelper.SetDefaultValueForTable(ds.Tables[0]);
            return ds.Tables[0];
        }

        public virtual bool InsertData(DataRow row)
        {
            int ret = 0;

            try
            {
                SqlParameter[] outPars;
                row["modified_at"] = DateTime.Now;
                string sql = base.buildInsertCommand("Insert", zEditTableName, zSchemaTable, row, out outPars, true);
                if (string.IsNullOrEmpty(sql))
                    return true;

                var id = MsSqlHelper.ExecuteScalar(ZenDatabase.ConnectionString, CommandType.Text, sql, outPars);

                return true;
            }
            catch (SqlException sex)
            {
                ret = sex.Number;
                throw new Exception(sex.Message, sex);
            }
            catch (Exception ex)
            {
                ret = -1;
                throw new Exception(ex.Message, ex);
            }
        }
        public virtual bool InsertData(DataRow row,string fkFieldName1, DataInfo child1)
        {
            int ret = 0;
            SqlConnection conn = new SqlConnection(ZenDatabase.ConnectionString);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            var oldFk = row[fkFieldName1];
            
            try
            {
                SqlParameter[] outPars;
                string sql = "";
                sql = base.buildInsertCommand("Insert", zEditTableName, zSchemaTable, row, out outPars, true);
                if (string.IsNullOrEmpty(sql))
                    return true;

                var id = MsSqlHelper.ExecuteScalar(trans, CommandType.Text, sql, outPars);

                sql = base.buildSelectCommand("Select", zViewTableName, null, string.Format("id={0}", id));
                DataTable tbl = MsSqlHelper.ExecuteDataTable(trans, CommandType.Text, sql);
                if (tbl == null || tbl.Rows.Count == 0)
                    return false;

                var newFk = tbl.Rows[0][fkFieldName1];
                row[fkFieldName1] = newFk;

                //Apply fk
                DataTable cTable = new DataTable(child1.TableName);
                base.buildSelectCommand("SelectSchema", child1.TableName, null, null);
                base.fillData(cTable, "SelectSchema");

                foreach (var cRow in child1.Rows)
                {
                    cRow[fkFieldName1] = newFk;

                    sql = base.buildInsertCommand("Insert", child1.TableName, cTable, cRow, out outPars, true);
                    id = MsSqlHelper.ExecuteScalar(trans, CommandType.Text, sql, outPars);
                }

                trans.Commit();
                return true;
            }
            catch (SqlException sex)
            {
                trans.Rollback();
                foreach (var cRow in child1.Rows)
                {
                    cRow[fkFieldName1] = oldFk;
                }
                ret = sex.Number;
                throw new Exception(sex.Message, sex);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                foreach (var cRow in child1.Rows)
                {
                    cRow[fkFieldName1] = oldFk;
                }
                ret = -1;
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                trans.Dispose();
                conn.Dispose();
            }
        }
        public virtual bool UpdateData(DataRow row)
        {
            
            //string sql = "UPDATE zDmNhVt SET modified_by = @modified_by, is_inactive = @is_inactive, ma_nhvt = @ma_nhvt, ten_nhvt = @ten_nhvt WHERE id = @id";
            int ret = 0;

            //IList<SqlParameter> parr = new List<SqlParameter>();
            //parr.Add(new SqlParameter("@modified_by", row["modified_by"]));
            //parr.Add(new SqlParameter("@is_inactive", row["is_inactive"]));
            //parr.Add(new SqlParameter("@ma_nhvt", row["ma_nhvt"]));
            //parr.Add(new SqlParameter("@ten_nhvt", row["ten_nhvt"]));
            //parr.Add(new SqlParameter("@id", row["id"]));

            try
            {
                SqlParameter[] outpars;
                //row["modified_by"] = ZenApp.CurrentUserId;
                row["modified_at"] = DateTime.Now;
                string sql = base.buildUpdateCommand("Update", zEditTableName, zSchemaTable, row, out outpars);
                if (string.IsNullOrEmpty(sql))
                    return true;

                MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, CommandType.Text, sql, outpars);
                return true;
            }
            catch (SqlException sex)
            {
                ret = sex.Number;
                throw new Exception(sex.Message, sex);
            }
            catch (Exception ex)
            {
                ret = -1;
                throw new Exception(ex.Message, ex);
            }
        }
        public virtual bool DeleteData(DataRow row)
        {
            //string sql = string.Format("DELETE FROM {0} WHERE Id = @id", this._tableName);
            string sql = base.buildDeleteCommand("Delete", zEditTableName, zSchemaTable);
            int ret = 0;
            //IList<SqlParameter> parr = new List<SqlParameter>();
            //parr.Add(new SqlParameter("@id", row["id"]));
            try
            {
                MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString,CommandType.Text, sql, base.buildDeleteParamters(zSchemaTable, row));
            }
            catch (SqlException sex)
            {
                ret = sex.Number;
                throw new Exception(sex.Message, sex);
            }
            catch (Exception ex)
            {
                ret = -1;
                throw new Exception(ex.Message, ex);
            }

            return true;
        }
    }
}
