using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AusNail
{
    public class MyDateTimePicker : DateTimePicker
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                SendKeys.Send("{RIGHT}");
                return true;
            }
            if (keyData == (Keys.Shift | Keys.Tab))
            {
                SendKeys.Send("{LEFT}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }


}
