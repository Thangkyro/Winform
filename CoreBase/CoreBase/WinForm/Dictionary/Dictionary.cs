using CoreBase.DataAccessLayer;
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
    public partial class Dictionary : DicBase
    {

        string strMessInfor = "";
        Timer t = new Timer();
        public enum FormMode
        {
            New,
            Edit,
            View
        }

        private DictionaryDAL _dal;
        public DictionaryDAL zDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new DictionaryDAL(zViewTableName, zEditTableName);
                return _dal;
            }
        }
        private DataTable _sourceTable;
        private DataTable zSourceTable
        {
            get
            {
                if (_sourceTable == null)
                    _sourceTable = zDAL.GetEmptyViewTable();

                return _sourceTable;
            }
        }
        public string zEditTableName { get;  set; }
        protected bool zIsLoading { get;  set; }
        public string zViewTableName { get;  set; }

        public FormMode zMode { get;  set; }
        public DataRow zEditRow { get;  set; }
        public DataRow zDeleteRow { get; set; }
        #region Ctors
        public Dictionary() : this(null) { }
        public Dictionary(string tableName) : this(tableName, tableName) { }
        public Dictionary(string viewTableName, string editTableName) : this(viewTableName, editTableName, null) { }
        public Dictionary(string viewTableName, string editTableName, DataTable sourceTable) 
        {
            InitializeComponent();

            zEditTableName = editTableName;
            zViewTableName = viewTableName;
            _sourceTable = sourceTable;
        }
        #endregion
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (zMode == FormMode.New)
            {
                Text = "New";
            }
            else if (zMode == FormMode.Edit)
            {
                Text = "Edit";
            }
            InitForm();
            zIsLoading = true;
            BeforeFillData();
            FillData();
            AfterFillData();
            RefreshControls();
            BaseRefreshControls();
            zIsLoading = false;
        }
        protected virtual void BaseRefreshControls()
        {
            if (zMode == FormMode.View)
            {
                foreach (Control ctl in Controls)
                    ctl.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Focus();
            }
        }
        protected virtual void RefreshControls()
        {
        }
        protected virtual void BeforeFillData()
        {
            t.Interval = 1000;  //in milliseconds

            t.Tick += new EventHandler(this.t_Tick);

            t.Start();  //this will use t_Tick() method
        }
        protected virtual void FillData()
        {
        }
        protected virtual void AfterFillData()
        { }
        protected virtual bool ValidData()
        {
            return true;
        }
        protected virtual void Cancel()
        {
            DialogResult = DialogResult.Cancel;
        }
        protected virtual bool SaveData()
        {
            BeforeSaveData();
            bool ret = false;
            if (zMode == FormMode.New)
            {
                ret = InsertData();
            }
            else
            {
                ret= UpdateData();
            }
            if (!ret)
                return false;

            return AfterSaveData();
            
        }
        protected virtual void BeforeSaveData() { }
        protected virtual bool AfterSaveData() { return true; }
        protected virtual bool InsertData()
        {
            return zDAL.InsertData(zEditRow);
        }
        protected virtual bool UpdateData()
        {
            return zDAL.UpdateData(zEditRow);
        }
        protected virtual bool WriteToRow()
        {
            foreach(Binding bd in BindingContext[Bds].Bindings)
            {
                bd.WriteValue();
            }

            return true;
        }
        protected virtual void InitForm()
        {         
        }

        protected virtual bool DeleteData()
        {
            return zDAL.DeleteData(zDeleteRow);
        }

        #region Bindings 
        protected void CreateBinding(Control ctrl)
        {
            string dataField = ctrl.Name.Substring(3);
            CreateBinding(ctrl, dataField);
            
        }
        protected void CreateBinding(Control ctrl, string dataField)
        {
            CreateBinding(ctrl, dataField, "Text");
        }
        protected void CreateBinding(Control ctrl, string dataField, string propName)
        {
            try
            {
                Binding bd = new Binding(propName, Bds, dataField);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            WriteToRow();

            if (!ValidData())
                return;

            if (SaveData())
                MessageBox.Show("Successfully","Information");
        }

        private void t_Tick(object sender, EventArgs e)
        {
            //get current time
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            //time
            string time = "";

            //padding leading zero
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            //update label
            lblTime.Text = time;
        }

        public void LoadMess()
        {
            lblMessInfomation.Text = strMessInfor;
        }

        #region Action
        public virtual bool AddNew()
        {
            DataTable tbl = zSourceTable.Clone();
            zEditRow = tbl.NewRow();
            tbl.Rows.Add(zEditRow);

            Bds.DataSource = tbl;
            Bds.Position = 0;

            zMode = FormMode.New;

            if( ShowDialog() == DialogResult.OK)
            {
                zEditRow.AcceptChanges();
                return true;
            }

            return false;
        }
        public virtual bool zEdit(DataRow editRow)
        {
            zEditRow = editRow;
            zMode = FormMode.Edit;
            Bds.DataSource = editRow.Table;
            Bds.Position = Bds.Find("id", editRow["id"]);

            return ShowDialog() == DialogResult.OK;
        }
        public virtual bool zEdit(int id)
        {
            DataTable tbl = zDAL.GetData(id);
            if (tbl == null || tbl.Rows.Count <= 0)
                return false;

            zEditRow = tbl.Rows[0];
            Bds.DataSource = tbl;
            Bds.Position = 0;
            zMode = FormMode.Edit;
            return ShowDialog() == DialogResult.OK;
        }
        public virtual void zOpen(DataRow editRow)
        {
            zEditRow = editRow;
            zMode = FormMode.View;
            Bds.DataSource = editRow.Table;
            Bds.Position = Bds.Find("id", editRow["id"]);

            ShowDialog();
        }
        public virtual void zOpen(int id)
        {
            DataTable tbl = zDAL.GetData(id);
            if (tbl == null || tbl.Rows.Count <= 0)
                return;

            zEditRow = tbl.Rows[0];
            Bds.DataSource = tbl;
            Bds.Position = 0;
            zMode = FormMode.View;
            ShowDialog();
        }

        #endregion
    }
}
