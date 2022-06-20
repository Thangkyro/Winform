namespace AusNail.Dictionary
{
    partial class frmService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmService));
            this.panel2 = new System.Windows.Forms.Panel();
            this.GridDetail = new System.Windows.Forms.DataGridView();
            this.ctmGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refeshListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.cbobranchId = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtEstimateTime = new System.Windows.Forms.TextBox();
            this.txtDecriptions = new System.Windows.Forms.TextBox();
            this.cboGroupSTT = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkis_discount = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnClear = new AltoControls.AltoButton();
            this.txtServiceID = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDetail)).BeginInit();
            this.ctmGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // chkis_inactive
            // 
            this.chkis_inactive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkis_inactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkis_inactive.Location = new System.Drawing.Point(904, 577);
            this.chkis_inactive.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkis_inactive.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 602);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel1.Size = new System.Drawing.Size(1199, 62);
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
            this.lblMessInfomation.Location = new System.Drawing.Point(325, 21);
            this.lblMessInfomation.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblMessInfomation.Size = new System.Drawing.Size(740, 25);
            this.lblMessInfomation.TabIndex = 0;
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(1071, 21);
            this.lblTime.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblTime.Size = new System.Drawing.Size(85, 20);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "21:57:57";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(147, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.TabIndex = 4;
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
            this.panel2.Size = new System.Drawing.Size(783, 568);
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
            this.GridDetail.Size = new System.Drawing.Size(783, 568);
            this.GridDetail.TabIndex = 0;
            this.GridDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDetail_CellClick);
            this.GridDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDetail_CellContentClick);
            this.GridDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.GridDetail_CellValidating);
            this.GridDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GridDetail_DataError);
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
            this.label2.Location = new System.Drawing.Point(863, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(844, 78);
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
            this.label4.Location = new System.Drawing.Point(804, 294);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "EstimateTime";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(856, 261);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Price";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(904, 142);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(281, 111);
            this.txtTitle.TabIndex = 7;
            this.txtTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbobranchId_KeyDown);
            // 
            // cbobranchId
            // 
            this.cbobranchId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbobranchId.FormattingEnabled = true;
            this.cbobranchId.Location = new System.Drawing.Point(904, 76);
            this.cbobranchId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbobranchId.Name = "cbobranchId";
            this.cbobranchId.Size = new System.Drawing.Size(281, 24);
            this.cbobranchId.TabIndex = 6;
            this.cbobranchId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbobranchId_KeyDown);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(816, 326);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 17);
            this.label14.TabIndex = 5;
            this.label14.Text = "Decriptions";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(966, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 41);
            this.label11.TabIndex = 0;
            this.label11.Text = "Service";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(904, 260);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(281, 22);
            this.txtPrice.TabIndex = 8;
            // 
            // txtEstimateTime
            // 
            this.txtEstimateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEstimateTime.Location = new System.Drawing.Point(904, 290);
            this.txtEstimateTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEstimateTime.Name = "txtEstimateTime";
            this.txtEstimateTime.Size = new System.Drawing.Size(281, 22);
            this.txtEstimateTime.TabIndex = 9;
            // 
            // txtDecriptions
            // 
            this.txtDecriptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecriptions.Location = new System.Drawing.Point(904, 322);
            this.txtDecriptions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDecriptions.Name = "txtDecriptions";
            this.txtDecriptions.Size = new System.Drawing.Size(281, 22);
            this.txtDecriptions.TabIndex = 10;
            // 
            // cboGroupSTT
            // 
            this.cboGroupSTT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGroupSTT.FormattingEnabled = true;
            this.cboGroupSTT.Location = new System.Drawing.Point(904, 108);
            this.cboGroupSTT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboGroupSTT.Name = "cboGroupSTT";
            this.cboGroupSTT.Size = new System.Drawing.Size(281, 24);
            this.cboGroupSTT.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(804, 113);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Service Group";
            // 
            // chkis_discount
            // 
            this.chkis_discount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkis_discount.AutoSize = true;
            this.chkis_discount.Location = new System.Drawing.Point(904, 547);
            this.chkis_discount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkis_discount.Name = "chkis_discount";
            this.chkis_discount.Size = new System.Drawing.Size(85, 21);
            this.chkis_discount.TabIndex = 14;
            this.chkis_discount.Text = "Discount";
            this.chkis_discount.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(802, 417);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 10010;
            this.label7.Text = "Image";
            // 
            // pbImage
            // 
            this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImage.Location = new System.Drawing.Point(904, 352);
            this.pbImage.Margin = new System.Windows.Forms.Padding(4);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(281, 147);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 10009;
            this.pbImage.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnClear.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClear.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btnClear.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnClear.Location = new System.Drawing.Point(983, 505);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Radius = 10;
            this.btnClear.Size = new System.Drawing.Size(123, 36);
            this.btnClear.Stroke = false;
            this.btnClear.StrokeColor = System.Drawing.Color.Gray;
            this.btnClear.TabIndex = 10011;
            this.btnClear.Text = "Clear Image";
            this.btnClear.Transparency = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtServiceID
            // 
            this.txtServiceID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServiceID.Location = new System.Drawing.Point(819, 557);
            this.txtServiceID.Margin = new System.Windows.Forms.Padding(4);
            this.txtServiceID.Multiline = true;
            this.txtServiceID.Name = "txtServiceID";
            this.txtServiceID.Size = new System.Drawing.Size(65, 25);
            this.txtServiceID.TabIndex = 10012;
            this.txtServiceID.Visible = false;
            // 
            // frmService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 664);
            this.Controls.Add(this.txtServiceID);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.chkis_discount);
            this.Controls.Add(this.cboGroupSTT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDecriptions);
            this.Controls.Add(this.txtEstimateTime);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cbobranchId);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmService";
            this.Text = "Service";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.chkis_inactive, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtTitle, 0);
            this.Controls.SetChildIndex(this.cbobranchId, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtPrice, 0);
            this.Controls.SetChildIndex(this.txtEstimateTime, 0);
            this.Controls.SetChildIndex(this.txtDecriptions, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cboGroupSTT, 0);
            this.Controls.SetChildIndex(this.chkis_discount, 0);
            this.Controls.SetChildIndex(this.pbImage, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.txtServiceID, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridDetail)).EndInit();
            this.ctmGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
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
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ComboBox cbobranchId;
        private System.Windows.Forms.ContextMenuStrip ctmGridView;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refeshListToolStripMenuItem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtEstimateTime;
        private System.Windows.Forms.TextBox txtDecriptions;
        private System.Windows.Forms.ComboBox cboGroupSTT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkis_discount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pbImage;
        protected AltoControls.AltoButton btnClear;
        private System.Windows.Forms.TextBox txtServiceID;
    }
}