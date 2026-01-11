namespace LibraryManagementSystem.Forms
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
this.dgvGuests = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
     this.txtNationality = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
    this.txtEmail = new System.Windows.Forms.TextBox();
        this.label7 = new System.Windows.Forms.Label();
   this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
        this.txtPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
    this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdentityCard = new System.Windows.Forms.TextBox();
     this.label3 = new System.Windows.Forms.Label();
         this.txtFullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
  this.label1 = new System.Windows.Forms.Label();
      this.btnAdd = new System.Windows.Forms.Button();
        this.btnUpdate = new System.Windows.Forms.Button();
  this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
      this.txtSearch = new System.Windows.Forms.TextBox();
     this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).BeginInit();
          this.groupBox1.SuspendLayout();
  this.SuspendLayout();
  // 
          // dgvGuests
       // 
            this.dgvGuests.AllowUserToAddRows = false;
     this.dgvGuests.AllowUserToDeleteRows = false;
        this.dgvGuests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGuests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
   this.dgvGuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGuests.Location = new System.Drawing.Point(12, 220);
     this.dgvGuests.Name = "dgvGuests";
            this.dgvGuests.ReadOnly = true;
         this.dgvGuests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
          this.dgvGuests.Size = new System.Drawing.Size(860, 320);
   this.dgvGuests.TabIndex = 0;
            this.dgvGuests.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGuests_CellClick);
            // 
  // groupBox1
          // 
            this.groupBox1.Controls.Add(this.txtNationality);
     this.groupBox1.Controls.Add(this.label8);
 this.groupBox1.Controls.Add(this.txtEmail);
   this.groupBox1.Controls.Add(this.label7);
        this.groupBox1.Controls.Add(this.txtAddress);
 this.groupBox1.Controls.Add(this.label6);
          this.groupBox1.Controls.Add(this.txtPhone);
  this.groupBox1.Controls.Add(this.label5);
   this.groupBox1.Controls.Add(this.dtpDOB);
    this.groupBox1.Controls.Add(this.label4);
       this.groupBox1.Controls.Add(this.txtIdentityCard);
  this.groupBox1.Controls.Add(this.label3);
    this.groupBox1.Controls.Add(this.txtFullName);
            this.groupBox1.Controls.Add(this.label2);
    this.groupBox1.Controls.Add(this.txtID);
    this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 160);
  this.groupBox1.TabIndex = 1;
        this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin khách hàng";
            // 
            // txtNationality
            // 
 this.txtNationality.Location = new System.Drawing.Point(430, 120);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(150, 23);
            this.txtNationality.TabIndex = 15;
     // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(360, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Qu?c t?ch:";
     // 
   // txtEmail
            // 
   this.txtEmail.Location = new System.Drawing.Point(100, 120);
    this.txtEmail.Name = "txtEmail";
          this.txtEmail.Size = new System.Drawing.Size(230, 23);
 this.txtEmail.TabIndex = 13;
        // 
            // label7
            // 
            this.label7.AutoSize = true;
        this.label7.Location = new System.Drawing.Point(15, 123);
            this.label7.Name = "label7";
 this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Email:";
      // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(430, 85);
      this.txtAddress.Name = "txtAddress";
        this.txtAddress.Size = new System.Drawing.Size(150, 23);
     this.txtAddress.TabIndex = 11;
            // 
   // label6
            // 
       this.label6.AutoSize = true;
          this.label6.Location = new System.Drawing.Point(360, 88);
          this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
     this.label6.TabIndex = 10;
            this.label6.Text = "Ð?a ch?:";
            // 
        // txtPhone
    // 
   this.txtPhone.Location = new System.Drawing.Point(100, 85);
            this.txtPhone.Name = "txtPhone";
    this.txtPhone.Size = new System.Drawing.Size(230, 23);
   this.txtPhone.TabIndex = 9;
 // 
         // label5
            // 
       this.label5.AutoSize = true;
   this.label5.Location = new System.Drawing.Point(15, 88);
  this.label5.Name = "label5";
       this.label5.Size = new System.Drawing.Size(30, 15);
   this.label5.TabIndex = 8;
            this.label5.Text = "SÐT:";
 // 
  // dtpDOB
            // 
      this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpDOB.Location = new System.Drawing.Point(430, 50);
     this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(150, 23);
       this.dtpDOB.TabIndex = 7;
   // 
      // label4
  // 
        this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(360, 53);
            this.label4.Name = "label4";
  this.label4.Size = new System.Drawing.Size(60, 15);
     this.label4.TabIndex = 6;
      this.label4.Text = "Ngày sinh:";
   // 
     // txtIdentityCard
       // 
            this.txtIdentityCard.Location = new System.Drawing.Point(100, 50);
            this.txtIdentityCard.Name = "txtIdentityCard";
