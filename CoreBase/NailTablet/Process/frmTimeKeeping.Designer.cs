namespace AusNail.Process
{
    partial class frmTimeKeeping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimeKeeping));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.gridHolidays = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStaffCode = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl_R_Total = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.gridRegister = new System.Windows.Forms.DataGridView();
            this.col_R_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_R_StaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_T_ServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_R_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_R_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.co_B_Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_R_Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_R_ServiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_R_StaffId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_B_StaftName = new System.Windows.Forms.ComboBox();
            this.pbQRCode = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHolidays)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder.bmp");
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = global::AusNail.Properties.Resources.zoom;
            this.btnSearch.Location = new System.Drawing.Point(238, 50);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(115, 49);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 367F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 14);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1228, 653);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtStaffCode);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(359, 645);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Checkin / Checkout";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox6.Controls.Add(this.gridHolidays);
            this.groupBox6.Location = new System.Drawing.Point(8, 512);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(344, 122);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Holidays";
            // 
            // gridHolidays
            // 
            this.gridHolidays.AllowUserToAddRows = false;
            this.gridHolidays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridHolidays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHolidays.Location = new System.Drawing.Point(13, 25);
            this.gridHolidays.Margin = new System.Windows.Forms.Padding(4);
            this.gridHolidays.Name = "gridHolidays";
            this.gridHolidays.RowHeadersVisible = false;
            this.gridHolidays.RowHeadersWidth = 51;
            this.gridHolidays.Size = new System.Drawing.Size(319, 84);
            this.gridHolidays.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.pbQRCode);
            this.groupBox3.Location = new System.Drawing.Point(8, 118);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(344, 387);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Action";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Staff Code:";
            // 
            // txtStaffCode
            // 
            this.txtStaffCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStaffCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffCode.Location = new System.Drawing.Point(41, 50);
            this.txtStaffCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtStaffCode.Multiline = true;
            this.txtStaffCode.Name = "txtStaffCode";
            this.txtStaffCode.Size = new System.Drawing.Size(190, 48);
            this.txtStaffCode.TabIndex = 0;
            this.txtStaffCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.lbl_R_Total);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.gridRegister);
            this.groupBox2.Controls.Add(this.cb_B_StaftName);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(371, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(853, 645);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Infor Time Keeping";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::AusNail.Properties.Resources.Print;
            this.button1.Location = new System.Drawing.Point(564, 568);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 53);
            this.button1.TabIndex = 25;
            this.button1.Text = "Print Temporary Bill";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Image = global::AusNail.Properties.Resources.cancel;
            this.button2.Location = new System.Drawing.Point(750, 568);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 53);
            this.button2.TabIndex = 26;
            this.button2.Text = "Exit";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lbl_R_Total
            // 
            this.lbl_R_Total.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_R_Total.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_R_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_R_Total.ForeColor = System.Drawing.Color.Red;
            this.lbl_R_Total.Location = new System.Drawing.Point(193, 568);
            this.lbl_R_Total.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_R_Total.Name = "lbl_R_Total";
            this.lbl_R_Total.Size = new System.Drawing.Size(363, 53);
            this.lbl_R_Total.TabIndex = 27;
            this.lbl_R_Total.Text = "0";
            this.lbl_R_Total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(79, 589);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 17);
            this.label15.TabIndex = 28;
            this.label15.Text = "Total";
            // 
            // gridRegister
            // 
            this.gridRegister.AllowUserToAddRows = false;
            this.gridRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRegister.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_R_Num,
            this.Col_R_StaffName,
            this.col_T_ServiceName,
            this.ColQuantity,
            this.col_R_Price,
            this.col_R_Amount,
            this.co_B_Discount,
            this.col_R_Note,
            this.col_R_ServiceId,
            this.Col_R_StaffId});
            this.gridRegister.Location = new System.Drawing.Point(8, 93);
            this.gridRegister.Margin = new System.Windows.Forms.Padding(4);
            this.gridRegister.Name = "gridRegister";
            this.gridRegister.RowHeadersWidth = 51;
            this.gridRegister.Size = new System.Drawing.Size(837, 467);
            this.gridRegister.TabIndex = 23;
            // 
            // col_R_Num
            // 
            this.col_R_Num.HeaderText = "Num";
            this.col_R_Num.MinimumWidth = 6;
            this.col_R_Num.Name = "col_R_Num";
            this.col_R_Num.ReadOnly = true;
            this.col_R_Num.Width = 40;
            // 
            // Col_R_StaffName
            // 
            this.Col_R_StaffName.HeaderText = "Staff Name";
            this.Col_R_StaffName.MinimumWidth = 6;
            this.Col_R_StaffName.Name = "Col_R_StaffName";
            this.Col_R_StaffName.ReadOnly = true;
            this.Col_R_StaffName.Width = 150;
            // 
            // col_T_ServiceName
            // 
            this.col_T_ServiceName.HeaderText = "ServiceName";
            this.col_T_ServiceName.MinimumWidth = 6;
            this.col_T_ServiceName.Name = "col_T_ServiceName";
            this.col_T_ServiceName.ReadOnly = true;
            this.col_T_ServiceName.Width = 150;
            // 
            // ColQuantity
            // 
            dataGridViewCellStyle13.Format = "N0";
            dataGridViewCellStyle13.NullValue = "0";
            this.ColQuantity.DefaultCellStyle = dataGridViewCellStyle13;
            this.ColQuantity.FillWeight = 70F;
            this.ColQuantity.HeaderText = "Quantity";
            this.ColQuantity.MinimumWidth = 6;
            this.ColQuantity.Name = "ColQuantity";
            this.ColQuantity.Width = 70;
            // 
            // col_R_Price
            // 
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = "0";
            this.col_R_Price.DefaultCellStyle = dataGridViewCellStyle14;
            this.col_R_Price.HeaderText = "Price";
            this.col_R_Price.MinimumWidth = 6;
            this.col_R_Price.Name = "col_R_Price";
            this.col_R_Price.ReadOnly = true;
            this.col_R_Price.Width = 125;
            // 
            // col_R_Amount
            // 
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = "0";
            this.col_R_Amount.DefaultCellStyle = dataGridViewCellStyle15;
            this.col_R_Amount.HeaderText = "Amount";
            this.col_R_Amount.MinimumWidth = 6;
            this.col_R_Amount.Name = "col_R_Amount";
            this.col_R_Amount.ReadOnly = true;
            this.col_R_Amount.Width = 125;
            // 
            // co_B_Discount
            // 
            this.co_B_Discount.HeaderText = "Discount";
            this.co_B_Discount.MinimumWidth = 6;
            this.co_B_Discount.Name = "co_B_Discount";
            this.co_B_Discount.Width = 125;
            // 
            // col_R_Note
            // 
            this.col_R_Note.HeaderText = "Note";
            this.col_R_Note.MinimumWidth = 6;
            this.col_R_Note.Name = "col_R_Note";
            this.col_R_Note.Width = 150;
            // 
            // col_R_ServiceId
            // 
            this.col_R_ServiceId.HeaderText = "ServiceId";
            this.col_R_ServiceId.MinimumWidth = 6;
            this.col_R_ServiceId.Name = "col_R_ServiceId";
            this.col_R_ServiceId.Visible = false;
            this.col_R_ServiceId.Width = 125;
            // 
            // Col_R_StaffId
            // 
            this.Col_R_StaffId.HeaderText = "Staff Id";
            this.Col_R_StaffId.MinimumWidth = 6;
            this.Col_R_StaffId.Name = "Col_R_StaffId";
            this.Col_R_StaffId.Visible = false;
            this.Col_R_StaffId.Width = 125;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(79, 34);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 17);
            this.label12.TabIndex = 29;
            this.label12.Text = "Branch";
            // 
            // cb_B_StaftName
            // 
            this.cb_B_StaftName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_B_StaftName.FormattingEnabled = true;
            this.cb_B_StaftName.Location = new System.Drawing.Point(140, 31);
            this.cb_B_StaftName.Margin = new System.Windows.Forms.Padding(4);
            this.cb_B_StaftName.Name = "cb_B_StaftName";
            this.cb_B_StaftName.Size = new System.Drawing.Size(650, 24);
            this.cb_B_StaftName.TabIndex = 19;
            // 
            // pbQRCode
            // 
            this.pbQRCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbQRCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbQRCode.Location = new System.Drawing.Point(12, 46);
            this.pbQRCode.Name = "pbQRCode";
            this.pbQRCode.Size = new System.Drawing.Size(324, 266);
            this.pbQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQRCode.TabIndex = 0;
            this.pbQRCode.TabStop = false;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.Location = new System.Drawing.Point(12, 318);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 62);
            this.button3.TabIndex = 1;
            this.button3.Text = "Checkin";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button4.Location = new System.Drawing.Point(191, 318);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 62);
            this.button4.TabIndex = 2;
            this.button4.Text = "Checkout";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(140, 63);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(650, 22);
            this.textBox2.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 66);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "Staft name";
            this.label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // frmTimeKeeping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 681);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmTimeKeeping";
            this.Text = "Time Keeping";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHolidays)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView gridHolidays;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStaffCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbQRCode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_R_Total;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView gridRegister;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_R_Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_R_StaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_T_ServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_R_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_R_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn co_B_Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_R_Note;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_R_ServiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_R_StaffId;
        private System.Windows.Forms.ComboBox cb_B_StaftName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
    }
}