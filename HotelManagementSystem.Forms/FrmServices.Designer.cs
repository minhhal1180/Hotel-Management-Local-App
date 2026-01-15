namespace HotelManagementSystem.Forms
{
    partial class FrmServices
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
            dgvServices = new DataGridView();
            groupBox1 = new GroupBox();
            chkActive = new CheckBox();
            txtDescription = new TextBox();
            label4 = new Label();
            txtPrice = new TextBox();
            label3 = new Label();
            txtServiceName = new TextBox();
            label2 = new Label();
            txtID = new TextBox();
            label1 = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvServices
            // 
            dgvServices.AllowUserToAddRows = false;
            dgvServices.AllowUserToDeleteRows = false;
            dgvServices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServices.Location = new Point(14, 213);
            dgvServices.Margin = new Padding(3, 4, 3, 4);
            dgvServices.Name = "dgvServices";
            dgvServices.ReadOnly = true;
            dgvServices.RowHeadersWidth = 51;
            dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServices.Size = new Size(640, 387);
            dgvServices.TabIndex = 0;
            dgvServices.CellClick += dgvServices_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkActive);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtServiceName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtID);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(457, 173);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin dịch vụ";
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Location = new Point(320, 127);
            chkActive.Margin = new Padding(3, 4, 3, 4);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(114, 27);
            chkActive.TabIndex = 8;
            chkActive.Text = "Hoạt động";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(114, 123);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(182, 30);
            txtDescription.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 127);
            label4.Name = "label4";
            label4.Size = new Size(59, 23);
            label4.TabIndex = 6;
            label4.Text = "Mô tả:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(320, 76);
            txtPrice.Margin = new Padding(3, 4, 3, 4);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(114, 30);
            txtPrice.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(263, 80);
            label3.Name = "label3";
            label3.Size = new Size(39, 23);
            label3.TabIndex = 4;
            label3.Text = "Giá:";
            // 
            // txtServiceName
            // 
            txtServiceName.Location = new Point(114, 76);
            txtServiceName.Margin = new Padding(3, 4, 3, 4);
            txtServiceName.Name = "txtServiceName";
            txtServiceName.Size = new Size(137, 30);
            txtServiceName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 80);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 2;
            label2.Text = "Tên dịch vụ:";
            // 
            // txtID
            // 
            txtID.Location = new Point(114, 29);
            txtID.Margin = new Padding(3, 4, 3, 4);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(137, 30);
            txtID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 33);
            label1.Name = "label1";
            label1.Size = new Size(66, 23);
            label1.TabIndex = 0;
            label1.Text = "Mã DV:";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(30, 60, 114);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(491, 33);
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
            btnUpdate.Location = new Point(491, 87);
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
            btnDelete.Location = new Point(491, 140);
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
            btnRefresh.Font = new Font("Segoe UI", 14F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(617, 33);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(37, 40);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "🔄";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // FrmServices
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(667, 615);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(groupBox1);
            Controls.Add(dgvServices);
            Font = new Font("Segoe UI", 10F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmServices";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Dịch vụ";
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServiceName;
   private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
      private System.Windows.Forms.Button btnRefresh;
    }
}
