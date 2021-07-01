namespace AusNail.Dictionary
{
    partial class frmBranch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBranch));
            this.txtBranchName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocated = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFacebook = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBranchCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ctmGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refeshListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSMSText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumberBill = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNoontime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.GridDetail = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            this.ctmGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // chkis_inactive
            // 
            this.chkis_inactive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkis_inactive.Enabled = false;
            this.chkis_inactive.Location = new System.Drawing.Point(781, 425);
            this.chkis_inactive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkis_inactive.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 460);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Size = new System.Drawing.Size(979, 50);
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
            this.lblMessInfomation.Location = new System.Drawing.Point(251, 20);
            this.lblMessInfomation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessInfomation.Size = new System.Drawing.Size(621, 20);
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(880, 20);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Size = new System.Drawing.Size(64, 16);
            this.lblTime.Text = "21:55:50";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 7);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(116, 8);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.TabIndex = 1;
            // 
            // txtBranchName
            // 
            this.txtBranchName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBranchName.Location = new System.Drawing.Point(781, 72);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Size = new System.Drawing.Size(186, 20);
            this.txtBranchName.TabIndex = 1;
            this.txtBranchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchCode_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(897, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Branch name";
            // 
            // txtLocated
            // 
            this.txtLocated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocated.Location = new System.Drawing.Point(781, 93);
            this.txtLocated.Name = "txtLocated";
            this.txtLocated.Size = new System.Drawing.Size(186, 20);
            this.txtLocated.TabIndex = 2;
            this.txtLocated.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchCode_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(698, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Located";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(781, 115);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(186, 20);
            this.txtPhoneNumber.TabIndex = 3;
            this.txtPhoneNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchCode_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(698, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Phone number";
            // 
            // txtFacebook
            // 
            this.txtFacebook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFacebook.Location = new System.Drawing.Point(781, 137);
            this.txtFacebook.Name = "txtFacebook";
            this.txtFacebook.Size = new System.Drawing.Size(186, 20);
            this.txtFacebook.TabIndex = 4;
            this.txtFacebook.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchCode_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(698, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Facebook";
            // 
            // txtBranchCode
            // 
            this.txtBranchCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBranchCode.Location = new System.Drawing.Point(781, 50);
            this.txtBranchCode.Name = "txtBranchCode";
            this.txtBranchCode.Size = new System.Drawing.Size(186, 20);
            this.txtBranchCode.TabIndex = 0;
            this.txtBranchCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchCode_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(698, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Branch code";
            // 
            // ctmGridView
            // 
            this.ctmGridView.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctmGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.refeshListToolStripMenuItem});
            this.ctmGridView.Name = "ctmGridView";
            this.ctmGridView.Size = new System.Drawing.Size(135, 56);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::AusNail.Properties.Resources.DeleteRow1;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // refeshListToolStripMenuItem
            // 
            this.refeshListToolStripMenuItem.Image = global::AusNail.Properties.Resources.Refresh;
            this.refeshListToolStripMenuItem.Name = "refeshListToolStripMenuItem";
            this.refeshListToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.refeshListToolStripMenuItem.Text = "Refesh List";
            this.refeshListToolStripMenuItem.Click += new System.EventHandler(this.refeshListToolStripMenuItem_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(781, 160);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(186, 20);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchCode_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(698, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Email";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebsite.Location = new System.Drawing.Point(781, 182);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(186, 20);
            this.txtWebsite.TabIndex = 6;
            this.txtWebsite.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchCode_KeyDown);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(698, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Website";
            // 
            // txtSMSText
            // 
            this.txtSMSText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSMSText.Location = new System.Drawing.Point(781, 205);
            this.txtSMSText.Multiline = true;
            this.txtSMSText.Name = "txtSMSText";
            this.txtSMSText.Size = new System.Drawing.Size(186, 169);
            this.txtSMSText.TabIndex = 7;
            this.txtSMSText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchCode_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(698, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "SMS text";
            // 
            // txtNumberBill
            // 
            this.txtNumberBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumberBill.Location = new System.Drawing.Point(781, 377);
            this.txtNumberBill.Name = "txtNumberBill";
            this.txtNumberBill.Size = new System.Drawing.Size(186, 20);
            this.txtNumberBill.TabIndex = 8;
            this.txtNumberBill.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchCode_KeyDown);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(698, 380);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Number bill";
            // 
            // txtNoontime
            // 
            this.txtNoontime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoontime.Location = new System.Drawing.Point(781, 399);
            this.txtNoontime.Name = "txtNoontime";
            this.txtNoontime.Size = new System.Drawing.Size(186, 20);
            this.txtNoontime.TabIndex = 9;
            this.txtNoontime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchCode_KeyDown);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(698, 402);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Noon time ";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(800, 7);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 35);
            this.label11.TabIndex = 14;
            this.label11.Text = "Branch";
            // 
            // GridDetail
            // 
            this.GridDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridDetail.BackgroundColor = System.Drawing.Color.White;
            this.GridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDetail.ContextMenuStrip = this.ctmGridView;
            this.GridDetail.Location = new System.Drawing.Point(12, 7);
            this.GridDetail.Name = "GridDetail";
            this.GridDetail.RowHeadersWidth = 51;
            this.GridDetail.Size = new System.Drawing.Size(680, 445);
            this.GridDetail.TabIndex = 13;
            this.GridDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDetail_CellClick);
            // 
            // frmBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(979, 510);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.GridDetail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBranchCode);
            this.Controls.Add(this.txtNoontime);
            this.Controls.Add(this.txtNumberBill);
            this.Controls.Add(this.txtSMSText);
            this.Controls.Add(this.txtWebsite);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtFacebook);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtLocated);
            this.Controls.Add(this.txtBranchName);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmBranch";
            this.Text = "Branch";
            this.Controls.SetChildIndex(this.txtBranchName, 0);
            this.Controls.SetChildIndex(this.txtLocated, 0);
            this.Controls.SetChildIndex(this.txtPhoneNumber, 0);
            this.Controls.SetChildIndex(this.txtFacebook, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.txtWebsite, 0);
            this.Controls.SetChildIndex(this.txtSMSText, 0);
            this.Controls.SetChildIndex(this.txtNumberBill, 0);
            this.Controls.SetChildIndex(this.txtNoontime, 0);
            this.Controls.SetChildIndex(this.txtBranchCode, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.GridDetail, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.chkis_inactive, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            this.ctmGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBranchName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocated;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFacebook;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBranchCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSMSText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumberBill;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNoontime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ContextMenuStrip ctmGridView;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refeshListToolStripMenuItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView GridDetail;
    }
}