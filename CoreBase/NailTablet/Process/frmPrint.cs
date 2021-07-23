using CoreBase.DataAccessLayer;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AusNail.Process
{
    public partial class frmPrint : Form
    {
        private int _branchId;
        private int _billId;
        private int _userId;
        private int _temtorarybill = 0;
        public frmPrint()
        {
            InitializeComponent();
        }

        public frmPrint(int branchId, int billId, int userId, int temporarybill)
        {
            InitializeComponent();
            _branchId = branchId;
            _billId = billId;
            _userId = userId;
            _temtorarybill = temporarybill;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            

            DataTable dataTable = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zBillPrint", _billId, _branchId);


            ReportDataSource rds = new ReportDataSource("DataSet1", dataTable);
            rptBill.LocalReport.DataSources.Clear();
            //Add ReportDataSource   
            rptBill.LocalReport.DataSources.Add(rds);
            

            // Refresh the report  
            this.rptBill.RefreshReport();
        }
    }
}
