using System.Drawing;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.splCMain = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.trTemporaryBill = new System.Windows.Forms.TreeView();
            this.cMSReload = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deeteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.trHistoryBill = new System.Windows.Forms.TreeView();
            this.btnSetColor = new AltoControls.AltoButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.altoSlidingLabel3 = new AltoControls.AltoSlidingLabel();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.txtColor = new AltoControls.AltoTextBox();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.dtpFilterDate = new System.Windows.Forms.DateTimePicker();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblFilterDate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDel = new AltoControls.AltoButton();
            this.lblTotalDiscount = new System.Windows.Forms.Label();
            this.lblTotalAmont = new System.Windows.Forms.Label();
            this.lblVoucher = new System.Windows.Forms.Label();
            this.lb3 = new System.Windows.Forms.Label();
            this.lblCard = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.lb2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPrint = new AltoControls.AltoButton();
            this.butCheckphone = new AltoControls.AltoButton();
            this.btnPay = new AltoControls.AltoButton();
            this.btnSave = new AltoControls.AltoButton();
            this.dgvService = new System.Windows.Forms.DataGridView();
            this.txtGenden = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtBilDate = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtBillCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mnsMenu = new System.Windows.Forms.MenuStrip();
            this.tsmHide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.zsys = new System.Windows.Forms.ToolStripMenuItem();
            this.formBorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zst = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.User = new System.Windows.Forms.ToolStripMenuItem();
            this.logoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dtpFiltDateTemp = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.splCMain)).BeginInit();
            this.splCMain.Panel1.SuspendLayout();
            this.splCMain.Panel2.SuspendLayout();
            this.splCMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.cMSReload.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).BeginInit();
            this.mnsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splCMain
            // 
            this.splCMain.BackColor = System.Drawing.Color.Transparent;
            this.splCMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splCMain.Location = new System.Drawing.Point(0, 0);
            this.splCMain.Name = "splCMain";
            // 
            // splCMain.Panel1
            // 
            this.splCMain.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splCMain.Panel1.Controls.Add(this.splitContainer2);
            this.splCMain.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splCMain.Panel2
            // 
            this.splCMain.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splCMain.Panel2.Controls.Add(this.pnlForm);
            this.splCMain.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splCMain.Size = new System.Drawing.Size(1795, 598);
            this.splCMain.SplitterDistance = 447;
            this.splCMain.TabIndex = 5;
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
            this.splitContainer2.Size = new System.Drawing.Size(447, 598);
            this.splitContainer2.SplitterDistance = 434;
            this.splitContainer2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(443, 430);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.trTemporaryBill);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(435, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Temporary bill";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // trTemporaryBill
            // 
            this.trTemporaryBill.ContextMenuStrip = this.cMSReload;
            this.trTemporaryBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trTemporaryBill.Location = new System.Drawing.Point(2, 2);
            this.trTemporaryBill.Name = "trTemporaryBill";
            this.trTemporaryBill.Size = new System.Drawing.Size(431, 400);
            this.trTemporaryBill.TabIndex = 0;
            this.trTemporaryBill.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trTemporaryBill_AfterSelect);
            this.trTemporaryBill.Click += new System.EventHandler(this.trTemporaryBill_Click);
            // 
            // cMSReload
            // 
            this.cMSReload.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cMSReload.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.deeteToolStripMenuItem});
            this.cMSReload.Name = "contextMenuStrip1";
            this.cMSReload.Size = new System.Drawing.Size(115, 56);
            this.cMSReload.Text = "ReLoad";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::AusNail.Properties.Resources.Refresh;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(114, 26);
            this.toolStripMenuItem1.Text = "Reload";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // deeteToolStripMenuItem
            // 
            this.deeteToolStripMenuItem.Image = global::AusNail.Properties.Resources.DeleteRow1;
            this.deeteToolStripMenuItem.Name = "deeteToolStripMenuItem";
            this.deeteToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.deeteToolStripMenuItem.Text = "Delete";
            this.deeteToolStripMenuItem.Click += new System.EventHandler(this.deeteToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.trHistoryBill);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(435, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "History bill";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // trHistoryBill
            // 
            this.trHistoryBill.ContextMenuStrip = this.cMSReload;
            this.trHistoryBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trHistoryBill.Location = new System.Drawing.Point(2, 2);
            this.trHistoryBill.Name = "trHistoryBill";
            this.trHistoryBill.Size = new System.Drawing.Size(431, 400);
            this.trHistoryBill.TabIndex = 0;
            this.trHistoryBill.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trHistoryBill_AfterSelect);
            this.trHistoryBill.Click += new System.EventHandler(this.trHistoryBill_Click);
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
            this.btnSetColor.Location = new System.Drawing.Point(118, 118);
            this.btnSetColor.Margin = new System.Windows.Forms.Padding(2);
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
            this.label2.Location = new System.Drawing.Point(46, 89);
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
            this.label1.Location = new System.Drawing.Point(17, 57);
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
            this.altoSlidingLabel3.Location = new System.Drawing.Point(20, 31);
            this.altoSlidingLabel3.Margin = new System.Windows.Forms.Padding(2);
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
            this.cboColor.Location = new System.Drawing.Point(80, 57);
            this.cboColor.Margin = new System.Windows.Forms.Padding(2);
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
            this.txtColor.Location = new System.Drawing.Point(80, 83);
            this.txtColor.Margin = new System.Windows.Forms.Padding(2);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(137, 25);
            this.txtColor.TabIndex = 6;
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.Transparent;
            this.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlForm.Controls.Add(this.dtpFiltDateTemp);
            this.pnlForm.Controls.Add(this.dtpFilterDate);
            this.pnlForm.Controls.Add(this.txtDesc);
            this.pnlForm.Controls.Add(this.lblFilterDate);
            this.pnlForm.Controls.Add(this.label8);
            this.pnlForm.Controls.Add(this.btnDel);
            this.pnlForm.Controls.Add(this.lblTotalDiscount);
            this.pnlForm.Controls.Add(this.lblTotalAmont);
            this.pnlForm.Controls.Add(this.lblVoucher);
            this.pnlForm.Controls.Add(this.lb3);
            this.pnlForm.Controls.Add(this.lblCard);
            this.pnlForm.Controls.Add(this.lblCash);
            this.pnlForm.Controls.Add(this.lb2);
            this.pnlForm.Controls.Add(this.label7);
            this.pnlForm.Controls.Add(this.lb1);
            this.pnlForm.Controls.Add(this.label6);
            this.pnlForm.Controls.Add(this.btnPrint);
            this.pnlForm.Controls.Add(this.butCheckphone);
            this.pnlForm.Controls.Add(this.btnPay);
            this.pnlForm.Controls.Add(this.btnSave);
            this.pnlForm.Controls.Add(this.dgvService);
            this.pnlForm.Controls.Add(this.txtGenden);
            this.pnlForm.Controls.Add(this.txtPhone);
            this.pnlForm.Controls.Add(this.txtBilDate);
            this.pnlForm.Controls.Add(this.txtCustomerName);
            this.pnlForm.Controls.Add(this.txtBillCode);
            this.pnlForm.Controls.Add(this.label5);
            this.pnlForm.Controls.Add(this.label4);
            this.pnlForm.Controls.Add(this.label3);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(1344, 598);
            this.pnlForm.TabIndex = 0;
            // 
            // dtpFilterDate
            // 
            this.dtpFilterDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFilterDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFilterDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFilterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilterDate.Location = new System.Drawing.Point(1175, 90);
            this.dtpFilterDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFilterDate.Name = "dtpFilterDate";
            this.dtpFilterDate.Size = new System.Drawing.Size(153, 22);
            this.dtpFilterDate.TabIndex = 10005;
            this.dtpFilterDate.Value = new System.DateTime(2021, 7, 7, 21, 34, 29, 0);
            this.dtpFilterDate.ValueChanged += new System.EventHandler(this.dtpFilterDate_ValueChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(87, 92);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(964, 20);
            this.txtDesc.TabIndex = 10004;
            // 
            // lblFilterDate
            // 
            this.lblFilterDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilterDate.AutoSize = true;
            this.lblFilterDate.Location = new System.Drawing.Point(1112, 95);
            this.lblFilterDate.Name = "lblFilterDate";
            this.lblFilterDate.Size = new System.Drawing.Size(58, 13);
            this.lblFilterDate.TabIndex = 10003;
            this.lblFilterDate.Text = "Filter Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 10003;
            this.label8.Text = "Descriptions:";
            // 
            // btnDel
            // 
            this.btnDel.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnDel.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.BackColor = System.Drawing.Color.Transparent;
            this.btnDel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDel.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnDel.ForeColor = System.Drawing.Color.Black;
            this.btnDel.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btnDel.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnDel.Location = new System.Drawing.Point(1241, 67);
            this.btnDel.Margin = new System.Windows.Forms.Padding(2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Radius = 10;
            this.btnDel.Size = new System.Drawing.Size(85, 21);
            this.btnDel.Stroke = false;
            this.btnDel.StrokeColor = System.Drawing.Color.Gray;
            this.btnDel.TabIndex = 17;
            this.btnDel.Text = "Delete";
            this.btnDel.Transparency = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lblTotalDiscount
            // 
            this.lblTotalDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDiscount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDiscount.Location = new System.Drawing.Point(863, 539);
            this.lblTotalDiscount.Name = "lblTotalDiscount";
            this.lblTotalDiscount.Size = new System.Drawing.Size(188, 44);
            this.lblTotalDiscount.TabIndex = 16;
            this.lblTotalDiscount.Text = "0";
            this.lblTotalDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalAmont
            // 
            this.lblTotalAmont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalAmont.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmont.Location = new System.Drawing.Point(588, 539);
            this.lblTotalAmont.Name = "lblTotalAmont";
            this.lblTotalAmont.Size = new System.Drawing.Size(188, 44);
            this.lblTotalAmont.TabIndex = 16;
            this.lblTotalAmont.Text = "0";
            this.lblTotalAmont.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVoucher
            // 
            this.lblVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVoucher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVoucher.Location = new System.Drawing.Point(398, 573);
            this.lblVoucher.Name = "lblVoucher";
            this.lblVoucher.Size = new System.Drawing.Size(105, 20);
            this.lblVoucher.TabIndex = 16;
            this.lblVoucher.Text = "0";
            this.lblVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb3
            // 
            this.lb3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb3.AutoSize = true;
            this.lb3.Location = new System.Drawing.Point(345, 574);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(50, 13);
            this.lb3.TabIndex = 16;
            this.lb3.Text = "Voucher:";
            // 
            // lblCard
            // 
            this.lblCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCard.Location = new System.Drawing.Point(398, 552);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(105, 20);
            this.lblCard.TabIndex = 16;
            this.lblCard.Text = "0";
            this.lblCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCash
            // 
            this.lblCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCash.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCash.Location = new System.Drawing.Point(398, 531);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(105, 20);
            this.lblCash.TabIndex = 16;
            this.lblCash.Text = "0";
            this.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb2
            // 
            this.lb2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb2.AutoSize = true;
            this.lb2.Location = new System.Drawing.Point(345, 553);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(32, 13);
            this.lb2.TabIndex = 16;
            this.lb2.Text = "Card:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(780, 556);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Total Discount:";
            // 
            // lb1
            // 
            this.lb1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(345, 533);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(34, 13);
            this.lb1.TabIndex = 16;
            this.lb1.Text = "Cash:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(509, 556);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Total Amount:";
            // 
            // btnPrint
            // 
            this.btnPrint.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnPrint.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPrint.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btnPrint.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnPrint.Location = new System.Drawing.Point(1163, 539);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Radius = 10;
            this.btnPrint.Size = new System.Drawing.Size(80, 44);
            this.btnPrint.Stroke = false;
            this.btnPrint.StrokeColor = System.Drawing.Color.Gray;
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "Print";
            this.btnPrint.Transparency = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // butCheckphone
            // 
            this.butCheckphone.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.butCheckphone.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.butCheckphone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butCheckphone.BackColor = System.Drawing.Color.Transparent;
            this.butCheckphone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butCheckphone.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCheckphone.ForeColor = System.Drawing.Color.Black;
            this.butCheckphone.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.butCheckphone.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.butCheckphone.Location = new System.Drawing.Point(31, 539);
            this.butCheckphone.Margin = new System.Windows.Forms.Padding(2);
            this.butCheckphone.Name = "butCheckphone";
            this.butCheckphone.Radius = 10;
            this.butCheckphone.Size = new System.Drawing.Size(110, 42);
            this.butCheckphone.Stroke = false;
            this.butCheckphone.StrokeColor = System.Drawing.Color.Gray;
            this.butCheckphone.TabIndex = 11;
            this.butCheckphone.Text = "New Bill";
            this.butCheckphone.Transparency = false;
            this.butCheckphone.Click += new System.EventHandler(this.butCheckphone_Click);
            // 
            // btnPay
            // 
            this.btnPay.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnPay.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPay.BackColor = System.Drawing.Color.Transparent;
            this.btnPay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPay.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.Black;
            this.btnPay.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btnPay.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnPay.Location = new System.Drawing.Point(1253, 539);
            this.btnPay.Margin = new System.Windows.Forms.Padding(2);
            this.btnPay.Name = "btnPay";
            this.btnPay.Radius = 10;
            this.btnPay.Size = new System.Drawing.Size(80, 44);
            this.btnPay.Stroke = false;
            this.btnPay.StrokeColor = System.Drawing.Color.Gray;
            this.btnPay.TabIndex = 15;
            this.btnPay.Text = "Pay";
            this.btnPay.Transparency = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnSave
            // 
            this.btnSave.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnSave.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btnSave.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnSave.Location = new System.Drawing.Point(1073, 539);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 10;
            this.btnSave.Size = new System.Drawing.Size(80, 44);
            this.btnSave.Stroke = false;
            this.btnSave.StrokeColor = System.Drawing.Color.Gray;
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.Transparency = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvService
            // 
            this.dgvService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvService.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvService.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvService.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvService.Location = new System.Drawing.Point(19, 118);
            this.dgvService.MultiSelect = false;
            this.dgvService.Name = "dgvService";
            this.dgvService.RowHeadersWidth = 51;
            this.dgvService.Size = new System.Drawing.Size(1313, 409);
            this.dgvService.TabIndex = 10;
            this.dgvService.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvService_CellContentClick);
            this.dgvService.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvService_CellEndEdit);
            this.dgvService.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvService_CellFormatting);
            this.dgvService.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvService_DataError);
            // 
            // txtGenden
            // 
            this.txtGenden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenden.Location = new System.Drawing.Point(1175, 67);
            this.txtGenden.Name = "txtGenden";
            this.txtGenden.ReadOnly = true;
            this.txtGenden.Size = new System.Drawing.Size(64, 20);
            this.txtGenden.TabIndex = 8;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Location = new System.Drawing.Point(1053, 67);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(120, 20);
            this.txtPhone.TabIndex = 7;
            // 
            // txtBilDate
            // 
            this.txtBilDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBilDate.Location = new System.Drawing.Point(1053, 45);
            this.txtBilDate.Name = "txtBilDate";
            this.txtBilDate.ReadOnly = true;
            this.txtBilDate.Size = new System.Drawing.Size(275, 20);
            this.txtBilDate.TabIndex = 5;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerName.Location = new System.Drawing.Point(87, 67);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(964, 20);
            this.txtCustomerName.TabIndex = 6;
            // 
            // txtBillCode
            // 
            this.txtBillCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBillCode.Location = new System.Drawing.Point(87, 45);
            this.txtBillCode.Name = "txtBillCode";
            this.txtBillCode.ReadOnly = true;
            this.txtBillCode.Size = new System.Drawing.Size(964, 20);
            this.txtBillCode.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Customer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Bill:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1341, 36);
            this.label3.TabIndex = 0;
            this.label3.Text = "BILL INFORMATION";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mnsMenu
            // 
            this.mnsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmHide,
            this.toolStripMenuItem2,
            this.zdm,
            this.zps,
            this.zbc,
            this.zsys,
            this.zst,
            this.logoffToolStripMenuItem,
            this.dBToolStripMenuItem});
            this.mnsMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMenu.Name = "mnsMenu";
            this.mnsMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.mnsMenu.Size = new System.Drawing.Size(1215, 28);
            this.mnsMenu.TabIndex = 6;
            this.mnsMenu.Text = "Menu";
            this.mnsMenu.Visible = false;
            // 
            // tsmHide
            // 
            this.tsmHide.Name = "tsmHide";
            this.tsmHide.Size = new System.Drawing.Size(35, 24);
            this.tsmHide.Text = "<<";
            this.tsmHide.Click += new System.EventHandler(this.tsmHide_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(22, 24);
            this.toolStripMenuItem2.Text = "|";
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
            this.TimeKeeping.Click += new System.EventHandler(this.TimeKeeping_Click);
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
            // zsys
            // 
            this.zsys.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formBorToolStripMenuItem});
            this.zsys.Name = "zsys";
            this.zsys.Size = new System.Drawing.Size(57, 24);
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
            this.logoffToolStripMenuItem.Click += new System.EventHandler(this.LogoffToolStripMenuItem_Click);
            // 
            // dBToolStripMenuItem
            // 
            this.dBToolStripMenuItem.Image = global::AusNail.Properties.Resources.database_gear;
            this.dBToolStripMenuItem.Name = "dBToolStripMenuItem";
            this.dBToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dBToolStripMenuItem.Size = new System.Drawing.Size(32, 24);
            this.dBToolStripMenuItem.Click += new System.EventHandler(this.dBToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder.bmp");
            // 
            // dtpFiltDateTemp
            // 
            this.dtpFiltDateTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFiltDateTemp.CustomFormat = "dd/MM/yyyy";
            this.dtpFiltDateTemp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFiltDateTemp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFiltDateTemp.Location = new System.Drawing.Point(1175, 90);
            this.dtpFiltDateTemp.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFiltDateTemp.Name = "dtpFiltDateTemp";
            this.dtpFiltDateTemp.Size = new System.Drawing.Size(153, 22);
            this.dtpFiltDateTemp.TabIndex = 10006;
            this.dtpFiltDateTemp.Value = new System.DateTime(2021, 7, 7, 21, 34, 29, 0);
            this.dtpFiltDateTemp.ValueChanged += new System.EventHandler(this.dtpFiltDateTemp_ValueChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1795, 598);
            this.Controls.Add(this.splCMain);
            this.Controls.Add(this.mnsMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnsMenu;
            this.Name = "frmMain";
            this.Text = "Nail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.splCMain.Panel1.ResumeLayout(false);
            this.splCMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splCMain)).EndInit();
            this.splCMain.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.cMSReload.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).EndInit();
            this.mnsMenu.ResumeLayout(false);
            this.mnsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splCMain;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.MenuStrip mnsMenu;
        private System.Windows.Forms.ToolStripMenuItem zdm;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ContextMenuStrip cMSReload;
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
        private System.Windows.Forms.ToolStripMenuItem TimeKeeping;
        private System.Windows.Forms.ToolStripMenuItem zst;
        private System.Windows.Forms.ToolStripMenuItem ChangePassword;
        private System.Windows.Forms.ToolStripMenuItem formBorToolStripMenuItem;
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
        private System.Windows.Forms.TreeView trTemporaryBill;
        private System.Windows.Forms.TreeView trHistoryBill;
        private System.Windows.Forms.ImageList imageList1;
        private AltoControls.AltoButton butCheckphone;
        private System.Windows.Forms.TextBox txtGenden;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtBilDate;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtBillCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private AltoControls.AltoButton btnPrint;
        private AltoControls.AltoButton btnPay;
        private AltoControls.AltoButton btnSave;
        private System.Windows.Forms.DataGridView dgvService;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deeteToolStripMenuItem;
        private System.Windows.Forms.Label lblTotalAmont;
        private System.Windows.Forms.Label label6;
        private AltoControls.AltoButton btnDel;
        private System.Windows.Forms.ToolStripMenuItem Booking;
        private System.Windows.Forms.Label lblVoucher;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.ToolStripMenuItem tsmHide;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem dBToolStripMenuItem;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalDiscount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFilterDate;
        private System.Windows.Forms.Label lblFilterDate;
        private System.Windows.Forms.DateTimePicker dtpFiltDateTemp;
    }
}

