namespace HotelManagementSystem.Forms
{
    partial class FrmMain
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
            lblWelcome = new Label();
            btnRooms = new Button();
            btnServices = new Button();
            btnLogout = new Button();
            btnBookings = new Button();
            btnGuests = new Button();
            btnInvoice = new Button();
            pnlSidebar = new Panel();
            lblAppTitle = new Label();
            pnlHeader = new Panel();
            lblDateTime = new Label();
            pnlMain = new Panel();
            lblMainTitle = new Label();
            lblDescription = new Label();
            pnlSidebar.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(30, 60, 114);
            pnlSidebar.Controls.Add(btnInvoice);
            pnlSidebar.Controls.Add(lblAppTitle);
            pnlSidebar.Controls.Add(btnRooms);
            pnlSidebar.Controls.Add(btnServices);
            pnlSidebar.Controls.Add(btnGuests);
            pnlSidebar.Controls.Add(btnBookings);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 500);
            pnlSidebar.TabIndex = 10;
            // 
            // lblAppTitle
            // 
            lblAppTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Location = new Point(10, 20);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(200, 50);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "🏨 KHÁCH SẠN";
            lblAppTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnRooms
            // 
            btnRooms.BackColor = Color.FromArgb(42, 82, 152);
            btnRooms.Cursor = Cursors.Hand;
            btnRooms.FlatAppearance.BorderSize = 0;
            btnRooms.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 102, 182);
            btnRooms.FlatStyle = FlatStyle.Flat;
            btnRooms.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRooms.ForeColor = Color.White;
            btnRooms.ImageAlign = ContentAlignment.MiddleLeft;
            btnRooms.Location = new Point(10, 90);
            btnRooms.Name = "btnRooms";
            btnRooms.Padding = new Padding(10, 0, 0, 0);
            btnRooms.Size = new Size(200, 50);
            btnRooms.TabIndex = 1;
            btnRooms.Text = "🛏️  Quản lý Phòng";
            btnRooms.TextAlign = ContentAlignment.MiddleLeft;
            btnRooms.UseVisualStyleBackColor = false;
            btnRooms.Click += btnRooms_Click;
            // 
            // btnServices
            // 
            btnServices.BackColor = Color.FromArgb(42, 82, 152);
            btnServices.Cursor = Cursors.Hand;
            btnServices.FlatAppearance.BorderSize = 0;
            btnServices.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 102, 182);
            btnServices.FlatStyle = FlatStyle.Flat;
            btnServices.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnServices.ForeColor = Color.White;
            btnServices.Location = new Point(10, 150);
            btnServices.Name = "btnServices";
            btnServices.Padding = new Padding(10, 0, 0, 0);
            btnServices.Size = new Size(200, 50);
            btnServices.TabIndex = 2;
            btnServices.Text = "🛎️  Dịch vụ";
            btnServices.TextAlign = ContentAlignment.MiddleLeft;
            btnServices.UseVisualStyleBackColor = false;
            btnServices.Click += btnServices_Click;
            // 
            // btnGuests
            // 
            btnGuests.BackColor = Color.FromArgb(42, 82, 152);
            btnGuests.Cursor = Cursors.Hand;
            btnGuests.FlatAppearance.BorderSize = 0;
            btnGuests.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 102, 182);
            btnGuests.FlatStyle = FlatStyle.Flat;
            btnGuests.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuests.ForeColor = Color.White;
            btnGuests.Location = new Point(10, 210);
            btnGuests.Name = "btnGuests";
            btnGuests.Padding = new Padding(10, 0, 0, 0);
            btnGuests.Size = new Size(200, 50);
            btnGuests.TabIndex = 5;
            btnGuests.Text = "🧑‍🤝‍🧑  Khách hàng";
            btnGuests.TextAlign = ContentAlignment.MiddleLeft;
            btnGuests.UseVisualStyleBackColor = false;
            btnGuests.Click += btnGuests_Click;
            // 
            // btnBookings
            // 
            btnBookings.BackColor = Color.FromArgb(42, 82, 152);
            btnBookings.Cursor = Cursors.Hand;
            btnBookings.FlatAppearance.BorderSize = 0;
            btnBookings.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 102, 182);
            btnBookings.FlatStyle = FlatStyle.Flat;
            btnBookings.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBookings.ForeColor = Color.White;
            btnBookings.Location = new Point(10, 270);
            btnBookings.Name = "btnBookings";
            btnBookings.Padding = new Padding(10, 0, 0, 0);
            btnBookings.Size = new Size(200, 50);
            btnBookings.TabIndex = 4;
            btnBookings.Text = "📅  Đặt / Trả Phòng";
            btnBookings.TextAlign = ContentAlignment.MiddleLeft;
            btnBookings.UseVisualStyleBackColor = false;
            btnBookings.Click += btnBookings_Click;
            // 
            // btnInvoice
            // 
            btnInvoice.BackColor = Color.FromArgb(42, 82, 152);
            btnInvoice.Cursor = Cursors.Hand;
            btnInvoice.FlatAppearance.BorderSize = 0;
            btnInvoice.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 102, 182);
            btnInvoice.FlatStyle = FlatStyle.Flat;
            btnInvoice.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInvoice.ForeColor = Color.White;
            btnInvoice.Location = new Point(10, 330);
            btnInvoice.Name = "btnInvoice";
            btnInvoice.Padding = new Padding(10, 0, 0, 0);
            btnInvoice.Size = new Size(200, 50);
            btnInvoice.TabIndex = 6;
            btnInvoice.Text = "🧾  Hóa đơn";
            btnInvoice.TextAlign = ContentAlignment.MiddleLeft;
            btnInvoice.UseVisualStyleBackColor = false;
            btnInvoice.Click += btnInvoice_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(220, 53, 69);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 35, 51);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(10, 430);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(10, 0, 0, 0);
            btnLogout.Size = new Size(200, 50);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "🚪  Đăng xuất";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(lblDateTime);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(220, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(680, 70);
            pnlHeader.TabIndex = 11;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.FromArgb(30, 60, 114);
            lblWelcome.Location = new Point(20, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(200, 30);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "👋 Xin chào, Admin!";
            // 
            // lblDateTime
            // 
            lblDateTime.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateTime.ForeColor = Color.Gray;
            lblDateTime.Location = new Point(450, 25);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(200, 20);
            lblDateTime.TabIndex = 1;
            lblDateTime.Text = "11/01/2026";
            lblDateTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(240, 244, 248);
            pnlMain.Controls.Add(lblMainTitle);
            pnlMain.Controls.Add(lblDescription);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(220, 70);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(680, 430);
            pnlMain.TabIndex = 12;
            // 
            // lblMainTitle
            // 
            lblMainTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMainTitle.ForeColor = Color.FromArgb(30, 60, 114);
            lblMainTitle.Location = new Point(50, 100);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new Size(580, 50);
            lblMainTitle.TabIndex = 0;
            lblMainTitle.Text = "HỆ THỐNG QUẢN LÝ KHÁCH SẠN";
            lblMainTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.ForeColor = Color.Gray;
            lblDescription.Location = new Point(50, 160);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(580, 100);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Chọn một chức năng từ menu bên trái để bắt đầu.\n\n🛏️ Quản lý phòng  |  🧑‍🤝‍🧑 Khách hàng  |  📅 Đặt/Trả phòng  |  🛎️ Dịch vụ  |  🧾 Hóa đơn";
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(900, 500);
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Quản lý Khách sạn";
            pnlSidebar.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblWelcome;
        private Button btnRooms;
        private Button btnServices;
        private Button btnLogout;
        private Button btnBookings;
        private Button btnGuests;
        private Button btnInvoice;
        private Panel pnlSidebar;
        private Label lblAppTitle;
        private Panel pnlHeader;
        private Label lblDateTime;
        private Panel pnlMain;
        private Label lblMainTitle;
        private Label lblDescription;
    }
}
