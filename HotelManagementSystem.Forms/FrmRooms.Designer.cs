namespace HotelManagementSystem.Forms
{
    partial class FrmRooms
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
            dgvRooms = new DataGridView();
            groupBox1 = new GroupBox();
            txtDescription = new TextBox();
            label6 = new Label();
            cboStatus = new ComboBox();
            label5 = new Label();
            txtFloor = new TextBox();
            label4 = new Label();
            cboRoomType = new ComboBox();
            label3 = new Label();
            txtRoomNumber = new TextBox();
            label2 = new Label();
            txtID = new TextBox();
            label1 = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnExport = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRooms
            // 
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRooms.Location = new Point(14, 267);
            dgvRooms.Margin = new Padding(3, 4, 3, 4);
            dgvRooms.Name = "dgvRooms";
            dgvRooms.ReadOnly = true;
            dgvRooms.RowHeadersWidth = 51;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.Size = new Size(869, 453);
            dgvRooms.TabIndex = 0;
            dgvRooms.CellClick += dgvRooms_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(cboStatus);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtFloor);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cboRoomType);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtRoomNumber);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtID);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(571, 187);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin phòng";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(394, 133);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(171, 30);
            txtDescription.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(309, 137);
            label6.Name = "label6";
            label6.Size = new Size(59, 23);
            label6.TabIndex = 10;
            label6.Text = "Mô tả:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Available", "Occupied", "Maintenance" });
            cboStatus.Location = new Point(114, 133);
            cboStatus.Margin = new Padding(3, 4, 3, 4);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(171, 31);
            cboStatus.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 137);
            label5.Name = "label5";
            label5.Size = new Size(91, 23);
            label5.TabIndex = 8;
            label5.Text = "Trạng thái:";
            // 
            // txtFloor
            // 
            txtFloor.Location = new Point(394, 81);
            txtFloor.Margin = new Padding(3, 4, 3, 4);
            txtFloor.Name = "txtFloor";
            txtFloor.Size = new Size(171, 30);
            txtFloor.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(309, 84);
            label4.Name = "label4";
            label4.Size = new Size(52, 23);
            label4.TabIndex = 6;
            label4.Text = "Tầng:";
            // 
            // cboRoomType
            // 
            cboRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoomType.FormattingEnabled = true;
            cboRoomType.Location = new Point(114, 81);
            cboRoomType.Margin = new Padding(3, 4, 3, 4);
            cboRoomType.Name = "cboRoomType";
            cboRoomType.Size = new Size(171, 31);
            cboRoomType.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 84);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 4;
            label3.Text = "Loại phòng:";
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Location = new Point(394, 34);
            txtRoomNumber.Margin = new Padding(3, 4, 3, 4);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(171, 30);
            txtRoomNumber.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(309, 37);
            label2.Name = "label2";
            label2.Size = new Size(88, 23);
            label2.TabIndex = 2;
            label2.Text = "Số phòng:";
            label2.Click += label2_Click;
            // 
            // txtID
            // 
            txtID.Location = new Point(114, 33);
            txtID.Margin = new Padding(3, 4, 3, 4);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(171, 30);
            txtID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 36);
            label1.Name = "label1";
            label1.Size = new Size(93, 23);
            label1.TabIndex = 0;
            label1.Text = "Mã phòng:";
            label1.Click += label1_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(30, 60, 114);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(606, 33);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(114, 40);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(30, 60, 114);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(731, 33);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(114, 40);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(606, 87);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(114, 40);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(30, 60, 114);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(731, 87);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(114, 40);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(14, 220);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(285, 30);
            txtSearch.TabIndex = 6;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(30, 60, 114);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(309, 217);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 36);
            btnSearch.TabIndex = 7;
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
            btnExport.Location = new Point(731, 140);
            btnExport.Margin = new Padding(3, 4, 3, 4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(114, 40);
            btnExport.TabIndex = 8;
            btnExport.Text = "Xuất Excel";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // FrmRooms
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(896, 748);
            Controls.Add(btnExport);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(groupBox1);
            Controls.Add(dgvRooms);
            Font = new Font("Segoe UI", 10F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmRooms";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Qu?n l? Ph?ng";
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.GroupBox groupBox1;
   private System.Windows.Forms.TextBox txtID;
     private System.Windows.Forms.Label label1;
     private System.Windows.Forms.TextBox txtRoomNumber;
      private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRoomType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboStatus;
     private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescription;
     private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;
    }
}
