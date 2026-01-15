using HotelManagementSystem.BLL.Interfaces;
using HotelManagementSystem.Entities.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagementSystem.Forms
{
    public partial class FrmInvoice : Form
    {
        private readonly IInvoiceService _invoiceService;
   private readonly IBookingService _bookingService;

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
         // Chỉ lấy các booking đã CheckedOut và chưa có hóa đơn
          var bookings = _bookingService.GetBookings()
     .Where(b => b.Status == "CheckedOut" && b.Invoice == null)
             .Select(b => new
         {
   b.BookingId,
  DisplayText = $"#{b.BookingId} - {b.Guest?.FullName} - Phòng {b.Room?.RoomNumber}"
           }).ToList();

    cboBooking.DataSource = bookings;
      cboBooking.DisplayMember = "DisplayText";
        cboBooking.ValueMember = "BookingId";
    cboBooking.SelectedIndex = -1;
            }
      catch (Exception ex)
     {
           MessageBox.Show("Lỗi tải booking: " + ex.Message);
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

    if (dgvInvoices.Columns["InvoiceId"] != null) dgvInvoices.Columns["InvoiceId"].HeaderText = "Mã HĐ";
     if (dgvInvoices.Columns["GuestName"] != null) dgvInvoices.Columns["GuestName"].HeaderText = "Khách hàng";
           if (dgvInvoices.Columns["RoomNumber"] != null) dgvInvoices.Columns["RoomNumber"].HeaderText = "Phòng";
      if (dgvInvoices.Columns["RoomCharge"] != null) dgvInvoices.Columns["RoomCharge"].HeaderText = "Tiền phòng";
       if (dgvInvoices.Columns["ServiceCharge"] != null) dgvInvoices.Columns["ServiceCharge"].HeaderText = "Tiền DV";
  if (dgvInvoices.Columns["Discount"] != null) dgvInvoices.Columns["Discount"].HeaderText = "Giảm giá";
     if (dgvInvoices.Columns["TotalAmount"] != null) dgvInvoices.Columns["TotalAmount"].HeaderText = "Tổng cộng";
if (dgvInvoices.Columns["PaymentMethod"] != null) dgvInvoices.Columns["PaymentMethod"].HeaderText = "Thanh toán";
  if (dgvInvoices.Columns["PaymentDate"] != null) dgvInvoices.Columns["PaymentDate"].HeaderText = "Ngày thanh toán";
    }
        catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải hóa đơn: " + ex.Message);
    }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
     {
  if (cboBooking.SelectedValue == null)
    {
     MessageBox.Show("Vui lòng chọn booking!");
  return;
     }

    try
   {
                int bookingId = (int)cboBooking.SelectedValue;
        decimal roomCharge = _invoiceService.CalculateRoomCharge(bookingId);
    decimal serviceCharge = _invoiceService.CalculateServiceCharge(bookingId);
                decimal discount = decimal.TryParse(txtDiscount.Text, out decimal d) ? d : 0;
                decimal total = roomCharge + serviceCharge - discount;

                lblRoomCharge.Text = $"Tiền phòng: {roomCharge:N0}";
      lblServiceCharge.Text = $"Tiền dịch vụ: {serviceCharge:N0}";
      lblTotal.Text = $"TỔNG CỘNG: {total:N0}";
            }
            catch (Exception ex)
       {
           MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

      private void btnCreate_Click(object sender, EventArgs e)
   {
   if (cboBooking.SelectedValue == null)
            {
 MessageBox.Show("Vui lòng chọn booking!");
      return;
  }

            try
            {
   int bookingId = (int)cboBooking.SelectedValue;
         decimal discount = decimal.TryParse(txtDiscount.Text, out decimal d) ? d : 0;
        string paymentMethod = cboPaymentMethod.Text;

          _invoiceService.CreateInvoice(bookingId, discount, paymentMethod, null, txtNote.Text.Trim());
                MessageBox.Show("Lập hóa đơn thành công!");
   LoadInvoices();
LoadBookingsForInvoice();
    ResetForm();
       }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnExportOne_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
     {
    MessageBox.Show("Vui lòng chọn hóa đơn cần xuất!");
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
           MessageBox.Show("Xuất hóa đơn thành công!");
      }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
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
      MessageBox.Show("Xuất danh sách hóa đơn thành công!");
          }
           catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
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
  lblRoomCharge.Text = "Tiền phòng: 0";
 lblServiceCharge.Text = "Tiền dịch vụ: 0";
        lblTotal.Text = "TỔNG CỘNG: 0";
        }
    }
}
