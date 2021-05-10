using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; 

namespace CoreBase.DataAccessLayer
{
    public class DataInfo
    {
        public string TableName { get; set; }
        public string ViewName { get; set; }
        public DataRow[] Rows { get; set; }
    }
}
