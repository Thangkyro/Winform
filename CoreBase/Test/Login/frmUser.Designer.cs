namespace AusNail.Dictionary
{
    partial class frmUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.panel2 = new System.Windows.Forms.Panel();
            this.GridDetail = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser_name = new System.Windows.Forms.TextBox();
            this.txtDecriptions = new System.Windows.Forms.TextBox();
            this.cboBranchId = new System.Windows.Forms.ComboBox();
            this.txtFull_Name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkIs_Admin = new System.Windows.Forms.CheckBox();
            this.cboStaffId = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPermission = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ctmGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refeshListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDetail)).BeginInit();
            this.ctmGridView.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkis_inactive
            // 
            this.chkis_inactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkis_inactive.Location = new System.Drawing.Point(892, 436);
            this.chkis_inactive.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkis_inactive.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 504);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel1.Size = new System.Drawing.Size(1277, 54);
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
            this.lblMessInfomation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMessInfomation.Location = new System.Drawing.Point(796, 19);
            this.lblMessInfomation.Size = new System.Drawing.Size(313, 17);
            // 
            // lblTime
            // 
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTime.Location = new System.Drawing.Point(1149, 20);
            this.lblTime.Text = "12:51:42";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.GridDetail);
            this.panel2.Location = new System.Drawing.Point(13, 13);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 482);
            this.panel2.TabIndex = 6;
            // 
            // GridDetail
            // 
            this.GridDetail.BackgroundColor = System.Drawing.Color.White;
            this.GridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridDetail.Location = new System.Drawing.Point(0, 0);
            this.GridDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GridDetail.Name = "GridDetail";
            this.GridDetail.RowHeadersWidth = 51;
            this.GridDetail.Size = new System.Drawing.Size(784, 482);
            this.GridDetail.TabIndex = 0;
            this.GridDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDetail_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(805, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "User Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(831, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Branch";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(805, 178);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Decriptions";
            // 
            // txtUser_name
            // 
            this.txtUser_name.Location = new System.Drawing.Point(892, 45);
            this.txtUser_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUser_name.Multiline = true;
            this.txtUser_name.Name = "txtUser_name";
            this.txtUser_name.Size = new System.Drawing.Size(372, 25);
            this.txtUser_name.TabIndex = 2;
            // 
            // txtDecriptions
            // 
            this.txtDecriptions.Location = new System.Drawing.Point(892, 176);
            this.txtDecriptions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDecriptions.Multiline = true;
            this.txtDecriptions.Name = "txtDecriptions";
            this.txtDecriptions.Size = new System.Drawing.Size(372, 25);
            this.txtDecriptions.TabIndex = 6;
            // 
            // cboBranchId
            // 
            this.cboBranchId.FormattingEnabled = true;
            this.cboBranchId.Location = new System.Drawing.Point(892, 13);
            this.cboBranchId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboBranchId.Name = "cboBranchId";
            this.cboBranchId.Size = new System.Drawing.Size(372, 24);
            this.cboBranchId.TabIndex = 1;
            // 
            // txtFull_Name
            // 
            this.txtFull_Name.Location = new System.Drawing.Point(892, 78);
            this.txtFull_Name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFull_Name.Multiline = true;
            this.txtFull_Name.Name = "txtFull_Name";
            this.txtFull_Name.Size = new System.Drawing.Size(372, 25);
            this.txtFull_Name.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(813, 80);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Full Name";
            // 
            // chkIs_Admin
            // 
            this.chkIs_Admin.AutoSize = true;
            this.chkIs_Admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIs_Admin.Location = new System.Drawing.Point(892, 406);
            this.chkIs_Admin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkIs_Admin.Name = "chkIs_Admin";
            this.chkIs_Admin.Size = new System.Drawing.Size(83, 21);
            this.chkIs_Admin.TabIndex = 8;
            this.chkIs_Admin.Text = "Is Admin";
            this.chkIs_Admin.UseVisualStyleBackColor = true;
            // 
            // cboStaffId
            // 
            this.cboStaffId.FormattingEnabled = true;
            this.cboStaffId.Location = new System.Drawing.Point(892, 111);
            this.cboStaffId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboStaffId.Name = "cboStaffId";
            this.cboStaffId.Size = new System.Drawing.Size(372, 24);
            this.cboStaffId.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(847, 113);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Staff";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(892, 143);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(372, 25);
            this.txtPassword.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(815, 145);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Password";
            // 
            // txtPermission
            // 
            this.txtPermission.Enabled = false;
            this.txtPermission.Location = new System.Drawing.Point(892, 209);
            this.txtPermission.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPermission.Multiline = true;
            this.txtPermission.Name = "txtPermission";
            this.txtPermission.Size = new System.Drawing.Size(372, 189);
            this.txtPermission.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(807, 211);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Permission";
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
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // refeshListToolStripMenuItem
            // 
            this.refeshListToolStripMenuItem.Image = global::AusNail.Properties.Resources.Refresh;
            this.refeshListToolStripMenuItem.Name = "refeshListToolStripMenuItem";
            this.refeshListToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.refeshListToolStripMenuItem.Text = "Refesh List";
            this.refeshListToolStripMenuItem.Click += new System.EventHandler(this.RefeshListToolStripMenuItem_Click);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 558);
            this.Controls.Add(this.txtPermission);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboStaffId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkIs_Admin);
            this.Controls.Add(this.txtFull_Name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboBranchId);
            this.Controls.Add(this.txtDecriptions);
            this.Controls.Add(this.txtUser_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmUser";
            this.Text = "User";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.chkis_inactive, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtUser_name, 0);
            this.Controls.SetChildIndex(this.txtDecriptions, 0);
            this.Controls.SetChildIndex(this.cboBranchId, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtFull_Name, 0);
            this.Controls.SetChildIndex(this.chkIs_Admin, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.cboStaffId, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtPassword, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtPermission, 0);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser_name;
        private System.Windows.Forms.TextBox txtDecriptions;
        private System.Windows.Forms.ComboBox cboBranchId;
        private System.Windows.Forms.TextBox txtFull_Name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkIs_Admin;
        private System.Windows.Forms.ComboBox cboStaffId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPermission;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ContextMenuStrip ctmGridView;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refeshListToolStripMenuItem;
    }
}