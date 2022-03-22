namespace AusNail.Process
{
    partial class frmBillList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBillList));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new AltoControls.AltoButton();
            this.btnExcel = new AltoControls.AltoButton();
            this.btnExecute = new AltoControls.AltoButton();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalDiscount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalAmont = new System.Windows.Forms.Label();
            this.lblVoucher = new System.Windows.Forms.Label();
            this.lb3 = new System.Windows.Forms.Label();
            this.lblCard = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.lb2 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.btnExecute);
            this.panel1.Controls.Add(this.cboPaymentMethod);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCustomerPhone);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpFrom);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 732);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnClose.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Inactive1 = System.Drawing.Color.Cyan;
            this.btnClose.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnClose.Location = new System.Drawing.Point(233, 231);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 10;
            this.btnClose.Size = new System.Drawing.Size(106, 41);
            this.btnClose.Stroke = false;
            this.btnClose.StrokeColor = System.Drawing.Color.Gray;
            this.btnClose.TabIndex = 10030;
            this.btnClose.Text = "Close";
            this.btnClose.Transparency = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnExcel.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnExcel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExcel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnExcel.ForeColor = System.Drawing.Color.Black;
            this.btnExcel.Inactive1 = System.Drawing.Color.Cyan;
            this.btnExcel.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnExcel.Location = new System.Drawing.Point(121, 231);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Radius = 10;
            this.btnExcel.Size = new System.Drawing.Size(106, 41);
            this.btnExcel.Stroke = false;
            this.btnExcel.StrokeColor = System.Drawing.Color.Gray;
            this.btnExcel.TabIndex = 10029;
            this.btnExcel.Text = "Excel";
            this.btnExcel.Transparency = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnExecute.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnExecute.BackColor = System.Drawing.Color.Transparent;
            this.btnExecute.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExecute.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnExecute.ForeColor = System.Drawing.Color.Black;
            this.btnExecute.Inactive1 = System.Drawing.Color.Cyan;
            this.btnExecute.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnExecute.Location = new System.Drawing.Point(10, 231);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Radius = 10;
            this.btnExecute.Size = new System.Drawing.Size(106, 41);
            this.btnExecute.Stroke = false;
            this.btnExecute.StrokeColor = System.Drawing.Color.Gray;
            this.btnExecute.TabIndex = 10028;
            this.btnExecute.Text = "Preview";
            this.btnExecute.Transparency = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPaymentMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Location = new System.Drawing.Point(138, 165);
            this.cboPaymentMethod.Margin = new System.Windows.Forms.Padding(2);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(201, 33);
            this.cboPaymentMethod.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 10027;
            this.label4.Text = "Payment Method";
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerPhone.Location = new System.Drawing.Point(138, 124);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(201, 31);
            this.txtCustomerPhone.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 10026;
            this.label3.Text = "Customer Phone";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(138, 84);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(2);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(201, 31);
            this.dtpTo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(107, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 10025;
            this.label2.Text = "To";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(138, 45);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(201, 31);
            this.dtpFrom.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(88, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 10024;
            this.label5.Text = "From";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(351, 40);
            this.panel3.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 23);
            this.label11.TabIndex = 15;
            this.label11.Text = "Fillter";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.dgvReport);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(351, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1064, 732);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblTotal);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.lblTotalDiscount);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.lblTotalAmont);
            this.panel5.Controls.Add(this.lblVoucher);
            this.panel5.Controls.Add(this.lb3);
            this.panel5.Controls.Add(this.lblCard);
            this.panel5.Controls.Add(this.lblCash);
            this.panel5.Controls.Add(this.lb2);
            this.panel5.Controls.Add(this.lb1);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 654);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1064, 78);
            this.panel5.TabIndex = 3;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(464, 15);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(162, 44);
            this.lblTotal.TabIndex = 27;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(418, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "Total:";
            // 
            // lblTotalDiscount
            // 
            this.lblTotalDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDiscount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDiscount.Location = new System.Drawing.Point(912, 15);
            this.lblTotalDiscount.Name = "lblTotalDiscount";
            this.lblTotalDiscount.Size = new System.Drawing.Size(142, 44);
            this.lblTotalDiscount.TabIndex = 25;
            this.lblTotalDiscount.Text = "0";
            this.lblTotalDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(841, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 44);
            this.label8.TabIndex = 26;
            this.label8.Text = "Total Discount:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalAmont
            // 
            this.lblTotalAmont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalAmont.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmont.Location = new System.Drawing.Point(697, 15);
            this.lblTotalAmont.Name = "lblTotalAmont";
            this.lblTotalAmont.Size = new System.Drawing.Size(142, 44);
            this.lblTotalAmont.TabIndex = 17;
            this.lblTotalAmont.Text = "0";
            this.lblTotalAmont.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVoucher
            // 
            this.lblVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVoucher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVoucher.Location = new System.Drawing.Point(313, 46);
            this.lblVoucher.Name = "lblVoucher";
            this.lblVoucher.Size = new System.Drawing.Size(105, 20);
            this.lblVoucher.TabIndex = 18;
            this.lblVoucher.Text = "0";
            this.lblVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb3
            // 
            this.lb3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb3.AutoSize = true;
            this.lb3.Location = new System.Drawing.Point(260, 47);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(50, 13);
            this.lb3.TabIndex = 19;
            this.lb3.Text = "Voucher:";
            // 
            // lblCard
            // 
            this.lblCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCard.Location = new System.Drawing.Point(313, 25);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(105, 20);
            this.lblCard.TabIndex = 20;
            this.lblCard.Text = "0";
            this.lblCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCash
            // 
            this.lblCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCash.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCash.Location = new System.Drawing.Point(313, 4);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(105, 20);
            this.lblCash.TabIndex = 21;
            this.lblCash.Text = "0";
            this.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb2
            // 
            this.lb2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb2.AutoSize = true;
            this.lb2.Location = new System.Drawing.Point(260, 26);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(32, 13);
            this.lb2.TabIndex = 22;
            this.lb2.Text = "Card:";
            // 
            // lb1
            // 
            this.lb1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(260, 6);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(34, 13);
            this.lb1.TabIndex = 23;
            this.lb1.Text = "Cash:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(632, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 44);
            this.label6.TabIndex = 24;
            this.label6.Text = "Total Amount:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(3, 42);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(1058, 611);
            this.dgvReport.TabIndex = 2;
            this.dgvReport.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReport_CellClick);
            this.dgvReport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReport_CellContentClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1064, 40);
            this.panel4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "Result";
            // 
            // frmBillList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1415, 732);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBillList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill List";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTotalDiscount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalAmont;
        private System.Windows.Forms.Label lblVoucher;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label label6;
        private AltoControls.AltoButton btnExecute;
        private AltoControls.AltoButton btnExcel;
        private AltoControls.AltoButton btnClose;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label9;
    }
}