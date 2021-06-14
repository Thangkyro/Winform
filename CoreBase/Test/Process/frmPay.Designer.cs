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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCompire = new System.Windows.Forms.CheckBox();
            this.dgvVoucher = new System.Windows.Forms.DataGridView();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new AltoControls.AltoButton();
            this.btnConfirm = new AltoControls.AltoButton();
            this.radCard = new System.Windows.Forms.RadioButton();
            this.radCash = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Amount:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radCash);
            this.groupBox1.Controls.Add(this.radCard);
            this.groupBox1.Controls.Add(this.chkCompire);
            this.groupBox1.Controls.Add(this.dgvVoucher);
            this.groupBox1.Controls.Add(this.lblTotalAmount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCash);
            this.groupBox1.Controls.Add(this.txtCard);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 304);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Booking information";
            // 
            // chkCompire
            // 
            this.chkCompire.AutoSize = true;
            this.chkCompire.Location = new System.Drawing.Point(88, 93);
            this.chkCompire.Name = "chkCompire";
            this.chkCompire.Size = new System.Drawing.Size(15, 14);
            this.chkCompire.TabIndex = 12;
            this.chkCompire.UseVisualStyleBackColor = true;
            this.chkCompire.CheckedChanged += new System.EventHandler(this.chkCompire_CheckedChanged);
            // 
            // dgvVoucher
            // 
            this.dgvVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVoucher.BackgroundColor = System.Drawing.Color.White;
            this.dgvVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVoucher.Location = new System.Drawing.Point(19, 114);
            this.dgvVoucher.Name = "dgvVoucher";
            this.dgvVoucher.Size = new System.Drawing.Size(401, 184);
            this.dgvVoucher.TabIndex = 11;
            this.dgvVoucher.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVoucher_CellContentClick);
            this.dgvVoucher.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVoucher_CellEndEdit);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(88, 18);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(332, 26);
            this.lblTotalAmount.TabIndex = 0;
            this.lblTotalAmount.Text = "0";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Compire:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Cash:";
            // 
            // txtCash
            // 
            this.txtCash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCash.Location = new System.Drawing.Point(105, 68);
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(315, 20);
            this.txtCash.TabIndex = 6;
            this.txtCash.Text = "0";
            this.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCash_KeyPress);
            this.txtCash.Validated += new System.EventHandler(this.txtCash_Validated);
            // 
            // txtCard
            // 
            this.txtCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCard.Location = new System.Drawing.Point(105, 47);
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(315, 20);
            this.txtCard.TabIndex = 6;
            this.txtCard.Text = "0";
            this.txtCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCard_KeyPress);
            this.txtCard.Validated += new System.EventHandler(this.txtCard_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Card:";
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
            this.btnCancel.Location = new System.Drawing.Point(340, 325);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 10;
            this.btnCancel.Size = new System.Drawing.Size(96, 30);
            this.btnCancel.Stroke = false;
            this.btnCancel.StrokeColor = System.Drawing.Color.Gray;
            this.btnCancel.TabIndex = 7;
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
            this.btnConfirm.Location = new System.Drawing.Point(238, 325);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Radius = 10;
            this.btnConfirm.Size = new System.Drawing.Size(96, 30);
            this.btnConfirm.Stroke = false;
            this.btnConfirm.StrokeColor = System.Drawing.Color.Gray;
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "Confirm ";
            this.btnConfirm.Transparency = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnCreateBill_Click);
            // 
            // radCard
            // 
            this.radCard.AutoSize = true;
            this.radCard.Checked = true;
            this.radCard.Location = new System.Drawing.Point(88, 51);
            this.radCard.Name = "radCard";
            this.radCard.Size = new System.Drawing.Size(14, 13);
            this.radCard.TabIndex = 13;
            this.radCard.TabStop = true;
            this.radCard.UseVisualStyleBackColor = true;
            this.radCard.CheckedChanged += new System.EventHandler(this.radCard_CheckedChanged);
            // 
            // radCash
            // 
            this.radCash.AutoSize = true;
            this.radCash.Location = new System.Drawing.Point(88, 71);
            this.radCash.Name = "radCash";
            this.radCash.Size = new System.Drawing.Size(14, 13);
            this.radCash.TabIndex = 13;
            this.radCash.UseVisualStyleBackColor = true;
            this.radCash.CheckedChanged += new System.EventHandler(this.radCash_CheckedChanged);
            // 
            // frmPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(453, 368);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pay";
            this.Load += new System.EventHandler(this.frmPay_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCard;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvVoucher;
        private System.Windows.Forms.CheckBox chkCompire;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCash;
        private AltoControls.AltoButton btnCancel;
        private AltoControls.AltoButton btnConfirm;
        private System.Windows.Forms.RadioButton radCash;
        private System.Windows.Forms.RadioButton radCard;
    }
}