using System;
using System.Collections;
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
    public partial class DicBase : Form
    {
        const int WM_KEYDOWN = 0x100;
        const int WM_CHAR = 0x102;
        Hashtable _EnterHandleControls = new Hashtable();
        public DicBase()
        {
            InitializeEnterHandleControls();
            InitializeComponent();
        }
        private void InitializeEnterHandleControls()
        {
            _EnterHandleControls.Add("TEXTBOX", "TEXTBOX");
            _EnterHandleControls.Add("COMBOBOX", "COMBOBOX");
            _EnterHandleControls.Add("CHECKBOX", "CHECKBOX");
            _EnterHandleControls.Add("RADIOBUTTON", "RADIOBUTTON");
            _EnterHandleControls.Add("GROUPBOX", "GROUPBOX");
            _EnterHandleControls.Add("TABCONTROL", "TABCONTROL");
            _EnterHandleControls.Add("ZENLOOKUPCONTROL", "ZENLOOKUPCONTROL");
            _EnterHandleControls.Add("C1NUMERICEDIT", "C1NUMERICEDIT");
            _EnterHandleControls.Add("C1DATEEDIT", "C1DATEEDIT");


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
        protected virtual void zProcessEscapeKey()
        {

            if (MessageBox.Show("Do you want exit?") == DialogResult.Yes)
            {
                Close();
            }
        }
        protected override bool ProcessKeyPreview(ref Message m)
        {
            var k = Keys.KeyCode & (Keys)m.WParam.ToInt32();
            if ((k == Keys.Return) & (_EnterHandleControls.Contains(this.ActiveControl.GetType().Name.ToUpper())))
            {
                switch (m.Msg)
                {
                    case WM_KEYDOWN:
                        ProcessTabKey(true);
                        return false;

                    case WM_CHAR:
                        m.HWnd = IntPtr.Zero;
                        return false;
                }
            }
            if (m.Msg == WM_KEYDOWN && k == Keys.F1)
            {
                //this.ShowHelp();
                return true;
            }
            if (m.Msg == WM_KEYDOWN && k == Keys.Escape)
            {
                zProcessEscapeKey();

                return true;
            }
            return base.ProcessKeyPreview(ref m);
        }
        #endregion
    }
}
