
namespace AusNail.Process
{
    partial class frmPrintNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintNew));
            this.rptReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rptReport
            // 
            this.rptReport.ActiveViewIndex = -1;
            this.rptReport.AutoScroll = true;
            this.rptReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rptReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptReport.Location = new System.Drawing.Point(0, 0);
            this.rptReport.Name = "rptReport";
            this.rptReport.ShowGroupTreeButton = false;
            this.rptReport.ShowLogo = false;
            this.rptReport.ShowParameterPanelButton = false;
            this.rptReport.Size = new System.Drawing.Size(1069, 672);
            this.rptReport.TabIndex = 21;
            this.rptReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rptReport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1069, 672);
            this.panel1.TabIndex = 22;
            // 
            // frmPrintNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 672);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrintNew";
            this.Text = "Print";
            this.Load += new System.EventHandler(this.frmPrintNew_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptReport;
        private System.Windows.Forms.Panel panel1;
    }
}