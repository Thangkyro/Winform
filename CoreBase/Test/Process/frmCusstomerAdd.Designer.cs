namespace AusNail.Process
{
    partial class frmCusstomerAdd
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
            this.radMale = new System.Windows.Forms.RadioButton();
            this.radFemale = new System.Windows.Forms.RadioButton();
            this.radOrder = new System.Windows.Forms.RadioButton();
            this.btnCancel = new AltoControls.AltoButton();
            this.btnConfirm = new AltoControls.AltoButton();
            this.altoSlidingLabel5 = new AltoControls.AltoSlidingLabel();
            this.altoSlidingLabel4 = new AltoControls.AltoSlidingLabel();
            this.altoSlidingLabel3 = new AltoControls.AltoSlidingLabel();
            this.altoSlidingLabel2 = new AltoControls.AltoSlidingLabel();
            this.altoSlidingLabel1 = new AltoControls.AltoSlidingLabel();
            this.txtPhoneNum = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.txtDateofBirth = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // radMale
            // 
            this.radMale.AutoSize = true;
            this.radMale.Checked = true;
            this.radMale.Location = new System.Drawing.Point(139, 138);
            this.radMale.Name = "radMale";
            this.radMale.Size = new System.Drawing.Size(48, 17);
            this.radMale.TabIndex = 9;
            this.radMale.TabStop = true;
            this.radMale.Text = "Male";
            this.radMale.UseVisualStyleBackColor = true;
            // 
            // radFemale
            // 
            this.radFemale.AutoSize = true;
            this.radFemale.Location = new System.Drawing.Point(139, 157);
            this.radFemale.Name = "radFemale";
            this.radFemale.Size = new System.Drawing.Size(59, 17);
            this.radFemale.TabIndex = 10;
            this.radFemale.Text = "Female";
            this.radFemale.UseVisualStyleBackColor = true;
            // 
            // radOrder
            // 
            this.radOrder.AutoSize = true;
            this.radOrder.Location = new System.Drawing.Point(139, 177);
            this.radOrder.Name = "radOrder";
            this.radOrder.Size = new System.Drawing.Size(51, 17);
            this.radOrder.TabIndex = 11;
            this.radOrder.Text = "Order";
            this.radOrder.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnCancel.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Inactive1 = System.Drawing.Color.Cyan;
            this.btnCancel.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnCancel.Location = new System.Drawing.Point(242, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 10;
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.Stroke = false;
            this.btnCancel.StrokeColor = System.Drawing.Color.Gray;
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Transparency = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnConfirm.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.Black;
            this.btnConfirm.Inactive1 = System.Drawing.Color.Cyan;
            this.btnConfirm.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnConfirm.Location = new System.Drawing.Point(112, 208);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Radius = 10;
            this.btnConfirm.Size = new System.Drawing.Size(120, 30);
            this.btnConfirm.Stroke = false;
            this.btnConfirm.StrokeColor = System.Drawing.Color.Gray;
            this.btnConfirm.TabIndex = 12;
            this.btnConfirm.Text = "Confirm ";
            this.btnConfirm.Transparency = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // altoSlidingLabel5
            // 
            this.altoSlidingLabel5.Location = new System.Drawing.Point(12, 89);
            this.altoSlidingLabel5.Name = "altoSlidingLabel5";
            this.altoSlidingLabel5.Size = new System.Drawing.Size(98, 20);
            this.altoSlidingLabel5.Slide = false;
            this.altoSlidingLabel5.TabIndex = 3;
            this.altoSlidingLabel5.Text = "Postcode:";
            // 
            // altoSlidingLabel4
            // 
            this.altoSlidingLabel4.Location = new System.Drawing.Point(12, 62);
            this.altoSlidingLabel4.Name = "altoSlidingLabel4";
            this.altoSlidingLabel4.Size = new System.Drawing.Size(98, 20);
            this.altoSlidingLabel4.Slide = false;
            this.altoSlidingLabel4.TabIndex = 2;
            this.altoSlidingLabel4.Text = "Date of birth:";
            // 
            // altoSlidingLabel3
            // 
            this.altoSlidingLabel3.Location = new System.Drawing.Point(110, 113);
            this.altoSlidingLabel3.Name = "altoSlidingLabel3";
            this.altoSlidingLabel3.Size = new System.Drawing.Size(98, 20);
            this.altoSlidingLabel3.Slide = false;
            this.altoSlidingLabel3.TabIndex = 8;
            this.altoSlidingLabel3.Text = "Gender:";
            // 
            // altoSlidingLabel2
            // 
            this.altoSlidingLabel2.Location = new System.Drawing.Point(12, 35);
            this.altoSlidingLabel2.Name = "altoSlidingLabel2";
            this.altoSlidingLabel2.Size = new System.Drawing.Size(98, 20);
            this.altoSlidingLabel2.Slide = false;
            this.altoSlidingLabel2.TabIndex = 1;
            this.altoSlidingLabel2.Text = "Name:";
            // 
            // altoSlidingLabel1
            // 
            this.altoSlidingLabel1.Location = new System.Drawing.Point(12, 10);
            this.altoSlidingLabel1.Name = "altoSlidingLabel1";
            this.altoSlidingLabel1.Size = new System.Drawing.Size(98, 20);
            this.altoSlidingLabel1.Slide = false;
            this.altoSlidingLabel1.TabIndex = 0;
            this.altoSlidingLabel1.Text = "Phone number:";
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Location = new System.Drawing.Point(110, 10);
            this.txtPhoneNum.Multiline = true;
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Size = new System.Drawing.Size(252, 20);
            this.txtPhoneNum.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(110, 35);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(252, 20);
            this.txtName.TabIndex = 5;
            // 
            // txtPostcode
            // 
            this.txtPostcode.Location = new System.Drawing.Point(110, 89);
            this.txtPostcode.Multiline = true;
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(252, 20);
            this.txtPostcode.TabIndex = 7;
            // 
            // txtDateofBirth
            // 
            this.txtDateofBirth.Location = new System.Drawing.Point(110, 62);
            this.txtDateofBirth.Mask = "00/00/0000";
            this.txtDateofBirth.Name = "txtDateofBirth";
            this.txtDateofBirth.Size = new System.Drawing.Size(252, 20);
            this.txtDateofBirth.TabIndex = 6;
            this.txtDateofBirth.ValidatingType = typeof(System.DateTime);
            // 
            // frmCusstomerAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(374, 256);
            this.Controls.Add(this.txtDateofBirth);
            this.Controls.Add(this.txtPostcode);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPhoneNum);
            this.Controls.Add(this.radOrder);
            this.Controls.Add(this.radFemale);
            this.Controls.Add(this.radMale);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.altoSlidingLabel5);
            this.Controls.Add(this.altoSlidingLabel4);
            this.Controls.Add(this.altoSlidingLabel3);
            this.Controls.Add(this.altoSlidingLabel2);
            this.Controls.Add(this.altoSlidingLabel1);
            this.MaximizeBox = false;
            this.Name = "frmCusstomerAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AltoControls.AltoSlidingLabel altoSlidingLabel1;
        private AltoControls.AltoSlidingLabel altoSlidingLabel2;
        private AltoControls.AltoSlidingLabel altoSlidingLabel3;
        private AltoControls.AltoSlidingLabel altoSlidingLabel4;
        private AltoControls.AltoSlidingLabel altoSlidingLabel5;
        private AltoControls.AltoButton btnCancel;
        private AltoControls.AltoButton btnConfirm;
        private System.Windows.Forms.RadioButton radMale;
        private System.Windows.Forms.RadioButton radFemale;
        private System.Windows.Forms.RadioButton radOrder;
        private System.Windows.Forms.TextBox txtPhoneNum;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPostcode;
        private System.Windows.Forms.MaskedTextBox txtDateofBirth;
    }
}