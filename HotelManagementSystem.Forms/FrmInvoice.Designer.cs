namespace HotelManagementSystem.Forms
{
 partial class FrmInvoice
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
            dgvInvoices = new DataGridView();
            groupBox1 = new GroupBox();
            btnCalculate = new Button();
            txtNote = new TextBox();
            label7 = new Label();
            cboPaymentMethod = new ComboBox();
            label6 = new Label();
            txtDiscount = new TextBox();
            label5 = new Label();
            lblTotal = new Label();
            lblServiceCharge = new Label();
            lblRoomCharge = new Label();
            cboBooking = new ComboBox();
            label2 = new Label();
            txtID = new TextBox();
            label1 = new Label();
            btnCreate = new Button();
            btnExportOne = new Button();
            btnExportAll = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvInvoices
            // 
            dgvInvoices.AllowUserToAddRows = false;
            dgvInvoices.AllowUserToDeleteRows = false;
            dgvInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoices.Location = new Point(14, 267);
            dgvInvoices.Margin = new Padding(3, 4, 3, 4);
            dgvInvoices.Name = "dgvInvoices";
            dgvInvoices.ReadOnly = true;
            dgvInvoices.RowHeadersWidth = 51;
            dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoices.Size = new Size(869, 333);
            dgvInvoices.TabIndex = 0;
            dgvInvoices.CellClick += dgvInvoices_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCalculate);
            groupBox1.Controls.Add(txtNote);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cboPaymentMethod);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtDiscount);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblTotal);
            groupBox1.Controls.Add(lblServiceCharge);
            groupBox1.Controls.Add(lblRoomCharge);
            groupBox1.Controls.Add(cboBooking);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtID);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(629, 227);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lập hóa đơn thanh toán";
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(491, 27);
            btnCalculate.Margin = new Padding(3, 4, 3, 4);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(114, 33);
            btnCalculate.TabIndex = 15;
            btnCalculate.Text = "Tính tiền";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // txtNote
            // 
            txtNote.Location = new Point(389, 180);
            txtNote.Margin = new Padding(3, 4, 3, 4);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(217, 30);
            txtNote.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(309, 184);
            label7.Name = "label7";
            label7.Size = new Size(73, 23);
            label7.TabIndex = 13;
            label7.Text = "Ghi chú:";
            // 
            // cboPaymentMethod
            // 
            cboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaymentMethod.FormattingEnabled = true;
            cboPaymentMethod.Items.AddRange(new object[] { "Cash", "Card", "Transfer" });
            cboPaymentMethod.Location = new Point(114, 180);
            cboPaymentMethod.Margin = new Padding(3, 4, 3, 4);
            cboPaymentMethod.Name = "cboPaymentMethod";
            cboPaymentMethod.Size = new Size(171, 31);
            cboPaymentMethod.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 184);
            label6.Name = "label6";
            label6.Size = new Size(102, 23);
            label6.TabIndex = 11;
            label6.Text = "Thanh toán:";
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(389, 133);
            txtDiscount.Margin = new Padding(3, 4, 3, 4);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(114, 30);
            txtDiscount.TabIndex = 10;
            txtDiscount.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(309, 137);
            label5.Name = "label5";
            label5.Size = new Size(82, 23);
            label5.TabIndex = 9;
            label5.Text = "Giảm giá:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotal.ForeColor = Color.Red;
            lblTotal.Location = new Point(17, 137);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(116, 20);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "TỔNG CỘNG: 0";
            // 
            // lblServiceCharge
            // 
            lblServiceCharge.AutoSize = true;
            lblServiceCharge.Location = new Point(309, 80);
            lblServiceCharge.Name = "lblServiceCharge";
            lblServiceCharge.Size = new Size(120, 23);
            lblServiceCharge.TabIndex = 7;
            lblServiceCharge.Text = "Tiền dịch vụ: 0";
            // 
            // lblRoomCharge
            // 
            lblRoomCharge.AutoSize = true;
            lblRoomCharge.Location = new Point(17, 80);
            lblRoomCharge.Name = "lblRoomCharge";
            lblRoomCharge.Size = new Size(115, 23);
            lblRoomCharge.TabIndex = 6;
            lblRoomCharge.Text = "Tiền phòng: 0";
            // 
            // cboBooking
            // 
            cboBooking.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBooking.FormattingEnabled = true;
            cboBooking.Location = new Point(114, 29);
            cboBooking.Margin = new Padding(3, 4, 3, 4);
            cboBooking.Name = "cboBooking";
            cboBooking.Size = new Size(365, 31);
            cboBooking.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 33);
            label2.Name = "label2";
            label2.Size = new Size(76, 23);
            label2.TabIndex = 4;
            label2.Text = "Booking:";
            // 
            // txtID
            // 
            txtID.Location = new Point(491, 76);
            txtID.Margin = new Padding(3, 4, 3, 4);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(114, 30);
            txtID.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(526, 100);
            label1.Name = "label1";
            label1.Size = new Size(0, 23);
            label1.TabIndex = 2;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(30, 60, 114);
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(663, 33);
            btnCreate.Margin = new Padding(3, 4, 3, 4);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(197, 47);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Lập hóa đơn";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnExportOne
            // 
            btnExportOne.BackColor = Color.FromArgb(30, 60, 114);
            btnExportOne.FlatAppearance.BorderSize = 0;
            btnExportOne.FlatStyle = FlatStyle.Flat;
            btnExportOne.ForeColor = Color.White;
            btnExportOne.Location = new Point(663, 93);
            btnExportOne.Margin = new Padding(3, 4, 3, 4);
            btnExportOne.Name = "btnExportOne";
            btnExportOne.Size = new Size(197, 47);
            btnExportOne.TabIndex = 3;
            btnExportOne.Text = "Xuất HĐ hiện tại";
            btnExportOne.UseVisualStyleBackColor = true;
            btnExportOne.Click += btnExportOne_Click;
            // 
            // btnExportAll
            // 
            btnExportAll.BackColor = Color.FromArgb(30, 60, 114);
            btnExportAll.FlatAppearance.BorderSize = 0;
            btnExportAll.FlatStyle = FlatStyle.Flat;
            btnExportAll.ForeColor = Color.White;
            btnExportAll.Location = new Point(663, 153);
            btnExportAll.Margin = new Padding(3, 4, 3, 4);
            btnExportAll.Name = "btnExportAll";
            btnExportAll.Size = new Size(197, 47);
            btnExportAll.TabIndex = 4;
            btnExportAll.Text = "Xuất tất cả";
            btnExportAll.UseVisualStyleBackColor = true;
            btnExportAll.Click += btnExportAll_Click;
            // 
            // FrmInvoice
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(896, 615);
            Controls.Add(btnExportAll);
            Controls.Add(btnExportOne);
            Controls.Add(btnCreate);
            Controls.Add(groupBox1);
            Controls.Add(dgvInvoices);
            Font = new Font("Segoe UI", 10F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmInvoice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hóa đơn Thanh toán";
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBooking;
   private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRoomCharge;
        private System.Windows.Forms.Label lblServiceCharge;
     private System.Windows.Forms.Label lblTotal;
      private System.Windows.Forms.TextBox txtDiscount;
     private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnExportOne;
        private System.Windows.Forms.Button btnExportAll;
    }
}
