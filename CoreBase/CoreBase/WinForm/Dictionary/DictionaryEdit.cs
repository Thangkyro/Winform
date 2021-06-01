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
    public partial class DictionaryEdit : NailForm
    {
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
        public string zEditTableName { get; private set; }
        protected bool zIsLoading { get; private set; }
        public string zViewTableName { get; private set; }

        public FormMode zMode { get; private set; }
        public DataRow zEditRow { get; private set; }
        #region Ctors
        public DictionaryEdit() : this(null) { }
        public DictionaryEdit(string tableName) : this(tableName, tableName) { }
        public DictionaryEdit(string viewTableName, string editTableName) : this(viewTableName, editTableName, null) { }
        public DictionaryEdit(string viewTableName, string editTableName, DataTable sourceTable)
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
                Text = "Thêm";
            }
            else if (zMode == FormMode.Edit)
            {
                Text = "Sửa";
            }
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
        { }

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
                ret = UpdateData();
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
            foreach (Binding bd in BindingContext[zBs].Bindings)
            {
                bd.WriteValue();
            }

            return true;
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
                Binding bd = new Binding(propName, zBs, dataField);
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
            Cancel();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            WriteToRow();

            if (!ValidData())
                return;

            if (SaveData())
                DialogResult = DialogResult.OK;
        }

        #region Action
        public virtual bool AddNew()
        {
            DataTable tbl = zSourceTable.Clone();
            //DataRow newrow = tbl.NewRow();
            //tbl.Rows.Add(newrow);
            zEditRow = tbl.NewRow();
            tbl.Rows.Add(zEditRow);

            zBs.DataSource = tbl;
            zBs.Position = 0;

            //zEditRow = newrow;


            zMode = FormMode.New;

            if (ShowDialog() == DialogResult.OK)
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
            zBs.DataSource = editRow.Table;
            zBs.Position = zBs.Find("id", editRow["id"]);

            return ShowDialog() == DialogResult.OK;
        }
        public virtual bool zEdit(int id)
        {
            DataTable tbl = zDAL.GetData(id);
            if (tbl == null || tbl.Rows.Count <= 0)
                return false;

            zEditRow = tbl.Rows[0];
            zBs.DataSource = tbl;
            zBs.Position = 0;
            zMode = FormMode.Edit;
            return ShowDialog() == DialogResult.OK;
        }
        public virtual void zOpen(DataRow editRow)
        {
            zEditRow = editRow;
            zMode = FormMode.View;
            zBs.DataSource = editRow.Table;
            zBs.Position = zBs.Find("id", editRow["id"]);

            ShowDialog();
        }
        public virtual void zOpen(int id)
        {
            DataTable tbl = zDAL.GetData(id);
            if (tbl == null || tbl.Rows.Count <= 0)
                return;

            zEditRow = tbl.Rows[0];
            zBs.DataSource = tbl;
            zBs.Position = 0;
            zMode = FormMode.View;
            ShowDialog();
        }

        #endregion
    }
}
