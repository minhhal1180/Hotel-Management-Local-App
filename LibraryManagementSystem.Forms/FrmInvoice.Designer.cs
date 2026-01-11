namespace LibraryManagementSystem.Forms
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
this.dgvInvoices = new System.Windows.Forms.DataGridView();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
    this.txtNote = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
    this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
  this.txtDiscount = new System.Windows.Forms.TextBox();
    this.label5 = new System.Windows.Forms.Label();
     this.lblTotal = new System.Windows.Forms.Label();
      this.lblServiceCharge = new System.Windows.Forms.Label();
        this.lblRoomCharge = new System.Windows.Forms.Label();
     this.cboBooking = new System.Windows.Forms.ComboBox();
     this.label2 = new System.Windows.Forms.Label();
      this.txtID = new System.Windows.Forms.TextBox();
  this.label1 = new System.Windows.Forms.Label();
     this.btnCreate = new System.Windows.Forms.Button();
     this.btnExportOne = new System.Windows.Forms.Button();
  this.btnExportAll = new System.Windows.Forms.Button();
      this.btnRefresh = new System.Windows.Forms.Button();
     this.btnCalculate = new System.Windows.Forms.Button();
 ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
         this.groupBox1.SuspendLayout();
  this.SuspendLayout();
    // 
            // dgvInvoices
   // 
   this.dgvInvoices.AllowUserToAddRows = false;
 this.dgvInvoices.AllowUserToDeleteRows = false;
   this.dgvInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
     | System.Windows.Forms.AnchorStyles.Left) 
  | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoices.Location = new System.Drawing.Point(12, 200);
this.dgvInvoices.Name = "dgvInvoices";
 this.dgvInvoices.ReadOnly = true;
        this.dgvInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
 this.dgvInvoices.Size = new System.Drawing.Size(760, 250);
            this.dgvInvoices.TabIndex = 0;
     this.dgvInvoices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoices_CellClick);
            // 
     // groupBox1
            // 
    this.groupBox1.Controls.Add(this.btnCalculate);
     this.groupBox1.Controls.Add(this.txtNote);
      this.groupBox1.Controls.Add(this.label7);
        this.groupBox1.Controls.Add(this.cboPaymentMethod);
      this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDiscount);
    this.groupBox1.Controls.Add(this.label5);
   this.groupBox1.Controls.Add(this.lblTotal);
 this.groupBox1.Controls.Add(this.lblServiceCharge);
            this.groupBox1.Controls.Add(this.lblRoomCharge);
    this.groupBox1.Controls.Add(this.cboBooking);
     this.groupBox1.Controls.Add(this.label2);
   this.groupBox1.Controls.Add(this.txtID);
    this.groupBox1.Controls.Add(this.label1);
 this.groupBox1.Location = new System.Drawing.Point(12, 12);
    this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 170);
            this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
this.groupBox1.Text = "L?p hóa ðõn thanh toán";
     // 
     // btnCalculate
     // 
       this.btnCalculate.Location = new System.Drawing.Point(430, 20);
     this.btnCalculate.Name = "btnCalculate";
    this.btnCalculate.Size = new System.Drawing.Size(100, 25);
   this.btnCalculate.TabIndex = 15;
    this.btnCalculate.Text = "Tính ti?n";
      this.btnCalculate.UseVisualStyleBackColor = true;
       this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
 // 
     // txtNote
  // 
     this.txtNote.Location = new System.Drawing.Point(340, 135);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(190, 23);
         this.txtNote.TabIndex = 14;
    // 
            // label7
     // 
       this.label7.AutoSize = true;
       this.label7.Location = new System.Drawing.Point(270, 138);
       this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(53, 15);
   this.label7.TabIndex = 13;
