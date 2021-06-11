namespace AusNail.Process
{
    partial class frmServiceAdd
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
            this.dgvService = new System.Windows.Forms.DataGridView();
            this.colServiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServiceName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDel = new System.Windows.Forms.DataGridViewImageColumn();
            this.altoSlidingLabel1 = new AltoControls.AltoSlidingLabel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.btnCancel = new AltoControls.AltoButton();
            this.btnConfirm = new AltoControls.AltoButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvService
            // 
            this.dgvService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvService.BackgroundColor = System.Drawing.Color.White;
            this.dgvService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colServiceID,
            this.colServiceName,
            this.colQuantity,
            this.colPrice,
            this.colAmount,
            this.colDel});
            this.dgvService.Location = new System.Drawing.Point(13, 60);
            this.dgvService.Name = "dgvService";
            this.dgvService.Size = new System.Drawing.Size(492, 203);
            this.dgvService.TabIndex = 0;
            this.dgvService.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvService_CellContentClick);
            // 
            // colServiceID
            // 
            this.colServiceID.HeaderText = "SeviceId";
            this.colServiceID.Name = "colServiceID";
            this.colServiceID.Visible = false;
            // 
            // colServiceName
            // 
            this.colServiceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colServiceName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colServiceName.HeaderText = "Service";
            this.colServiceName.Name = "colServiceName";
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Price";
            this.colPrice.Name = "colPrice";
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colDel
            // 
            this.colDel.HeaderText = "";
            this.colDel.Image = global::AusNail.Properties.Resources.cancel;
            this.colDel.Name = "colDel";
            this.colDel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDel.ToolTipText = "Delete";
            this.colDel.Width = 20;
            // 
            // altoSlidingLabel1
            // 
            this.altoSlidingLabel1.Location = new System.Drawing.Point(13, 22);
            this.altoSlidingLabel1.Name = "altoSlidingLabel1";
            this.altoSlidingLabel1.Size = new System.Drawing.Size(64, 23);
            this.altoSlidingLabel1.Slide = false;
            this.altoSlidingLabel1.TabIndex = 1;
            this.altoSlidingLabel1.Text = "Customer:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(73, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(254, 20);
            this.txtName.TabIndex = 2;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhoneNumber.Enabled = false;
            this.txtPhoneNumber.Location = new System.Drawing.Point(333, 24);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(171, 20);
            this.txtPhoneNumber.TabIndex = 2;
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
            this.btnCancel.Location = new System.Drawing.Point(410, 277);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 10;
            this.btnCancel.Size = new System.Drawing.Size(96, 30);
            this.btnCancel.Stroke = false;
            this.btnCancel.StrokeColor = System.Drawing.Color.Gray;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Transparency = false;
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
            this.btnConfirm.Location = new System.Drawing.Point(308, 277);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Radius = 10;
            this.btnConfirm.Size = new System.Drawing.Size(96, 30);
            this.btnConfirm.Stroke = false;
            this.btnConfirm.StrokeColor = System.Drawing.Color.Gray;
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Confirm ";
            this.btnConfirm.Transparency = false;
            // 
            // frmServiceAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(516, 322);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.altoSlidingLabel1);
            this.Controls.Add(this.dgvService);
            this.Name = "frmServiceAdd";
            this.Text = "Service";
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvService;
        private AltoControls.AltoSlidingLabel altoSlidingLabel1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private AltoControls.AltoButton btnCancel;
        private AltoControls.AltoButton btnConfirm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServiceID;
        private System.Windows.Forms.DataGridViewComboBoxColumn colServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewImageColumn colDel;
    }
}