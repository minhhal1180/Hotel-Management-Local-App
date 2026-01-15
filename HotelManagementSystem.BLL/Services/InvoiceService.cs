using HotelManagementSystem.BLL.Interfaces;
using HotelManagementSystem.DAL.Repositories;
using HotelManagementSystem.Entities.Entities;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HotelManagementSystem.BLL.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
    private static List<Invoice>? _cachedInvoices = null;

 public InvoiceService(IUnitOfWork unitOfWork)
      {
            _unitOfWork = unitOfWork;
        }

        public void RefreshCache()
  {
      _cachedInvoices = _unitOfWork.InvoiceRepository.GetAll(
     includeProperties: "Booking,Booking.Guest,Booking.Room,Booking.Room.RoomType,Staff"
            ).ToList();
        }

      public IEnumerable<Invoice> GetInvoices(string keyword = "")
        {
   if (_cachedInvoices == null)
       {
RefreshCache();
         }

   if (string.IsNullOrEmpty(keyword))
            {
 return _cachedInvoices!;
   }

            keyword = keyword.ToLower();
          return _cachedInvoices!.Where(i =>
                (i.Booking?.Guest?.FullName.ToLower().Contains(keyword) ?? false) ||
        (i.Booking?.Room?.RoomNumber.ToLower().Contains(keyword) ?? false)
 ).ToList();
        }

        public Invoice? GetInvoiceById(int id)
   {
      if (_cachedInvoices == null) RefreshCache();
            return _cachedInvoices!.FirstOrDefault(i => i.InvoiceId == id);
        }

        public Invoice? GetInvoiceByBooking(int bookingId)
        {
            if (_cachedInvoices == null) RefreshCache();
       return _cachedInvoices!.FirstOrDefault(i => i.BookingId == bookingId);
        }

      public decimal CalculateRoomCharge(int bookingId)
        {
  var booking = _unitOfWork.BookingRepository.GetAll(
     filter: b => b.BookingId == bookingId,
  includeProperties: "Room,Room.RoomType"
    ).FirstOrDefault();

        if (booking == null) return 0;

   // Tính s? đêm th?c t?
    DateTime checkOut = booking.ActualCheckOut ?? booking.CheckOutDate;
 int nights = (int)(checkOut - booking.CheckInDate).TotalDays;
    if (nights <= 0) nights = 1;

     decimal pricePerNight = booking.Room?.RoomType?.PricePerNight ?? 0;
  return nights * pricePerNight;
      }

  public decimal CalculateServiceCharge(int bookingId)
        {
            var services = _unitOfWork.BookingServiceRepository.GetAll(
      filter: bs => bs.BookingId == bookingId
            ).ToList();

          return services.Sum(s => s.Quantity * s.UnitPrice);
        }

        public Invoice CreateInvoice(int bookingId, decimal discount, string paymentMethod, int? staffId, string? note = null)
        {
            var booking = _unitOfWork.BookingRepository.GetByID(bookingId);
            if (booking == null) throw new Exception("Không t?m th?y booking!");

            // Ki?m tra đ? có hóa đơn chưa
   var existingInvoice = _unitOfWork.InvoiceRepository.GetAll(
    filter: i => i.BookingId == bookingId
    ).FirstOrDefault();

     if (existingInvoice != null) throw new Exception("Booking này đ? có hóa đơn!");

            decimal roomCharge = CalculateRoomCharge(bookingId);
  decimal serviceCharge = CalculateServiceCharge(bookingId);
            decimal totalAmount = roomCharge + serviceCharge - discount;

            var invoice = new Invoice
        {
BookingId = bookingId,
        RoomCharge = roomCharge,
        ServiceCharge = serviceCharge,
        Discount = discount,
  TotalAmount = totalAmount,
    PaymentMethod = paymentMethod,
    PaymentDate = DateTime.Now,
     Note = note,
     CreatedBy = staffId
    };

            _unitOfWork.InvoiceRepository.Insert(invoice);
 _unitOfWork.Save();

            RefreshCache();
   return invoice;
 }

        public void ExportInvoiceToExcel(int invoiceId, string filePath)
        {
         var invoice = GetInvoiceById(invoiceId);
    if (invoice == null) throw new Exception("Không t?m th?y hóa đơn!");

        var bookingServices = _unitOfWork.BookingServiceRepository.GetAll(
     filter: bs => bs.BookingId == invoice.BookingId,
           includeProperties: "Service"
            ).ToList();

            using (var package = new ExcelPackage())
          {
                var sheet = package.Workbook.Worksheets.Add("Hóa đơn");

         // Thông tin chung
          sheet.Cells[1, 1].Value = "HÓA ĐƠN THANH TOÁN";
                sheet.Cells[2, 1].Value = $"M? hóa đơn: {invoice.InvoiceId}";
      sheet.Cells[3, 1].Value = $"Ngày: {invoice.PaymentDate:dd/MM/yyyy}";
            sheet.Cells[4, 1].Value = $"Khách hàng: {invoice.Booking?.Guest?.FullName}";
   sheet.Cells[5, 1].Value = $"Ph?ng: {invoice.Booking?.Room?.RoomNumber}";

     // Chi ti?t ti?n ph?ng
    sheet.Cells[7, 1].Value = "TI?N PH?NG";
            sheet.Cells[7, 2].Value = invoice.RoomCharge;

     // Chi ti?t d?ch v?
    int row = 9;
     sheet.Cells[row, 1].Value = "D?CH V? S? D?NG";
          row++;
   foreach (var bs in bookingServices)
    {
        sheet.Cells[row, 1].Value = bs.Service?.ServiceName;
      sheet.Cells[row, 2].Value = bs.Quantity;
         sheet.Cells[row, 3].Value = bs.UnitPrice;
          sheet.Cells[row, 4].Value = bs.Quantity * bs.UnitPrice;
       row++;
       }

 row++;
    sheet.Cells[row, 1].Value = "Ti?n d?ch v?:";
 sheet.Cells[row, 2].Value = invoice.ServiceCharge;

    row++;
    sheet.Cells[row, 1].Value = "Gi?m giá:";
          sheet.Cells[row, 2].Value = invoice.Discount;

             row++;
                sheet.Cells[row, 1].Value = "T?NG C?NG:";
          sheet.Cells[row, 2].Value = invoice.TotalAmount;

  row++;
       sheet.Cells[row, 1].Value = $"Phương th?c: {invoice.PaymentMethod}";

          sheet.Cells.AutoFitColumns();
      package.SaveAs(new FileInfo(filePath));
      }
        }

 public void ExportAllInvoicesToExcel(string filePath)
 {
            var invoices = GetInvoices("").ToList();

   using (var package = new ExcelPackage())
      {
     var sheet = package.Workbook.Worksheets.Add("Danh sách Hóa đơn");

          string[] headers = { "M? HĐ", "Khách hàng", "Ph?ng", "Ti?n ph?ng", "Ti?n DV", "Gi?m giá", "T?ng c?ng", "Thanh toán", "Ngày" };
       for (int i = 0; i < headers.Length; i++)
          sheet.Cells[1, i + 1].Value = headers[i];

       for (int i = 0; i < invoices.Count; i++)
                {
           var inv = invoices[i];
       sheet.Cells[i + 2, 1].Value = inv.InvoiceId;
 sheet.Cells[i + 2, 2].Value = inv.Booking?.Guest?.FullName;
   sheet.Cells[i + 2, 3].Value = inv.Booking?.Room?.RoomNumber;
    sheet.Cells[i + 2, 4].Value = inv.RoomCharge;
     sheet.Cells[i + 2, 5].Value = inv.ServiceCharge;
   sheet.Cells[i + 2, 6].Value = inv.Discount;
  sheet.Cells[i + 2, 7].Value = inv.TotalAmount;
  sheet.Cells[i + 2, 8].Value = inv.PaymentMethod;
      sheet.Cells[i + 2, 9].Value = inv.PaymentDate.ToString("dd/MM/yyyy");
      }

    sheet.Cells.AutoFitColumns();
    package.SaveAs(new FileInfo(filePath));
    }
        }
    }
}
