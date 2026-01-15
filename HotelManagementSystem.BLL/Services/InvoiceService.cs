using HotelManagementSystem.BLL.Interfaces;
using HotelManagementSystem.DAL.Repositories;
using HotelManagementSystem.Entities.Entities;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task RefreshCacheAsync()
        {
            var invoices = await _unitOfWork.InvoiceRepository.GetAllAsync(
                includeProperties: "Booking,Booking.Guest,Booking.Room,Booking.Room.RoomType,Staff"
            );
            _cachedInvoices = invoices.ToList();
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesAsync(string keyword = "")
        {
            if (_cachedInvoices == null)
            {
                await RefreshCacheAsync();
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

        public async Task<Invoice?> GetInvoiceByIdAsync(int id)
        {
            if (_cachedInvoices == null) await RefreshCacheAsync();
            return _cachedInvoices!.FirstOrDefault(i => i.InvoiceId == id);
        }

        public async Task<Invoice?> GetInvoiceByBookingAsync(int bookingId)
        {
            if (_cachedInvoices == null) await RefreshCacheAsync();
            return _cachedInvoices!.FirstOrDefault(i => i.BookingId == bookingId);
        }

        public async Task<decimal> CalculateRoomChargeAsync(int bookingId)
        {
            var bookings = await _unitOfWork.BookingRepository.GetAllAsync(
                filter: b => b.BookingId == bookingId,
                includeProperties: "Room,Room.RoomType"
            );
            var booking = bookings.FirstOrDefault();

            if (booking == null) return 0;

            // Tính số đêm thực tế
            DateTime checkOut = booking.ActualCheckOut ?? booking.CheckOutDate;
            int nights = (int)(checkOut - booking.CheckInDate).TotalDays;
            if (nights <= 0) nights = 1;

            decimal pricePerNight = booking.Room?.RoomType?.PricePerNight ?? 0;
            return nights * pricePerNight;
        }

        public async Task<decimal> CalculateServiceChargeAsync(int bookingId)
        {
            var services = await _unitOfWork.BookingServiceRepository.GetAllAsync(
                filter: bs => bs.BookingId == bookingId
            );

            return services.Sum(s => s.Quantity * s.UnitPrice);
        }

        public async Task<Invoice> CreateInvoiceAsync(int bookingId, decimal discount, string paymentMethod, int? staffId, string? note = null)
        {
            var booking = await _unitOfWork.BookingRepository.GetByIDAsync(bookingId);
            if (booking == null) throw new Exception("Không tìm thấy booking!");

            // Kiểm tra đã có hóa đơn chưa
            var existingInvoices = await _unitOfWork.InvoiceRepository.GetAllAsync(
                filter: i => i.BookingId == bookingId
            );
            var existingInvoice = existingInvoices.FirstOrDefault();

            if (existingInvoice != null) throw new Exception("Booking này đã có hóa đơn!");

            decimal roomCharge = await CalculateRoomChargeAsync(bookingId);
            decimal serviceCharge = await CalculateServiceChargeAsync(bookingId);
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
            await _unitOfWork.SaveAsync();

            await RefreshCacheAsync();
            return invoice;
        }

        public async Task ExportInvoiceToExcelAsync(int invoiceId, string filePath)
        {
            var invoice = await GetInvoiceByIdAsync(invoiceId);
            if (invoice == null) throw new Exception("Không tìm thấy hóa đơn!");

            var bookingServices = await _unitOfWork.BookingServiceRepository.GetAllAsync(
                filter: bs => bs.BookingId == invoice.BookingId,
                includeProperties: "Service"
            );

            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("Hóa đơn");

                // Thông tin chung
                sheet.Cells[1, 1].Value = "HÓA ĐƠN THANH TOÁN";
                sheet.Cells[2, 1].Value = $"Mã hóa đơn: {invoice.InvoiceId}";
                sheet.Cells[3, 1].Value = $"Ngày: {invoice.PaymentDate:dd/MM/yyyy}";
                sheet.Cells[4, 1].Value = $"Khách hàng: {invoice.Booking?.Guest?.FullName}";
                sheet.Cells[5, 1].Value = $"Phòng: {invoice.Booking?.Room?.RoomNumber}";

                // Chi tiết tiền phòng
                sheet.Cells[7, 1].Value = "TIỀN PHÒNG";
                sheet.Cells[7, 2].Value = invoice.RoomCharge;

                // Chi tiết dịch vụ
                int row = 9;
                sheet.Cells[row, 1].Value = "DỊCH VỤ SỬ DỤNG";
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
                sheet.Cells[row, 1].Value = "Tiền dịch vụ:";
                sheet.Cells[row, 2].Value = invoice.ServiceCharge;

                row++;
                sheet.Cells[row, 1].Value = "Giảm giá:";
                sheet.Cells[row, 2].Value = invoice.Discount;

                row++;
                sheet.Cells[row, 1].Value = "TỔNG CỘNG:";
                sheet.Cells[row, 2].Value = invoice.TotalAmount;

                row++;
                sheet.Cells[row, 1].Value = $"Phương thức: {invoice.PaymentMethod}";

                sheet.Cells.AutoFitColumns();
                await package.SaveAsAsync(new FileInfo(filePath));
            }
        }

        public async Task ExportAllInvoicesToExcelAsync(string filePath)
        {
            var invoices = (await GetInvoicesAsync("")).ToList();

            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("Danh sách Hóa đơn");

                string[] headers = { "Mã HĐ", "Khách hàng", "Phòng", "Tiền phòng", "Tiền DV", "Giảm giá", "Tổng cộng", "Thanh toán", "Ngày" };
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
                await package.SaveAsAsync(new FileInfo(filePath));
            }
        }
    }
}
