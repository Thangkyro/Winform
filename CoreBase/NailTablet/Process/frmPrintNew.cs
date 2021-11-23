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
                string zcurFile = "Report//" + _reportFile;
                string curFile = "..//..//Report//" + _reportFile;
                if (File.Exists(zcurFile))
                {
                    curFile = zcurFile;
                }
                if (!File.Exists(curFile))
                {
                    MessageBox.Show("File does not exist.", "Warning");
                    return;
                }
                oRpt = new ReportDocument();
                oRpt.Load(curFile, OpenReportMethod.OpenReportByDefault);
                oRpt.SetParameterValue("@BillId", _billId.ToString());
                oRpt.SetParameterValue("@BranchId", _branchId.ToString());
                oRpt.SetDataSource(_dsReport.Tables[0]);
                rptReport.ReportSource = oRpt;
                if (!_view)
                {
                    this.Cursor = Cursors.WaitCursor;
                    oRpt.PrintToPrinter(1, false, 0, 0);
                    this.Cursor = Cursors.Default;
                    //this.Visible = false;
                    //this.Close();
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    //oRpt.PrintToPrinter(1, false, 0, 0);
                    this.Cursor = Cursors.Default;
                }

                if (oRpt != null)
                {
                    oRpt.Close();
                    oRpt.Dispose();
                }

                this.Visible = false;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Warning");
            }
        }
    }
}
