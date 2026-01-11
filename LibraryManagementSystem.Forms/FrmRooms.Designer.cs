namespace LibraryManagementSystem.Forms
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
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
   this.txtDescription = new System.Windows.Forms.TextBox();
     this.label6 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
        this.label5 = new System.Windows.Forms.Label();
            this.txtFloor = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.cboRoomType = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
this.txtRoomNumber = new System.Windows.Forms.TextBox();
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
      ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.groupBox1.SuspendLayout();
        this.SuspendLayout();
        // 
            // dgvRooms
            // 
            this.dgvRooms.AllowUserToAddRows = false;
            this.dgvRooms.AllowUserToDeleteRows = false;
        this.dgvRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
   | System.Windows.Forms.AnchorStyles.Left) 
          | System.Windows.Forms.AnchorStyles.Right)));
        this.dgvRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Location = new System.Drawing.Point(12, 200);
         this.dgvRooms.Name = "dgvRooms";
     this.dgvRooms.ReadOnly = true;
            this.dgvRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRooms.Size = new System.Drawing.Size(760, 340);
            this.dgvRooms.TabIndex = 0;
            this.dgvRooms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRooms_CellClick);
            // 
 // groupBox1
            // 
       this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label6);
  this.groupBox1.Controls.Add(this.cboStatus);
            this.groupBox1.Controls.Add(this.label5);
    this.groupBox1.Controls.Add(this.txtFloor);
            this.groupBox1.Controls.Add(this.label4);
 this.groupBox1.Controls.Add(this.cboRoomType);
          this.groupBox1.Controls.Add(this.label3);
  this.groupBox1.Controls.Add(this.txtRoomNumber);
    this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtID);
         this.groupBox1.Controls.Add(this.label1);
        this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(500, 140);
this.groupBox1.TabIndex = 1;
       this.groupBox1.TabStop = false;
    this.groupBox1.Text = "Thông tin ph?ng";
     // 
  // txtDescription
 // 
            this.txtDescription.Location = new System.Drawing.Point(330, 100);
 this.txtDescription.Name = "txtDescription";
this.txtDescription.Size = new System.Drawing.Size(150, 23);
          this.txtDescription.TabIndex = 11;
      // 
            // label6
            // 
            this.label6.AutoSize = true;
     this.label6.Location = new System.Drawing.Point(270, 103);
            this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(44, 15);
        this.label6.TabIndex = 10;
          this.label6.Text = "Mô t?:";
            // 
         // cboStatus
        // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    this.cboStatus.FormattingEnabled = true;
    this.cboStatus.Items.AddRange(new object[] {
            "Available",
    "Occupied",
     "Maintenance"});
          this.cboStatus.Location = new System.Drawing.Point(90, 100);
   this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(150, 23);
      this.cboStatus.TabIndex = 9;
      // 
            // label5
         // 
        this.label5.AutoSize = true;
       this.label5.Location = new System.Drawing.Point(15, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
   this.label5.TabIndex = 8;
      this.label5.Text = "Tr?ng thái:";
            // 
    // txtFloor
        // 
this.txtFloor.Location = new System.Drawing.Point(330, 60);
   this.txtFloor.Name = "txtFloor";
       this.txtFloor.Size = new System.Drawing.Size(150, 23);
         this.txtFloor.TabIndex = 7;
       // 
            // label4
         // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 63);
   this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
     this.label4.TabIndex = 6;
            this.label4.Text = "T?ng:";
      // 
     // cboRoomType
        // 
            this.cboRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboRoomType.FormattingEnabled = true;
      this.cboRoomType.Location = new System.Drawing.Point(90, 60);
            this.cboRoomType.Name = "cboRoomType";
      this.cboRoomType.Size = new System.Drawing.Size(150, 23);
            this.cboRoomType.TabIndex = 5;
// 
            // label3
            // 
    this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 63);
    this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
        this.label3.TabIndex = 4;
  this.label3.Text = "Lo?i ph?ng:";
            // 
      // txtRoomNumber
            // 
   this.txtRoomNumber.Location = new System.Drawing.Point(330, 25);
            this.txtRoomNumber.Name = "txtRoomNumber";
     this.txtRoomNumber.Size = new System.Drawing.Size(150, 23);
            this.txtRoomNumber.TabIndex = 3;
    // 
            // label2
  // 
            this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(270, 28);
     this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(58, 15);
         this.label2.TabIndex = 2;
   this.label2.Text = "S? ph?ng:";
            // 
       // txtID
  // 
            this.txtID.Location = new System.Drawing.Point(90, 25);
         this.txtID.Name = "txtID";
          this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(150, 23);
         this.txtID.TabIndex = 1;
            // 
        // label1
       // 
            this.label1.AutoSize = true;
    this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "M? ph?ng:";
     // 
            // btnAdd
 // 
            this.btnAdd.Location = new System.Drawing.Point(530, 25);
 this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(100, 30);
  this.btnAdd.TabIndex = 2;
     this.btnAdd.Text = "Thêm";
    this.btnAdd.UseVisualStyleBackColor = true;
         this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
       // btnUpdate
         // 
         this.btnUpdate.Location = new System.Drawing.Point(640, 25);
     this.btnUpdate.Name = "btnUpdate";
         this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 3;
  this.btnUpdate.Text = "C?p nh?t";
            this.btnUpdate.UseVisualStyleBackColor = true;
        this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
        // 
            // btnDelete
            // 
        this.btnDelete.Location = new System.Drawing.Point(530, 65);
         this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xóa";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
     // 
            // btnRefresh
   // 
            this.btnRefresh.Location = new System.Drawing.Point(640, 65);
   this.btnRefresh.Name = "btnRefresh";
 this.btnRefresh.Size = new System.Drawing.Size(100, 30);
      this.btnRefresh.TabIndex = 5;
      this.btnRefresh.Text = "Làm m?i";
       this.btnRefresh.UseVisualStyleBackColor = true;
  this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
   // 
         // txtSearch
 // 
    this.txtSearch.Location = new System.Drawing.Point(12, 165);
  this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 23);
            this.txtSearch.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(270, 163);
       this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 27);
         this.btnSearch.TabIndex = 7;
        this.btnSearch.Text = "T?m ki?m";
     this.btnSearch.UseVisualStyleBackColor = true;
      this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
         // 
     // btnExport
            // 
        this.btnExport.Location = new System.Drawing.Point(640, 105);
            this.btnExport.Name = "btnExport";
   this.btnExport.Size = new System.Drawing.Size(100, 30);
            this.btnExport.TabIndex = 8;
      this.btnExport.Text = "Xu?t Excel";
          this.btnExport.UseVisualStyleBackColor = true;
 this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
        // FrmRooms
      // 
   this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
  this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnExport);
       this.Controls.Add(this.btnSearch);
this.Controls.Add(this.txtSearch);
        this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
         this.Controls.Add(this.btnUpdate);
 this.Controls.Add(this.btnAdd);
     this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.dgvRooms);
          this.Name = "FrmRooms";
     this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    this.Text = "Qu?n l? Ph?ng";
         ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.groupBox1.ResumeLayout(false);
     this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
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
