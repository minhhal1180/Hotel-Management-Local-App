namespace HotelManagementSystem.Forms
{
    partial class FrmBooking
    {
      private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
  if (disposing && (components != null))
     {
       components.Dispose();
            }
        base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvBookings = new DataGridView();
            groupBox1 = new GroupBox();
            txtNote = new TextBox();
            label6 = new Label();
            dtpCheckOut = new DateTimePicker();
            label5 = new Label();
            dtpCheckIn = new DateTimePicker();
            label4 = new Label();
            cboRoom = new ComboBox();
            label3 = new Label();
            cboGuest = new ComboBox();
            label2 = new Label();
            txtID = new TextBox();
            label1 = new Label();
            btnBooking = new Button();
            btnCheckIn = new Button();
            btnCheckOut = new Button();
            btnCancel = new Button();
            btnRefresh = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnExport = new Button();
            lblAvailableRooms = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBookings
            // 
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.AllowUserToDeleteRows = false;
            dgvBookings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookings.Location = new Point(14, 293);
            dgvBookings.Margin = new Padding(3, 4, 3, 4);
            dgvBookings.Name = "dgvBookings";
            dgvBookings.ReadOnly = true;
            dgvBookings.RowHeadersWidth = 51;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.Size = new Size(983, 427);
            dgvBookings.TabIndex = 0;
            dgvBookings.CellClick += dgvBookings_CellClick;
            dgvBookings.CellContentClick += dgvBookings_CellContentClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtNote);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(dtpCheckOut);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dtpCheckIn);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cboRoom);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cboGuest);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtID);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(686, 213);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Đặt phòng mới";
            // 
            // txtNote
            // 
            txtNote.Location = new Point(491, 113);
            txtNote.Margin = new Padding(3, 4, 3, 4);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(171, 30);
            txtNote.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(411, 117);
            label6.Name = "label6";
            label6.Size = new Size(73, 23);
            label6.TabIndex = 12;
            label6.Text = "Ghi chú:";
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Format = DateTimePickerFormat.Short;
            dtpCheckOut.Location = new Point(128, 113);
            dtpCheckOut.Margin = new Padding(3, 4, 3, 4);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(171, 30);
            dtpCheckOut.TabIndex = 11;
            dtpCheckOut.ValueChanged += dtpDate_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 117);
            label5.Name = "label5";
            label5.Size = new Size(93, 23);
            label5.TabIndex = 10;
            label5.Text = "Check-out:";
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Format = DateTimePickerFormat.Short;
            dtpCheckIn.Location = new Point(491, 67);
            dtpCheckIn.Margin = new Padding(3, 4, 3, 4);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(171, 30);
            dtpCheckIn.TabIndex = 9;
            dtpCheckIn.ValueChanged += dtpDate_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(411, 71);
            label4.Name = "label4";
            label4.Size = new Size(81, 23);
            label4.TabIndex = 8;
            label4.Text = "Check-in:";
            // 
            // cboRoom
            // 
            cboRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoom.FormattingEnabled = true;
            cboRoom.Location = new Point(128, 67);
            cboRoom.Margin = new Padding(3, 4, 3, 4);
            cboRoom.Name = "cboRoom";
            cboRoom.Size = new Size(262, 31);
            cboRoom.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 71);
            label3.Name = "label3";
            label3.Size = new Size(64, 23);
            label3.TabIndex = 6;
            label3.Text = "Phòng:";
            // 
            // cboGuest
            // 
            cboGuest.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGuest.FormattingEnabled = true;
            cboGuest.Location = new Point(128, 26);
            cboGuest.Margin = new Padding(3, 4, 3, 4);
            cboGuest.Name = "cboGuest";
            cboGuest.Size = new Size(262, 31);
            cboGuest.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 31);
            label2.Name = "label2";
            label2.Size = new Size(105, 23);
            label2.TabIndex = 4;
            label2.Text = "Khách hàng:";
            // 
            // txtID
            // 
            txtID.Location = new Point(491, 27);
            txtID.Margin = new Padding(3, 4, 3, 4);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(171, 30);
            txtID.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(411, 31);
            label1.Name = "label1";
            label1.Size = new Size(65, 23);
            label1.TabIndex = 2;
            label1.Text = "Mã ĐP:";
            // 
            // btnBooking
            // 
            btnBooking.BackColor = Color.FromArgb(30, 60, 114);
            btnBooking.FlatAppearance.BorderSize = 0;
            btnBooking.FlatStyle = FlatStyle.Flat;
            btnBooking.ForeColor = Color.White;
            btnBooking.Location = new Point(720, 33);
            btnBooking.Margin = new Padding(3, 4, 3, 4);
            btnBooking.Name = "btnBooking";
            btnBooking.Size = new Size(114, 40);
            btnBooking.TabIndex = 2;
            btnBooking.Text = "Đặt phòng";
            btnBooking.UseVisualStyleBackColor = true;
            btnBooking.Click += btnBooking_Click;
            // 
            // btnCheckIn
            // 
            btnCheckIn.BackColor = Color.FromArgb(30, 60, 114);
            btnCheckIn.FlatAppearance.BorderSize = 0;
            btnCheckIn.FlatStyle = FlatStyle.Flat;
            btnCheckIn.ForeColor = Color.White;
            btnCheckIn.Location = new Point(846, 33);
            btnCheckIn.Margin = new Padding(3, 4, 3, 4);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(114, 40);
            btnCheckIn.TabIndex = 3;
            btnCheckIn.Text = "Nhận phòng";
            btnCheckIn.UseVisualStyleBackColor = true;
            btnCheckIn.Click += btnCheckIn_Click;
            // 
            // btnCheckOut
            // 
            btnCheckOut.BackColor = Color.FromArgb(30, 60, 114);
            btnCheckOut.FlatAppearance.BorderSize = 0;
            btnCheckOut.FlatStyle = FlatStyle.Flat;
            btnCheckOut.ForeColor = Color.White;
            btnCheckOut.Location = new Point(720, 87);
            btnCheckOut.Margin = new Padding(3, 4, 3, 4);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(114, 40);
            btnCheckOut.TabIndex = 4;
            btnCheckOut.Text = "Trả phòng";
            btnCheckOut.UseVisualStyleBackColor = true;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(220, 53, 69);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(846, 87);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 40);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Hủy đặt";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(30, 60, 114);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(720, 140);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(114, 40);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(14, 247);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(285, 30);
            txtSearch.TabIndex = 7;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(30, 60, 114);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(309, 244);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 36);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(30, 60, 114);
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(846, 140);
            btnExport.Margin = new Padding(3, 4, 3, 4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(114, 40);
            btnExport.TabIndex = 9;
            btnExport.Text = "Xuất Excel";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // lblAvailableRooms
            // 
            lblAvailableRooms.AutoSize = true;
            lblAvailableRooms.Location = new Point(450, 249);
            lblAvailableRooms.Name = "lblAvailableRooms";
            lblAvailableRooms.Size = new Size(125, 23);
            lblAvailableRooms.TabIndex = 10;
            lblAvailableRooms.Text = "Phòng trống: 0";
            // 
            // FrmBooking
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(1010, 748);
            Controls.Add(lblAvailableRooms);
            Controls.Add(btnExport);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnRefresh);
            Controls.Add(btnCancel);
            Controls.Add(btnCheckOut);
            Controls.Add(btnCheckIn);
            Controls.Add(btnBooking);
            Controls.Add(groupBox1);
            Controls.Add(dgvBookings);
            Font = new Font("Segoe UI", 10F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmBooking";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Đặt phòng";
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtID;
    private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboGuest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRoom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
  private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNote;
 private System.Windows.Forms.Label label6;
   private System.Windows.Forms.Button btnBooking;
      private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
  private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblAvailableRooms;
    }
}
