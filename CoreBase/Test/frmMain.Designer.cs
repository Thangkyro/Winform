﻿using System.Drawing;
namespace AusNail
{
    partial class frmMain
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSetColor = new AltoControls.AltoButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.altoSlidingLabel3 = new AltoControls.AltoSlidingLabel();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.txtColor = new AltoControls.AltoTextBox();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.mnsMenu = new System.Windows.Forms.MenuStrip();
            this.zdm = new System.Windows.Forms.ToolStripMenuItem();
            this.Branch = new System.Windows.Forms.ToolStripMenuItem();
            this.Customer = new System.Windows.Forms.ToolStripMenuItem();
            this.Service = new System.Windows.Forms.ToolStripMenuItem();
            this.Staff = new System.Windows.Forms.ToolStripMenuItem();
            this.Holiday = new System.Windows.Forms.ToolStripMenuItem();
            this.Voucher = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessHour = new System.Windows.Forms.ToolStripMenuItem();
            this.zps = new System.Windows.Forms.ToolStripMenuItem();
            this.Bill = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeKeeping = new System.Windows.Forms.ToolStripMenuItem();
            this.checkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zbc = new System.Windows.Forms.ToolStripMenuItem();
            this.zsys = new System.Windows.Forms.ToolStripMenuItem();
            this.formBorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zst = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.User = new System.Windows.Forms.ToolStripMenuItem();
            this.logoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.mnsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.pnlForm);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(970, 519);
            this.splitContainer1.SplitterDistance = 243;
            this.splitContainer1.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AccessibleName = "";
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Panel2.Controls.Add(this.btnSetColor);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.altoSlidingLabel3);
            this.splitContainer2.Panel2.Controls.Add(this.cboColor);
            this.splitContainer2.Panel2.Controls.Add(this.txtColor);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(243, 519);
            this.splitContainer2.SplitterDistance = 345;
            this.splitContainer2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(239, 341);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(231, 315);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Temporary bill";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(231, 315);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "History";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSetColor
            // 
            this.btnSetColor.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnSetColor.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnSetColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetColor.BackColor = System.Drawing.Color.Transparent;
            this.btnSetColor.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSetColor.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnSetColor.ForeColor = System.Drawing.Color.Black;
            this.btnSetColor.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btnSetColor.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnSetColor.Location = new System.Drawing.Point(119, 115);
            this.btnSetColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSetColor.Name = "btnSetColor";
            this.btnSetColor.Radius = 10;
            this.btnSetColor.Size = new System.Drawing.Size(100, 24);
            this.btnSetColor.Stroke = false;
            this.btnSetColor.StrokeColor = System.Drawing.Color.Gray;
            this.btnSetColor.TabIndex = 14;
            this.btnSetColor.Text = "Setup Color";
            this.btnSetColor.Transparency = false;
            this.btnSetColor.Click += new System.EventHandler(this.BtnSetColor_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Color";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Color Code";
            // 
            // altoSlidingLabel3
            // 
            this.altoSlidingLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.altoSlidingLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altoSlidingLabel3.Location = new System.Drawing.Point(21, 28);
            this.altoSlidingLabel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.altoSlidingLabel3.Name = "altoSlidingLabel3";
            this.altoSlidingLabel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.altoSlidingLabel3.Size = new System.Drawing.Size(158, 22);
            this.altoSlidingLabel3.Slide = false;
            this.altoSlidingLabel3.TabIndex = 11;
            this.altoSlidingLabel3.Text = "Change Theme Color";
            // 
            // cboColor
            // 
            this.cboColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(82, 54);
            this.cboColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(138, 21);
            this.cboColor.TabIndex = 9;
            this.cboColor.SelectedIndexChanged += new System.EventHandler(this.CboColor_SelectedIndexChanged);
            // 
            // txtColor
            // 
            this.txtColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtColor.BackColor = System.Drawing.Color.Transparent;
            this.txtColor.Br = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtColor.Enabled = false;
            this.txtColor.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.txtColor.ForeColor = System.Drawing.Color.DimGray;
            this.txtColor.Location = new System.Drawing.Point(82, 79);
            this.txtColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(137, 25);
            this.txtColor.TabIndex = 6;
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.Transparent;
            this.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(723, 519);
            this.pnlForm.TabIndex = 0;
            // 
            // mnsMenu
            // 
            this.mnsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zdm,
            this.zps,
            this.zbc,
            this.zsys,
            this.zst,
            this.logoffToolStripMenuItem});
            this.mnsMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMenu.Name = "mnsMenu";
            this.mnsMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.mnsMenu.Size = new System.Drawing.Size(970, 24);
            this.mnsMenu.TabIndex = 6;
            this.mnsMenu.Text = "Menu";
            // 
            // zdm
            // 
            this.zdm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Branch,
            this.Customer,
            this.Service,
            this.Staff,
            this.Holiday,
            this.Voucher,
            this.BusinessHour});
            this.zdm.Name = "zdm";
            this.zdm.Size = new System.Drawing.Size(67, 20);
            this.zdm.Text = "Category";
            // 
            // Branch
            // 
            this.Branch.Name = "Branch";
            this.Branch.Size = new System.Drawing.Size(146, 22);
            this.Branch.Text = "Branch";
            // 
            // Customer
            // 
            this.Customer.Name = "Customer";
            this.Customer.Size = new System.Drawing.Size(146, 22);
            this.Customer.Text = "Customer";
            // 
            // Service
            // 
            this.Service.Name = "Service";
            this.Service.Size = new System.Drawing.Size(146, 22);
            this.Service.Text = "Service";
            // 
            // Staff
            // 
            this.Staff.Name = "Staff";
            this.Staff.Size = new System.Drawing.Size(146, 22);
            this.Staff.Text = "Staff";
            // 
            // Holiday
            // 
            this.Holiday.Name = "Holiday";
            this.Holiday.Size = new System.Drawing.Size(146, 22);
            this.Holiday.Text = "Holiday";
            // 
            // Voucher
            // 
            this.Voucher.Name = "Voucher";
            this.Voucher.Size = new System.Drawing.Size(146, 22);
            this.Voucher.Text = "Voucher";
            // 
            // BusinessHour
            // 
            this.BusinessHour.Name = "BusinessHour";
            this.BusinessHour.Size = new System.Drawing.Size(146, 22);
            this.BusinessHour.Text = "BusinessHour";
            // 
            // zps
            // 
            this.zps.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Bill,
            this.TimeKeeping,
            this.checkingToolStripMenuItem});
            this.zps.Name = "zps";
            this.zps.Size = new System.Drawing.Size(59, 20);
            this.zps.Text = "Process";
            // 
            // Bill
            // 
            this.Bill.Name = "Bill";
            this.Bill.Size = new System.Drawing.Size(143, 22);
            this.Bill.Text = "Bill";
            this.Bill.Click += new System.EventHandler(this.Bill_Click);
            // 
            // TimeKeeping
            // 
            this.TimeKeeping.Name = "TimeKeeping";
            this.TimeKeeping.Size = new System.Drawing.Size(143, 22);
            this.TimeKeeping.Text = "TimeKeeping";
            // 
            // checkingToolStripMenuItem
            // 
            this.checkingToolStripMenuItem.Name = "checkingToolStripMenuItem";
            this.checkingToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.checkingToolStripMenuItem.Text = "Checking";
            this.checkingToolStripMenuItem.Click += new System.EventHandler(this.checkingToolStripMenuItem_Click);
            // 
            // zbc
            // 
            this.zbc.Name = "zbc";
            this.zbc.Size = new System.Drawing.Size(59, 20);
            this.zbc.Text = "Reports";
            // 
            // zsys
            // 
            this.zsys.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formBorToolStripMenuItem});
            this.zsys.Name = "zsys";
            this.zsys.Size = new System.Drawing.Size(57, 20);
            this.zsys.Text = "System";
            // 
            // formBorToolStripMenuItem
            // 
            this.formBorToolStripMenuItem.CheckOnClick = true;
            this.formBorToolStripMenuItem.Name = "formBorToolStripMenuItem";
            this.formBorToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.formBorToolStripMenuItem.Text = "Form Border Style";
            // 
            // zst
            // 
            this.zst.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangePassword,
            this.User});
            this.zst.Name = "zst";
            this.zst.Size = new System.Drawing.Size(56, 20);
            this.zst.Text = "Setting";
            // 
            // ChangePassword
            // 
            this.ChangePassword.Name = "ChangePassword";
            this.ChangePassword.Size = new System.Drawing.Size(168, 22);
            this.ChangePassword.Text = "Change Password";
            this.ChangePassword.Click += new System.EventHandler(this.ChangePassword_Click);
            // 
            // User
            // 
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(168, 22);
            this.User.Text = "User";
            // 
            // logoffToolStripMenuItem
            // 
            this.logoffToolStripMenuItem.Name = "logoffToolStripMenuItem";
            this.logoffToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.logoffToolStripMenuItem.Text = "Logoff";
            this.logoffToolStripMenuItem.Click += new System.EventHandler(this.LogoffToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 543);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mnsMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsMenu;
            this.Name = "frmMain";
            this.Text = "Nail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.mnsMenu.ResumeLayout(false);
            this.mnsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.MenuStrip mnsMenu;
        private System.Windows.Forms.ToolStripMenuItem zdm;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem zps;
        private System.Windows.Forms.ToolStripMenuItem zbc;
        private System.Windows.Forms.ToolStripMenuItem zsys;
        private System.Windows.Forms.ToolStripMenuItem Branch;
        private System.Windows.Forms.ToolStripMenuItem Customer;
        private System.Windows.Forms.ToolStripMenuItem Service;
        private System.Windows.Forms.ToolStripMenuItem Staff;
        private System.Windows.Forms.ToolStripMenuItem Holiday;
        private System.Windows.Forms.ToolStripMenuItem Voucher;
        private System.Windows.Forms.ToolStripMenuItem BusinessHour;
        private System.Windows.Forms.ToolStripMenuItem Bill;
        private System.Windows.Forms.ToolStripMenuItem TimeKeeping;
        private System.Windows.Forms.ToolStripMenuItem zst;
        private System.Windows.Forms.ToolStripMenuItem ChangePassword;
        private System.Windows.Forms.ToolStripMenuItem formBorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem User;
        private System.Windows.Forms.ToolStripMenuItem logoffToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboColor;
        private AltoControls.AltoTextBox txtColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private AltoControls.AltoSlidingLabel altoSlidingLabel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private AltoControls.AltoButton btnSetColor;
    }
}

