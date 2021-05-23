using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreBase.WinForm.Dictionary
{
    public partial class NailForm : Form
    {
        public NailForm()
        {
            InitializeComponent();
        }

        #region Bindings 
        protected void zCreateBinding(Control ctrl, object bs)
        {
            string dataField = ctrl.Name.Substring(3);
            zCreateBinding(ctrl, dataField, bs);

        }
        protected void zCreateBinding(Control ctrl, string dataField, object bs)
        {
            zCreateBinding(ctrl, dataField, "Text", bs);
        }
        protected void zCreateBinding(Control ctrl, string dataField, string propName, object bs)
        {
            try
            {
                Binding bd = new Binding(propName, bs, dataField);
                bd.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation;
                bd.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
                ctrl.DataBindings.Add(bd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
