using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CoreBase.DataAccessLayer
{
    public class GenericDAL : IDisposable
    {
        #region Cache command
        protected string _zSourceTableName = string.Empty;
        public virtual string zSourceTableName
        {
            get
            {
                return this._zSourceTableName;
            }
            set
            {
                if (this._zSourceTableName == value)
                {
                    return;
                }
                //if (!this.reset())
                //{
                //    return;
                //}
                this._zSourceTableName = value;
                //this._sourcePermission = this.permission();
            }
        }

        private Dictionary<string, DbCommand> _commandCollection;
        protected internal Dictionary<string, DbCommand> commandCollection
        {
            get
            {
                if (this._commandCollection == null)
                {
                    this.initCommandCollection();
                }
                return this._commandCollection;
            }
        }

        protected void initCommandCollection()
        {
            _commandCollection = new Dictionary<string, DbCommand>();

        }
        public bool containsCommand(string commandKey)
        {
            if (this._commandCollection == null || !this._commandCollection.ContainsKey(commandKey))
            {
                return false;
            }
            return this._commandCollection[commandKey] != null;
        }
        public DbCommand getCommand(string commandKey)
        {
            if (!this.containsCommand(commandKey))
            {
                return null;
            }
            return this._commandCollection[commandKey];
        }
        public DbCommand addCommand(string commandKey, string commandText)
        {
            if (this.containsCommand(commandKey))
            {
                this.commandCollection[commandKey].Cancel();
                this.commandCollection[commandKey].Dispose();
                this.commandCollection.Remove(commandKey);
            }
            this.commandCollection.Add(commandKey, new SqlCommand());
            if (string.IsNullOrEmpty(commandText) && this.containsCommand("Select"))
            {
                commandText = this.getCommand("Select").CommandText;
            }
            DbCommand dbCommand = this.getCommand(commandKey);
            if (dbCommand.CommandText != commandText)
            {
                dbCommand.Connection = this.connection;
                dbCommand.CommandText = commandText;
                dbCommand.CommandType = (commandText.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure);
            }
            return dbCommand;
        }
        #endregion

        #region Ctors
        public GenericDAL() { }
        public GenericDAL(string sourceTableName) { _zSourceTableName = sourceTableName; }
        #endregion

        #region Not user
        private string _defaultNameSpace = "Zen.BusinessEntities";
        public string zDefaultNamespace
        {
            get
            {
                return this._defaultNameSpace;
            }
            set
            {
                if (this._businessEntity == null)
                {
                    this._defaultNameSpace = value;
                }
            }
        }
        
        protected DataSet _businessEntity;
        public virtual DataSet businessEntity
        {
            get
            {
                return null;

                DataSet dataSet;
                try
                {
                    if (this._businessEntity == null && !string.IsNullOrEmpty(this.zSourceTableName))
                    {
                        // this._businessEntity = this.loadBusinessEntity(this.zDefaultNamespace, this.zSourceTableName);
                        if (this._businessEntity == null || !this._businessEntity.Tables.Contains(this.zSourceTableName))
                        {
                            throw new ArgumentNullException(this.zSourceTableName);
                        }
                    }
                    dataSet = this._businessEntity;
                }
                catch (Exception ex1)
                {
                    Exception exception = ex1;
                    //this.u = new Exception(exception.Message, exception);
                    this._businessEntity = null;
                    Trace.TraceError(exception.ToString());
                    dataSet = null;
                    throw;
                }
            }
        }

        //protected virtual DataSet loadBusinessEntity(string pzNamespace, string pzBusinessEntityName)
        //{
        //    return (DataSet)GenericDAL.InitObject(string.Format("{0}.{1}", pzNamespace, pzBusinessEntityName), string.Format("{0}.{1}DataSet", pzNamespace, pzBusinessEntityName), null);
        //}




        //public static object InitObject(string A_0, string A_1, string A_2)
        //{
        //    Assembly assembly = Assembly.Load(new AssemblyName(A_0));
        //    Type type = assembly.GetType(A_1, true, false);
        //    return b.a(type, A_2)();
        //}
        #endregion

        public StringBuilder p = new StringBuilder();

        private DbConnection _connection;
        private bool c;
        public DbConnection connection
        {
            get
            {
                if (this._connection == null)
                {
                    _connection = this.initConnection();
                    c = true;
                }
                return _connection;
            }
            set
            {
                if ((this._connection != null) && this.c)
                {
                    this._connection.Close();
                    this._connection.Dispose();
                    this._connection = null;
                }
                this._connection = value;
                this.c = false;

                if (this._adapter != null)
                {
                    if (this._adapter.InsertCommand != null)
                    {
                        this._adapter.InsertCommand.Connection = value;
                    }
                    if (this._adapter.DeleteCommand != null)
                    {
                        this._adapter.DeleteCommand.Connection = value;
                    }
                    if (this._adapter.UpdateCommand != null)
                    {
                        this._adapter.UpdateCommand.Connection = value;
                    }
                }
                if (this._commandCollection != null)
                {
                    foreach (KeyValuePair<string, DbCommand> pair in this._commandCollection)
                    {
                        if (pair.Value != null)
                        {
                            pair.Value.Connection = value;
                        }
                    }
                }
            }
        }
        
        protected DbConnection initConnection()
        {
            DbConnection connection = new SqlConnection(ZenDatabase.ConnectionString);

            //connection.StateChange -= new StateChangeEventHandler(this.a);
            //connection.StateChange += new StateChangeEventHandler(this.a);
            //((SqlConnection)connection).InfoMessage -= new SqlInfoMessageEventHandler(this.a);
            //((SqlConnection)connection).InfoMessage += new SqlInfoMessageEventHandler(this.a);
            return connection;
        }
        
        public int fillData(DataTable table, string commandKey)
        {
            return this.fillData(table, commandKey, null);
        }
        public int fillData(DataTable table, string commandKey, object[] args)
        {
            object obj;
            return this.fillData(table, commandKey, args, out obj);

        }
        public int fillData(DataTable table, string commandKey, object[] args, out object returnValue)
        {

            int count;
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                DbDataAdapter dbAdapter = this.adapter;
                DbCommand cmd = buildCommand(string.Format("{0}.{1}", table.TableName, commandKey), args);
                DbCommand cmd1 = cmd;
                dbAdapter.SelectCommand = cmd;
                if (cmd == null)
                    throw new ArgumentNullException(commandKey);

                if ((commandKey == "SelectSchema") && (table == null || table.Columns.Count < 1))
                {
                    this.adapter.FillSchema(table, SchemaType.Source);
                }
                if ((commandKey == "SelectEmpty") && (table == null || table.Columns.Count < 1))
                {
                    this.adapter.Fill(table);
                }

                if (commandKey == "SelectSchema" || commandKey == "SelectEmpty")
                {

                    returnValue = 0;
                    return 0;
                }

                table.BeginLoadData();
                ConnectionState state = this.adapter.SelectCommand.Connection.State;

                try
                {
                    if ((this.adapter.SelectCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
                    {
                        this.adapter.SelectCommand.Connection.Open();
                    }
                    int num = 0;

                    using (DbDataReader dbDataReaders = this.adapter.SelectCommand.ExecuteReader())
                    {
                        //if (this.bClearBeforeFill)
                        //{
                        table.Clear();
                        //}
                        num = table.Rows.Count;
                        if (dbDataReaders != null && dbDataReaders.HasRows)
                        {

                            table.Load(dbDataReaders, this.fillingLoadOption);

                            dbDataReaders.Close();

                        }
                    }
                    returnValue = this.getParameterValue(this.adapter.SelectCommand, "RETURN_VALUE");
                    //this.a(this.adapter.SelectCommand);
                    this.p.AppendFormat("Results:{0};", table.Rows.Count - num);
                    sw.Stop();
                    this.p.AppendFormat("Duration:{0}ms;", sw.ElapsedMilliseconds);
                    //Trace.TraceInformation(this.commandExecutionLog);
                    count = table.Rows.Count;
                }
                finally
                {
                    table.EndLoadData();
                    if (state == ConnectionState.Closed)
                    {
                        this.adapter.SelectCommand.Connection.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                returnValue = null;
                count = -1;
            }
            return count;
        }
        private LoadOption _fillingLoadOption = LoadOption.PreserveChanges;
        [DefaultValue(LoadOption.PreserveChanges)]
        public LoadOption fillingLoadOption
        {
            get
            {
                return this._fillingLoadOption;
            }
            set
            {
                this._fillingLoadOption = value;
                if (this._adapter != null)
                {
                    this._adapter.FillLoadOption = this._fillingLoadOption;
                }
            }
        }

        private DbCommand buildCommand(string commandKey, object[] args)
        {
            if (!this.commandCollection.ContainsKey(commandKey))
            {
                return null;
            }

            DbParameter parameter = null;
            if (this.containsParameter(commandKey, "RETURN_VALUE"))
            {
                parameter = this.getParameter(commandKey, "RETURN_VALUE");
                this.getCommand(commandKey).Parameters.Remove(parameter);
            }
            if (args != null)
            {
                for (int i = 0; i < (int)args.Length; i++)
                {
                    if (i < this.getCommand(commandKey).Parameters.Count)
                    {
                        this.getCommand(commandKey).Parameters[i].Value = args[i];
                    }
                }
            }
            if (parameter == null)
            {
                this.addParameter(commandKey, "RETURN_VALUE", null, ParameterDirection.ReturnValue);
            }
            else
            {
                this.getCommand(commandKey).Parameters.Add(parameter);
            }
            return this.getCommand(commandKey);
        }

        public bool containsParameter(string commandKey, string parameterName)
        {
            parameterName = ZenDatabase.ConvertParameterName(parameterName);
            if (this.containsCommand(commandKey) && this.getCommand(commandKey).Parameters.Contains(parameterName) && this.getCommand(commandKey).Parameters[parameterName] != null)
            {
                return true;
            }
            return false;
        }
        public DbParameter getParameter(string commandKey, string parameterName)
        {
            parameterName = ZenDatabase.ConvertParameterName(parameterName);
            if (!this.containsParameter(commandKey, parameterName))
            {
                return null;
            }
            return this.getCommand(commandKey).Parameters[parameterName];
        }
        public object getParameterValue(string commandKey, string parameterName)
        {
            if (!this.containsParameter(commandKey, parameterName))
            {
                return null;
            }
            return this.getParameter(commandKey, parameterName).Value;
        }
        public object getParameterValue(DbCommand command, string parameterName)
        {
            parameterName = ZenDatabase.ConvertParameterName(parameterName);
            if (!command.Parameters.Contains(parameterName))
            {
                return null;
            }
            return command.Parameters[parameterName].Value;
        }
        public DbParameter addParameter(string commandKey, string parameterName, object parameterValue, ParameterDirection parameterDirection)
        {
            object value;
            if (!this.containsCommand(commandKey))
            {
                return null;
            }
            parameterName = ZenDatabase.ConvertParameterName(parameterName);
            if (!this.getCommand(commandKey).Parameters.Contains(parameterName))
            {
                this.getCommand(commandKey).Parameters.Add(new SqlParameter(parameterName, parameterValue));
            }
            DbParameter parameter = this.getParameter(commandKey, parameterName);
            DbParameter dbParameter = parameter;
            if (parameterValue == null)
            {
                value = DBNull.Value;
            }
            else
            {
                value = parameterValue;
            }
            dbParameter.Value = value;
            parameter.Direction = parameterDirection;
            parameter.IsNullable = true;
            parameter.Size = -1;
            return parameter;
        }
        private DbDataAdapter _adapter;
        protected DbDataAdapter adapter
        {
            get
            {
                if (this._adapter == null)
                {
                    this.initAdapter();
                }
                return this._adapter;
            }
        }
        protected void initAdapter()
        {
            this._adapter = new SqlDataAdapter();
            this._adapter.FillLoadOption = this.fillingLoadOption;


        }

        private void a(IDbCommand command)
        {
            bool flag = false;
            foreach (DbParameter parameter in command.Parameters)
            {
                if (parameter.Direction == ParameterDirection.Input)
                {
                    continue;
                }
                if (!flag)
                {
                    this.p.Append((parameter.Direction == ParameterDirection.ReturnValue ? "Return:" : "Output:"));
                    flag = true;
                }
                if (parameter.Value == null || parameter.Value == DBNull.Value)
                {
                    this.p.AppendFormat("{0}=NULL;", parameter.ParameterName);
                }
                else if (parameter.DbType.ToString().Contains("String") || parameter.DbType.ToString().Contains("DateTime"))
                {
                    this.p.AppendFormat("{0}='{1}';", parameter.ParameterName, parameter.Value);
                }
                else
                {
                    this.p.AppendFormat("{0}={1};", parameter.ParameterName, parameter.Value);
                }
            }
        }
        public string buildDeleteCommand(string commandKey, string tableName, DataTable schemaTable)
        {
            StringBuilder sb = new StringBuilder();
            //Nếu có sử dụng trường is_deleted để đánh dấu xóa chứ không xóa hẳn
            //if (schemaTable.Columns.Contains(ZenDatabase.IS_DELETED_COLNAME))
            //    sb.AppendFormat("UPDATE {0} SET {1}=1", tableName, ZenDatabase.IS_DELETED_COLNAME);
            //else
            //    sb.AppendFormat("DELETE FROM {0}", tableName);

            if (schemaTable.Columns.Contains(ZenDatabase.IS_INACTIVE_COLUMN_NAME))
                sb.AppendFormat("UPDATE {0} SET {1}=1", tableName, ZenDatabase.IS_INACTIVE_COLUMN_NAME);
            else
                sb.AppendFormat("DELETE FROM {0}", tableName);

            bool isFirst = true;

            foreach (DataColumn col in schemaTable.PrimaryKey)
            {
                if (isFirst)
                {
                    sb.Append(" WHERE"); isFirst = false;
                }
                else
                    sb.Append(" AND");

                sb.AppendFormat(" {0}={1}", col.ColumnName, ZenDatabase.ConvertParameterName(col.ColumnName));
            }
            
            return sb.ToString();
        }
        public SqlParameter[] buildDeleteParamters(DataTable schemaTable, DataRow deletedRow)
        {
            IList<SqlParameter> pars = new List<SqlParameter>();
            foreach (DataColumn col in schemaTable.PrimaryKey)
            {
                pars.Add(new SqlParameter(ZenDatabase.ConvertParameterName(col.ColumnName), deletedRow[col.ColumnName, DataRowVersion.Original]));
                
            }

            return pars.ToArray();
        }
        public string buildUpdateCommand(string commandKey, string tableName, DataTable schemaTable)
        {
            StringBuilder sb = new StringBuilder(string.Format("UPDATE {0}", tableName));
            StringBuilder sbSet = new StringBuilder();
            StringBuilder sbWhere = new StringBuilder();
            bool isFirst = true;

            foreach (DataColumn col in schemaTable.Columns)
            {
                if (col.AutoIncrement || !string.IsNullOrEmpty( col.Expression) || schemaTable.PrimaryKey.Contains(col)  || ZenDatabase.excludeColumns.Contains(col.ColumnName))
                {
                    continue;
                }
                if (isFirst)
                {
                    sbSet.AppendFormat("{0}={1}", col.ColumnName, ZenDatabase.ConvertParameterName(col.ColumnName));
                    isFirst = false;
                }
                else
                    sbSet.AppendFormat(",{0}={1}", col.ColumnName, ZenDatabase.ConvertParameterName(col.ColumnName));

            }
            isFirst = true;
            foreach (DataColumn col in schemaTable.PrimaryKey)
            {
                if (!isFirst)
                    sbWhere.Append(" AND");

                sbWhere.AppendFormat(" {0}={1}", col.ColumnName, ZenDatabase.ConvertParameterName(col.ColumnName));
            }

            sb.Append(sbSet.Length > 0 ? " SET " + sbSet.ToString() : "");
            sb.Append(sbWhere.Length > 0 ? " WHERE " + sbWhere.ToString() : "");

            return sb.ToString();
        }
        public string buildUpdateCommand(string commandKey, string tableName, DataTable schemaTable, DataRow updateRow,out SqlParameter[] pars)
        {
            IList<SqlParameter> lsPars = new List<SqlParameter>();

            StringBuilder sb = new StringBuilder(string.Format("UPDATE {0}", tableName));
            StringBuilder sbSet = new StringBuilder();
            StringBuilder sbWhere = new StringBuilder();
            bool isFirst = true;

            foreach (DataColumn col in schemaTable.Columns)
            {
                //Update for update branchID
                if (NailApp.IsAdmin() && !(col.AutoIncrement || !string.IsNullOrEmpty(col.Expression) || ZenDatabase.excludeColumns.Contains(col.ColumnName)
                    || !updateRow.Table.Columns.Contains(col.ColumnName)))
                {

                }
                else 
                if (col.AutoIncrement || !string.IsNullOrEmpty(col.Expression) || schemaTable.PrimaryKey.Contains(col) || ZenDatabase.excludeColumns.Contains(col.ColumnName)
                    || !updateRow.Table.Columns.Contains(col.ColumnName))
                {
                    continue;
                }
                
                var orgVal = updateRow[col.ColumnName, DataRowVersion.Original];
                var newVal = updateRow[col.ColumnName];
                if (!orgVal.Equals(newVal))
                {
                    if (isFirst)
                    {
                        sbSet.AppendFormat("{0}={1}", col.ColumnName, ZenDatabase.ConvertParameterName(col.ColumnName));
                        isFirst = false;
                    }
                    else
                        sbSet.AppendFormat(",{0}={1}", col.ColumnName, ZenDatabase.ConvertParameterName(col.ColumnName));

                    lsPars.Add(new SqlParameter(ZenDatabase.ConvertParameterName(col.ColumnName), newVal));
                }
            }

            isFirst = true;
            foreach (DataColumn col in schemaTable.PrimaryKey)
            {
                if (NailApp.IsAdmin() && col.ColumnName == "branchId") //Update for update branchID
                {
                    continue;
                }
                if (!isFirst)
                    sbWhere.Append(" AND");

                sbWhere.AppendFormat(" {0}={1}", col.ColumnName, ZenDatabase.ConvertParameterName(col.ColumnName));
                lsPars.Add(new SqlParameter(ZenDatabase.ConvertParameterName(col.ColumnName), updateRow[col.ColumnName]));
                isFirst = false;
            }

            pars = lsPars.ToArray();

            if (sbSet.Length ==0)
                return "";
            
            sb.Append(sbSet.Length > 0 ? " SET " + sbSet.ToString() : "");
            sb.Append(sbWhere.Length > 0 ? " WHERE " + sbWhere.ToString() : "");

            

            return sb.ToString();
        }
        public SqlParameter[] buildUpdateParamters(DataTable schemaTable, DataRow updateRow)
        {
            IList<SqlParameter> pars = new List<SqlParameter>();
            foreach (DataColumn col in schemaTable.Columns)
            {
                if (!string.IsNullOrEmpty(col.Expression) || ZenDatabase.excludeColumns.Contains(col.ColumnName))
                {
                    continue;
                }

                var orgVal = updateRow[col.ColumnName, DataRowVersion.Original];
                var newVal = updateRow[col.ColumnName];

                pars.Add(new SqlParameter(ZenDatabase.ConvertParameterName(col.ColumnName), updateRow[col.ColumnName]));
            }

            return pars.ToArray();
        }
        public string buildInsertCommand(string commandKey, string tableName, DataTable schemaTable, bool hasRetId)
        {
            StringBuilder sb = new StringBuilder(string.Format("INSERT INTO {0}", tableName));
            
            StringBuilder sbCols = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            bool isFirst = true;

            foreach (DataColumn col in schemaTable.Columns)
            {
                if (col.AutoIncrement || !string.IsNullOrEmpty(col.Expression) || ZenDatabase.excludeColumns.Contains(col.ColumnName))
                {
                    continue;
                }

                if (isFirst)
                {
                    sbCols.Append(col.ColumnName);
                    sbValues.Append(ZenDatabase.ConvertParameterName(col.ColumnName));
                    isFirst = false;
                }
                else
                {
                    sbCols.AppendFormat(",{0}", col.ColumnName);
                    sbValues.AppendFormat(",{0}", ZenDatabase.ConvertParameterName(col.ColumnName));
                }
            }

            if (sbCols.Length == 0)
                return null;

            //sb.AppendFormat(" ({0}) {1} VALUES ({2})", sbCols.ToString(), hasRetId? "OUTPUT INSERTED.id" : "", sbValues.ToString());
            sb.AppendFormat(" ({0}) VALUES ({1}){2} ", sbCols.ToString(), sbValues.ToString(), hasRetId ? "; SELECT SCOPE_IDENTITY();" : "");
            //sb.AppendFormat(" ({0}) VALUES ({1}){2} ", sbCols.ToString(), sbValues.ToString(), hasRetId ? "; SELECT @@Identity;" : "");
            return sb.ToString();
        }
        public string buildInsertCommand(string commandKey, string tableName, DataTable schemaTable, DataRow  insertRow, out SqlParameter[] pars, bool hasRetId)
        {
            IList<SqlParameter> lsPars = new List<SqlParameter>();
            StringBuilder sb = new StringBuilder(string.Format("INSERT INTO {0}", tableName));

            StringBuilder sbCols = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            bool isFirst = true;

            foreach (DataColumn col in schemaTable.Columns)
            {
                if (col.AutoIncrement || !string.IsNullOrEmpty(col.Expression) || ZenDatabase.excludeColumns.Contains(col.ColumnName))
                {
                    continue;
                }
                if (insertRow.Table.Columns.Contains(col.ColumnName))
                {
                    if (isFirst)
                    {
                        sbCols.Append(col.ColumnName);
                        sbValues.Append(ZenDatabase.ConvertParameterName(col.ColumnName));                        
                        isFirst = false;
                    }
                    else
                    {
                        sbCols.AppendFormat(",{0}", col.ColumnName);
                        sbValues.AppendFormat(",{0}", ZenDatabase.ConvertParameterName(col.ColumnName));
                    }
                    lsPars.Add(new SqlParameter(ZenDatabase.ConvertParameterName(col.ColumnName), insertRow[col.ColumnName]));
                }
            }
            pars = lsPars.ToArray();

            if (sbCols.Length == 0)
                return null;

            //sb.AppendFormat(" ({0}) {1} VALUES ({2})", sbCols.ToString(), hasRetId? "OUTPUT INSERTED.id" : "", sbValues.ToString());
            sb.AppendFormat(" ({0}) VALUES ({1}){2} ", sbCols.ToString(), sbValues.ToString(), hasRetId ? "; SELECT SCOPE_IDENTITY();" : "");
            //sb.AppendFormat(" ({0}) VALUES ({1}){2} ", sbCols.ToString(), sbValues.ToString(), hasRetId ? "; SELECT @@Identity;" : "");
            return sb.ToString();
        }
        public SqlParameter[] buildInsertParamters(DataTable schemaTable, DataRow insertRow)
        {
            IList<SqlParameter> pars = new List<SqlParameter>();
            foreach (DataColumn col in schemaTable.Columns)
            {
                if (col.AutoIncrement || !string.IsNullOrEmpty(col.Expression) || ZenDatabase.excludeColumns.Contains(col.ColumnName))
                {
                    continue;
                }

                pars.Add(new SqlParameter(ZenDatabase.ConvertParameterName(col.ColumnName), insertRow[col.ColumnName]));
            }

            return pars.ToArray();
        }

        public string buildSelectCommand(string commandKey, string tableName, string overrideColumnList, string whereExpr)
        {
            StringBuilder sb = new StringBuilder("SELECT");
            if (!string.IsNullOrEmpty(overrideColumnList))
            {
                sb.AppendFormat(" {0}", overrideColumnList);
            }
            else if (commandKey == "SelectSchema" || commandKey == "SelectEmpty")
            {
                sb.Append(" TOP 0 *");
            }
            else
            {
                sb.Append(" *");
            }

            sb.AppendFormat(" FROM {0}", tableName);
            if (commandKey == "SelectSchema" || commandKey == "SelectEmpty")
            {
                sb.Append(";");
                addCommand(string.Format("{0}.{1}", tableName, commandKey), sb.ToString());
                return sb.ToString();
            }

            if (!string.IsNullOrEmpty(whereExpr))
            {
                sb.AppendFormat(" WHERE {0}", whereExpr);
            }
            

            addCommand(string.Format("{0}.{1}", tableName, commandKey), sb.ToString());
            return sb.ToString();
        }
        public void buildSelectCommand(string commandKey, string overrideColumnList, string whereExpr)
        {
            StringBuilder sb = new StringBuilder("SELECT");
            if (!string.IsNullOrEmpty(overrideColumnList))
            {
                sb.AppendFormat(" {0}", overrideColumnList);
            }
            else if (commandKey != "SelectSchema")
            {
                sb.Append(" *");
            }
            else
            {
                sb.Append(" TOP 0 *");
            }

            sb.AppendFormat(" FROM {0}", this.zSourceTableName);
            if (commandKey == "SelectSchema")
            {
                sb.Append(";");
                addCommand(string.Format("{0}.{1}", zSourceTableName,commandKey), sb.ToString());
                return;
            }

            if (!string.IsNullOrEmpty(whereExpr))
            {
                sb.AppendFormat(" WHERE {0}", whereExpr);
            }
            addCommand(string.Format("{0}.{1}", zSourceTableName, commandKey), sb.ToString());

        }

        public void Dispose()
        {
            if (_connection == null)
                return;

            if ( _connection.State == ConnectionState.Open)
                _connection.Close();
            _connection.Dispose();
        }
    }
}
