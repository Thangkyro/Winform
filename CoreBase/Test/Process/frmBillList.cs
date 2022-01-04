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
    public partial class frmBillList : Form
    {
        DataTable _dtPayment = new DataTable();
        DataTable _dtResult;
        public frmBillList()
        {
            InitializeComponent();
            Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            _dtPayment.Columns.Add("Code");
            _dtPayment.Columns.Add("Name");
            string[] strPayment;
            strPayment = new string[4] { "All", "Card", "Cash", "Compare"};
            foreach (var item in strPayment)
            {
                DataRow dr1 = _dtPayment.NewRow();
                dr1["Code"] = item;
                dr1["Name"] = item;
                _dtPayment.Rows.Add(dr1);
            }
            

            cboPaymentMethod.DisplayMember = "Name";
            cboPaymentMethod.ValueMember = "Code";
            cboPaymentMethod.DataSource = _dtPayment.DefaultView;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                if (true)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                if (_dtResult != null && _dtResult.Rows.Count > 0)
                {
                    //Creating DataTable
                    DataTable dt = new DataTable();

                    //Adding the Columns
                    foreach (DataGridViewColumn column in dgvReport.Columns)
                    {
                        if (column.Name == "BillID")
                        {

                        }
                        else
                        {
                            dt.Columns.Add(column.HeaderText, column.ValueType);
                        }
                    }

                    //Adding the Rows
                    foreach (DataGridViewRow row in dgvReport.Rows)
                    {
                        dt.Rows.Add();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.ColumnIndex != 11)
                            {
                                dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();

                            }
                            
                        }
                    }

                    //Add row total
                    decimal PaymentCash = decimal.Parse(_dtResult.Compute("Sum(PaymentCash)", string.Empty).ToString());
                    decimal PaymentCard = decimal.Parse(_dtResult.Compute("Sum(PaymentCard)", string.Empty).ToString());
                    decimal PaymentVoucher = decimal.Parse(_dtResult.Compute("Sum(PaymentVoucher)", string.Empty).ToString());
                    string Total = string.Format("{0:#,##0.00}", decimal.Parse(_dtResult.Compute("Sum(PaymentCash)", string.Empty).ToString()) + decimal.Parse(_dtResult.Compute("Sum(PaymentCard)", string.Empty).ToString()));
                    decimal TotalAmount = decimal.Parse(_dtResult.Compute("Sum(TotalAmount)", string.Empty).ToString());
                    decimal TotalDiscount = decimal.Parse(_dtResult.Compute("Sum(TotalDiscount)", string.Empty).ToString());

                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1][4] = "Total";
                    dt.Rows[dt.Rows.Count - 1][5] = Total.ToString();
                    dt.Rows[dt.Rows.Count - 1][6] = TotalAmount.ToString();
                    dt.Rows[dt.Rows.Count - 1][7] = TotalDiscount.ToString();
                    dt.Rows[dt.Rows.Count - 1][8] = PaymentCash.ToString();
                    dt.Rows[dt.Rows.Count - 1][9] = PaymentCard.ToString();
                    dt.Rows[dt.Rows.Count - 1][10] = PaymentVoucher.ToString();

                    //Exporting to Excel
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";
                    sfd.FileName = "BillList.xlsx";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        //string folderPath = "C:\\Excel\\";
                        //if (!Directory.Exists(folderPath))
                        //{
                        //    Directory.CreateDirectory(folderPath);
                        //}
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "Bill");
                            wb.SaveAs(sfd.FileName);
                        }

                        // Open the newly saved excel file
                        if (File.Exists(sfd.FileName))
                            System.Diagnostics.Process.Start(sfd.FileName);
                    }

                    //SaveFileDialog sfd = new SaveFileDialog();
                    //sfd.Filter = "Excel Documents (*.xls)|*.xls";
                    //sfd.FileName = "BillList.xls";
                    //if (sfd.ShowDialog() == DialogResult.OK)
                    //{
                    //    // Copy DataGridView results to clipboard
                    //    copyAlltoClipboard();

                    //    object misValue = System.Reflection.Missing.Value;
                    //    Excel.Application xlexcel = new Excel.Application();

                    //    xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                    //    Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                    //    Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    //    // Format column D as text before pasting results, this was required for my data
                    //    //Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
                    //    //rng.NumberFormat = "@";

                    //    // Paste clipboard results to worksheet range
                    //    Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                    //    CR.Select();
                    //    xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                    //    // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
                    //    // Delete blank column A and select cell A1
                    //    //Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                    //    //delRng.Delete(Type.Missing);
                    //    //xlWorkSheet.get_Range("A1").Select();

                    //    // Save the excel file under the captured location from the SaveFileDialog
                    //    xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    //    xlexcel.DisplayAlerts = true;
                    //    xlWorkBook.Close(true, misValue, misValue);
                    //    xlexcel.Quit();

                    //    releaseObject(xlWorkSheet);
                    //    releaseObject(xlWorkBook);
                    //    releaseObject(xlexcel);

                    //    // Clear Clipboard and DataGridView selection
                    //    Clipboard.Clear();
                    //    dgvReport.ClearSelection();

                    //    // Open the newly saved excel file
                    //    if (File.Exists(sfd.FileName))
                    //        System.Diagnostics.Process.Start(sfd.FileName);
                    //}


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
                else if(dtT < dtF)
                {
                    MessageBox.Show("Date From can't more than Date To.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int error = 0;
                string errorMesg = "";
                if (_dtResult != null)
                {
                    _dtResult.Clear();

                }

                lblCard.Text = "0";
                lblCash.Text = "0";
                lblVoucher.Text = "0";
                lblTotalAmont.Text = "0";
                lblTotalDiscount.Text = "0";

                _dtResult = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillList_GetAll", dtF, dtT, txtCustomerPhone.Text.Trim(), cboPaymentMethod.SelectedValue.ToString(), int.Parse(NailApp.BranchID));
                dgvReport.DataSource = _dtResult;

                dgvReport.Columns["No"].HeaderText = "No";
                dgvReport.Columns["BillDate"].HeaderText = "Bill Date";
                //dgvReport.Columns["BillDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvReport.Columns["NumberBill"].HeaderText = "Number Bill";
                dgvReport.Columns["CustomerName"].HeaderText = "Customer Name";
                dgvReport.Columns["CustomerPhone"].HeaderText = "Customer Phone";
                dgvReport.Columns["Decriptions"].HeaderText = "Decriptions";
                dgvReport.Columns["TotalAmount"].HeaderText = "Total Amount";
                dgvReport.Columns["TotalDiscount"].HeaderText = "Total Discount";
                dgvReport.Columns["PaymentCash"].HeaderText = "Payment Cash";
                dgvReport.Columns["PaymentCard"].HeaderText = "Payment Card";
                dgvReport.Columns["PaymentVoucher"].HeaderText = "Payment Voucher";
                dgvReport.Columns["BillID"].Visible = false;

                dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (_dtResult != null && _dtResult.Rows.Count > 0)
                {
                    lblCash.Text = string.Format("{0:#,##0.00}", decimal.Parse(_dtResult.Compute("Sum(PaymentCash)", string.Empty).ToString()));
                    lblCard.Text = string.Format("{0:#,##0.00}", decimal.Parse(_dtResult.Compute("Sum(PaymentCard)", string.Empty).ToString()));
                    lblVoucher.Text = string.Format("{0:#,##0.00}", decimal.Parse(_dtResult.Compute("Sum(PaymentVoucher)", string.Empty).ToString()));
                    lblTotal.Text = string.Format("{0:#,##0.00}", decimal.Parse(_dtResult.Compute("Sum(PaymentCash)", string.Empty).ToString()) + decimal.Parse(_dtResult.Compute("Sum(PaymentCard)", string.Empty).ToString()));
                    lblTotalAmont.Text = string.Format("{0:#,##0.00}", decimal.Parse(_dtResult.Compute("Sum(TotalAmount)", string.Empty).ToString()));
                    lblTotalDiscount.Text = string.Format("{0:#,##0.00}", decimal.Parse(_dtResult.Compute("Sum(TotalDiscount)", string.Empty).ToString()));
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void dgvReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (dgvReport["BillID", e.RowIndex].Value != DBNull.Value)
            //    {
            //        int idBill = 0;
            //        if (int.TryParse(dgvReport["BillID", e.RowIndex].Value.ToString(), out idBill))
            //        {
            //            //show form bill infomation
            //            frmBillDetail frmBilldt = new frmBillDetail(idBill, int.Parse(NailApp.BranchID));
            //            frmBilldt.ShowDialog();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvReport["BillID", e.RowIndex].Value != DBNull.Value)
                {
                    int idBill = 0;
                    if (int.TryParse(dgvReport["BillID", e.RowIndex].Value.ToString(), out idBill))
                    {
                        //show form bill infomation
                        frmBillDetail frmBilldt = new frmBillDetail(idBill, int.Parse(NailApp.BranchID));
                        frmBilldt.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
