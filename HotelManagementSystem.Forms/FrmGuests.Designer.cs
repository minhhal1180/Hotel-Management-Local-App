namespace HotelManagementSystem.Forms
{
    partial class FrmGuests
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
            dgvGuests = new DataGridView();
            groupBox1 = new GroupBox();
            txtNationality = new TextBox();
            label8 = new Label();
            txtEmail = new TextBox();
            label7 = new Label();
            txtAddress = new TextBox();
            label6 = new Label();
            txtPhone = new TextBox();
            label5 = new Label();
            dtpDOB = new DateTimePicker();
            label4 = new Label();
            txtIdentityCard = new TextBox();
            label3 = new Label();
            txtFullName = new TextBox();
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
            ((System.ComponentModel.ISupportInitialize)dgvGuests).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvGuests
            // 
            dgvGuests.AllowUserToAddRows = false;
            dgvGuests.AllowUserToDeleteRows = false;
            dgvGuests.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGuests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGuests.Location = new Point(14, 293);
            dgvGuests.Margin = new Padding(3, 4, 3, 4);
            dgvGuests.Name = "dgvGuests";
            dgvGuests.ReadOnly = true;
            dgvGuests.RowHeadersWidth = 51;
            dgvGuests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGuests.Size = new Size(983, 427);
            dgvGuests.TabIndex = 0;
            dgvGuests.CellClick += dgvGuests_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtNationality);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dtpDOB);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtIdentityCard);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtFullName);
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
            groupBox1.Text = "Thông tin khách hàng";
            // 
            // txtNationality
            // 
            txtNationality.Location = new Point(491, 160);
            txtNationality.Margin = new Padding(3, 4, 3, 4);
            txtNationality.Name = "txtNationality";
            txtNationality.Size = new Size(171, 30);
            txtNationality.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(401, 160);
            label8.Name = "label8";
            label8.Size = new Size(88, 23);
            label8.TabIndex = 14;
            label8.Text = "Quốc tịch:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(114, 160);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(262, 30);
            txtEmail.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 164);
            label7.Name = "label7";
            label7.Size = new Size(55, 23);
            label7.TabIndex = 12;
            label7.Text = "Email:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(491, 113);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(171, 30);
            txtAddress.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(401, 113);
            label6.Name = "label6";
            label6.Size = new Size(66, 23);
            label6.TabIndex = 10;
            label6.Text = "Địa chỉ:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(114, 113);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(262, 30);
            txtPhone.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 117);
            label5.Name = "label5";
            label5.Size = new Size(44, 23);
            label5.TabIndex = 8;
            label5.Text = "SĐT:";
            // 
            // dtpDOB
            // 
            dtpDOB.Format = DateTimePickerFormat.Short;
            dtpDOB.Location = new Point(491, 67);
            dtpDOB.Margin = new Padding(3, 4, 3, 4);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(171, 30);
            dtpDOB.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(401, 71);
            label4.Name = "label4";
            label4.Size = new Size(90, 23);
            label4.TabIndex = 6;
            label4.Text = "Ngày sinh:";
            // 
            // txtIdentityCard
            // 
            txtIdentityCard.Location = new Point(114, 67);
            txtIdentityCard.Margin = new Padding(3, 4, 3, 4);
            txtIdentityCard.Name = "txtIdentityCard";
            txtIdentityCard.Size = new Size(262, 30);
            txtIdentityCard.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 71);
            label3.Name = "label3";
            label3.Size = new Size(59, 23);
            label3.TabIndex = 4;
            label3.Text = "CCCD:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(491, 27);
            txtFullName.Margin = new Padding(3, 4, 3, 4);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(171, 30);
            txtFullName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(401, 34);
            label2.Name = "label2";
            label2.Size = new Size(66, 23);
            label2.TabIndex = 2;
            label2.Text = "Họ tên:";
            // 
            // txtID
            // 
            txtID.Location = new Point(114, 27);
            txtID.Margin = new Padding(3, 4, 3, 4);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(262, 30);
            txtID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 31);
            label1.Name = "label1";
            label1.Size = new Size(65, 23);
            label1.TabIndex = 0;
            label1.Text = "Mã KH:";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(30, 60, 114);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(720, 33);
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
            btnUpdate.Location = new Point(846, 33);
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
            btnDelete.Location = new Point(720, 87);
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
            btnRefresh.Location = new Point(846, 87);
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
            txtSearch.Location = new Point(14, 247);
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
            btnSearch.Location = new Point(309, 244);
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
            btnExport.Location = new Point(846, 140);
            btnExport.Margin = new Padding(3, 4, 3, 4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(114, 40);
            btnExport.TabIndex = 8;
            btnExport.Text = "Xuất Excel";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // FrmGuests
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(1010, 748);
            Controls.Add(btnExport);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(groupBox1);
            Controls.Add(dgvGuests);
            Font = new Font("Segoe UI", 10F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmGuests";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Khách hàng";
            Load += FrmGuests_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGuests).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGuests;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdentityCard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label5;
  private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
 private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.Label label8;
private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;
    }
}
