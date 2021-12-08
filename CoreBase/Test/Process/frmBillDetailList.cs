using ClosedXML.Excel;
using CoreBase;
using CoreBase.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;

namespace AusNail.Process
{
    public partial class frmBillDetailList : Form
    {
        DataTable _dtGroup1 = new DataTable();
        DataTable _dtGroup2 = new DataTable();
        DateTime _dtF;
        DateTime _dtT;
        string _Group1 = string.Empty;
        string _Group2 = string.Empty;
        string _paramQuery1 = string.Empty;
        DataTable _dtResult = new DataTable();
        DataTable _dtResultDetail = new DataTable();
        private bool _isAutoLoad = false;
        public frmBillDetailList()
        {
            InitializeComponent();
            Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            _dtGroup1.Columns.Add("Code");
            _dtGroup1.Columns.Add("Name");
            string[] strPayment;
            strPayment = new string[2] { "Staff", "Service" };
            foreach (var item in strPayment)
            {
                DataRow dr1 = _dtGroup1.NewRow();
                dr1["Code"] = item;
                dr1["Name"] = item;
                _dtGroup1.Rows.Add(dr1);
            }


            cboGroup1.DisplayMember = "Name";
            cboGroup1.ValueMember = "Code";
            cboGroup1.DataSource = _dtGroup1.DefaultView;

            LoadGroup2(cboGroup1.SelectedValue.ToString());
        }

