using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Windows.Forms;
using CoreBase.Helpers;
using System.Data.Common;
using System.ComponentModel;
using System.Diagnostics;


namespace CoreBase.DataAccessLayer
{
   
    public class ZenDbInfo
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool isWin { get; set; }
        public string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = ServerName;
                scsb.InitialCatalog = DatabaseName;
                if (!isWin)
                {
                    scsb.IntegratedSecurity = true;
                }
                else
                {
                    scsb.PersistSecurityInfo = true;
                    scsb.UserID = UserName;
                    scsb.Password = Password;
                }

                return scsb.ConnectionString;
            }
        }
        public static ZenDbInfo GetDbInfo(string connectionString)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(connectionString);
            ZenDbInfo dta = new ZenDbInfo();
            dta.ServerName = scsb.DataSource;
            dta.DatabaseName = scsb.InitialCatalog;
            if (!scsb.IntegratedSecurity)
            {
                dta.UserName = scsb.UserID;
                dta.Password = scsb.Password;
                dta.isWin = true;
            }
            else
            {
                dta.isWin = false;
            }
            return dta;

        }

    }
    public class ZenDatabase
    {
        public static DateTime CurrentDateTime
        {
            get
            {
                string cmdText = "select getdate() as current_datetime";
                try
                {
                    var curDt = MsSqlHelper.ExecuteScalar(ZenDatabase.ConnectionString, CommandType.Text, cmdText);
                    return (DateTime)curDt;
                }
                catch (Exception ex)
                {
                    ErrorProcess.HandleException(ex);
                    return DateTime.Now;
                }
            }
        }
        public static DateTime CurrentDate
        {
            get
            {
                return CurrentDateTime.Date;
            }
        }
        private static ZenDbInfo _currentDbInfo = null;
        public static ZenDbInfo CurrentDbInfo
        {
            get { return _currentDbInfo; }
            set
            {
                _currentDbInfo = value;
                _connectionString = GetConnectionString(value);
            }
        }
        private static string _connectionString = string.Empty;
        public static string DbCfgPassEncrypt = "dbconfig";
        public const string CREATED_AT_COLUMN_NAME = "created_at";
        public const string CREATED_BY_COLUMN_NAME = "created_by";
        public const string MODIFIED_AT_COLUMN_NAME = "created_at";
        public const string MODIFIED_BY_COLUMN_NAME = "created_by";
        public const string ID_COLUMN_NAME = "id";
        public const string TIMESTAMP_COLUM_NAME = "timestamp";
        public const string VERSION_TRACK_COLUMN_NAME = "version_track";
        public const string INACTIVE_COLUMN_NAME = "inactive";
        public const string IS_INACTIVE_COLUMN_NAME = "is_inactive";
        public const string IS_DELETED_COLNAME = "is_deleted";
        public const string MA_DVCS_COLUMN_NAME = "ma_dvcs";
        public static string[] excludeColumns = { "created_at", "timestamp", "version_track"}; // "modified_at",
        private DbConnection _connection;
        public DbConnection Connection
        {
            get
            {
                if (this._connection == null)
                {
                    _connection = this.InitConnection();
                }
                return _connection;
            }
            set
            {
                if ((this._connection != null))// && this.c)
                {
                    this._connection.Close();
                    this._connection.Dispose();
                    this._connection = null;
                }
                this._connection = value;

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

        protected DbConnection InitConnection()
        {
            DbConnection connection = new SqlConnection(ConnectionString);

            //connection.StateChange -= new StateChangeEventHandler(this.a);
            //connection.StateChange += new StateChangeEventHandler(this.a);
            //((SqlConnection)connection).InfoMessage -= new SqlInfoMessageEventHandler(this.a);
            //((SqlConnection)connection).InfoMessage += new SqlInfoMessageEventHandler(this.a);
            return connection;
        }
        private DbDataAdapter _adapter;
        protected DbDataAdapter Adapter
        {
            get
            {
                if (this._adapter == null)
                {
                    this.InitAdapter();
                }
                return this._adapter;
            }
        }

        private LoadOption _fillingLoadOption = LoadOption.PreserveChanges;
        [DefaultValue(LoadOption.PreserveChanges)]
        public LoadOption FillingLoadOption
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
        private Dictionary<string, DbCommand> _commandCollection;
        protected internal Dictionary<string, DbCommand> CommandCollection
        {
            get
            {
                if (this._commandCollection == null)
                {
                    _commandCollection = new Dictionary<string, DbCommand>();
                }
                return this._commandCollection;
            }
        }

        public static ZenDbInfo GetDbInfo(string connectionString)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(connectionString);
            return new ZenDbInfo()
            {
                ServerName = scsb.DataSource,
                DatabaseName = scsb.InitialCatalog,
                UserName = scsb.UserID,
                Password = scsb.Password
            };
        }
        public static void InitCurrentDb()
        {

            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            string connStringName = conf.AppSettings.Settings["ConnectionString"].Value;
            ConnectionStringSettings css = conf.ConnectionStrings.ConnectionStrings[connStringName];
            _connectionString = "Persist Security Info = True;" + StringCipher.Decrypt(css.ConnectionString, ZenDatabase.DbCfgPassEncrypt);
            CurrentDbInfo = GetDbInfo(_connectionString);

        }
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString) )
                {
                    InitCurrentDb();
                }
                return _connectionString;


                //return string.Format("Server={0}; User id={1}; Password={2}; Database={3}", new object[] { serverName, userName, password, dbname });
            }
        }
        public static string GetConnectionString(ZenDbInfo dbInfo)
        {
            return GetConnectionString(dbInfo.ServerName, dbInfo.DatabaseName, dbInfo.UserName, dbInfo.Password);

        }
        public static string GetConnectionString(string serverName, string databaseName, string userName, string password)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = serverName;
            scsb.InitialCatalog = databaseName;
            scsb.UserID = userName;
            scsb.Password = password;
            scsb.PersistSecurityInfo = true;

            return scsb.ConnectionString;
            //    return string.Format("Server={0};Database={1};User Id={2};Password={3};",
            //        serverName, databaseName, userName, password);
        }

        public static string ConvertParameterName(string pzName)
        {
            if (pzName == string.Concat("@_"[0], "RETURN_VALUE"))
            {
                return pzName;
            }
            if (pzName == "@_RETURN_VALUE" || pzName == "RETURN_VALUE")
            {
                return string.Concat("@_"[0], "RETURN_VALUE");
            }
            if (pzName.StartsWith("@_"))
            {
                return pzName;
            }
            return pzName.Insert(0, "@_");
        }

        public static bool TestConnection(string connString)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                Helpers.ErrorProcess.HandleException(ex);
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        protected void InitAdapter()
        {
            this._adapter = new SqlDataAdapter();
            this._adapter.FillLoadOption = this.FillingLoadOption;


        }

        public string BuildSelectCommand(string commandKey, string tableName, string overrideColumnList, string whereExpr)
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
                AddCommand(string.Format("{0}.{1}", tableName, commandKey), sb.ToString());
                return sb.ToString();
            }

            if (!string.IsNullOrEmpty(whereExpr))
            {
                sb.AppendFormat(" WHERE {0}", whereExpr);
            }


            AddCommand(string.Format("{0}.{1}", tableName, commandKey), sb.ToString());
            return sb.ToString();
        }
        public string BuildDeleteCommand(string commandKey, string tableName, DataTable schemaTable)
        {
            StringBuilder sb = new StringBuilder();
            //Nếu có sử dụng trường is_deleted để đánh dấu xóa chứ không xóa hẳn
            if (schemaTable.Columns.Contains(IS_DELETED_COLNAME))
                sb.AppendFormat("UPDATE {0} SET {1}=1", tableName, IS_DELETED_COLNAME);
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

                sb.AppendFormat(" {0}={1}", col.ColumnName, ConvertParameterName(col.ColumnName));
            }

            return sb.ToString();
        }
        public SqlParameter[] BuildDeleteParamters(DataTable schemaTable, DataRow deletedRow)
        {
            IList<SqlParameter> pars = new List<SqlParameter>();
            foreach (DataColumn col in schemaTable.PrimaryKey)
            {
                pars.Add(new SqlParameter(ConvertParameterName(col.ColumnName), deletedRow[col.ColumnName, DataRowVersion.Original]));

            }

            return pars.ToArray();
        }
        public string BuildUpdateCommand(string commandKey, string tableName, DataTable schemaTable)
        {
            StringBuilder sb = new StringBuilder(string.Format("UPDATE {0}", tableName));
            StringBuilder sbSet = new StringBuilder();
            StringBuilder sbWhere = new StringBuilder();
            bool isFirst = true;

            foreach (DataColumn col in schemaTable.Columns)
            {
                if (col.AutoIncrement || !string.IsNullOrEmpty(col.Expression) || schemaTable.PrimaryKey.Contains(col) || excludeColumns.Contains(col.ColumnName))
                {
                    continue;
                }
                if (isFirst)
                {
                    sbSet.AppendFormat("{0}={1}", col.ColumnName, ConvertParameterName(col.ColumnName));
                    isFirst = false;
                }
                else
                    sbSet.AppendFormat(",{0}={1}", col.ColumnName, ConvertParameterName(col.ColumnName));

            }
            isFirst = true;
            foreach (DataColumn col in schemaTable.PrimaryKey)
            {
                if (!isFirst)
                    sbWhere.Append(" AND");

                sbWhere.AppendFormat(" {0}={1}", col.ColumnName, ConvertParameterName(col.ColumnName));
            }

            sb.Append(sbSet.Length > 0 ? " SET " + sbSet.ToString() : "");
            sb.Append(sbWhere.Length > 0 ? " WHERE " + sbWhere.ToString() : "");

            return sb.ToString();
        }
        public string BuildUpdateCommand(string commandKey, string tableName, DataTable schemaTable, DataRow updateRow, out SqlParameter[] pars)
        {
            IList<SqlParameter> lsPars = new List<SqlParameter>();

            StringBuilder sb = new StringBuilder(string.Format("UPDATE {0}", tableName));
            StringBuilder sbSet = new StringBuilder();
            StringBuilder sbWhere = new StringBuilder();
            bool isFirst = true;

            foreach (DataColumn col in schemaTable.Columns)
            {
                if (col.AutoIncrement || !string.IsNullOrEmpty(col.Expression) || schemaTable.PrimaryKey.Contains(col) || excludeColumns.Contains(col.ColumnName)
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
                        sbSet.AppendFormat("{0}={1}", col.ColumnName, ConvertParameterName(col.ColumnName));
                        isFirst = false;
                    }
                    else
                        sbSet.AppendFormat(",{0}={1}", col.ColumnName, ConvertParameterName(col.ColumnName));

                    lsPars.Add(new SqlParameter(ConvertParameterName(col.ColumnName), newVal));
                }
            }

            isFirst = true;
            foreach (DataColumn col in schemaTable.PrimaryKey)
            {
                if (!isFirst)
                    sbWhere.Append(" AND");
                else
                    isFirst = false;

                sbWhere.AppendFormat(" {0}={1}", col.ColumnName, ConvertParameterName(col.ColumnName));
                lsPars.Add(new SqlParameter(ConvertParameterName(col.ColumnName), updateRow[col.ColumnName]));
            }

            pars = lsPars.ToArray();

            if (sbSet.Length == 0)
                return "";

            sb.Append(sbSet.Length > 0 ? " SET " + sbSet.ToString() : "");
            sb.Append(sbWhere.Length > 0 ? " WHERE " + sbWhere.ToString() : "");



            return sb.ToString();
        }
        public SqlParameter[] BuildUpdateParamters(DataTable schemaTable, DataRow updateRow)
        {
            IList<SqlParameter> pars = new List<SqlParameter>();
            foreach (DataColumn col in schemaTable.Columns)
            {
                if (!string.IsNullOrEmpty(col.Expression) || excludeColumns.Contains(col.ColumnName))
                {
                    continue;
                }

                var orgVal = updateRow[col.ColumnName, DataRowVersion.Original];
                var newVal = updateRow[col.ColumnName];

                pars.Add(new SqlParameter(ConvertParameterName(col.ColumnName), updateRow[col.ColumnName]));
            }

            return pars.ToArray();
        }
        public string BuildInsertCommand(string commandKey, string tableName, DataTable schemaTable, bool hasRetId)
        {
            StringBuilder sb = new StringBuilder(string.Format("INSERT INTO {0}", tableName));

            StringBuilder sbCols = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            bool isFirst = true;

            foreach (DataColumn col in schemaTable.Columns)
            {
                if (col.AutoIncrement || !string.IsNullOrEmpty(col.Expression) || excludeColumns.Contains(col.ColumnName))
                {
                    continue;
                }

                if (isFirst)
                {
                    sbCols.Append(col.ColumnName);
                    sbValues.Append(ConvertParameterName(col.ColumnName));
                    isFirst = false;
                }
                else
                {
                    sbCols.AppendFormat(",{0}", col.ColumnName);
                    sbValues.AppendFormat(",{0}", ConvertParameterName(col.ColumnName));
                }
            }

            if (sbCols.Length == 0)
                return null;

            //sb.AppendFormat(" ({0}) {1} VALUES ({2})", sbCols.ToString(), hasRetId? "OUTPUT INSERTED.id" : "", sbValues.ToString());
            sb.AppendFormat(" ({0}) VALUES ({1}){2} ", sbCols.ToString(), sbValues.ToString(), hasRetId ? "; SELECT SCOPE_IDENTITY();" : "");
            //sb.AppendFormat(" ({0}) VALUES ({1}){2} ", sbCols.ToString(), sbValues.ToString(), hasRetId ? "; SELECT @@Identity;" : "");
            return sb.ToString();
        }
        public string BuildInsertCommand(string commandKey, string tableName, DataTable schemaTable, DataRow insertRow, out SqlParameter[] pars, bool hasRetId)
        {
            IList<SqlParameter> lsPars = new List<SqlParameter>();
            StringBuilder sb = new StringBuilder(string.Format("INSERT INTO {0}", tableName));

            StringBuilder sbCols = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            bool isFirst = true;

            foreach (DataColumn col in schemaTable.Columns)
            {
                if (col.AutoIncrement || !string.IsNullOrEmpty(col.Expression) || excludeColumns.Contains(col.ColumnName))
                {
                    continue;
                }
                if (insertRow.Table.Columns.Contains(col.ColumnName))
                {
                    if (isFirst)
                    {
                        sbCols.Append(col.ColumnName);
                        sbValues.Append(ConvertParameterName(col.ColumnName));
                        isFirst = false;
                    }
                    else
                    {
                        sbCols.AppendFormat(",{0}", col.ColumnName);
                        sbValues.AppendFormat(",{0}", ConvertParameterName(col.ColumnName));
                    }
                    lsPars.Add(new SqlParameter(ConvertParameterName(col.ColumnName), insertRow[col.ColumnName]));
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
        public SqlParameter[] BuildInsertParamters(DataTable schemaTable, DataRow insertRow)
        {
            IList<SqlParameter> pars = new List<SqlParameter>();
            foreach (DataColumn col in schemaTable.Columns)
            {
                if (col.AutoIncrement || !string.IsNullOrEmpty(col.Expression) || excludeColumns.Contains(col.ColumnName))
                {
                    continue;
                }

                pars.Add(new SqlParameter(ConvertParameterName(col.ColumnName), insertRow[col.ColumnName]));
            }

            return pars.ToArray();
        }
        public int FillData(DataTable table, string commandKey)
        {
            return FillData(table, commandKey, null);
        }

        public int FillData(DataTable table, string commandKey, object[] args)
        {
            object obj;
            return this.FillData(table, commandKey, args, out obj);
        }

        public int FillData(DataTable table, string commandKey, object[] args, out object returnValue)
        {
            int count;
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                DbDataAdapter dbAdapter = this.Adapter;
                DbCommand cmd = BuildCommand(string.Format("{0}.{1}", table.TableName, commandKey), args);
                DbCommand cmd1 = cmd;
                dbAdapter.SelectCommand = cmd;
                if (cmd == null)
                    throw new ArgumentNullException(commandKey);

                if ((commandKey == "SelectSchema") && (table == null || table.Columns.Count < 1))
                {
                    this.Adapter.FillSchema(table, SchemaType.Source);
                }
                if ((commandKey == "SelectEmpty") && (table == null || table.Columns.Count < 1))
                {
                    this.Adapter.Fill(table);
                }

                if (commandKey == "SelectSchema" || commandKey == "SelectEmpty")
                {

                    returnValue = 0;
                    return 0;
                }

                table.BeginLoadData();
                ConnectionState state = this.Adapter.SelectCommand.Connection.State;

                try
                {
                    if ((this.Adapter.SelectCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
                    {
                        this.Adapter.SelectCommand.Connection.Open();
                    }
                    int num = 0;

                    using (DbDataReader dbDataReaders = this.Adapter.SelectCommand.ExecuteReader())
                    {
                        //if (this.bClearBeforeFill)
                        //{
                        table.Clear();
                        //}
                        num = table.Rows.Count;
                        if (dbDataReaders != null && dbDataReaders.HasRows)
                        {

                            table.Load(dbDataReaders, this.FillingLoadOption);

                            dbDataReaders.Close();

                        }
                    }
                    returnValue = this.GetParameterValue(this.Adapter.SelectCommand, "RETURN_VALUE");
                    //this.a(this.adapter.SelectCommand);
                    //this.p.AppendFormat("Results:{0};", table.Rows.Count - num);
                    sw.Stop();
                    //this.p.AppendFormat("Duration:{0}ms;", sw.ElapsedMilliseconds);
                    //Trace.TraceInformation(this.commandExecutionLog);
                    count = table.Rows.Count;
                }
                finally
                {
                    table.EndLoadData();
                    if (state == ConnectionState.Closed)
                    {
                        this.Adapter.SelectCommand.Connection.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorProcess.HandleException(ex);
                returnValue = null;
                count = -1;
            }
            return count;
        }
        public object GetParameterValue(DbCommand command, string parameterName)
        {
            parameterName = ConvertParameterName(parameterName);
            if (!command.Parameters.Contains(parameterName))
            {
                return null;
            }
            return command.Parameters[parameterName].Value;
        }
        public DbParameter GetParameter(string commandKey, string parameterName)
        {
            parameterName = ConvertParameterName(parameterName);
            if (!this.ContainsParameter(commandKey, parameterName))
            {
                return null;
            }
            return this.GetCommand(commandKey).Parameters[parameterName];

        }
        public bool ContainsCommand(string commandKey)
        {
            if (this._commandCollection == null || !this._commandCollection.ContainsKey(commandKey))
            {
                return false;
            }
            return this._commandCollection[commandKey] != null;
        }
        public bool ContainsParameter(string commandKey, string parameterName)
        {
            parameterName = ConvertParameterName(parameterName);
            if (this.ContainsCommand(commandKey) && this.GetCommand(commandKey).Parameters.Contains(parameterName) && this.GetCommand(commandKey).Parameters[parameterName] != null)
            {
                return true;
            }
            return false;
        }

        private DbCommand BuildCommand(string commandKey, object[] args)
        {
            if (!this.CommandCollection.ContainsKey(commandKey))
            {
                return null;
            }

            DbParameter parameter = null;
            if (this.ContainsParameter(commandKey, "RETURN_VALUE"))
            {
                parameter = this.GetParameter(commandKey, "RETURN_VALUE");
                this.GetCommand(commandKey).Parameters.Remove(parameter);
            }
            if (args != null)
            {
                for (int i = 0; i < (int)args.Length; i++)
                {
                    if (i < this.GetCommand(commandKey).Parameters.Count)
                    {
                        this.GetCommand(commandKey).Parameters[i].Value = args[i];
                    }
                }
            }
            if (parameter == null)
            {
                this.AddParameter(commandKey, "RETURN_VALUE", null, ParameterDirection.ReturnValue);
            }
            else
            {
                this.GetCommand(commandKey).Parameters.Add(parameter);
            }
            return this.GetCommand(commandKey);
        }
        public DbCommand GetCommand(string commandKey)
        {
            if (!this.ContainsCommand(commandKey))
            {
                return null;
            }
            return this._commandCollection[commandKey];
        }
        public DbCommand AddCommand(string commandKey, string commandText)
        {
            if (this.ContainsCommand(commandKey))
            {
                this.CommandCollection[commandKey].Cancel();
                this.CommandCollection[commandKey].Dispose();
                this.CommandCollection.Remove(commandKey);
            }
            this.CommandCollection.Add(commandKey, new SqlCommand());
            if (string.IsNullOrEmpty(commandText) && this.ContainsCommand("Select"))
            {
                commandText = this.GetCommand("Select").CommandText;
            }
            DbCommand dbCommand = this.GetCommand(commandKey);
            if (dbCommand.CommandText != commandText)
            {
                dbCommand.Connection = this.Connection;
                dbCommand.CommandText = commandText;
                dbCommand.CommandType = (commandText.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure);
            }
            return dbCommand;
        }
        public DbParameter AddParameter(string commandKey, string parameterName, object parameterValue, ParameterDirection parameterDirection)
        {
            object value;
            if (!this.ContainsCommand(commandKey))
            {
                return null;
            }
            parameterName = ConvertParameterName(parameterName);
            if (!this.GetCommand(commandKey).Parameters.Contains(parameterName))
            {
                this.GetCommand(commandKey).Parameters.Add(new SqlParameter(parameterName, parameterValue));
            }
            DbParameter parameter = this.GetParameter(commandKey, parameterName);
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


        #region Read        
        public object ReadScalar(string spName, params object[] parameterValues)
        {
            return MsSqlHelper.ExecuteScalar(ConnectionString, spName, parameterValues);
        }
        public object ReadScalar(CommandType cmdType, string cmdText)
        {
            return MsSqlHelper.ExecuteScalar(ConnectionString, cmdType, cmdText);
        }
        public DataTable Read(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                return null;
            string sql = string.Format("select * from {0};", tableName);

            return MsSqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, sql);
        }

        public DataTable Read(string tableName, string where)
        {
            if (string.IsNullOrEmpty(tableName))
                return null;
            if (string.IsNullOrEmpty(where))
                return Read(tableName);

            string sql = string.Format("SELECT * FROM {0} WHERE {1};", tableName, where);

            return MsSqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, sql);
        }

        public DataTable Read(string spName, params object[] parameterValues)
        {
            return MsSqlHelper.ExecuteDataTable(ConnectionString, spName, parameterValues);
        }
        public DataTable Read(CommandType commandType, string commandText)
        {
            return MsSqlHelper.ExecuteDataTable(ConnectionString, commandType, commandText);

        }
        public DataTable Read(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            return MsSqlHelper.ExecuteDataTable(ConnectionString, commandType, commandText, commandParameters);
        }

        public DataRow ReadFirstRow(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                return null;
            string sql = string.Format("select TOP 1 * from {0};", tableName);

            DataTable t = MsSqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, sql);
            if (t != null && t.Rows.Count > 0)
                return t.Rows[0];

            return null;
        }
        public DataRow ReadFirstRow(string tableName, string where)
        {
            if (string.IsNullOrEmpty(tableName))
                return null;
            if (string.IsNullOrEmpty(where))
                return ReadFirstRow(tableName);

            string sql = string.Format("SELECT TOP 1 * FROM {0} WHERE {1};", tableName, where);

            DataTable t = MsSqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, sql);
            if (t != null && t.Rows.Count > 0)
                return t.Rows[0];

            return null;
        }
        public DataRow ReadFirstRow(string spName, params object[] parameterValues)
        {
            DataTable t = MsSqlHelper.ExecuteDataTable(ConnectionString, spName, parameterValues);
            if (t != null && t.Rows.Count > 0)
                return t.Rows[0];

            return null;
        }
        public DataRow ReadFirstRow(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            DataTable t = MsSqlHelper.ExecuteDataTable(ConnectionString, commandType, commandText, commandParameters);
            if (t != null && t.Rows.Count > 0)
                return t.Rows[0];
            return null;
        }

        public DataSet ReadDataSet(string spName, params object[] parameterValues)
        {
            return MsSqlHelper.ExecuteDataset(ConnectionString, spName, parameterValues);
        }
        public DataSet ReadDataSet(CommandType cmdType, string cmdText)
        {
            return MsSqlHelper.ExecuteDataset(ConnectionString, cmdType, cmdText);
        }
        public DataSet ReadDataSet(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return MsSqlHelper.ExecuteDataset(ConnectionString, cmdType, cmdText, commandParameters);
        }
        #endregion

        #region Read Reader
        public IDataReader ReadReader(CommandType cmdType, string cmdText)
        {
            return MsSqlHelper.ExecuteReader(ConnectionString, cmdType, cmdText);
        }
        public IDataReader ReadReader(string spName, params object[] parameterValues)
        {
            return MsSqlHelper.ExecuteReader(ConnectionString, spName, parameterValues);
        }
        public IDataReader ReadReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return MsSqlHelper.ExecuteReader(ConnectionString, cmdType, cmdText, commandParameters);
        }
        #endregion

        #region Execute 
        public int Execute(string spName)
        {
            return MsSqlHelper.ExecuteNonQuery(ConnectionString, spName);
        }
        public int Execute(string spName, params object[] parameterValues)
        {
            return MsSqlHelper.ExecuteNonQuery(ConnectionString, spName, parameterValues);
        }
        public int Execute(CommandType cmdType, string cmdText)
        {
            return MsSqlHelper.ExecuteNonQuery(ConnectionString, cmdType, cmdText);
        }
        public int Execute(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return MsSqlHelper.ExecuteNonQuery(ConnectionString, cmdType, cmdText, commandParameters);
        }

        #endregion
    }
}
