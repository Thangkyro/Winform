using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBase
{
    public class TransactionState
    {
        public string ma_ct { get; set; }
        public int trang_thai { get; set; }
        public string ten_trang_thai { get; set; }
        public Color color { get; set; }
        public bool to_gl { get; set; }
        public bool to_in { get; set; }
        public bool is_cancelled { get; set; }
        public bool is_lock { get; set; }
        public bool allow_print { get; set; }
        public bool allow_delete { get; set; }
        public IList<int> to_allows { get; set; }
        public bool is_inactive { get; set; }
        public override string ToString()
        {
            return ten_trang_thai;
        }
        //public Dictionary<int, TransactionState> to_allows { get; set; }

    }
}
