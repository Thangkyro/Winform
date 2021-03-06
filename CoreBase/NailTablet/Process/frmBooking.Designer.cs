namespace AusNail.Process
{
    partial class frmBooking
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBooking));
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.btnCancel = new AltoControls.AltoButton();
            this.btnNewCustomer = new AltoControls.AltoButton();
            this.btnNewBooking = new AltoControls.AltoButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvHeader = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grbDetail = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnReLoad = new AltoControls.AltoButton();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblBookingDate = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeader)).BeginInit();
            this.panel2.SuspendLayout();
            this.grbDetail.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(2, 18);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersWidth = 51;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetail.Size = new System.Drawing.Size(947, 288);
            this.dgvDetail.TabIndex = 2;
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnCancel.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Inactive1 = System.Drawing.Color.Cyan;
            this.btnCancel.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnCancel.Location = new System.Drawing.Point(831, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 10;
            this.btnCancel.Size = new System.Drawing.Size(129, 41);
            this.btnCancel.Stroke = false;
            this.btnCancel.StrokeColor = System.Drawing.Color.Gray;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Transparency = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnNewCustomer.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnNewCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnNewCustomer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNewCustomer.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnNewCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnNewCustomer.Inactive1 = System.Drawing.Color.Cyan;
            this.btnNewCustomer.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnNewCustomer.Location = new System.Drawing.Point(689, 12);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Radius = 10;
            this.btnNewCustomer.Size = new System.Drawing.Size(129, 41);
            this.btnNewCustomer.Stroke = false;
            this.btnNewCustomer.StrokeColor = System.Drawing.Color.Gray;
            this.btnNewCustomer.TabIndex = 4;
            this.btnNewCustomer.Text = "New Customer";
            this.btnNewCustomer.Transparency = false;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // btnNewBooking
            // 
            this.btnNewBooking.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnNewBooking.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnNewBooking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewBooking.BackColor = System.Drawing.Color.Transparent;
            this.btnNewBooking.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNewBooking.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnNewBooking.ForeColor = System.Drawing.Color.Black;
            this.btnNewBooking.Inactive1 = System.Drawing.Color.Cyan;
            this.btnNewBooking.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnNewBooking.Location = new System.Drawing.Point(546, 12);
            this.btnNewBooking.Name = "btnNewBooking";
            this.btnNewBooking.Radius = 10;
            this.btnNewBooking.Size = new System.Drawing.Size(129, 41);
            this.btnNewBooking.Stroke = false;
            this.btnNewBooking.StrokeColor = System.Drawing.Color.Gray;
            this.btnNewBooking.TabIndex = 3;
            this.btnNewBooking.Text = "New Booking";
            this.btnNewBooking.Transparency = false;
            this.btnNewBooking.Click += new System.EventHandler(this.btnNewBooking_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.dgvHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panel1.Size = new System.Drawing.Size(969, 141);
            this.panel1.TabIndex = 7;
            // 
            // dgvHeader
            // 
            this.dgvHeader.AllowUserToAddRows = false;
            this.dgvHeader.AllowUserToDeleteRows = false;
            this.dgvHeader.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHeader.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHeader.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHeader.Location = new System.Drawing.Point(8, 8);
            this.dgvHeader.Name = "dgvHeader";
            this.dgvHeader.ReadOnly = true;
            this.dgvHeader.RowHeadersWidth = 51;
            this.dgvHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvHeader.Size = new System.Drawing.Size(953, 125);
            this.dgvHeader.TabIndex = 1;
            this.dgvHeader.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHeader_CellClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.grbDetail);
            this.panel2.Location = new System.Drawing.Point(2, 138);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panel2.Size = new System.Drawing.Size(967, 324);
            this.panel2.TabIndex = 8;
            // 
            // grbDetail
            // 
            this.grbDetail.Controls.Add(this.dgvDetail);
            this.grbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDetail.Location = new System.Drawing.Point(8, 8);
            this.grbDetail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbDetail.Name = "grbDetail";
            this.grbDetail.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbDetail.Size = new System.Drawing.Size(951, 308);
            this.grbDetail.TabIndex = 9;
            this.grbDetail.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.btnReLoad);
            this.panel3.Controls.Add(this.dtpDate);
            this.panel3.Controls.Add(this.lblBookingDate);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnNewCustomer);
            this.panel3.Controls.Add(this.btnNewBooking);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 462);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(969, 67);
            this.panel3.TabIndex = 9;
            // 
            // btnReLoad
            // 
            this.btnReLoad.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnReLoad.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnReLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReLoad.BackColor = System.Drawing.Color.Transparent;
            this.btnReLoad.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnReLoad.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnReLoad.ForeColor = System.Drawing.Color.Black;
            this.btnReLoad.Inactive1 = System.Drawing.Color.Cyan;
            this.btnReLoad.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnReLoad.Location = new System.Drawing.Point(296, 12);
            this.btnReLoad.Name = "btnReLoad";
            this.btnReLoad.Radius = 10;
            this.btnReLoad.Size = new System.Drawing.Size(105, 41);
            this.btnReLoad.Stroke = false;
            this.btnReLoad.StrokeColor = System.Drawing.Color.Gray;
            this.btnReLoad.TabIndex = 9;
            this.btnReLoad.Text = "Re-Load";
            this.btnReLoad.Transparency = false;
            this.btnReLoad.Click += new System.EventHandler(this.btnReLoad_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(122, 15);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(163, 37);
            this.dtpDate.TabIndex = 8;
            this.dtpDate.Value = new System.DateTime(2021, 7, 7, 21, 34, 29, 0);
            // 
            // lblBookingDate
            // 
            this.lblBookingDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBookingDate.AutoSize = true;
            this.lblBookingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingDate.Location = new System.Drawing.Point(16, 23);
            this.lblBookingDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBookingDate.Name = "lblBookingDate";
            this.lblBookingDate.Size = new System.Drawing.Size(110, 20);
            this.lblBookingDate.TabIndex = 7;
            this.lblBookingDate.Text = "Date Booking:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(969, 529);
            this.panel4.TabIndex = 10;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(969, 529);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Booking";
            this.Load += new System.EventHandler(this.frmBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeader)).EndInit();
            this.panel2.ResumeLayout(false);
            this.grbDetail.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetail;
        private AltoControls.AltoButton btnCancel;
        private AltoControls.AltoButton btnNewCustomer;
        private AltoControls.AltoButton btnNewBooking;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvHeader;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblBookingDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox grbDetail;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private AltoControls.AltoButton btnReLoad;
    }
}