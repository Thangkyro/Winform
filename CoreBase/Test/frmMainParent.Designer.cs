namespace AusNail
{
    partial class frmMainParent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainParent));
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
            this.TimeKeeping = new System.Windows.Forms.ToolStripMenuItem();
            this.Booking = new System.Windows.Forms.ToolStripMenuItem();
            this.zbc = new System.Windows.Forms.ToolStripMenuItem();
            this.zst = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.User = new System.Windows.Forms.ToolStripMenuItem();
            this.logoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabForms = new System.Windows.Forms.TabControl();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMenu
            // 
            this.mnsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.toolStripMenuItem1,
            this.zdm,
            this.zps,
            this.zbc,
            this.zst,
            this.logoffToolStripMenuItem,
            this.dBToolStripMenuItem});
            this.mnsMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMenu.Name = "mnsMenu";
            this.mnsMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.mnsMenu.Size = new System.Drawing.Size(1020, 28);
            this.mnsMenu.TabIndex = 7;
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
            this.zdm.Size = new System.Drawing.Size(67, 24);
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
            this.TimeKeeping,
            this.Booking});
            this.zps.Name = "zps";
            this.zps.Size = new System.Drawing.Size(59, 24);
            this.zps.Text = "Process";
            // 
            // TimeKeeping
            // 
            this.TimeKeeping.Enabled = false;
            this.TimeKeeping.Name = "TimeKeeping";
            this.TimeKeeping.Size = new System.Drawing.Size(143, 22);
            this.TimeKeeping.Text = "TimeKeeping";
            // 
            // Booking
            // 
            this.Booking.Name = "Booking";
            this.Booking.Size = new System.Drawing.Size(143, 22);
            this.Booking.Text = "Booking";
            // 
            // zbc
            // 
            this.zbc.Name = "zbc";
            this.zbc.Size = new System.Drawing.Size(59, 24);
            this.zbc.Text = "Reports";
            // 
            // zst
            // 
            this.zst.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangePassword,
            this.User});
            this.zst.Name = "zst";
            this.zst.Size = new System.Drawing.Size(56, 24);
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
            this.logoffToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.logoffToolStripMenuItem.Text = "Logoff";
            this.logoffToolStripMenuItem.Click += new System.EventHandler(this.logoffToolStripMenuItem_Click);
            // 
            // dBToolStripMenuItem
            // 
            this.dBToolStripMenuItem.Image = global::AusNail.Properties.Resources.database_gear;
            this.dBToolStripMenuItem.Name = "dBToolStripMenuItem";
            this.dBToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dBToolStripMenuItem.Size = new System.Drawing.Size(32, 24);
            this.dBToolStripMenuItem.Click += new System.EventHandler(this.dBToolStripMenuItem_Click);
            // 
            // tabForms
            // 
            this.tabForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabForms.Location = new System.Drawing.Point(0, 28);
            this.tabForms.Name = "tabForms";
            this.tabForms.SelectedIndex = 0;
            this.tabForms.Size = new System.Drawing.Size(1020, 24);
            this.tabForms.TabIndex = 8;
            this.tabForms.Visible = false;
            this.tabForms.SelectedIndexChanged += new System.EventHandler(this.tabForms_SelectedIndexChanged);
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.mainToolStripMenuItem.Text = "Main";
            this.mainToolStripMenuItem.Click += new System.EventHandler(this.mainToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 24);
            this.toolStripMenuItem1.Text = "|";
            // 
            // frmMainParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1020, 502);
            this.Controls.Add(this.tabForms);
            this.Controls.Add(this.mnsMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMainParent";
            this.Text = "Nail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainParent_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmMainParent_MdiChildActivate);
            this.mnsMenu.ResumeLayout(false);
            this.mnsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMenu;
        private System.Windows.Forms.ToolStripMenuItem zdm;
        private System.Windows.Forms.ToolStripMenuItem Branch;
        private System.Windows.Forms.ToolStripMenuItem Customer;
        private System.Windows.Forms.ToolStripMenuItem Service;
        private System.Windows.Forms.ToolStripMenuItem Staff;
        private System.Windows.Forms.ToolStripMenuItem Holiday;
        private System.Windows.Forms.ToolStripMenuItem Voucher;
        private System.Windows.Forms.ToolStripMenuItem BusinessHour;
        private System.Windows.Forms.ToolStripMenuItem zps;
        private System.Windows.Forms.ToolStripMenuItem TimeKeeping;
        private System.Windows.Forms.ToolStripMenuItem Booking;
        private System.Windows.Forms.ToolStripMenuItem zbc;
        private System.Windows.Forms.ToolStripMenuItem zst;
        private System.Windows.Forms.ToolStripMenuItem ChangePassword;
        private System.Windows.Forms.ToolStripMenuItem User;
        private System.Windows.Forms.ToolStripMenuItem logoffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBToolStripMenuItem;
        private System.Windows.Forms.TabControl tabForms;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}