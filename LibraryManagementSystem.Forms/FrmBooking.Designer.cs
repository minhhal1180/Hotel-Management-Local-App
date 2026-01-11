namespace LibraryManagementSystem.Forms
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
          this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
       this.txtNote = new System.Windows.Forms.TextBox();
  this.label6 = new System.Windows.Forms.Label();
      this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
    this.label4 = new System.Windows.Forms.Label();
            this.cboRoom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboGuest = new System.Windows.Forms.ComboBox();
   this.label2 = new System.Windows.Forms.Label();
   this.txtID = new System.Windows.Forms.TextBox();
     this.label1 = new System.Windows.Forms.Label();
    this.btnBooking = new System.Windows.Forms.Button();
 this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
  this.btnCancel = new System.Windows.Forms.Button();
        this.btnRefresh = new System.Windows.Forms.Button();
        this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
      this.lblAvailableRooms = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
this.groupBox1.SuspendLayout();
        this.SuspendLayout();
     // 
            // dgvBookings
            // 
      this.dgvBookings.AllowUserToAddRows = false;
         this.dgvBookings.AllowUserToDeleteRows = false;
            this.dgvBookings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
  | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
 this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Location = new System.Drawing.Point(12, 220);
 this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.ReadOnly = true;
     this.dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvBookings.Size = new System.Drawing.Size(860, 320);
    this.dgvBookings.TabIndex = 0;
      this.dgvBookings.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookings_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNote);
       this.groupBox1.Controls.Add(this.label6);
          this.groupBox1.Controls.Add(this.dtpCheckOut);
            this.groupBox1.Controls.Add(this.label5);
   this.groupBox1.Controls.Add(this.dtpCheckIn);
       this.groupBox1.Controls.Add(this.label4);
     this.groupBox1.Controls.Add(this.cboRoom);
       this.groupBox1.Controls.Add(this.label3);
     this.groupBox1.Controls.Add(this.cboGuest);
            this.groupBox1.Controls.Add(this.label2);
     this.groupBox1.Controls.Add(this.txtID);
 this.groupBox1.Controls.Add(this.label1);
          this.groupBox1.Controls.Add(this.lblAvailableRooms);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
     this.groupBox1.Size = new System.Drawing.Size(600, 160);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ð?t ph?ng m?i";
            // 
      // txtNote
    // 
  this.txtNote.Location = new System.Drawing.Point(430, 85);
     this.txtNote.Name = "txtNote";
     this.txtNote.Size = new System.Drawing.Size(150, 23);
            this.txtNote.TabIndex = 13;
     // 
      // label6
            // 
            this.label6.AutoSize = true;
          this.label6.Location = new System.Drawing.Point(360, 88);
            this.label6.Name = "label6";
       this.label6.Size = new System.Drawing.Size(53, 15);
        this.label6.TabIndex = 12;
          this.label6.Text = "Ghi chú:";
    // 
            // dtpCheckOut
     // 
            this.dtpCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckOut.Location = new System.Drawing.Point(100, 85);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(150, 23);
            this.dtpCheckOut.TabIndex = 11;
          this.dtpCheckOut.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label5
         // 
     this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 88);
    this.label5.Name = "label5";
     this.label5.Size = new System.Drawing.Size(65, 15);
       this.label5.TabIndex = 10;
this.label5.Text = "Check-out:";
     // 
       // dtpCheckIn
            // 
    this.dtpCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckIn.Location = new System.Drawing.Point(430, 50);
    this.dtpCheckIn.Name = "dtpCheckIn";
 this.dtpCheckIn.Size = new System.Drawing.Size(150, 23);
            this.dtpCheckIn.TabIndex = 9;
            this.dtpCheckIn.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
      // 
        // label4
      // 
            this.label4.AutoSize = true;
     this.label4.Location = new System.Drawing.Point(360, 53);
        this.label4.Name = "label4";
this.label4.Size = new System.Drawing.Size(56, 15);
         this.label4.TabIndex = 8;
            this.label4.Text = "Check-in:";
            // 
         // cboRoom
            // 
            this.cboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboRoom.FormattingEnabled = true;
            this.cboRoom.Location = new System.Drawing.Point(100, 50);
            this.cboRoom.Name = "cboRoom";
         this.cboRoom.Size = new System.Drawing.Size(230, 23);
     this.cboRoom.TabIndex = 7;
    // 
    // label3
    // 
            this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(15, 53);
            this.label3.Name = "label3";
     this.label3.Size = new System.Drawing.Size(44, 15);
    this.label3.TabIndex = 6;
   this.label3.Text = "Ph?ng:";
    // 
     // cboGuest
            // 
 this.cboGuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
 this.cboGuest.FormattingEnabled = true;
 this.cboGuest.Location = new System.Drawing.Point(100, 20);
  this.cboGuest.Name = "cboGuest";
            this.cboGuest.Size = new System.Drawing.Size(230, 23);
          this.cboGuest.TabIndex = 5;
     // 
   // label2
       // 
   this.label2.AutoSize = true;
       this.label2.Location = new System.Drawing.Point(15, 23);
       this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(76, 15);
      this.label2.TabIndex = 4;
       this.label2.Text = "Khách hàng:";
   // 
        // txtID
      // 
            this.txtID.Location = new System.Drawing.Point(430, 20);
