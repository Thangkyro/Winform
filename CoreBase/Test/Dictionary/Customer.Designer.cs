namespace AusNail.Dictionary
{
    partial class frmCustomer
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
            //this.txtBranchName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            //this.txtLocated = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            //this.txtFacebook = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            //this.txtBranchCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treHistory = new System.Windows.Forms.TreeView();
            this.col_PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DateofBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Postcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkinactive
            // 
            this.chkis_inactive.Location = new System.Drawing.Point(152, 4);
            this.chkis_inactive.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 348);
            this.panel1.Size = new System.Drawing.Size(857, 44);
            // 
            // txtCustomerCode
            // 
            //this.txtBranchName.Location = new System.Drawing.Point(30, 61);
            //this.txtBranchName.Name = "txtCustomerCode";
            //this.txtBranchName.Size = new System.Drawing.Size(186, 20);
            //this.txtBranchName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer code:";
            // 
            // txtCustomerName
            // 
            //this.txtLocated.Location = new System.Drawing.Point(30, 99);
            //this.txtLocated.Name = "txtCustomerName";
            //this.txtLocated.Size = new System.Drawing.Size(186, 20);
            //this.txtLocated.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Customer name:";
            // 
            // txtDateofBirth
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(30, 137);
            this.txtPhoneNumber.Name = "txtDateofBirth";
            this.txtPhoneNumber.Size = new System.Drawing.Size(186, 20);
            this.txtPhoneNumber.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Date of birth:";
            // 
            // txtPostCode
            // 
            //this.txtFacebook.Location = new System.Drawing.Point(30, 175);
            //this.txtFacebook.Name = "txtPostCode";
            //this.txtFacebook.Size = new System.Drawing.Size(186, 20);
            //this.txtFacebook.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Postcode:";
            // 
            // txtPhoneNumber
            // 
            //this.txtBranchCode.Location = new System.Drawing.Point(30, 23);
            //this.txtBranchCode.Name = "txtPhoneNumber";
            //this.txtBranchCode.Size = new System.Drawing.Size(186, 20);
            //this.txtBranchCode.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Phone number:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_PhoneNumber,
            this.col_CustomerCode,
            this.col_CustomerName,
            this.col_DateofBirth,
            this.col_Postcode});
            this.dataGridView1.Location = new System.Drawing.Point(222, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(623, 319);
            this.dataGridView1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treHistory);
            this.groupBox1.Location = new System.Drawing.Point(15, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 141);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "History";
            // 
            // treHistory
            // 
            this.treHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treHistory.Location = new System.Drawing.Point(3, 16);
            this.treHistory.Name = "treHistory";
            this.treHistory.Size = new System.Drawing.Size(194, 122);
            this.treHistory.TabIndex = 8;
            // 
            // col_PhoneNumber
            // 
            this.col_PhoneNumber.HeaderText = "Phone number";
            this.col_PhoneNumber.Name = "col_PhoneNumber";
            this.col_PhoneNumber.Width = 120;
            // 
            // col_CustomerCode
            // 
            this.col_CustomerCode.HeaderText = "Customer code";
            this.col_CustomerCode.Name = "col_CustomerCode";
            this.col_CustomerCode.Width = 120;
            // 
            // col_CustomerName
            // 
            this.col_CustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_CustomerName.HeaderText = "Customer name";
            this.col_CustomerName.Name = "col_CustomerName";
            // 
            // col_DateofBirth
            // 
            this.col_DateofBirth.HeaderText = "Date of birth";
            this.col_DateofBirth.Name = "col_DateofBirth";
            this.col_DateofBirth.Width = 120;
            // 
            // col_Postcode
            // 
            this.col_Postcode.HeaderText = "Postcode";
            this.col_Postcode.Name = "col_Postcode";
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 392);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            //this.Controls.Add(this.txtBranchCode);
            //this.Controls.Add(this.txtFacebook);
            //this.Controls.Add(this.txtPhoneNumber);
            //this.Controls.Add(this.txtLocated);
            //this.Controls.Add(this.txtBranchName);
            this.Name = "frmCustomer";
            this.Text = "Customer";
            //this.Controls.SetChildIndex(this.txtBranchName, 0);
            //this.Controls.SetChildIndex(this.txtLocated, 0);
            //this.Controls.SetChildIndex(this.txtPhoneNumber, 0);
            //this.Controls.SetChildIndex(this.txtFacebook, 0);
            //this.Controls.SetChildIndex(this.txtBranchCode, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.chkis_inactive, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDateofBirth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPostCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DateofBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Postcode;

    }
}