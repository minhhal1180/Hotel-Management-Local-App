using LibraryManagementSystem.BLL.Interfaces;
using LibraryManagementSystem.Entities.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryManagementSystem.Forms
{
 public partial class FrmInvoice : Form
    {
        private readonly IInvoiceService _invoiceService;
 private readonly IBookingService _bookingService;
  private int? _currentStaffId; // ID nhân viên ðang ðãng nh?p

   public FrmInvoice(IInvoiceService invoiceService, IBookingService bookingService)
        {
 InitializeComponent();
_invoiceService = invoiceService;
            _bookingService = bookingService;
   this.Load += FrmInvoice_Load;
        }

   private void FrmInvoice_Load(object? sender, EventArgs e)
  {
      LoadBookingsForInvoice();
   LoadInvoices();
    cboPaymentMethod.SelectedIndex = 0;
     }

        private void LoadBookingsForInvoice()
 {
      try
       {
   // Ch? l?y các booking ð? CheckedOut và chýa có hóa ðõn
      var bookings = _bookingService.GetBookings()
  .Where(b => b.Status == "CheckedOut" && b.Invoice == null)
     .Select(b => new
         {
    b.BookingId,
    DisplayText = $"#{b.BookingId} - {b.Guest?.FullName} - Ph?ng {b.Room?.RoomNumber}"
   }).ToList();

    cboBooking.DataSource = bookings;
          cboBooking.DisplayMember = "DisplayText";
    cboBooking.ValueMember = "BookingId";
    cboBooking.SelectedIndex = -1;
 }
 catch (Exception ex)
  {
         MessageBox.Show("L?i t?i booking: " + ex.Message);
    }
        }

   private void LoadInvoices()
 {
 try
   {
        var invoices = _invoiceService.GetInvoices();
      var displayList = invoices.Select(i => new
     {
        i.InvoiceId,
   GuestName = i.Booking?.Guest?.FullName,
        RoomNumber = i.Booking?.Room?.RoomNumber,
   i.RoomCharge,
 i.ServiceCharge,
     i.Discount,
      i.TotalAmount,
      i.PaymentMethod,
          PaymentDate = i.PaymentDate.ToString("dd/MM/yyyy HH:mm")
    }).ToList();

       dgvInvoices.DataSource = displayList;

    if (dgvInvoices.Columns["InvoiceId"] != null) dgvInvoices.Columns["InvoiceId"].HeaderText = "M? HÐ";
         if (dgvInvoices.Columns["GuestName"] != null) dgvInvoices.Columns["GuestName"].HeaderText = "Khách hàng";
   if (dgvInvoices.Columns["RoomNumber"] != null) dgvInvoices.Columns["RoomNumber"].HeaderText = "Ph?ng";
       if (dgvInvoices.Columns["RoomCharge"] != null) dgvInvoices.Columns["RoomCharge"].HeaderText = "Ti?n ph?ng";
    if (dgvInvoices.Columns["ServiceCharge"] != null) dgvInvoices.Columns["ServiceCharge"].HeaderText = "Ti?n DV";
    if (dgvInvoices.Columns["Discount"] != null) dgvInvoices.Columns["Discount"].HeaderText = "Gi?m giá";
           if (dgvInvoices.Columns["TotalAmount"] != null) dgvInvoices.Columns["TotalAmount"].HeaderText = "T?ng c?ng";
       if (dgvInvoices.Columns["PaymentMethod"] != null) dgvInvoices.Columns["PaymentMethod"].HeaderText = "Thanh toán";
        if (dgvInvoices.Columns["PaymentDate"] != null) dgvInvoices.Columns["PaymentDate"].HeaderText = "Ngày thanh toán";
     }
            catch (Exception ex)
            {
   MessageBox.Show("L?i t?i hóa ðõn: " + ex.Message);
    }
        }

   private void btnCalculate_Click(object sender, EventArgs e)
        {
    if (cboBooking.SelectedValue == null)
    {
        MessageBox.Show("Vui l?ng ch?n booking!");
return;
   }

            try
         {
  int bookingId = (int)cboBooking.SelectedValue;
  decimal roomCharge = _invoiceService.CalculateRoomCharge(bookingId);
            decimal serviceCharge = _invoiceService.CalculateServiceCharge(bookingId);
  decimal discount = decimal.TryParse(txtDiscount.Text, out decimal d) ? d : 0;
       decimal total = roomCharge + serviceCharge - discount;

             lblRoomCharge.Text = $"Ti?n ph?ng: {roomCharge:N0}";
     lblServiceCharge.Text = $"Ti?n d?ch v?: {serviceCharge:N0}";
        lblTotal.Text = $"T?NG C?NG: {total:N0}";
     }
         catch (Exception ex)
       {
     MessageBox.Show("L?i: " + ex.Message);
      }
        }

 private void btnCreate_Click(object sender, EventArgs e)
        {
  if (cboBooking.SelectedValue == null)
     {
         MessageBox.Show("Vui l?ng ch?n booking!");
  return;
     }

      try
   {
      int bookingId = (int)cboBooking.SelectedValue;
    decimal discount = decimal.TryParse(txtDiscount.Text, out decimal d) ? d : 0;
    string paymentMethod = cboPaymentMethod.Text;

        _invoiceService.CreateInvoice(bookingId, discount, paymentMethod, _currentStaffId, txtNote.Text.Trim());
  MessageBox.Show("L?p hóa ðõn thành công!");
    LoadInvoices();
           LoadBookingsForInvoice();
 ResetForm();
 }
catch (Exception ex)
    {
      MessageBox.Show("L?i: " + ex.Message);
}
        }

        private void btnExportOne_Click(object sender, EventArgs e)
  {
if (string.IsNullOrEmpty(txtID.Text))
  {
    MessageBox.Show("Vui l?ng ch?n hóa ðõn c?n xu?t!");
        return;
  }

  using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel|*.xlsx", FileName = $"HoaDon_{txtID.Text}.xlsx" })
         {
        if (sfd.ShowDialog() == DialogResult.OK)
    {
    try
        {
int invoiceId = int.Parse(txtID.Text);
             _invoiceService.ExportInvoiceToExcel(invoiceId, sfd.FileName);
     MessageBox.Show("Xu?t hóa ðõn thành công!");
        }
   catch (Exception ex) { MessageBox.Show("L?i: " + ex.Message); }
      }
   }
        }

      private void btnExportAll_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel|*.xlsx", FileName = "DanhSachHoaDon.xlsx" })
   {
  if (sfd.ShowDialog() == DialogResult.OK)
      {
    try
 {
       _invoiceService.ExportAllInvoicesToExcel(sfd.FileName);
  MessageBox.Show("Xu?t danh sách hóa ðõn thành công!");
           }
          catch (Exception ex) { MessageBox.Show("L?i: " + ex.Message); }
}
  }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
 {
       LoadInvoices();
      LoadBookingsForInvoice();
   ResetForm();
        }

        private void dgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
  {
       if (e.RowIndex >= 0)
        {
   DataGridViewRow row = dgvInvoices.Rows[e.RowIndex];
     txtID.Text = row.Cells["InvoiceId"].Value?.ToString();
     }
   }

        private void ResetForm()
   {
      txtID.Clear();
 txtDiscount.Text = "0";
      txtNote.Clear();
    cboBooking.SelectedIndex = -1;
       cboPaymentMethod.SelectedIndex = 0;
lblRoomCharge.Text = "Ti?n ph?ng: 0";
      lblServiceCharge.Text = "Ti?n d?ch v?: 0";
     lblTotal.Text = "T?NG C?NG: 0";
    }
    }
}
