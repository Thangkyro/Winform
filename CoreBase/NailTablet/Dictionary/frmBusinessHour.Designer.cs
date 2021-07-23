namespace AusNail.Dictionary
{
    partial class frmBusinessHour
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusinessHour));
            this.panel2 = new System.Windows.Forms.Panel();
            this.GridDetail = new System.Windows.Forms.DataGridView();
            this.ctmGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refeshListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDayOfWeek = new System.Windows.Forms.TextBox();
            this.txtBusinessTo = new System.Windows.Forms.TextBox();
            this.txtBusinessFrom = new System.Windows.Forms.TextBox();
            this.cbobranchId = new System.Windows.Forms.ComboBox();
            this.txtDecriptions = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDetail)).BeginInit();
            this.ctmGridView.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkis_inactive
            // 
            this.chkis_inactive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkis_inactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkis_inactive.Location = new System.Drawing.Point(636, 279);
            this.chkis_inactive.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkis_inactive.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 441);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel1.Size = new System.Drawing.Size(920, 62);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(0, "Save.png");
            this.imageList.Images.SetKeyName(1, "add.png");
            this.imageList.Images.SetKeyName(2, "disk_edit.png");
            this.imageList.Images.SetKeyName(3, "Edit.png");
            this.imageList.Images.SetKeyName(4, "cancel.png");
            // 
            // lblMessInfomation
            // 
            this.lblMessInfomation.Location = new System.Drawing.Point(351, 26);
            this.lblMessInfomation.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblMessInfomation.Size = new System.Drawing.Size(434, 23);
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(791, 27);
            this.lblTime.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblTime.Size = new System.Drawing.Size(115, 23);
            this.lblTime.Text = "22:01:44";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 9);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(149, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.GridDetail);
            this.panel2.Location = new System.Drawing.Point(16, 17);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(511, 415);
            this.panel2.TabIndex = 6;
            // 
            // GridDetail
            // 
            this.GridDetail.BackgroundColor = System.Drawing.Color.White;
            this.GridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDetail.ContextMenuStrip = this.ctmGridView;
            this.GridDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridDetail.Location = new System.Drawing.Point(0, 0);
            this.GridDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GridDetail.Name = "GridDetail";
            this.GridDetail.RowHeadersWidth = 51;
            this.GridDetail.Size = new System.Drawing.Size(511, 415);
            this.GridDetail.TabIndex = 0;
            this.GridDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDetail_CellClick);
            this.GridDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.GridDetail_CellValidating);
            this.GridDetail.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.GridDetail_DefaultValuesNeeded);
            // 
            // ctmGridView
            // 
            this.ctmGridView.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctmGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.refeshListToolStripMenuItem});
            this.ctmGridView.Name = "ctmGridView";
            this.ctmGridView.Size = new System.Drawing.Size(153, 56);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::AusNail.Properties.Resources.DeleteRow1;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // refeshListToolStripMenuItem
            // 
            this.refeshListToolStripMenuItem.Image = global::AusNail.Properties.Resources.Refresh;
            this.refeshListToolStripMenuItem.Name = "refeshListToolStripMenuItem";
            this.refeshListToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.refeshListToolStripMenuItem.Text = "Refesh List";
            this.refeshListToolStripMenuItem.Click += new System.EventHandler(this.RefeshListToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(535, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Day Of Week";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(575, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Branch";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(601, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "To";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(587, 135);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "From";
            // 
            // txtDayOfWeek
            // 
            this.txtDayOfWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDayOfWeek.Location = new System.Drawing.Point(635, 100);
            this.txtDayOfWeek.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDayOfWeek.Multiline = true;
            this.txtDayOfWeek.Name = "txtDayOfWeek";
            this.txtDayOfWeek.Size = new System.Drawing.Size(271, 25);
            this.txtDayOfWeek.TabIndex = 7;
            this.txtDayOfWeek.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDayOfWeek_KeyDown);
            // 
            // txtBusinessTo
            // 
            this.txtBusinessTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusinessTo.Location = new System.Drawing.Point(635, 166);
            this.txtBusinessTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBusinessTo.Multiline = true;
            this.txtBusinessTo.Name = "txtBusinessTo";
            this.txtBusinessTo.Size = new System.Drawing.Size(271, 25);
            this.txtBusinessTo.TabIndex = 9;
            this.txtBusinessTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDayOfWeek_KeyDown);
            // 
            // txtBusinessFrom
            // 
            this.txtBusinessFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusinessFrom.Location = new System.Drawing.Point(635, 133);
            this.txtBusinessFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBusinessFrom.Multiline = true;
            this.txtBusinessFrom.Name = "txtBusinessFrom";
            this.txtBusinessFrom.Size = new System.Drawing.Size(271, 25);
            this.txtBusinessFrom.TabIndex = 8;
            this.txtBusinessFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDayOfWeek_KeyDown);
            // 
            // cbobranchId
            // 
            this.cbobranchId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbobranchId.FormattingEnabled = true;
            this.cbobranchId.Location = new System.Drawing.Point(635, 68);
            this.cbobranchId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbobranchId.Name = "cbobranchId";
            this.cbobranchId.Size = new System.Drawing.Size(271, 24);
            this.cbobranchId.TabIndex = 6;
            this.cbobranchId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbobranchId_KeyDown);
            // 
            // txtDecriptions
            // 
            this.txtDecriptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecriptions.Location = new System.Drawing.Point(636, 199);
            this.txtDecriptions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDecriptions.Multiline = true;
            this.txtDecriptions.Name = "txtDecriptions";
            this.txtDecriptions.Size = new System.Drawing.Size(271, 70);
            this.txtDecriptions.TabIndex = 10;
            this.txtDecriptions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDayOfWeek_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(548, 201);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Decriptions";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(631, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(221, 41);
            this.label11.TabIndex = 0;
            this.label11.Text = "Business Hour";
            // 
            // frmBusinessHour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 504);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDecriptions);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbobranchId);
            this.Controls.Add(this.txtBusinessFrom);
            this.Controls.Add(this.txtBusinessTo);
            this.Controls.Add(this.txtDayOfWeek);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmBusinessHour";
            this.Text = "Business Hour";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtDayOfWeek, 0);
            this.Controls.SetChildIndex(this.txtBusinessTo, 0);
            this.Controls.SetChildIndex(this.txtBusinessFrom, 0);
            this.Controls.SetChildIndex(this.cbobranchId, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtDecriptions, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.chkis_inactive, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridDetail)).EndInit();
            this.ctmGridView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView GridDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDayOfWeek;
        private System.Windows.Forms.TextBox txtBusinessTo;
        private System.Windows.Forms.TextBox txtBusinessFrom;
        private System.Windows.Forms.ComboBox cbobranchId;
        private System.Windows.Forms.TextBox txtDecriptions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip ctmGridView;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refeshListToolStripMenuItem;
        private System.Windows.Forms.Label label11;
    }
}