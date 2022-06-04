namespace Nail.Core
{
    partial class UDateTimePicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtPicker
            // 
            this.dtPicker.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPicker.Location = new System.Drawing.Point(2, 1);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(144, 20);
            this.dtPicker.TabIndex = 0;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(147, 1);
            this.txtDate.MaxLength = 10;
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(72, 20);
            this.txtDate.TabIndex = 1;
            this.txtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDate_KeyPress);
            this.txtDate.Validated += new System.EventHandler(this.txtDate_Validated);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(220, 1);
            this.txtTime.MaxLength = 8;
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(60, 20);
            this.txtTime.TabIndex = 2;
            this.txtTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTime_KeyPress);
            this.txtTime.Validated += new System.EventHandler(this.txtDate_Validated);
            // 
            // UDateTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.dtPicker);
            this.Name = "UDateTimePicker";
            this.Size = new System.Drawing.Size(282, 23);
            this.Load += new System.EventHandler(this.UDateTimePicker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtPicker;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtTime;
    }
}
