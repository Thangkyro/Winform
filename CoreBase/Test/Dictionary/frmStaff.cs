using CoreBase;
using CoreBase.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AusNail.Dictionary
{
    public partial class frmStaff : CoreBase.WinForm.Dictionary.Dictionary
    {
        const string STAFF_CMDKEY = "Staff";
        const string STAFF_ADD_CMDKEY = "Staff_add";
        const string STAFF_DEL_CMDKEY = "Staff_del";
        const string STAFF_EDIT_CMDKEY = "Staff_edit";
        const string STAFF_LIST_CMDKEY = "Staff_list";
        DataRow _dr;
        DataTable _Staff;
        string _tableName = "zStaff";
        string _Mode = "";
        string _idName = "StaffId";
        int _postion = 0;
        DataTable _branch = new DataTable();
        DataTable _dtGender = new DataTable();
        Dictionary<string, byte[]> dicImage = new Dictionary<string, byte[]>();
        public frmStaff()
        {
            InitializeComponent();
            Load += UserForm_Load;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            using (ReadOnlyDAL dal = new ReadOnlyDAL("zBranch"))
            {
                _branch = dal.Read("is_inactive = 0");
            }

            _branch.DefaultView.Sort = "BranchCode";
            DataRow dr1 = _branch.NewRow();
            dr1["branchId"] = 0;
            dr1["BranchName"] = "";
            _branch.Rows.Add(dr1);

            cbobranchId.DisplayMember = "BranchName";
            cbobranchId.ValueMember = "branchId";
            cbobranchId.DataSource = _branch.DefaultView;

            _dtGender.Columns.Add("key", typeof(string));
            _dtGender.Columns.Add("value", typeof(string));
            _dtGender.Rows.Add(new object[] { "Male", "Male" });
            _dtGender.Rows.Add(new object[] { "Female", "Female" });
            _dtGender.Rows.Add(new object[] { "Order", "Order" });


        }


        protected override void BeforeFillData()
        {
            if (!NailApp.lstPermission.Contains(STAFF_LIST_CMDKEY) && !NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            LoadData();
            base.BeforeFillData();
        }

        protected override void FillData()
        {
            if (!NailApp.lstPermission.Contains(STAFF_LIST_CMDKEY) && !NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            base.FillData();
            CreateBinding(cbobranchId);
            CreateBinding(txtStaffCode);
            CreateBinding(txtName);
            CreateBinding(txtGender);
            CreateBinding(txtPhoneNumber1);
            CreateBinding(txtPhoneSimple1);
            CreateBinding(txtPhoneNumber2);
            CreateBinding(txtPhoneSimple2);
            CreateBinding(txtDateOfBirth);
            CreateBinding(txtTFN);
            CreateBinding(txtAcountNumber);
            CreateBinding(txtBSB);
            CreateBinding(txtDecriptions);
            CreateBinding(chkis_inactive, "is_inactive", "Checked");
        }
        protected override bool InsertData()
        {
            bool isSuccess = false;
            try
            {
                LoadEditRow();
                if (_Mode == "Add")
                {
                    if (!NailApp.lstPermission.Contains(STAFF_ADD_CMDKEY) && !NailApp.IsAdmin())
                    {
                        lblMessInfomation.Text = "Unauthorized";
                        return false;
                    }
                    //isSuccess = base.InsertData();
                    //if (isSuccess)
                    //{
                    //    // Insert Image
                    //    int staffID = 0;
                    //    DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, "Select StaffID From zStaff WITH(NOLOCK) Where StaffCode = '" + zEditRow["StaffCode"].ToString() + "'");
                    //    if (dt != null && dt.Rows.Count > 0)
                    //    {
                    //        staffID = int.Parse(dt.Rows[0][0].ToString());
                    //    }
                    //    byte[] image = null;
                    //    if (dicImage.Where(d => d.Key == zEditRow["StaffCode"].ToString()).ToList().Count > 0)
                    //    {
                    //        image = dicImage[zEditRow["StaffCode"].ToString()];
                    //    }
                    //    if (staffID != 0)
                    //    {
                    //        int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zStaffImagesInsert", staffID, image, image, NailApp.CurrentUserId, DateTime.Now.ToString(), NailApp.CurrentUserId, DateTime.Now.ToString(), 0, "");

                    //    }
                        
                    //}
                    
                }
                else
                {
                    if (!NailApp.lstPermission.Contains(STAFF_EDIT_CMDKEY) && !NailApp.IsAdmin())
                    {
                        lblMessInfomation.Text = "Unauthorized";
                        return false;
                    }
                    //if (isSuccess = base.UpdateData())
                    //{
                    //    // Insert Image
                    //    int staffID = 0;
                    //    DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, "Select StaffID From zStaff WITH(NOLOCK) Where StaffCode = '" + zEditRow["StaffCode"].ToString() + "'");
                    //    if (dt != null && dt.Rows.Count > 0)
                    //    {
                    //        staffID = int.Parse(dt.Rows[0][0].ToString());
                    //    }
                    //    byte[] image = null;
                    //    if (dicImage.Where(d => d.Key == zEditRow["StaffCode"].ToString()).ToList().Count > 0)
                    //    {
                    //        image = dicImage[zEditRow["StaffCode"].ToString()];
                    //    }
                    //    if (staffID != 0)
                    //    {
                    //        int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zStaffImagesInsert", staffID, image, image, NailApp.CurrentUserId, DateTime.Now.ToString(), NailApp.CurrentUserId, DateTime.Now.ToString(), 0, "");

                    //    }
                    //}
                    //return base.UpdateData();
                }

                string listError = "";
                #region Đoạn này cho phép sửa hoặc add mới nhiều dòng cùng 1 lúc => Phải sửa lại
                DataTable changedRows = ((DataTable)(Bds.DataSource)).GetChanges();

                foreach (DataRow dr in changedRows.Rows)
                {
                    dr["created_by"] = NailApp.CurrentUserId;
                    dr["modified_by"] = NailApp.CurrentUserId;
                    if (dr[_idName].ToString() == "0")
                    {
                        this.zEditRow = dr;
                        isSuccess = base.InsertData();
                    }
                    else
                    {
                        this.zEditRow = dr;
                        isSuccess = base.UpdateData();
                    }

                    if (!isSuccess)
                    {
                        listError += "Save error staff: " + dr["Name"].ToString() + ". \n";
                    }
                    else
                    {
                        int staffID = 0;
                        DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, "Select StaffID From zStaff WITH(NOLOCK) Where StaffCode = '" + zEditRow["StaffCode"].ToString() + "'");
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            staffID = int.Parse(dt.Rows[0][0].ToString());
                        }
                        byte[] image = null;
                        if (dicImage.Where(d => d.Key == zEditRow["StaffCode"].ToString()).ToList().Count > 0)
                        {
                            image = dicImage[zEditRow["StaffCode"].ToString()];
                        }
                        if (staffID != 0)
                        {
                            int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, "zStaffImagesInsert", staffID, image, image, NailApp.CurrentUserId, DateTime.Now.ToString(), NailApp.CurrentUserId, DateTime.Now.ToString(), 0, "");

                        }
                    }
                }
                #endregion

                if (isSuccess)
                {
                    LoadData();
                }
                else
                {
                    LoadData();
                    lblMessInfomation.Text = listError;
                }
                
            }
            catch (Exception ex)
            {

            }
            return isSuccess;
        }


        protected override void InitForm()
        {
            this.zEditTableName = _tableName;
            this.zViewTableName = _tableName;
            this.Text += " Staff"; 
            base.InitForm();
        }

        private void LoadData()
        {
            using (DictionaryDAL dal = new DictionaryDAL(_tableName))
                Bds.DataSource = _Staff = dal.GetData();
            LoadGrid();
            _postion = 0;
        }

        private void LoadEditRow()
        {

            if (((DataTable)Bds.DataSource).Select(string.Format("{0} = 0", _idName)).Count() == 1)
            {
                this.zEditRow = ((DataTable)Bds.DataSource).Select(string.Format("{0} = 0", _idName))[0];
                //this.zEditRow["StaffCode"] = GenStaffCode();
                _Mode = "Add";
            }
            else
            {
                this.zEditRow = ((DataTable)Bds.DataSource).Rows[_postion];
                _Mode = "Update";
            }
        }

        private void LoadGrid()
        {
            GridDetail.DataSource = Bds.DataSource;
            GridDetail.Columns.Remove("branchId");

            DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
            dgvCmb.DataPropertyName = "BranchId";
            dgvCmb.HeaderText = "Branch";
            dgvCmb.Name = "BranchId";
            dgvCmb.DisplayMember = "BranchName";
            dgvCmb.ValueMember = "branchId";
            dgvCmb.DataSource = _branch;
            GridDetail.Columns.Add(dgvCmb);
            GridDetail.Columns["BranchId"].DisplayIndex = 0;



            DataGridViewButtonColumn dgvC = new DataGridViewButtonColumn();
            dgvC.DataPropertyName = "UploadImage";
            dgvC.HeaderText = "UploadImage";
            dgvC.Name = "UploadImage";
            dgvC.Text = "Upload Image";
            dgvC.UseColumnTextForButtonValue = true;
            var DataGridViewButtonColumn = GridDetail.Columns["UploadImage"];
            if (DataGridViewButtonColumn == null)
            {
                GridDetail.Columns.Add(dgvC);
                GridDetail.Columns["UploadImage"].DisplayIndex = 2;
            }
            

            //Image
            //DataGridViewImageColumn dgvIm = new DataGridViewImageColumn();
            //dgvIm.DataPropertyName = "ImageName";
            //dgvIm.HeaderText = "ImageName";
            //dgvIm.Name = "ImageName";
            //GridDetail.Columns.Add(dgvIm);
            //GridDetail.Columns["ImageName"].DisplayIndex = 20;


            //DataGridViewTextBoxColumn dgvT = new DataGridViewTextBoxColumn();
            //dgvT.DataPropertyName = "ImageName";
            //dgvT.HeaderText = "ImageName";
            //dgvT.Name = "ImageName";
            //GridDetail.Columns.Add(dgvT);

            ///GridDetail.Columns["ImageName"].ReadOnly = true;
            GridDetail.Columns["StaffId"].Visible = false;
            //GridDetail.Columns["branchId"].HeaderText = "Branch";
            GridDetail.Columns["StaffCode"].HeaderText = "Staff Code";
            GridDetail.Columns["StaffCode"].ReadOnly = true;
            GridDetail.Columns["Name"].HeaderText = "Name";

            GridDetail.Columns.Remove("Gender");
            DataGridViewComboBoxColumn dgvCmbG = new DataGridViewComboBoxColumn();
            dgvCmbG.DataPropertyName = "Gender";
            dgvCmbG.HeaderText = "Gender";
            dgvCmbG.Name = "Gender";
            dgvCmbG.DisplayMember = "value";
            dgvCmbG.ValueMember = "key";
            dgvCmbG.DataSource = _dtGender;
            GridDetail.Columns.Add(dgvCmbG);
            GridDetail.Columns["Gender"].DisplayIndex = 5;

            GridDetail.Columns["PhoneNumber1"].HeaderText = "Phone Number 1";
            GridDetail.Columns["PhoneSimple1"].HeaderText = "Phone Simple 1";
            GridDetail.Columns["PhoneNumber2"].HeaderText = "Phone Number 2";
            GridDetail.Columns["PhoneSimple2"].HeaderText = "Phone Simple 2";
            GridDetail.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
            GridDetail.Columns["DateOfBirth"].DefaultCellStyle.Format = "MM/dd/yyyy";
            GridDetail.Columns["TFN"].HeaderText = "Tax Number";
            GridDetail.Columns["BSB"].HeaderText = "BSB";
            GridDetail.Columns["Decriptions"].Visible = false;
            GridDetail.Columns["is_inactive"].HeaderText = "Inactive";
            GridDetail.Columns["created_by"].HeaderText = "Create by";
            GridDetail.Columns["created_at"].HeaderText = "Create at";
            GridDetail.Columns["modified_by"].HeaderText = "Modified by";
            GridDetail.Columns["modified_at"].HeaderText = "Modified at";
            
        }

        private void GridDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 )//&& e.ColumnIndex != 19) // #Button Upload Image
                {
                    _postion = e.RowIndex;
                    DataGridViewRow row = this.GridDetail.Rows[e.RowIndex];
                    cbobranchId.SelectedValue = row.Cells["branchId"].Value.ToString();
                    txtStaffCode.Text = row.Cells["StaffCode"].Value.ToString();
                    txtName.Text = row.Cells["Name"].Value.ToString();
                    txtGender.Text = row.Cells["Gender"].Value.ToString();
                    txtDateOfBirth.Text = row.Cells["DateOfBirth"].Value.ToString();
                    txtPhoneNumber1.Text = row.Cells["PhoneNumber1"].Value.ToString();
                    txtPhoneNumber2.Text = row.Cells["PhoneNumber2"].Value.ToString();
                    txtPhoneSimple1.Text = row.Cells["PhoneSimple1"].Value.ToString();
                    txtPhoneSimple2.Text = row.Cells["PhoneSimple2"].Value.ToString();
                    txtTFN.Text = row.Cells["TFN"].Value.ToString();
                    txtAcountNumber.Text = row.Cells["AcountNumber"].Value.ToString();
                    txtBSB.Text = row.Cells["BSB"].Value.ToString();
                    txtDecriptions.Text = row.Cells["Decriptions"].Value.ToString();
                    chkis_inactive.Checked = bool.Parse(row.Cells["is_inactive"].Value.ToString());
                    int staffID = int.Parse(row.Cells["StaffId"].Value.ToString());
                    //Load image
                    DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, CommandType.Text, "Select Top 1 Image From zStaffImages WITH(NOLOCK) Where StaffId = " + staffID + " order by created_at desc");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0] != DBNull.Value)
                        {
                            var data = (Byte[])dt.Rows[0][0];
                            var stream = new MemoryStream(data);
                            pbImage.Image = Image.FromStream(stream);
                        }
                        
                    }
                    else
                    {
                        pbImage.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw;
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!NailApp.lstPermission.Contains(STAFF_DEL_CMDKEY) && !NailApp.IsAdmin())
            {
                lblMessInfomation.Text = "Unauthorized";
                return;
            }
            DialogResult result = MessNotifications("Notifications", "Do you want delete line?");
            if (result == DialogResult.Yes)
            {
                this.zDeleteRow = ((DataTable)Bds.DataSource).Rows[_postion];
                // Check use for bill or booking.
                DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zCheckStaffExists", int.Parse(zDeleteRow["StaffId"].ToString()));
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Staff is already in use, cannot be deleted.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    bool flag = base.DeleteData();
                }
                LoadData();
            }
            else
            {

            }
        }

        private void RefeshListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private DialogResult MessNotifications(string title, string message)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            return result;
        }

        private string GenStaffCode()
        {
            string StaffCode = "";
            try
            {
                DataTable dt = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zGetNewCode", _tableName, "ST", _idName, 8);
                if (dt != null)
                {
                    StaffCode = dt.Rows[0][0].ToString();
                }
            }
            catch
            {

            }
            return StaffCode;
        }


        private void GridDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && GridDetail["StaffCode", e.RowIndex].Value != "")
            {
                //TODO - Button Clicked - Execute Code Here
                OpenFileDialog opnfd = new OpenFileDialog();
                opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
                if (opnfd.ShowDialog() == DialogResult.OK)
                {
                    string fileName = opnfd.FileName;
                    byte[] bytes = File.ReadAllBytes(fileName);
                    //pbImage.Image = new Bitmap(opnfd.FileName);
                    //pbImage.ImageLocation = opnfd.FileName;
                    //System.Drawing.Image imm = pbImage.Image;
                    //int checkImage = 1;
                    int rIndex = e.RowIndex;
                    int cIndex = 20;
                    if (bytes != null)
                    {
                        GridDetail[cIndex, rIndex].Value = bytes;
                        string staffCode = GridDetail["StaffCode", rIndex].Value.ToString();
                        if (dicImage.ContainsKey(staffCode))
                        {
                            dicImage.Remove(staffCode);
                            dicImage.Add(staffCode, bytes);
                        }
                        else
                        {
                            dicImage.Add(staffCode, bytes);
                        }
                        lblMessInfomation.Text = "Upload Image Complete";
                    }
                }
            }
            else
            {
                lblMessInfomation.Text = "Please input Name.";
            }
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(imageIn, typeof(byte[]));
            return xByte;
        }

        private void GridDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = GridDetail.Columns[e.ColumnIndex].Name;
            if (headerText.Equals("Name") && Convert.ToString(e.FormattedValue) != "") // 1 Name
            {
                int id = int.Parse(GridDetail["StaffId", e.RowIndex].Value != DBNull.Value ? GridDetail["StaffId", e.RowIndex].Value.ToString() : "0");
                if (id == 0) // add new
                {
                    int rIndex = e.RowIndex;
                    GridDetail["StaffCode", rIndex].Value = GenStaffCode();
                }
                
            }
        }

        private void GridDetail_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //int rIndex = e.RowIndex;
            //int cIndex = 0;
            //string id = GridDetail[cIndex, rIndex].Value.ToString();
            //lblMessInfomation.Text = id;
        }

        private void cbobranchId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
