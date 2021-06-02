namespace AusNail.Process
{
    partial class frmPay
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblReceivable = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVoucherCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateBill = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblCash = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Amount:";
            // 
            // lblReceivable
            // 
            this.lblReceivable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReceivable.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceivable.ForeColor = System.Drawing.Color.Red;
            this.lblReceivable.Location = new System.Drawing.Point(88, 104);
            this.lblReceivable.Name = "lblReceivable";
            this.lblReceivable.Size = new System.Drawing.Size(265, 37);
            this.lblReceivable.TabIndex = 5;
            this.lblReceivable.Text = "0";
            this.lblReceivable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblCash);
            this.groupBox1.Controls.Add(this.lblDiscount);
            this.groupBox1.Controls.Add(this.lblTotalAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.txtDiscount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCard);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtVoucherCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblReceivable);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Booking information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Uighur", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(241, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "VAT included (If any)";
            // 
            // lblDiscount
            // 
            this.lblDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(163, 81);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(190, 20);
            this.lblDiscount.TabIndex = 4;
            this.lblDiscount.Text = "0";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(88, 31);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(265, 26);
            this.lblTotalAmount.TabIndex = 0;
            this.lblTotalAmount.Text = "0";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Receivable:";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(276, 58);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(77, 22);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(88, 81);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(56, 20);
            this.txtDiscount.TabIndex = 3;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            this.txtDiscount.Validated += new System.EventHandler(this.txtDiscount_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Discount:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Cash:";
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(88, 144);
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(147, 20);
            this.txtCard.TabIndex = 6;
            this.txtCard.Text = "0";
            this.txtCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            this.txtCard.Validated += new System.EventHandler(this.txtCard_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Crad:";
            // 
            // txtVoucherCode
            // 
            this.txtVoucherCode.Location = new System.Drawing.Point(88, 59);
            this.txtVoucherCode.Name = "txtVoucherCode";
            this.txtVoucherCode.Size = new System.Drawing.Size(187, 20);
            this.txtVoucherCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Voucher:";
            // 
            // btnCreateBill
            // 
            this.btnCreateBill.Location = new System.Drawing.Point(178, 218);
            this.btnCreateBill.Name = "btnCreateBill";
            this.btnCreateBill.Size = new System.Drawing.Size(204, 39);
            this.btnCreateBill.TabIndex = 2;
            this.btnCreateBill.Text = "Create Bill";
            this.btnCreateBill.UseVisualStyleBackColor = true;
            this.btnCreateBill.Click += new System.EventHandler(this.btnCreateBill_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 230);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(63, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Print Bill";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // lblCash
            // 
            this.lblCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.Location = new System.Drawing.Point(88, 166);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(147, 20);
            this.lblCash.TabIndex = 4;
            this.lblCash.Text = "0";
            this.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 264);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnCreateBill);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pay";
            this.Load += new System.EventHandler(this.frmPay_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReceivable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtVoucherCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCreateBill;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCard;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCash;
    }
}