this.label7.Text = "Ghi chú:";
 // 
  // cboPaymentMethod
       // 
       this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
 this.cboPaymentMethod.FormattingEnabled = true;
   this.cboPaymentMethod.Items.AddRange(new object[] {
   "Cash",
       "Card",
 "Transfer"});
     this.cboPaymentMethod.Location = new System.Drawing.Point(100, 135);
  this.cboPaymentMethod.Name = "cboPaymentMethod";
       this.cboPaymentMethod.Size = new System.Drawing.Size(150, 23);
   this.cboPaymentMethod.TabIndex = 12;
 // 
         // label6
        // 
       this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 138);
     this.label6.Name = "label6";
 this.label6.Size = new System.Drawing.Size(68, 15);
          this.label6.TabIndex = 11;
       this.label6.Text = "Thanh toán:";
            // 
   // txtDiscount
     // 
            this.txtDiscount.Location = new System.Drawing.Point(340, 100);
    this.txtDiscount.Name = "txtDiscount";
      this.txtDiscount.Size = new System.Drawing.Size(100, 23);
      this.txtDiscount.TabIndex = 10;
 this.txtDiscount.Text = "0";
    // 
      // label5
 // 
         this.label5.AutoSize = true;
       this.label5.Location = new System.Drawing.Point(270, 103);
      this.label5.Name = "label5";
   this.label5.Size = new System.Drawing.Size(57, 15);
       this.label5.TabIndex = 9;
            this.label5.Text = "Gi?m giá:";
  // 
      // lblTotal
     // 
      this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
  this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(15, 103);
      this.lblTotal.Name = "lblTotal";
   this.lblTotal.Size = new System.Drawing.Size(88, 15);
   this.lblTotal.TabIndex = 8;
       this.lblTotal.Text = "T?NG C?NG: 0";
 // 
            // lblServiceCharge
         // 
  this.lblServiceCharge.AutoSize = true;
    this.lblServiceCharge.Location = new System.Drawing.Point(270, 60);
            this.lblServiceCharge.Name = "lblServiceCharge";
     this.lblServiceCharge.Size = new System.Drawing.Size(77, 15);
    this.lblServiceCharge.TabIndex = 7;
  this.lblServiceCharge.Text = "Ti?n d?ch v?: 0";
  // 
         // lblRoomCharge
    // 
    this.lblRoomCharge.AutoSize = true;
 this.lblRoomCharge.Location = new System.Drawing.Point(15, 60);
    this.lblRoomCharge.Name = "lblRoomCharge";
       this.lblRoomCharge.Size = new System.Drawing.Size(75, 15);
  this.lblRoomCharge.TabIndex = 6;
   this.lblRoomCharge.Text = "Ti?n ph?ng: 0";
  // 
            // cboBooking
     // 
       this.cboBooking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
     this.cboBooking.FormattingEnabled = true;
this.cboBooking.Location = new System.Drawing.Point(100, 22);
 this.cboBooking.Name = "cboBooking";
 this.cboBooking.Size = new System.Drawing.Size(320, 23);
        this.cboBooking.TabIndex = 5;
        // 
      // label2
      // 
          this.label2.AutoSize = true;
       this.label2.Location = new System.Drawing.Point(15, 25);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 4;
      this.label2.Text = "Booking:";
 // 
 // txtID
// 
 this.txtID.Location = new System.Drawing.Point(430, 57);
   this.txtID.Name = "txtID";
       this.txtID.ReadOnly = true;
  this.txtID.Size = new System.Drawing.Size(100, 23);
  this.txtID.TabIndex = 3;
            // 
   // label1
     // 
 this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 75);
  this.label1.Name = "label1";
  this.label1.Size = new System.Drawing.Size(0, 15);
      this.label1.TabIndex = 2;
    // 
            // btnCreate
     // 
     this.btnCreate.Location = new System.Drawing.Point(580, 25);
            this.btnCreate.Name = "btnCreate";
this.btnCreate.Size = new System.Drawing.Size(120, 35);
         this.btnCreate.TabIndex = 2;
this.btnCreate.Text = "L?p hóa ðõn";
            this.btnCreate.UseVisualStyleBackColor = true;
   this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
       // btnExportOne
        // 
 this.btnExportOne.Location = new System.Drawing.Point(580, 70);
            this.btnExportOne.Name = "btnExportOne";
          this.btnExportOne.Size = new System.Drawing.Size(120, 35);
   this.btnExportOne.TabIndex = 3;
this.btnExportOne.Text = "Xu?t HÐ ðang ch?n";
            this.btnExportOne.UseVisualStyleBackColor = true;
 this.btnExportOne.Click += new System.EventHandler(this.btnExportOne_Click);
        // 
      // btnExportAll
            // 
 this.btnExportAll.Location = new System.Drawing.Point(580, 115);
   this.btnExportAll.Name = "btnExportAll";
  this.btnExportAll.Size = new System.Drawing.Size(120, 35);
      this.btnExportAll.TabIndex = 4;
         this.btnExportAll.Text = "Xu?t t?t c?";
  this.btnExportAll.UseVisualStyleBackColor = true;
      this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
         // 
   // btnRefresh
     // 
       this.btnRefresh.Location = new System.Drawing.Point(710, 25);
   this.btnRefresh.Name = "btnRefresh";
   this.btnRefresh.Size = new System.Drawing.Size(40, 35);
   this.btnRefresh.TabIndex = 5;
      this.btnRefresh.Text = "??";
         this.btnRefresh.UseVisualStyleBackColor = true;
this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
 // 
            // FrmInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
  this.ClientSize = new System.Drawing.Size(784, 461);
  this.Controls.Add(this.btnRefresh);
       this.Controls.Add(this.btnExportAll);
      this.Controls.Add(this.btnExportOne);
       this.Controls.Add(this.btnCreate);
   this.Controls.Add(this.groupBox1);
       this.Controls.Add(this.dgvInvoices);
 this.Name = "FrmInvoice";
    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Hóa ðõn Thanh toán";
       ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
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
   private System.Windows.Forms.Button btnRefresh;
    }
}