this.txtID.Name = "txtID";
   this.txtID.ReadOnly = true;
   this.txtID.Size = new System.Drawing.Size(150, 23);
     this.txtID.TabIndex = 3;
            // 
      // label1
            // 
   this.label1.AutoSize = true;
   this.label1.Location = new System.Drawing.Point(360, 23);
    this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(48, 15);
    this.label1.TabIndex = 2;
         this.label1.Text = "M? ÐP:";
          // 
            // lblAvailableRooms
            // 
            this.lblAvailableRooms.AutoSize = true;
        this.lblAvailableRooms.ForeColor = System.Drawing.Color.Blue;
     this.lblAvailableRooms.Location = new System.Drawing.Point(15, 125);
  this.lblAvailableRooms.Name = "lblAvailableRooms";
this.lblAvailableRooms.Size = new System.Drawing.Size(150, 15);
            this.lblAvailableRooms.TabIndex = 14;
this.lblAvailableRooms.Text = "Ph?ng tr?ng: Ch?n ngày ð? xem";
            // 
            // btnBooking
            // 
            this.btnBooking.Location = new System.Drawing.Point(630, 25);
         this.btnBooking.Name = "btnBooking";
this.btnBooking.Size = new System.Drawing.Size(100, 30);
          this.btnBooking.TabIndex = 2;
  this.btnBooking.Text = "Ð?t ph?ng";
    this.btnBooking.UseVisualStyleBackColor = true;
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
        // 
   // btnCheckIn
    // 
  this.btnCheckIn.Location = new System.Drawing.Point(740, 25);
      this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(100, 30);
            this.btnCheckIn.TabIndex = 3;
     this.btnCheckIn.Text = "Nh?n ph?ng";
         this.btnCheckIn.UseVisualStyleBackColor = true;
      this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
     // 
        // btnCheckOut
      // 
   this.btnCheckOut.Location = new System.Drawing.Point(630, 65);
  this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(100, 30);
  this.btnCheckOut.TabIndex = 4;
            this.btnCheckOut.Text = "Tr? ph?ng";
          this.btnCheckOut.UseVisualStyleBackColor = true;
 this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(740, 65);
  this.btnCancel.Name = "btnCancel";
     this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "H?y ð?t";
      this.btnCancel.UseVisualStyleBackColor = true;
 this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
    // 
        // btnRefresh
            // 
     this.btnRefresh.Location = new System.Drawing.Point(630, 105);
         this.btnRefresh.Name = "btnRefresh";
       this.btnRefresh.Size = new System.Drawing.Size(100, 30);
   this.btnRefresh.TabIndex = 6;
 this.btnRefresh.Text = "Làm m?i";
this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
          // txtSearch
    // 
    this.txtSearch.Location = new System.Drawing.Point(12, 185);
            this.txtSearch.Name = "txtSearch";
     this.txtSearch.Size = new System.Drawing.Size(250, 23);
  this.txtSearch.TabIndex = 7;
            // 
      // btnSearch
  // 
            this.btnSearch.Location = new System.Drawing.Point(270, 183);
          this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(100, 27);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "T?m ki?m";
        this.btnSearch.UseVisualStyleBackColor = true;
     this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExport
        // 
     this.btnExport.Location = new System.Drawing.Point(740, 105);
        this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 30);
            this.btnExport.TabIndex = 9;
          this.btnExport.Text = "Xu?t Excel";
            this.btnExport.UseVisualStyleBackColor = true;
  this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FrmBooking
     // 
   this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.ClientSize = new System.Drawing.Size(884, 561);
    this.Controls.Add(this.btnExport);
  this.Controls.Add(this.btnSearch);
  this.Controls.Add(this.txtSearch);
   this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnCheckOut);
          this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnBooking);
   this.Controls.Add(this.groupBox1);
       this.Controls.Add(this.dgvBookings);
     this.Name = "FrmBooking";
    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
   this.Text = "Qu?n l? Ð?t ph?ng";
       ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
       this.ResumeLayout(false);
            this.PerformLayout();
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
        private System.Windows.Forms.Label lblAvailableRooms;
   private System.Windows.Forms.Button btnBooking;
      private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
  private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;
    }
}
