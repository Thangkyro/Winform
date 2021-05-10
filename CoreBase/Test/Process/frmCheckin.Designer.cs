namespace AusNail.Process
{
    partial class frmCheckin
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblDistributor = new System.Windows.Forms.Label();
            this.lblDatetime = new System.Windows.Forms.Label();
            this.lblStaff = new System.Windows.Forms.Label();
            this.gridService = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServiceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lbl_R_Total = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.gridRegister = new System.Windows.Forms.DataGridView();
            this.col_R_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_T_ServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_R_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_R_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_R_ServiceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cb_S_ServiceName = new System.Windows.Forms.ComboBox();
            this.cb_S_StaftName = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_C_Postcode = new System.Windows.Forms.TextBox();
            this.txt_C_DateofBirth = new System.Windows.Forms.TextBox();
            this.txt_C_Name = new System.Windows.Forms.TextBox();
            this.txt_C_PhoneNumber = new System.Windows.Forms.TextBox();
            this.btnEditBooking = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numSL = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridService)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegister)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.93395F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.06605F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(863, 469);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbPaymentMethod);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnPay);
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPhoneNumber);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 463);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Checking";
            // 
            // cbPaymentMethod
            // 
            this.cbPaymentMethod.FormattingEnabled = true;
            this.cbPaymentMethod.Location = new System.Drawing.Point(91, 428);
            this.cbPaymentMethod.Name = "cbPaymentMethod";
            this.cbPaymentMethod.Size = new System.Drawing.Size(152, 21);
            this.cbPaymentMethod.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 432);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Payment method:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.lblTotal);
            this.groupBox3.Controls.Add(this.lblDistributor);
            this.groupBox3.Controls.Add(this.lblDatetime);
            this.groupBox3.Controls.Add(this.lblStaff);
            this.groupBox3.Controls.Add(this.gridService);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(6, 93);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(318, 323);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detail";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Service:";
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Location = new System.Drawing.Point(85, 273);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(227, 43);
            this.lblTotal.TabIndex = 4;
            // 
            // lblDistributor
            // 
            this.lblDistributor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDistributor.Location = new System.Drawing.Point(85, 77);
            this.lblDistributor.Name = "lblDistributor";
            this.lblDistributor.Size = new System.Drawing.Size(227, 23);
            this.lblDistributor.TabIndex = 4;
            // 
            // lblDatetime
            // 
            this.lblDatetime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDatetime.Location = new System.Drawing.Point(85, 46);
            this.lblDatetime.Name = "lblDatetime";
            this.lblDatetime.Size = new System.Drawing.Size(227, 23);
            this.lblDatetime.TabIndex = 4;
            // 
            // lblStaff
            // 
            this.lblStaff.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStaff.Location = new System.Drawing.Point(85, 19);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(227, 23);
            this.lblStaff.TabIndex = 4;
            // 
            // gridService
            // 
            this.gridService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colServiceName,
            this.colPrice,
            this.colAmount,
            this.colServiceCode});
            this.gridService.Location = new System.Drawing.Point(25, 118);
            this.gridService.Name = "gridService";
            this.gridService.Size = new System.Drawing.Size(287, 150);
            this.gridService.TabIndex = 3;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "Num";
            this.colSTT.Name = "colSTT";
            this.colSTT.Width = 40;
            // 
            // colServiceName
            // 
            this.colServiceName.HeaderText = "ServiceName";
            this.colServiceName.Name = "colServiceName";
            this.colServiceName.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colServiceCode
            // 
            this.colServiceCode.HeaderText = "ServiceCode";
            this.colServiceCode.Name = "colServiceCode";
            this.colServiceCode.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Distribubor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Staff:";
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(249, 418);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 40);
            this.btnPay.TabIndex = 2;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(249, 41);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 40);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phone number:";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(31, 41);
            this.txtPhoneNumber.Multiline = true;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(212, 40);
            this.txtPhoneNumber.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(338, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 463);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registration";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numSL);
            this.groupBox5.Controls.Add(this.btnRegister);
            this.groupBox5.Controls.Add(this.lbl_R_Total);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.gridRegister);
            this.groupBox5.Controls.Add(this.btnAdd);
            this.groupBox5.Controls.Add(this.cb_S_ServiceName);
            this.groupBox5.Controls.Add(this.cb_S_StaftName);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Location = new System.Drawing.Point(27, 168);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(474, 289);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Booking information";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(342, 243);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(121, 43);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // lbl_R_Total
            // 
            this.lbl_R_Total.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_R_Total.Location = new System.Drawing.Point(59, 243);
            this.lbl_R_Total.Name = "lbl_R_Total";
            this.lbl_R_Total.Size = new System.Drawing.Size(277, 43);
            this.lbl_R_Total.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 260);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "Total:";
            // 
            // gridRegister
            // 
            this.gridRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRegister.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_R_Num,
            this.col_T_ServiceName,
            this.col_R_Price,
            this.col_R_Amount,
            this.col_R_ServiceCode});
            this.gridRegister.Location = new System.Drawing.Point(22, 78);
            this.gridRegister.Name = "gridRegister";
            this.gridRegister.Size = new System.Drawing.Size(441, 163);
            this.gridRegister.TabIndex = 4;
            // 
            // col_R_Num
            // 
            this.col_R_Num.HeaderText = "Num";
            this.col_R_Num.Name = "col_R_Num";
            this.col_R_Num.Width = 40;
            // 
            // col_T_ServiceName
            // 
            this.col_T_ServiceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_T_ServiceName.HeaderText = "ServiceName";
            this.col_T_ServiceName.Name = "col_T_ServiceName";
            this.col_T_ServiceName.ReadOnly = true;
            // 
            // col_R_Price
            // 
            this.col_R_Price.HeaderText = "Price";
            this.col_R_Price.Name = "col_R_Price";
            this.col_R_Price.ReadOnly = true;
            // 
            // col_R_Amount
            // 
            this.col_R_Amount.HeaderText = "Amount";
            this.col_R_Amount.Name = "col_R_Amount";
            this.col_R_Amount.ReadOnly = true;
            // 
            // col_R_ServiceCode
            // 
            this.col_R_ServiceCode.HeaderText = "ServiceCode";
            this.col_R_ServiceCode.Name = "col_R_ServiceCode";
            this.col_R_ServiceCode.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(412, 44);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(52, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // cb_S_ServiceName
            // 
            this.cb_S_ServiceName.FormattingEnabled = true;
            this.cb_S_ServiceName.Location = new System.Drawing.Point(104, 45);
            this.cb_S_ServiceName.Name = "cb_S_ServiceName";
            this.cb_S_ServiceName.Size = new System.Drawing.Size(232, 21);
            this.cb_S_ServiceName.TabIndex = 2;
            // 
            // cb_S_StaftName
            // 
            this.cb_S_StaftName.FormattingEnabled = true;
            this.cb_S_StaftName.Location = new System.Drawing.Point(104, 20);
            this.cb_S_StaftName.Name = "cb_S_StaftName";
            this.cb_S_StaftName.Size = new System.Drawing.Size(359, 21);
            this.cb_S_StaftName.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Service name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Staft name:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_C_Postcode);
            this.groupBox4.Controls.Add(this.txt_C_DateofBirth);
            this.groupBox4.Controls.Add(this.txt_C_Name);
            this.groupBox4.Controls.Add(this.txt_C_PhoneNumber);
            this.groupBox4.Controls.Add(this.btnEditBooking);
            this.groupBox4.Controls.Add(this.btnCreate);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(27, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(474, 143);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Customer information";
            // 
            // txt_C_Postcode
            // 
            this.txt_C_Postcode.Location = new System.Drawing.Point(104, 100);
            this.txt_C_Postcode.Name = "txt_C_Postcode";
            this.txt_C_Postcode.Size = new System.Drawing.Size(226, 20);
            this.txt_C_Postcode.TabIndex = 1;
            // 
            // txt_C_DateofBirth
            // 
            this.txt_C_DateofBirth.Location = new System.Drawing.Point(104, 74);
            this.txt_C_DateofBirth.Name = "txt_C_DateofBirth";
            this.txt_C_DateofBirth.Size = new System.Drawing.Size(226, 20);
            this.txt_C_DateofBirth.TabIndex = 1;
            // 
            // txt_C_Name
            // 
            this.txt_C_Name.Location = new System.Drawing.Point(104, 48);
            this.txt_C_Name.Name = "txt_C_Name";
            this.txt_C_Name.Size = new System.Drawing.Size(226, 20);
            this.txt_C_Name.TabIndex = 1;
            // 
            // txt_C_PhoneNumber
            // 
            this.txt_C_PhoneNumber.Location = new System.Drawing.Point(104, 22);
            this.txt_C_PhoneNumber.Name = "txt_C_PhoneNumber";
            this.txt_C_PhoneNumber.Size = new System.Drawing.Size(226, 20);
            this.txt_C_PhoneNumber.TabIndex = 1;
            // 
            // btnEditBooking
            // 
            this.btnEditBooking.Location = new System.Drawing.Point(336, 74);
            this.btnEditBooking.Name = "btnEditBooking";
            this.btnEditBooking.Size = new System.Drawing.Size(121, 46);
            this.btnEditBooking.TabIndex = 2;
            this.btnEditBooking.Text = "Edit Booking ";
            this.btnEditBooking.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(336, 22);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(121, 46);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create and Register";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Postcode:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Date of birth:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Phone number:";
            // 
            // numSL
            // 
            this.numSL.Location = new System.Drawing.Point(340, 45);
            this.numSL.Name = "numSL";
            this.numSL.Size = new System.Drawing.Size(69, 20);
            this.numSL.TabIndex = 8;
            // 
            // frmCheckin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 493);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmCheckin";
            this.Text = "Checkin";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridService)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegister)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridService;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblDistributor;
        private System.Windows.Forms.Label lblDatetime;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lbl_R_Total;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView gridRegister;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cb_S_ServiceName;
        private System.Windows.Forms.ComboBox cb_S_StaftName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_C_Postcode;
        private System.Windows.Forms.TextBox txt_C_DateofBirth;
        private System.Windows.Forms.TextBox txt_C_Name;
        private System.Windows.Forms.TextBox txt_C_PhoneNumber;
        private System.Windows.Forms.Button btnEditBooking;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServiceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_R_Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_T_ServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_R_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_R_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_R_ServiceCode;
        private System.Windows.Forms.NumericUpDown numSL;
    }
}