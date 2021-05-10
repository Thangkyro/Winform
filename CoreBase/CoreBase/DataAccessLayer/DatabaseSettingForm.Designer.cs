namespace CoreBase.DataAccessLayer
{
    partial class DatabaseSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseSettingForm));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.btnTryConnect = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTryConnect);
            this.panel1.Location = new System.Drawing.Point(0, 126);
            this.panel1.Size = new System.Drawing.Size(426, 39);
            this.panel1.TabIndex = 8;
            this.panel1.Controls.SetChildIndex(this.btnTryConnect, 0);
            // 
            // commandImageList16x16
            // 
            this.commandImageList16x16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("commandImageList16x16.ImageStream")));
            this.commandImageList16x16.Images.SetKeyName(0, "Add.png");
            this.commandImageList16x16.Images.SetKeyName(1, "AddFolder.png");
            this.commandImageList16x16.Images.SetKeyName(2, "ArrowEdit.png");
            this.commandImageList16x16.Images.SetKeyName(3, "CancelSave.png");
            this.commandImageList16x16.Images.SetKeyName(4, "ChangeCode.png");
            this.commandImageList16x16.Images.SetKeyName(5, "Copy.png");
            this.commandImageList16x16.Images.SetKeyName(6, "delete.png");
            this.commandImageList16x16.Images.SetKeyName(7, "DeleteRow.png");
            this.commandImageList16x16.Images.SetKeyName(8, "DeleteRow1.png");
            this.commandImageList16x16.Images.SetKeyName(9, "edit.png");
            this.commandImageList16x16.Images.SetKeyName(10, "Exit.png");
            this.commandImageList16x16.Images.SetKeyName(11, "First.png");
            this.commandImageList16x16.Images.SetKeyName(12, "Folder.png");
            this.commandImageList16x16.Images.SetKeyName(13, "FontConfiguration.png");
            this.commandImageList16x16.Images.SetKeyName(14, "FontConfiguration1.png");
            this.commandImageList16x16.Images.SetKeyName(15, "HelpIc.png");
            this.commandImageList16x16.Images.SetKeyName(16, "Image1.png");
            this.commandImageList16x16.Images.SetKeyName(17, "InsertRowAbove.png");
            this.commandImageList16x16.Images.SetKeyName(18, "InsertRowAbove1.png");
            this.commandImageList16x16.Images.SetKeyName(19, "InsertRowBelow.png");
            this.commandImageList16x16.Images.SetKeyName(20, "Last.png");
            this.commandImageList16x16.Images.SetKeyName(21, "List.png");
            this.commandImageList16x16.Images.SetKeyName(22, "MoveRowDown.png");
            this.commandImageList16x16.Images.SetKeyName(23, "MoveRowUp.png");
            this.commandImageList16x16.Images.SetKeyName(24, "Next.png");
            this.commandImageList16x16.Images.SetKeyName(25, "page_add.png");
            this.commandImageList16x16.Images.SetKeyName(26, "page_delete.png");
            this.commandImageList16x16.Images.SetKeyName(27, "page_edit.png");
            this.commandImageList16x16.Images.SetKeyName(28, "Pin2.ico");
            this.commandImageList16x16.Images.SetKeyName(29, "pin3.ico");
            this.commandImageList16x16.Images.SetKeyName(30, "Previous.png");
            this.commandImageList16x16.Images.SetKeyName(31, "Print.png");
            this.commandImageList16x16.Images.SetKeyName(32, "Refresh.png");
            this.commandImageList16x16.Images.SetKeyName(33, "Row.png");
            this.commandImageList16x16.Images.SetKeyName(34, "Save.png");
            this.commandImageList16x16.Images.SetKeyName(35, "Search.png");
            this.commandImageList16x16.Images.SetKeyName(36, "Shutdown.png");
            this.commandImageList16x16.Images.SetKeyName(37, "Sum.png");
            this.commandImageList16x16.Images.SetKeyName(38, "Sum1.png");
            this.commandImageList16x16.Images.SetKeyName(39, "user_add.png");
            this.commandImageList16x16.Images.SetKeyName(40, "user_delete.png");
            this.commandImageList16x16.Images.SetKeyName(41, "user_edit.png");
            this.commandImageList16x16.Images.SetKeyName(42, "View.png");
            this.commandImageList16x16.Images.SetKeyName(43, "key.png");
            this.commandImageList16x16.Images.SetKeyName(44, "cancel.png");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cơ sở dữ liệu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Máy chủ";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(124, 90);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(152, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(124, 64);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(152, 20);
            this.txtUserName.TabIndex = 5;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(124, 38);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(291, 20);
            this.txtDatabaseName.TabIndex = 3;
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(124, 12);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(291, 20);
            this.txtServerName.TabIndex = 1;
            // 
            // btnTryConnect
            // 
            this.btnTryConnect.Image = global::Zen.Core.Properties.Resources.database_connect;
            this.btnTryConnect.Location = new System.Drawing.Point(307, 7);
            this.btnTryConnect.Name = "btnTryConnect";
            this.btnTryConnect.Size = new System.Drawing.Size(107, 23);
            this.btnTryConnect.TabIndex = 4;
            this.btnTryConnect.Text = "Thử kết nối";
            this.btnTryConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTryConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTryConnect.UseVisualStyleBackColor = true;
            // 
            // DatabaseSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 165);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtDatabaseName);
            this.Controls.Add(this.txtServerName);
            this.Name = "DatabaseSettingForm";
            this.Text = "Database Setting";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.txtServerName, 0);
            this.Controls.SetChildIndex(this.txtDatabaseName, 0);
            this.Controls.SetChildIndex(this.txtUserName, 0);
            this.Controls.SetChildIndex(this.txtPassword, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Button btnTryConnect;
    }
}