using System;
using System.Collections.Generic;
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

        public ZenSqlNotification(Action action, string command)
        {
            _command = command;
            _action = action;

            SqlDependency.Start(_connectionString);
        }

        public void LoadData()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(_command, con);
                SqlDependency dependency = new SqlDependency(cmd);

                dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                _action?.Invoke();
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency dependency = sender as SqlDependency;
            dependency.OnChange -= dependency_OnChange;
            LoadData();
        }

        public void Dispose()
        {
            SqlDependency.Stop(_connectionString);
        }

    }
}
