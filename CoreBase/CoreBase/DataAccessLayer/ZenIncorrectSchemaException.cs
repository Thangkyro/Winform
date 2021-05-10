using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CoreBase.DataAccessLayer
{
    public class ZenIncorrectSchemaException : DataException
    {
        private const string a = "info";

        public string info
        {
            get
            {
                if (!this.Data.Contains("info"))
                {
                    return string.Empty;
                }
                return this.Data["info"].ToString();
            }
        }
        public ZenIncorrectSchemaException(string pzSourceName) : this(pzSourceName, null, null)
        {
        }

        public ZenIncorrectSchemaException(string pzSourceName, string pzPrimaryKey) : this(pzSourceName, pzPrimaryKey, null)
        {
        }

        public ZenIncorrectSchemaException(string pzSourceName, string[] invalidColumns) : this(pzSourceName, null, invalidColumns)
        {
        }
        public ZenIncorrectSchemaException(string pzSourceName, string pzPrimaryKey, string[] invalidColumns)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (!string.IsNullOrEmpty(pzSourceName))
            {
                stringBuilder.AppendFormat("DATA SOURCE: {0}", pzSourceName);
                stringBuilder.AppendLine();
            }
            if (!string.IsNullOrEmpty(pzPrimaryKey))
            {
                stringBuilder.AppendFormat("UNIQUE-PRIMARY KEY: {0}", pzPrimaryKey);
                stringBuilder.AppendLine();
            }
            if (invalidColumns != null && (int)invalidColumns.Length > 0)
            {
                stringBuilder.Append("INVALID COLUMNS: ");
                for (int i = 0; i < (int)invalidColumns.Length; i++)
                {
                    stringBuilder.AppendFormat((i > 0 ? ", {0}" : "{0}"), invalidColumns[i]);
                }
            }
            base.Data.Add("info", stringBuilder.ToString());
        }
    }
}