this.txtIdentityCard.Size = new System.Drawing.Size(230, 23);
   this.txtIdentityCard.TabIndex = 5;
     // 
// label3
// 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(15, 53);
        this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
 this.label3.TabIndex = 4;
    this.label3.Text = "CMND/CCCD:";
         // 
     // txtFullName
          // 
            this.txtFullName.Location = new System.Drawing.Point(430, 20);
      this.txtFullName.Name = "txtFullName";
       this.txtFullName.Size = new System.Drawing.Size(150, 23);
       this.txtFullName.TabIndex = 3;
            // 
   // label2
      // 
      this.label2.AutoSize = true;
 this.label2.Location = new System.Drawing.Point(360, 23);
            this.label2.Name = "label2";
   this.label2.Size = new System.Drawing.Size(47, 15);
      this.label2.TabIndex = 2;
   this.label2.Text = "H? tên:";
    // 
      // txtID
      // 
  this.txtID.Location = new System.Drawing.Point(100, 20);
  this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
   this.txtID.Size = new System.Drawing.Size(230, 23);
      this.txtID.TabIndex = 1;
      // 
      // label1
    // 
         this.label1.AutoSize = true;
   this.label1.Location = new System.Drawing.Point(15, 23);
    this.label1.Name = "label1";
    this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 0;
      this.label1.Text = "M? KH:";
  // 
            // btnAdd
   // 
  this.btnAdd.Location = new System.Drawing.Point(630, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
          this.btnAdd.TabIndex = 2;
  this.btnAdd.Text = "Thêm";
    this.btnAdd.UseVisualStyleBackColor = true;
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
          // 
  // btnUpdate
       // 
      this.btnUpdate.Location = new System.Drawing.Point(740, 25);
  this.btnUpdate.Name = "btnUpdate";
       this.btnUpdate.Size = new System.Drawing.Size(100, 30);
    this.btnUpdate.TabIndex = 3;
  this.btnUpdate.Text = "C?p nh?t";
    this.btnUpdate.UseVisualStyleBackColor = true;
   this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
  // 
            // btnDelete
     // 
    this.btnDelete.Location = new System.Drawing.Point(630, 65);
  this.btnDelete.Name = "btnDelete";
     this.btnDelete.Size = new System.Drawing.Size(100, 30);
    this.btnDelete.TabIndex = 4;
    this.btnDelete.Text = "Xóa";
         this.btnDelete.UseVisualStyleBackColor = true;
   this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
         // 
            // btnRefresh
    // 
            this.btnRefresh.Location = new System.Drawing.Point(740, 65);
          this.btnRefresh.Name = "btnRefresh";
         this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 5;
   this.btnRefresh.Text = "Làm m?i";
          this.btnRefresh.UseVisualStyleBackColor = true;
       this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
   // 
   // txtSearch
        // 
   this.txtSearch.Location = new System.Drawing.Point(12, 185);
    this.txtSearch.Name = "txtSearch";
   this.txtSearch.Size = new System.Drawing.Size(250, 23);
       this.txtSearch.TabIndex = 6;
        // 
            // btnSearch
          // 
            this.btnSearch.Location = new System.Drawing.Point(270, 183);
            this.btnSearch.Name = "btnSearch";
        this.btnSearch.Size = new System.Drawing.Size(100, 27);
 this.btnSearch.TabIndex = 7;
    this.btnSearch.Text = "T?m ki?m";
    this.btnSearch.UseVisualStyleBackColor = true;
         this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
    // 
            // btnExport
            // 
 this.btnExport.Location = new System.Drawing.Point(740, 105);
        this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 30);
            this.btnExport.TabIndex = 8;
 this.btnExport.Text = "Xu?t Excel";
            this.btnExport.UseVisualStyleBackColor = true;
   this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
    // FrmGuests
     // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
       this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.btnExport);
        this.Controls.Add(this.btnSearch);
          this.Controls.Add(this.txtSearch);
      this.Controls.Add(this.btnRefresh);
      this.Controls.Add(this.btnDelete);
this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
         this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvGuests);
 this.Name = "FrmGuests";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
   this.Text = "Qu?n l? Khách hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
    this.PerformLayout();
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
