namespace HotelManagementSystem.Forms
{
    partial class FrmLogin
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
            lbluser = new Label();
            lblPass = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            lblTitle = new Label();
            btnLogin = new Button();
            btnExit = new Button();
            pnlLogin = new Panel();
            lblIcon = new Label();
            lblSubTitle = new Label();
            pnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // lbluser
            // 
            lbluser.AutoSize = true;
            lbluser.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbluser.ForeColor = Color.FromArgb(64, 64, 64);
            lbluser.Location = new Point(57, 220);
            lbluser.Name = "lbluser";
            lbluser.Size = new Size(86, 23);
            lbluser.TabIndex = 0;
            lbluser.Text = "Tài khoản:";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPass.ForeColor = Color.FromArgb(64, 64, 64);
            lblPass.Location = new Point(57, 300);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(86, 23);
            lblPass.TabIndex = 1;
            lblPass.Text = "Mật khẩu:";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(57, 249);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(343, 32);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(57, 329);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(343, 32);
            txtPassword.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(0, 122, 204);
            lblTitle.Location = new Point(57, 107);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(357, 53);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "HỆ THỐNG KS";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 122, 204);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(57, 393);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(166, 53);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "🔓 Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(220, 53, 69);
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(234, 393);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(166, 53);
            btnExit.TabIndex = 6;
            btnExit.Text = "✖ Thoát";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.White;
            pnlLogin.Controls.Add(lblIcon);
            pnlLogin.Controls.Add(lblSubTitle);
            pnlLogin.Controls.Add(lblTitle);
            pnlLogin.Controls.Add(lbluser);
            pnlLogin.Controls.Add(lblPass);
            pnlLogin.Controls.Add(txtUsername);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(btnExit);
            pnlLogin.Location = new Point(229, 67);
            pnlLogin.Margin = new Padding(3, 4, 3, 4);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(457, 467);
            pnlLogin.TabIndex = 10;
            // 
            // lblIcon
            // 
            lblIcon.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIcon.ForeColor = Color.FromArgb(0, 122, 204);
            lblIcon.Location = new Point(171, 27);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new Size(114, 80);
            lblIcon.TabIndex = 11;
            lblIcon.Text = "🏨";
            lblIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubTitle
            // 
            lblSubTitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubTitle.ForeColor = Color.Gray;
            lblSubTitle.Location = new Point(57, 160);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(343, 33);
            lblSubTitle.TabIndex = 12;
            lblSubTitle.Text = "Đăng nhập để quản lý khách sạn";
            lblSubTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(914, 600);
            Controls.Add(pnlLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập - Hệ thống Quản lý Khách sạn";
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lbluser;
        private Label lblPass;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblTitle;
        private Button btnLogin;
        private Button btnExit;
        private Panel pnlLogin;
        private Label lblSubTitle;
        private Label lblIcon;
    }
}