        private void LoadGroup2(string group1)
        {
            _dtGroup2 = new DataTable();
            _dtGroup2.Columns.Add("Code");
            _dtGroup2.Columns.Add("Name");
            string[] strPayment;
            strPayment = new string[4] { "", "Staff", "Service", "Date" };
            foreach (var item in strPayment)
            {
                if (!string.IsNullOrEmpty(group1))
                {
                    if (item != group1)
                    {
                        DataRow dr1 = _dtGroup2.NewRow();
                        dr1["Code"] = item;
                        dr1["Name"] = item;
                        _dtGroup2.Rows.Add(dr1);
                    }
                }
                else
                {
                    DataRow dr1 = _dtGroup2.NewRow();
                    dr1["Code"] = item;
                    dr1["Name"] = item;
                    _dtGroup2.Rows.Add(dr1);
                }
            }


            cboGroup2.DisplayMember = "Name";
            cboGroup2.ValueMember = "Code";
            cboGroup2.DataSource = _dtGroup2.DefaultView;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //LoadData();
                if (_dtResult != null && _dtResult.Rows.Count > 0)
                {
                    //Creating DataTable
                    DataTable dt = new DataTable();

                    //Adding the Columns
                    foreach (DataGridViewColumn column in dgvReport.Columns)
                    {
                        //if (column.Name == "BillID")
                        //{

                        //}
                        //else
                        //{
                        dt.Columns.Add(column.HeaderText, column.ValueType);
                        //}
                    }

                    //Adding the Rows
                    foreach (DataGridViewRow row in dgvReport.Rows)
                    {
                        dt.Rows.Add();
                        foreach (DataGridViewCell cell in row.Cells)
                        {

                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                        }
                    }

                    DataTable dt1 = new DataTable();
                    if (_dtResultDetail != null && _dtResultDetail.Rows.Count > 0)
                    {
                        foreach (DataGridViewColumn column in dgvReportDetail.Columns)
                        {
                           
                            dt1.Columns.Add(column.HeaderText, column.ValueType);
                        }

                        foreach (DataGridViewRow row in dgvReportDetail.Rows)
                        {
                            dt1.Rows.Add();
                            foreach (DataGridViewCell cell in row.Cells)
                            {

                                dt1.Rows[dt1.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                            }
                        }
                    }

                    

                    

                    //Add row total
                    //decimal PaymentCash = decimal.Parse(_dtResult.Compute("Sum(PaymentCash)", string.Empty).ToString());
                    //decimal PaymentCard = decimal.Parse(_dtResult.Compute("Sum(PaymentCard)", string.Empty).ToString());
                    //decimal PaymentVoucher = decimal.Parse(_dtResult.Compute("Sum(PaymentVoucher)", string.Empty).ToString());
                    //decimal TotalAmount = decimal.Parse(_dtResult.Compute("Sum(TotalAmount)", string.Empty).ToString());
                    //decimal TotalDiscount = decimal.Parse(_dtResult.Compute("Sum(TotalDiscount)", string.Empty).ToString());

                    //dt.Rows.Add();
                    //dt.Rows[dt.Rows.Count - 1][5] = "Total";
                    //dt.Rows[dt.Rows.Count - 1][6] = TotalAmount.ToString();
                    //dt.Rows[dt.Rows.Count - 1][7] = TotalDiscount.ToString();
                    //dt.Rows[dt.Rows.Count - 1][8] = PaymentCash.ToString();
                    //dt.Rows[dt.Rows.Count - 1][9] = PaymentCard.ToString();
                    //dt.Rows[dt.Rows.Count - 1][10] = PaymentVoucher.ToString();

                    //Exporting to Excel
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";
                    sfd.FileName = "BillDetailList.xlsx";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        //string folderPath = "C:\\Excel\\";
                        //if (!Directory.Exists(folderPath))
                        //{
                        //    Directory.CreateDirectory(folderPath);
                        //}
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "Header");
                            wb.Worksheets.Add(dt1, "Detail");
                            wb.SaveAs(sfd.FileName);
                        }

                        // Open the newly saved excel file
                        if (File.Exists(sfd.FileName))
                            System.Diagnostics.Process.Start(sfd.FileName);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void copyAlltoClipboard()
        {
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            //dgvReport.MultiSelect = true;
            dgvReport.RowHeadersVisible = false;
            dgvReport.SelectAll();
            DataObject dataObj = dgvReport.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void LoadData()
        {
            try
            {
                DateTime dtF;
                DateTime dtT;
                DateTime.TryParseExact(dtpFrom.Text.Trim().ToString(), "dd/MM/yyyy",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out dtF);
                DateTime.TryParseExact(dtpTo.Text.Trim().ToString(), "dd/MM/yyyy",
                              CultureInfo.InvariantCulture,
                              DateTimeStyles.None,
                              out dtT);
                if (dtF == null)
                {
                    MessageBox.Show("Please choose date filter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (dtF.Year == 0001)
                {
                    MessageBox.Show("Date from invaild !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dtT == null)
                {
                    MessageBox.Show("Please choose date filter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (dtT.Year == 0001)
                {
                    MessageBox.Show("Date to invaild !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (dtT < dtF)
                {
                    MessageBox.Show("Date From can't more than Date To.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int error = 0;
                string errorMesg = "";
                _dtResult = new DataTable();
                _dtResultDetail = new DataTable();

                _dtF = dtF;
                _dtT = dtT;
                _Group1 = cboGroup1.SelectedValue.ToString();
                _Group2 = cboGroup2.SelectedValue.ToString();

                _isAutoLoad = true;
                _dtResult = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillDetailList_GetAll", _dtF, _dtT, _Group1, int.Parse(NailApp.BranchID));
                dgvReport.DataSource = _dtResult;

                dgvReport.Columns["IDHead"].Visible = false;

                dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                //Load detail Grid 2
                _dtResultDetail = new DataTable();
                dgvReportDetail.DataSource = _dtResultDetail;
                string cellValue = "";
                //if (_dtResult != null && _dtResult.Rows.Count > 0)
                //{
                //    int selectedrowindex = dgvReport.SelectedCells[0].RowIndex;
                //    DataGridViewRow selectedRow = dgvReport.Rows[selectedrowindex];

                //    cellValue = Convert.ToString(selectedRow.Cells["IDHead"].Value);

                //}
                _dtResultDetail = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillDetailList_GetByGroup", _dtF, _dtT, _Group1, _Group2, cellValue, "", int.Parse(NailApp.BranchID), "Detail");
                if (_dtResultDetail != null)
                {
                    dgvReportDetail.DataSource = _dtResultDetail;
                    dgvReportDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                _isAutoLoad = true;
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadDataDetail(string pGroup1, bool isClick)
        {
            try
            {
                //pGroup1 = StaffID
                if (!string.IsNullOrEmpty(_Group2))
                {
                    //Load detail Grid 2
                    _dtResultDetail = new DataTable();
                    _dtResultDetail = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillDetailList_GetByGroup", _dtF, _dtT, _Group1, _Group2, pGroup1, "", int.Parse(NailApp.BranchID), "Detail");
                    if (_dtResultDetail != null && _dtResultDetail.Rows.Count > 0)
                    {
                        dgvReportDetail.DataSource = _dtResultDetail;
                        dgvReportDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                else // Show form list detail
                {
                    if (!string.IsNullOrEmpty(pGroup1) && isClick)
                    {
                        frmBillDetailListDetail frmBilldt = new frmBillDetailListDetail(int.Parse(NailApp.BranchID), _Group1, _Group2, pGroup1, "", _dtF, _dtT);
                        frmBilldt.ShowDialog();
                    }
                }

            }
            catch (Exception ex)
            {
                _dtResultDetail = new DataTable();
                dgvReportDetail.DataSource = _dtResultDetail;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dtResult != null && _dtResult.Rows.Count > 0)
                {
                    _paramQuery1 = string.Empty;
                    if (dgvReport["IDHead", e.RowIndex].Value != DBNull.Value)
                    {
                        _paramQuery1 = dgvReport["IDHead", e.RowIndex].Value.ToString();
                        LoadDataDetail(dgvReport["IDHead", e.RowIndex].Value.ToString(), true);
                    }

                }

            }
            catch (Exception ex)
            {

            }
        }

        private void cboGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string value = cboGroup1.SelectedValue.ToString();
                LoadGroup2(value);
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvReportDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dtResultDetail != null && _dtResultDetail.Rows.Count > 0)
                {
                    if (_Group2 == "Staff") //Staff
                    {
                        if (dgvReportDetail["StaffID", e.RowIndex].Value != DBNull.Value)
                        {
                            if (!string.IsNullOrEmpty(dgvReportDetail["StaffID", e.RowIndex].Value.ToString()))
                            {
                                frmBillDetailListDetail frmBilldt = new frmBillDetailListDetail(int.Parse(NailApp.BranchID), _Group1, _Group2, _paramQuery1, dgvReportDetail["StaffID", e.RowIndex].Value.ToString(), _dtF, _dtT);
                                frmBilldt.ShowDialog();
                            }
                        }
                    }
                    else if (_Group2 == "Service") //Service
                    {
                        if (dgvReportDetail["ServiceID", e.RowIndex].Value != DBNull.Value)
                        {
                            if (!string.IsNullOrEmpty(dgvReportDetail["ServiceID", e.RowIndex].Value.ToString()))
                            {
                                frmBillDetailListDetail frmBilldt = new frmBillDetailListDetail(int.Parse(NailApp.BranchID), _Group1, _Group2, _paramQuery1, dgvReportDetail["ServiceID", e.RowIndex].Value.ToString(), _dtF, _dtT);
                                frmBilldt.ShowDialog();
                            }
                        }
                    }
                    else //Date
                    {
                        if (dgvReportDetail["BillDate", e.RowIndex].Value != DBNull.Value)
                        {
                            if (!string.IsNullOrEmpty(dgvReportDetail["BillDate", e.RowIndex].Value.ToString()))
                            {
                                DateTime dtC;
                                DateTime.TryParseExact(dgvReportDetail["BillDate", e.RowIndex].Value.ToString(), "dd/MM/yyyy",
                                               CultureInfo.InvariantCulture,
                                               DateTimeStyles.None,
                                               out dtC);

                                frmBillDetailListDetail frmBilldt = new frmBillDetailListDetail(int.Parse(NailApp.BranchID), _Group1, _Group2, _paramQuery1, dtC.ToString("yyyyMMdd"), _dtF, _dtT);
                                frmBilldt.ShowDialog();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void dgvReport_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isAutoLoad)
                {
                    _isAutoLoad = false;
                }
                else
                {
                    int curRow = dgvReport.CurrentRow.Index;
                    //if (e.StateChanged != DataGridViewElementStates.Selected) return;
                    if (_dtResult != null && _dtResult.Rows.Count > 0)
                    {
                        _paramQuery1 = string.Empty;
                        if (dgvReport["IDHead", curRow].Value != DBNull.Value)
                        {
                            _paramQuery1 = dgvReport["IDHead", curRow].Value.ToString();
                            LoadDataDetail(dgvReport["IDHead", curRow].Value.ToString(), false);
                        }

                    }
                }

            }
            catch (Exception)
            {

            }
        }
    }
}
