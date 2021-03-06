namespace AusNail.Dictionary
{
    partial class frmVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucher));
            this.panel2 = new System.Windows.Forms.Panel();
            this.GridDetail = new System.Windows.Forms.DataGridView();
            this.ctmGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refeshListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVoucherCode = new System.Windows.Forms.TextBox();
            this.txtAvailableAmount = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtIssueDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVoucherFrom = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtVoucherTo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtzPrintname = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDecriptions = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboIssueBy = new System.Windows.Forms.ComboBox();
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
            this.chkis_inactive.Location = new System.Drawing.Point(684, 367);
            this.chkis_inactive.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkis_inactive.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 457);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel1.Size = new System.Drawing.Size(999, 62);
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
            this.lblMessInfomation.Location = new System.Drawing.Point(356, 21);
            this.lblMessInfomation.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblMessInfomation.Size = new System.Drawing.Size(509, 25);
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(871, 21);
            this.lblTime.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblTime.Size = new System.Drawing.Size(85, 20);
            this.lblTime.Text = "23:27:39";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(147, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.GridDetail);
            this.panel2.Location = new System.Drawing.Point(13, 14);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 434);
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
            this.GridDetail.Size = new System.Drawing.Size(535, 434);
            this.GridDetail.TabIndex = 0;
            this.GridDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDetail_CellClick);
            this.GridDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.GridDetail_CellValidating);
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
            this.label2.Location = new System.Drawing.Point(575, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Voucher Code";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(556, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Available Amount";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(619, 103);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Amount";
            // 
            // txtVoucherCode
            // 
            this.txtVoucherCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVoucherCode.Location = new System.Drawing.Point(684, 66);
            this.txtVoucherCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVoucherCode.Multiline = true;
            this.txtVoucherCode.Name = "txtVoucherCode";
            this.txtVoucherCode.Size = new System.Drawing.Size(303, 25);
            this.txtVoucherCode.TabIndex = 2;
            this.txtVoucherCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVoucherCode_KeyDown);
            // 
            // txtAvailableAmount
            // 
            this.txtAvailableAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAvailableAmount.Location = new System.Drawing.Point(684, 134);
            this.txtAvailableAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAvailableAmount.Multiline = true;
            this.txtAvailableAmount.Name = "txtAvailableAmount";
            this.txtAvailableAmount.Size = new System.Drawing.Size(303, 25);
            this.txtAvailableAmount.TabIndex = 4;
            this.txtAvailableAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVoucherCode_KeyDown);
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount.Location = new System.Drawing.Point(684, 101);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAmount.Multiline = true;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(303, 25);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVoucherCode_KeyDown);
            // 
            // txtIssueDate
            // 
            this.txtIssueDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIssueDate.Location = new System.Drawing.Point(684, 167);
            this.txtIssueDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIssueDate.Multiline = true;
            this.txtIssueDate.Name = "txtIssueDate";
            this.txtIssueDate.Size = new System.Drawing.Size(303, 25);
            this.txtIssueDate.TabIndex = 5;
            this.txtIssueDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVoucherCode_KeyDown);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(612, 203);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Issue By";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(597, 170);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Issue Date";
            // 
            // txtVoucherFrom
            // 
            this.txtVoucherFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVoucherFrom.Location = new System.Drawing.Point(684, 234);
            this.txtVoucherFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVoucherFrom.Multiline = true;
            this.txtVoucherFrom.Name = "txtVoucherFrom";
            this.txtVoucherFrom.Size = new System.Drawing.Size(303, 25);
            this.txtVoucherFrom.TabIndex = 7;
            this.txtVoucherFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVoucherCode_KeyDown);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(576, 236);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Voucher From";
            // 
            // txtVoucherTo
            // 
            this.txtVoucherTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVoucherTo.Location = new System.Drawing.Point(684, 267);
            this.txtVoucherTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVoucherTo.Multiline = true;
            this.txtVoucherTo.Name = "txtVoucherTo";
            this.txtVoucherTo.Size = new System.Drawing.Size(303, 25);
            this.txtVoucherTo.TabIndex = 8;
            this.txtVoucherTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVoucherCode_KeyDown);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(591, 270);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 17);
            this.label13.TabIndex = 25;
            this.label13.Text = "Voucher To";
            // 
            // txtzPrintname
            // 
            this.txtzPrintname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtzPrintname.Location = new System.Drawing.Point(684, 300);
            this.txtzPrintname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtzPrintname.Multiline = true;
            this.txtzPrintname.Name = "txtzPrintname";
            this.txtzPrintname.Size = new System.Drawing.Size(303, 25);
            this.txtzPrintname.TabIndex = 9;
            this.txtzPrintname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVoucherCode_KeyDown);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(595, 303);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 17);
            this.label14.TabIndex = 27;
            this.label14.Text = "Print Name";
            // 
            // txtDecriptions
            // 
            this.txtDecriptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecriptions.Location = new System.Drawing.Point(684, 334);
            this.txtDecriptions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDecriptions.Multiline = true;
            this.txtDecriptions.Name = "txtDecriptions";
            this.txtDecriptions.Size = new System.Drawing.Size(303, 25);
            this.txtDecriptions.TabIndex = 10;
            this.txtDecriptions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVoucherCode_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(595, 335);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Decriptions";
            // 
            // cboIssueBy
            // 
            this.cboIssueBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIssueBy.FormattingEnabled = true;
            this.cboIssueBy.Location = new System.Drawing.Point(684, 202);
            this.cboIssueBy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboIssueBy.Name = "cboIssueBy";
            this.cboIssueBy.Size = new System.Drawing.Size(303, 24);
            this.cboIssueBy.TabIndex = 6;
            this.cboIssueBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVoucherCode_KeyDown);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(723, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 41);
            this.label11.TabIndex = 30;
            this.label11.Text = "Voucher";
            // 
            // frmVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 519);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboIssueBy);
            this.Controls.Add(this.txtDecriptions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtzPrintname);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtVoucherTo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtVoucherFrom);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtIssueDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtAvailableAmount);
            this.Controls.Add(this.txtVoucherCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmVoucher";
            this.Text = "Voucher";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtVoucherCode, 0);
            this.Controls.SetChildIndex(this.txtAvailableAmount, 0);
            this.Controls.SetChildIndex(this.txtAmount, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtIssueDate, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtVoucherFrom, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtVoucherTo, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtzPrintname, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtDecriptions, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.chkis_inactive, 0);
            this.Controls.SetChildIndex(this.cboIssueBy, 0);
            this.Controls.SetChildIndex(this.label11, 0);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVoucherCode;
        private System.Windows.Forms.TextBox txtAvailableAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtIssueDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVoucherFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVoucherTo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtzPrintname;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDecriptions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip ctmGridView;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refeshListToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboIssueBy;
        private System.Windows.Forms.Label label11;
    }
}