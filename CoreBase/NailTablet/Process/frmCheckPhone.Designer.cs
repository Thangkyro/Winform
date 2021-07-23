namespace AusNail.Process
{
    partial class frmCheckPhone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckPhone));
            this.btnConfirm = new AltoControls.AltoButton();
            this.altoSlidingLabel1 = new AltoControls.AltoSlidingLabel();
            this.btnCancel = new AltoControls.AltoButton();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lbSize = new System.Windows.Forms.Label();
            this.pnSDT = new System.Windows.Forms.Panel();
            this.btn9 = new AltoControls.AltoButton();
            this.btn6 = new AltoControls.AltoButton();
            this.btn3 = new AltoControls.AltoButton();
            this.btn0 = new AltoControls.AltoButton();
            this.btn8 = new AltoControls.AltoButton();
            this.btn7 = new AltoControls.AltoButton();
            this.btn5 = new AltoControls.AltoButton();
            this.btn4 = new AltoControls.AltoButton();
            this.btn2 = new AltoControls.AltoButton();
            this.btn1 = new AltoControls.AltoButton();
            this.btnDel = new AltoControls.AltoButton();
            this.altoButton2 = new AltoControls.AltoButton();
            this.pnSDT.SuspendLayout();
            this.SuspendLayout();
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
            this.btnConfirm.Location = new System.Drawing.Point(129, 311);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Radius = 10;
            this.btnConfirm.Size = new System.Drawing.Size(96, 30);
            this.btnConfirm.Stroke = false;
            this.btnConfirm.StrokeColor = System.Drawing.Color.Gray;
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Confirm ";
            this.btnConfirm.Transparency = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // altoSlidingLabel1
            // 
            this.altoSlidingLabel1.Location = new System.Drawing.Point(21, 25);
            this.altoSlidingLabel1.Name = "altoSlidingLabel1";
            this.altoSlidingLabel1.Size = new System.Drawing.Size(102, 36);
            this.altoSlidingLabel1.Slide = false;
            this.altoSlidingLabel1.TabIndex = 0;
            this.altoSlidingLabel1.Text = "Customer Phone:";
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
            this.btnCancel.Location = new System.Drawing.Point(231, 311);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 10;
            this.btnCancel.Size = new System.Drawing.Size(96, 30);
            this.btnCancel.Stroke = false;
            this.btnCancel.StrokeColor = System.Drawing.Color.Gray;
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Transparency = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(129, 25);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(198, 36);
            this.txtPhone.TabIndex = 1;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbSize.Location = new System.Drawing.Point(2, 0);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(19, 13);
            this.lbSize.TabIndex = 4;
            this.lbSize.Text = ">>";
            this.lbSize.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnSDT
            // 
            this.pnSDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnSDT.Controls.Add(this.btn9);
            this.pnSDT.Controls.Add(this.btn6);
            this.pnSDT.Controls.Add(this.btn3);
            this.pnSDT.Controls.Add(this.altoButton2);
            this.pnSDT.Controls.Add(this.btnDel);
            this.pnSDT.Controls.Add(this.btn0);
            this.pnSDT.Controls.Add(this.btn8);
            this.pnSDT.Controls.Add(this.btn7);
            this.pnSDT.Controls.Add(this.btn5);
            this.pnSDT.Controls.Add(this.btn4);
            this.pnSDT.Controls.Add(this.btn2);
            this.pnSDT.Controls.Add(this.btn1);
            this.pnSDT.Location = new System.Drawing.Point(129, 67);
            this.pnSDT.Name = "pnSDT";
            this.pnSDT.Size = new System.Drawing.Size(198, 238);
            this.pnSDT.TabIndex = 5;
            // 
            // btn9
            // 
            this.btn9.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btn9.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btn9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn9.BackColor = System.Drawing.Color.Transparent;
            this.btn9.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn9.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.ForeColor = System.Drawing.Color.Black;
            this.btn9.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn9.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn9.Location = new System.Drawing.Point(132, 123);
            this.btn9.Name = "btn9";
            this.btn9.Radius = 10;
            this.btn9.Size = new System.Drawing.Size(55, 45);
            this.btn9.Stroke = false;
            this.btn9.StrokeColor = System.Drawing.Color.Gray;
            this.btn9.TabIndex = 3;
            this.btn9.Text = "9";
            this.btn9.Transparency = false;
            this.btn9.Click += new System.EventHandler(this.btn9_Click);
            // 
            // btn6
            // 
            this.btn6.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btn6.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btn6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn6.BackColor = System.Drawing.Color.Transparent;
            this.btn6.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn6.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.ForeColor = System.Drawing.Color.Black;
            this.btn6.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn6.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn6.Location = new System.Drawing.Point(132, 72);
            this.btn6.Name = "btn6";
            this.btn6.Radius = 10;
            this.btn6.Size = new System.Drawing.Size(55, 45);
            this.btn6.Stroke = false;
            this.btn6.StrokeColor = System.Drawing.Color.Gray;
            this.btn6.TabIndex = 3;
            this.btn6.Text = "6";
            this.btn6.Transparency = false;
            this.btn6.Click += new System.EventHandler(this.btn6_Click);
            // 
            // btn3
            // 
            this.btn3.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btn3.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btn3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn3.BackColor = System.Drawing.Color.Transparent;
            this.btn3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn3.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.ForeColor = System.Drawing.Color.Black;
            this.btn3.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn3.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn3.Location = new System.Drawing.Point(132, 21);
            this.btn3.Name = "btn3";
            this.btn3.Radius = 10;
            this.btn3.Size = new System.Drawing.Size(55, 45);
            this.btn3.Stroke = false;
            this.btn3.StrokeColor = System.Drawing.Color.Gray;
            this.btn3.TabIndex = 3;
            this.btn3.Text = "3";
            this.btn3.Transparency = false;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn0
            // 
            this.btn0.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btn0.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btn0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn0.BackColor = System.Drawing.Color.Transparent;
            this.btn0.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn0.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.ForeColor = System.Drawing.Color.Black;
            this.btn0.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn0.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn0.Location = new System.Drawing.Point(70, 174);
            this.btn0.Name = "btn0";
            this.btn0.Radius = 10;
            this.btn0.Size = new System.Drawing.Size(55, 45);
            this.btn0.Stroke = false;
            this.btn0.StrokeColor = System.Drawing.Color.Gray;
            this.btn0.TabIndex = 3;
            this.btn0.Text = "0";
            this.btn0.Transparency = false;
            this.btn0.Click += new System.EventHandler(this.btn0_Click);
            // 
            // btn8
            // 
            this.btn8.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btn8.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btn8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn8.BackColor = System.Drawing.Color.Transparent;
            this.btn8.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn8.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.ForeColor = System.Drawing.Color.Black;
            this.btn8.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn8.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn8.Location = new System.Drawing.Point(70, 123);
            this.btn8.Name = "btn8";
            this.btn8.Radius = 10;
            this.btn8.Size = new System.Drawing.Size(55, 45);
            this.btn8.Stroke = false;
            this.btn8.StrokeColor = System.Drawing.Color.Gray;
            this.btn8.TabIndex = 3;
            this.btn8.Text = "8";
            this.btn8.Transparency = false;
            this.btn8.Click += new System.EventHandler(this.btn8_Click);
            // 
            // btn7
            // 
            this.btn7.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btn7.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btn7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn7.BackColor = System.Drawing.Color.Transparent;
            this.btn7.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn7.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.ForeColor = System.Drawing.Color.Black;
            this.btn7.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn7.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn7.Location = new System.Drawing.Point(9, 123);
            this.btn7.Name = "btn7";
            this.btn7.Radius = 10;
            this.btn7.Size = new System.Drawing.Size(55, 45);
            this.btn7.Stroke = false;
            this.btn7.StrokeColor = System.Drawing.Color.Gray;
            this.btn7.TabIndex = 3;
            this.btn7.Text = "7";
            this.btn7.Transparency = false;
            this.btn7.Click += new System.EventHandler(this.btn7_Click);
            // 
            // btn5
            // 
            this.btn5.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btn5.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btn5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn5.BackColor = System.Drawing.Color.Transparent;
            this.btn5.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn5.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.ForeColor = System.Drawing.Color.Black;
            this.btn5.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn5.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn5.Location = new System.Drawing.Point(70, 72);
            this.btn5.Name = "btn5";
            this.btn5.Radius = 10;
            this.btn5.Size = new System.Drawing.Size(55, 45);
            this.btn5.Stroke = false;
            this.btn5.StrokeColor = System.Drawing.Color.Gray;
            this.btn5.TabIndex = 3;
            this.btn5.Text = "5";
            this.btn5.Transparency = false;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn4
            // 
            this.btn4.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btn4.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btn4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn4.BackColor = System.Drawing.Color.Transparent;
            this.btn4.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn4.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.ForeColor = System.Drawing.Color.Black;
            this.btn4.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn4.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn4.Location = new System.Drawing.Point(9, 72);
            this.btn4.Name = "btn4";
            this.btn4.Radius = 10;
            this.btn4.Size = new System.Drawing.Size(55, 45);
            this.btn4.Stroke = false;
            this.btn4.StrokeColor = System.Drawing.Color.Gray;
            this.btn4.TabIndex = 3;
            this.btn4.Text = "4";
            this.btn4.Transparency = false;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btn2
            // 
            this.btn2.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btn2.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btn2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn2.BackColor = System.Drawing.Color.Transparent;
            this.btn2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn2.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.ForeColor = System.Drawing.Color.Black;
            this.btn2.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn2.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn2.Location = new System.Drawing.Point(70, 21);
            this.btn2.Name = "btn2";
            this.btn2.Radius = 10;
            this.btn2.Size = new System.Drawing.Size(55, 45);
            this.btn2.Stroke = false;
            this.btn2.StrokeColor = System.Drawing.Color.Gray;
            this.btn2.TabIndex = 3;
            this.btn2.Text = "2";
            this.btn2.Transparency = false;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn1
            // 
            this.btn1.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btn1.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn1.BackColor = System.Drawing.Color.Transparent;
            this.btn1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn1.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.ForeColor = System.Drawing.Color.Black;
            this.btn1.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn1.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn1.Location = new System.Drawing.Point(9, 21);
            this.btn1.Name = "btn1";
            this.btn1.Radius = 10;
            this.btn1.Size = new System.Drawing.Size(55, 45);
            this.btn1.Stroke = false;
            this.btn1.StrokeColor = System.Drawing.Color.Gray;
            this.btn1.TabIndex = 3;
            this.btn1.Text = "1";
            this.btn1.Transparency = false;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btnDel
            // 
            this.btnDel.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnDel.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.BackColor = System.Drawing.Color.Transparent;
            this.btnDel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDel.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.ForeColor = System.Drawing.Color.Black;
            this.btnDel.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDel.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDel.Location = new System.Drawing.Point(132, 174);
            this.btnDel.Name = "btnDel";
            this.btnDel.Radius = 10;
            this.btnDel.Size = new System.Drawing.Size(55, 45);
            this.btnDel.Stroke = false;
            this.btnDel.StrokeColor = System.Drawing.Color.Gray;
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "Del";
            this.btnDel.Transparency = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // altoButton2
            // 
            this.altoButton2.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.altoButton2.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.altoButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.altoButton2.BackColor = System.Drawing.Color.Transparent;
            this.altoButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.altoButton2.Enabled = false;
            this.altoButton2.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altoButton2.ForeColor = System.Drawing.Color.Black;
            this.altoButton2.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.altoButton2.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.altoButton2.Location = new System.Drawing.Point(9, 174);
            this.altoButton2.Name = "altoButton2";
            this.altoButton2.Radius = 10;
            this.altoButton2.Size = new System.Drawing.Size(55, 45);
            this.altoButton2.Stroke = false;
            this.altoButton2.StrokeColor = System.Drawing.Color.Gray;
            this.altoButton2.TabIndex = 3;
            this.altoButton2.Transparency = false;
            this.altoButton2.Click += new System.EventHandler(this.btn0_Click);
            // 
            // frmCheckPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(354, 361);
            this.Controls.Add(this.pnSDT);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.altoSlidingLabel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCheckPhone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.frmCheckPhone_Load);
            this.pnSDT.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private AltoControls.AltoButton btnConfirm;
        private AltoControls.AltoSlidingLabel altoSlidingLabel1;
        private AltoControls.AltoButton btnCancel;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.Panel pnSDT;
        private AltoControls.AltoButton btn9;
        private AltoControls.AltoButton btn6;
        private AltoControls.AltoButton btn3;
        private AltoControls.AltoButton btn0;
        private AltoControls.AltoButton btn8;
        private AltoControls.AltoButton btn7;
        private AltoControls.AltoButton btn5;
        private AltoControls.AltoButton btn4;
        private AltoControls.AltoButton btn2;
        private AltoControls.AltoButton btn1;
        private AltoControls.AltoButton altoButton2;
        private AltoControls.AltoButton btnDel;
    }
}