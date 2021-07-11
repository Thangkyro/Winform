using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CoreBase.DataAccessLayer
{
    public class ZenSqlNotification : IDisposable
    {
        private string _connectionString = ZenDatabase.ConnectionString;
        private string _command;
        private Action _action;
        private DateTime _zBegin;
        private DateTime _zEnd;
        private bool _isDate = false;

        public ZenSqlNotification(Action action, string command)
        {
            _command = command;
            _action = action;

            SqlDependency.Start(_connectionString);
        }
        public ZenSqlNotification(Action action, string command, DateTime zBegin, DateTime zEnd)
        {
            _command = command;
            _action = action;
            _zBegin = zBegin;
            _zEnd = zEnd;
            _isDate = true;
            SqlDependency.Start(_connectionString);
        }

        public void LoadData()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(_command, con);
                if (_isDate)
                {
                    cmd.Parameters.Add("@begin", SqlDbType.DateTime);
                    cmd.Parameters["@begin"].Value = _zBegin;
                    cmd.Parameters.Add("@End", SqlDbType.DateTime);
                    cmd.Parameters["@End"].Value = _zEnd;
                }
                SqlDependency dependency = new SqlDependency(cmd);

                dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (_action != null)
                {
                    _action.Invoke();
                }

            }
        }

        //public void LoadData(DateTime zBegin,DateTime zEnd)
        //{
        //    using (SqlConnection con = new SqlConnection(_connectionString))
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand(_command, con);
        //        cmd.Parameters.Add("@begin", SqlDbType.DateTime);
        //        cmd.Parameters["@begin"].Value = zBegin;
        //        cmd.Parameters.Add("@End", SqlDbType.DateTime);
        //        cmd.Parameters["@End"].Value = zEnd;

        //        SqlDependency dependency = new SqlDependency(cmd);

        //        dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

        //        cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

        //        _action?.Invoke();
        //    }
        //}

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {

            SqlDependency dependency = sender as SqlDependency;
            if (dependency != null)
            {
                dependency.OnChange -= dependency_OnChange;
                dependency = null;
            }
            if (e.Type == SqlNotificationType.Change)
            {
                LoadData();
            }
          

        }

        protected virtual void OnDependencyChanged(SqlNotificationEventArgs e)
        {
            if (_action != null)
            {
                _action.Invoke();
            }
        }
        public void Dispose()
        {
            _isDate = false;
            SqlDependency.Stop(_connectionString);
        }

    }
}
