namespace AusNail.Process
{
    partial class frmLedgerAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLedgerAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblCheckedCash = new System.Windows.Forms.Label();
            this.CheckedCash = new System.Windows.Forms.Label();
            this.lblRevenueCash = new System.Windows.Forms.Label();
            this.lblCashIn = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkLocked = new System.Windows.Forms.CheckBox();
            this.lblRenenueVoucher = new System.Windows.Forms.Label();
            this.lblRevenueBank = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCashOut = new System.Windows.Forms.TextBox();
            this.txtExpenseCash = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new AltoControls.AltoButton();
            this.btnConfirm = new AltoControls.AltoButton();
            this.btnRefresh = new AltoControls.AltoButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Revenue Bank";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.lblCheckedCash);
            this.groupBox1.Controls.Add(this.CheckedCash);
            this.groupBox1.Controls.Add(this.lblRevenueCash);
            this.groupBox1.Controls.Add(this.lblCashIn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.chkLocked);
            this.groupBox1.Controls.Add(this.lblRenenueVoucher);
            this.groupBox1.Controls.Add(this.lblRevenueBank);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCashOut);
            this.groupBox1.Controls.Add(this.txtExpenseCash);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 311);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ledger information";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.CalendarMonthBackground = System.Drawing.Color.Gray;
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(106, 20);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(201, 29);
            this.dtpDate.TabIndex = 0;
            // 
            // lblCheckedCash
            // 
            this.lblCheckedCash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckedCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCheckedCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckedCash.Location = new System.Drawing.Point(106, 250);
            this.lblCheckedCash.Name = "lblCheckedCash";
            this.lblCheckedCash.Size = new System.Drawing.Size(315, 26);
            this.lblCheckedCash.TabIndex = 15;
            this.lblCheckedCash.Text = "0";
            this.lblCheckedCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckedCash
            // 
            this.CheckedCash.AutoSize = true;
            this.CheckedCash.Location = new System.Drawing.Point(10, 259);
            this.CheckedCash.Name = "CheckedCash";
            this.CheckedCash.Size = new System.Drawing.Size(77, 13);
            this.CheckedCash.TabIndex = 14;
            this.CheckedCash.Text = "Checked Cash";
            // 
            // lblRevenueCash
            // 
            this.lblRevenueCash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRevenueCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRevenueCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueCash.Location = new System.Drawing.Point(106, 89);
            this.lblRevenueCash.Name = "lblRevenueCash";
            this.lblRevenueCash.Size = new System.Drawing.Size(315, 26);
            this.lblRevenueCash.TabIndex = 12;
            this.lblRevenueCash.Text = "0";
            this.lblRevenueCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCashIn
            // 
            this.lblCashIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCashIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCashIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashIn.Location = new System.Drawing.Point(106, 58);
            this.lblCashIn.Name = "lblCashIn";
            this.lblCashIn.Size = new System.Drawing.Size(315, 26);
            this.lblCashIn.TabIndex = 13;
            this.lblCashIn.Text = "0";
            this.lblCashIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Revenue Cash";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Cash In";
            // 
            // chkLocked
            // 
            this.chkLocked.AutoSize = true;
            this.chkLocked.Location = new System.Drawing.Point(106, 281);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(15, 14);
            this.chkLocked.TabIndex = 3;
            this.chkLocked.UseVisualStyleBackColor = true;
            this.chkLocked.CheckedChanged += new System.EventHandler(this.chkCompire_CheckedChanged);
            // 
            // lblRenenueVoucher
            // 
            this.lblRenenueVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRenenueVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRenenueVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenenueVoucher.Location = new System.Drawing.Point(106, 151);
            this.lblRenenueVoucher.Name = "lblRenenueVoucher";
            this.lblRenenueVoucher.Size = new System.Drawing.Size(315, 26);
            this.lblRenenueVoucher.TabIndex = 4;
            this.lblRenenueVoucher.Text = "0";
            this.lblRenenueVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRevenueBank
            // 
            this.lblRevenueBank.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRevenueBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRevenueBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueBank.Location = new System.Drawing.Point(106, 120);
            this.lblRevenueBank.Name = "lblRevenueBank";
            this.lblRevenueBank.Size = new System.Drawing.Size(315, 26);
            this.lblRevenueBank.TabIndex = 4;
            this.lblRevenueBank.Text = "0";
            this.lblRevenueBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Locked";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Cash Out";
            // 
            // txtCashOut
            // 
            this.txtCashOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCashOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashOut.Location = new System.Drawing.Point(106, 216);
            this.txtCashOut.Name = "txtCashOut";
            this.txtCashOut.Size = new System.Drawing.Size(315, 29);
            this.txtCashOut.TabIndex = 2;
            this.txtCashOut.Text = "0";
            this.txtCashOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCashOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCard_KeyDown);
            this.txtCashOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCash_KeyPress);
            this.txtCashOut.Validated += new System.EventHandler(this.txtCash_Validated);
            // 
            // txtExpenseCash
            // 
            this.txtExpenseCash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpenseCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpenseCash.Location = new System.Drawing.Point(106, 182);
            this.txtExpenseCash.Name = "txtExpenseCash";
            this.txtExpenseCash.Size = new System.Drawing.Size(315, 29);
            this.txtExpenseCash.TabIndex = 1;
            this.txtExpenseCash.Text = "0";
            this.txtExpenseCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExpenseCash.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCard_KeyDown);
            this.txtExpenseCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCard_KeyPress);
            this.txtExpenseCash.Validated += new System.EventHandler(this.txtCard_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Renenue Voucher";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Expense Cash";
            // 
            // btnCancel
            // 
            this.btnCancel.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnCancel.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Inactive1 = System.Drawing.Color.Cyan;
            this.btnCancel.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnCancel.Location = new System.Drawing.Point(340, 332);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 10;
            this.btnCancel.Size = new System.Drawing.Size(96, 30);
            this.btnCancel.Stroke = false;
            this.btnCancel.StrokeColor = System.Drawing.Color.Gray;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Transparency = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnConfirm.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.Black;
            this.btnConfirm.Inactive1 = System.Drawing.Color.Cyan;
            this.btnConfirm.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnConfirm.Location = new System.Drawing.Point(238, 332);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Radius = 10;
            this.btnConfirm.Size = new System.Drawing.Size(96, 30);
            this.btnConfirm.Stroke = false;
            this.btnConfirm.StrokeColor = System.Drawing.Color.Gray;
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Confirm ";
            this.btnConfirm.Transparency = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnCreateBill_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnRefresh.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRefresh.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Inactive1 = System.Drawing.Color.Cyan;
            this.btnRefresh.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnRefresh.Location = new System.Drawing.Point(312, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Radius = 10;
            this.btnRefresh.Size = new System.Drawing.Size(94, 30);
            this.btnRefresh.Stroke = false;
            this.btnRefresh.StrokeColor = System.Drawing.Color.Gray;
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Transparency = false;
            // 
            // frmLedgerAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(453, 375);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLedgerAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Ledger";
            this.Load += new System.EventHandler(this.frmPay_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRevenueBank;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtExpenseCash;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkLocked;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCashOut;
        private AltoControls.AltoButton btnCancel;
        private AltoControls.AltoButton btnConfirm;
        private System.Windows.Forms.Label lblRenenueVoucher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCheckedCash;
        private System.Windows.Forms.Label CheckedCash;
        private System.Windows.Forms.Label lblRevenueCash;
        private System.Windows.Forms.Label lblCashIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private AltoControls.AltoButton btnRefresh;
    }
}