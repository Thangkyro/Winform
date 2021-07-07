using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AusNail.Class
{
    public class Print
    {
        public Print()
        {
        }
        public void Printer(DataSet ds, string tenfile)
        {
            try
            {
                ReportDocument oRpt = new ReportDocument();
                oRpt.Load("..//..//Report//" + tenfile, OpenReportMethod.OpenReportByTempCopy);
                oRpt.SetDataSource(ds);

                //oRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize;//.PaperA4;
                //oRpt.PrintOptions.PaperOrientation = (kieu == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape;

                oRpt.PrintToPrinter(1, false, 0, 0);
                if (oRpt != null)
                {
                    oRpt.Close();
                    oRpt.Dispose();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }


}
