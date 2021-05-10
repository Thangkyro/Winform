using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CoreBase.DataAccessLayer
{
    public class SimpleListDAL : GenericDAL
    {
        private string _schemaTableName;
        private DataTable _schemaTable;
        protected DataTable zSchemaTable
        {
            get
            {
                if (_schemaTable == null)
                {
                    this.buildSelectCommand("SelectSchema", null,null);
                    _schemaTable = new DataTable(_schemaTableName);
                    base.fillData(_schemaTable, "SelectSchema");
                }
                return _schemaTable;
            }
        }
        public SimpleListDAL(string tableName) :base(tableName)
        {
            _schemaTableName = tableName;

            initSource();
            
        }

        public virtual void initSource()
        {
            if (this._schemaTable != null)
                this._schemaTable.Dispose();

            this.buildSelectCommand("SelectSchema", null, null);
            _schemaTable = new DataTable(_schemaTableName);
            base.fillData(_schemaTable, "SelectSchema");
        }

        public bool SaveData(DataTable tbl)
        {
            if (tbl == null)
                return true;

            string cmdText = string.Empty;
            SqlConnection conn = new SqlConnection(ZenDatabase.ConnectionString);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            IList<SqlParameter> pars = new List<SqlParameter>();

            try
            {
                //Xóa
                cmdText = base.buildDeleteCommand("Delete", _schemaTableName, zSchemaTable);// string.Format("DELETE FROM {0} WHERE {1} = @id", _tableName, ZenDatabase.ID_COLUMN_NAME);
               
                foreach (DataRow dr in tbl.Select(null, null, DataViewRowState.Deleted))
                {

                    MsSqlHelper.ExecuteNonQuery(trans, CommandType.Text, cmdText, base.buildDeleteParamters(_schemaTable, dr));
                    
                }
                //Update
                cmdText = buildUpdateCommand("Update", _schemaTableName, zSchemaTable);

                //cmdText = string.Format("UPDATE {0} SET dvt = @dvt, {1} = @is_inactive WHERE {2} = @id", _tableName, ZenDatabase.INACTIVE_COLUMN_NAME, ZenDatabase.ID_COLUMN_NAME);

                foreach (DataRow dr in tbl.Select(null, null, DataViewRowState.ModifiedOriginal | DataViewRowState.Unchanged | DataViewRowState.ModifiedCurrent))
                {
                    //dr["modified_by"] = ZenApp.CurrentUserId;
                    dr["modified_at"] = DateTime.Now;
                    MsSqlHelper.ExecuteNonQuery(trans, CommandType.Text, cmdText, buildUpdateParamters(_schemaTable,dr) );
                }
                //insert
                cmdText = buildInsertCommand("Insert", _schemaTableName, zSchemaTable, true);// string.Format("INSERT INTO {0} (dvt,{1}) OUTPUT INSERTED.id VALUES (@dvt,@is_inactive) ", _tableName, ZenDatabase.INACTIVE_COLUMN_NAME);
                foreach (DataRow dr in tbl.Select(null, null, DataViewRowState.Added))
                {
                    
                    var id = MsSqlHelper.ExecuteScalar(trans, CommandType.Text, cmdText,buildInsertParamters(_schemaTable, dr));
                    dr["id"] = id;
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
                trans.Dispose();
                conn.Dispose();
            }

            return true;
        }

        public DataTable GetData()
        {
            return GetData(null);
        }

        public DataTable GetData(string condition)
        {
            string where = "";
            bool isFirst = true;

            if (zSchemaTable.Columns.Contains(ZenDatabase.IS_DELETED_COLNAME))
            {
                where = string.Format("{0}=0", ZenDatabase.IS_DELETED_COLNAME);
                isFirst = false;
            }

            if (!string.IsNullOrEmpty(condition))
            {
                if (isFirst)
                    where = condition;
                else
                    where = condition + " AND " + where;
            }

            string sql = base.buildSelectCommand("Select", _schemaTableName, null, where); // string.Format("SELECT * FROM {0}", _tableName);

            DataSet ds = MsSqlHelper.ExecuteDataset(ZenDatabase.ConnectionString, CommandType.Text, sql);

            if (ds == null || ds.Tables.Count < 0)
                return null;
            ds.Tables[0].TableName = _schemaTableName;
            //ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["id"] };

            MsSqlHelper.SetDefaultValueForTable(ds.Tables[0]);
            return ds.Tables[0];

            ////Where
            //string where = null;
            //if (this._sourceTable != null)
            //{
            //    if (_sourceTable.Columns.Contains(ZenDatabase.INACTIVE_COLUMN_NAME))
            //    {
            //        where = string.Format("{0}=0", ZenDatabase.INACTIVE_COLUMN_NAME);
            //    }
            //}
            ////Select command
            //buildSelectCommand("Select", null, where);

            //fillData(_sourceTable, "Select");
            //return _sourceTable;
        }

    }
    public class SimpleListDAL1 : GenericDAL
    {
        string[] excludeColumns = { "created_at", "modified_at", "timestamp" };
        private string _tableName;
        private DataTable _sourceTable;

        public SimpleListDAL1(string tableName)
        {
            _tableName = tableName;
            initSource();
            //AutoBuildCommand();
        }

        public virtual void initSource()
        {
            if (this._sourceTable != null)
                this._sourceTable.Dispose();

            this.buildSelectCommand("SelectSchema", null, null);
            _sourceTable = new DataTable(_tableName);
            base.fillData(_sourceTable, "SelectSchema");


        }
        
        protected void AutoBuildCommand()
        {
            DataTableMapping tableMapping = new DataTableMapping()
            {
                SourceTable = "Table",
                DataSetTable = _tableName
            };

            StringBuilder stringBuilder = null;
            StringBuilder stringBuilder1 = null;
            StringBuilder stringBuilder2 = null;
            stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("INSERT INTO [{0}] ", this._sourceTable);
            stringBuilder1 = new StringBuilder();
            stringBuilder1.AppendFormat("UPDATE [{0}] SET ", this._sourceTable);
            stringBuilder2 = new StringBuilder();
            stringBuilder2.AppendFormat("DELETE FROM [{0}] ", this._sourceTable);
            foreach (DataColumn column in _sourceTable.Columns)
            {
                if (!string.IsNullOrEmpty(column.Expression))
                {
                    continue;
                }
                tableMapping.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                
                string.Compare(column.ColumnName,ZenDatabase.MODIFIED_AT_COLUMN_NAME, true); 
            }
            adapter.TableMappings.Add(tableMapping);

            if (_sourceTable.PrimaryKey.Length < 0)
            {
                throw new ZenIncorrectSchemaException(this._tableName, "<PRIMARYKEY>");
            }
            if (!_sourceTable.Columns.Contains("timestamp"))
            {
                throw new ZenIncorrectSchemaException(this._tableName, new string[] { "timestamp" });
            }
            for (int i = 0; i < (int)_sourceTable.PrimaryKey.Length; i++)
            {
                stringBuilder2.AppendFormat(" {0} [{1}]={2}", (i == 0 ? "WHERE" : "AND"), _sourceTable.PrimaryKey[i].ColumnName, ZenDatabase.ConvertParameterName(string.Concat("Original_", _sourceTable.PrimaryKey[i].ColumnName)));
                this.adapter.DeleteCommand.Parameters.Add(this.getParameter(_sourceTable.PrimaryKey[i], DataRowVersion.Original));
            }
        }
        private string BuildInsertSql()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("INSERT INTO [{0}] ", this._sourceTable);
            StringBuilder values = new StringBuilder("VALUES (");
            bool bFirst = true;
            bool bIdentity = false;
            string identityType = null;

            foreach (DataColumn column in _sourceTable.Columns)
            {
                if (!column.AutoIncrement && string.IsNullOrEmpty( column.Expression) && !excludeColumns.Contains(column.ColumnName.ToLower()))
                {
                    if (bFirst)
                        bFirst = false;
                    else
                    {
                        sql.Append(", ");
                        values.Append(", ");
                    }

                    sql.Append(column.ColumnName);
                    values.Append(ZenDatabase.ConvertParameterName(column.ColumnName));
                    values.Append(column.ColumnName);
                }
            }
            sql.Append(") ");
            sql.Append(values.ToString());
            sql.Append(")");
            sql.Append("; SELECT * FROM {0} WHERE id = scope_identity();");

            return sql.ToString(); ;

        }
        private DbParameter getParameter(DataColumn column, DataRowVersion rowVersion)
        {
            SqlParameter sqlParameter = new SqlParameter();
            if (rowVersion != DataRowVersion.Original)
            {
                sqlParameter.ParameterName = ZenDatabase.ConvertParameterName(column.ColumnName);
            }
            else
            {
                sqlParameter.ParameterName = ZenDatabase.ConvertParameterName(string.Concat("Original_", column.ColumnName));
            }
            sqlParameter.Direction = ParameterDirection.Input;
            sqlParameter.IsNullable = true;
            sqlParameter.SourceColumn = column.ColumnName;
            sqlParameter.SourceColumnNullMapping = false;
            sqlParameter.SourceVersion = rowVersion;
            if (column.ColumnName == "timestamp")
            {
                sqlParameter.SqlDbType = SqlDbType.Timestamp;
            }
            else if (column.DataType == typeof(byte[]))
            {
                sqlParameter.SqlDbType = SqlDbType.VarBinary;
            }
            sqlParameter.XmlSchemaCollectionDatabase = string.Empty;
            sqlParameter.XmlSchemaCollectionName = string.Empty;
            sqlParameter.XmlSchemaCollectionOwningSchema = string.Empty;
            return sqlParameter;
        }
        public DataTable GetData()
        {
            //Where
            string where = null;
            if (this._sourceTable != null)
            {
                if (_sourceTable.Columns.Contains(ZenDatabase.INACTIVE_COLUMN_NAME))
                {
                    where = string.Format("{0}=0", ZenDatabase.INACTIVE_COLUMN_NAME);
                }
            }
            //Select command
            buildSelectCommand("Select", null, where);

            fillData(_sourceTable, "Select");
            return _sourceTable;
            
        }
        
    }
}
