using CoreBase.DataAccessLayer;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AusNail.Process
{
    public partial class frmPrintNew : Form
    {
        private int _branchId;
        private int _billId;
        private int _userId;
        private int _temtorarybill = 0;
        private bool _view = true;
        private string _reportFile;
        private DataSet _dsReport;
        ReportDocument oRpt;
        public frmPrintNew()
        {
            InitializeComponent();
        }

        public frmPrintNew(DataSet ds, string reportFile, bool view)
        {
            InitializeComponent();
            _reportFile = reportFile;
            _dsReport = ds;
            _view = view;
        }

        public frmPrintNew(DataSet ds, string reportFile, bool view, int branchId, int billID)
        {
            InitializeComponent();
            _reportFile = reportFile;
            _dsReport = ds;
            _view = view;
            _branchId = branchId;
            _billId = billID;
        }

        private void frmPrintNew_Load(object sender, EventArgs e)
        {
            try
            {

                //string curFile = "..//..//Report//" + _reportFile;
                //string hehe = File.Exists(curFile) ? "File exists." : "File does not exist.";

                oRpt = new ReportDocument();
                oRpt.Load("..//..//Report//" + _reportFile, OpenReportMethod.OpenReportByTempCopy);
                oRpt.SetParameterValue("@BillId", _billId);
                oRpt.SetParameterValue("@BranchId", _branchId);
                oRpt.SetDataSource(_dsReport);
                rptReport.ReportSource = oRpt;
                if (!_view)
                {
                    this.Cursor = Cursors.WaitCursor;
                    oRpt.PrintToPrinter(1, false, 0, 0);
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Warning");
            }
        }
    }
}
