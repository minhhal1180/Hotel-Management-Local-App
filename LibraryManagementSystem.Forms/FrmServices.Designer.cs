namespace LibraryManagementSystem.Forms
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
   this.dgvServices = new System.Windows.Forms.DataGridView();
    this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.chkActive = new System.Windows.Forms.CheckBox();
       this.txtDescription = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
       this.txtPrice = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
 this.txtServiceName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
      this.txtID = new System.Windows.Forms.TextBox();
   this.label1 = new System.Windows.Forms.Label();
 this.btnAdd = new System.Windows.Forms.Button();
     this.btnUpdate = new System.Windows.Forms.Button();
 this.btnDelete = new System.Windows.Forms.Button();
          this.btnRefresh = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
   this.groupBox1.SuspendLayout();
   this.SuspendLayout();
     // 
   // dgvServices
// 
   this.dgvServices.AllowUserToAddRows = false;
     this.dgvServices.AllowUserToDeleteRows = false;
   this.dgvServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
         | System.Windows.Forms.AnchorStyles.Left) 
 | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dgvServices.Location = new System.Drawing.Point(12, 160);
            this.dgvServices.Name = "dgvServices";
this.dgvServices.ReadOnly = true;
         this.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServices.Size = new System.Drawing.Size(560, 290);
            this.dgvServices.TabIndex = 0;
       this.dgvServices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServices_CellClick);
  // 
      // groupBox1
     // 
            this.groupBox1.Controls.Add(this.chkActive);
            this.groupBox1.Controls.Add(this.txtDescription);
  this.groupBox1.Controls.Add(this.label4);
 this.groupBox1.Controls.Add(this.txtPrice);
   this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtServiceName);
       this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtID);
       this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
     this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 130);
  this.groupBox1.TabIndex = 1;
    this.groupBox1.TabStop = false;
     this.groupBox1.Text = "Thông tin d?ch v?";
        // 
    // chkActive
            // 
            this.chkActive.AutoSize = true;
     this.chkActive.Checked = true;
        this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
  this.chkActive.Location = new System.Drawing.Point(280, 95);
       this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(81, 19);
            this.chkActive.TabIndex = 8;
    this.chkActive.Text = "Ho?t ð?ng";
   this.chkActive.UseVisualStyleBackColor = true;
  // 
            // txtDescription
    // 
            this.txtDescription.Location = new System.Drawing.Point(100, 92);
            this.txtDescription.Name = "txtDescription";
    this.txtDescription.Size = new System.Drawing.Size(160, 23);
            this.txtDescription.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 95);
        this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(44, 15);
       this.label4.TabIndex = 6;
            this.label4.Text = "Mô t?:";
      // 
            // txtPrice
     // 
       this.txtPrice.Location = new System.Drawing.Point(280, 57);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 23);
            this.txtPrice.TabIndex = 5;
            // 
         // label3
    // 
            this.label3.AutoSize = true;
   this.label3.Location = new System.Drawing.Point(230, 60);
    this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
    this.label3.TabIndex = 4;
 this.label3.Text = "Giá:";
      // 
            // txtServiceName
    // 
     this.txtServiceName.Location = new System.Drawing.Point(100, 57);
          this.txtServiceName.Name = "txtServiceName";
       this.txtServiceName.Size = new System.Drawing.Size(120, 23);
 this.txtServiceName.TabIndex = 3;
            // 
     // label2
      // 
     this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
     this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
      this.label2.TabIndex = 2;
            this.label2.Text = "Tên d?ch v?:";
            // 
            // txtID
    // 
            this.txtID.Location = new System.Drawing.Point(100, 22);
 this.txtID.Name = "txtID";
      this.txtID.ReadOnly = true;
      this.txtID.Size = new System.Drawing.Size(120, 23);
            this.txtID.TabIndex = 1;
 // 
       // label1
       // 
        this.label1.AutoSize = true;
    this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
this.label1.TabIndex = 0;
        this.label1.Text = "M? DV:";
      // 
 // btnAdd
   // 
            this.btnAdd.Location = new System.Drawing.Point(430, 25);
    this.btnAdd.Name = "btnAdd";
     this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Thêm";
      this.btnAdd.UseVisualStyleBackColor = true;
     this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
  // btnUpdate
    // 
        this.btnUpdate.Location = new System.Drawing.Point(430, 65);
  this.btnUpdate.Name = "btnUpdate";
  this.btnUpdate.Size = new System.Drawing.Size(100, 30);
        this.btnUpdate.TabIndex = 3;
   this.btnUpdate.Text = "C?p nh?t";
     this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
    // 
     // btnDelete
          // 
      this.btnDelete.Location = new System.Drawing.Point(430, 105);
            this.btnDelete.Name = "btnDelete";
  this.btnDelete.Size = new System.Drawing.Size(100, 30);
        this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xóa";
          this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
    // 
            // btnRefresh
    // 
         this.btnRefresh.Location = new System.Drawing.Point(540, 25);
       this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(32, 30);
            this.btnRefresh.TabIndex = 5;
   this.btnRefresh.Text = "??";
     this.btnRefresh.UseVisualStyleBackColor = true;
         this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
 // 
// FrmServices
// 
       this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.btnRefresh);
          this.Controls.Add(this.btnDelete);
       this.Controls.Add(this.btnUpdate);
        this.Controls.Add(this.btnAdd);
   this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.dgvServices);
     this.Name = "FrmServices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Qu?n l? D?ch v?";
   ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.groupBox1.ResumeLayout(false);
    this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
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
