using HotelManagementSystem.Entities.Entities;
using System.Collections.Generic;

namespace HotelManagementSystem.BLL.Interfaces
{
    /// <summary>
    /// Interface qu?n l? Hóa đơn thanh toán
    /// </summary>
    public interface IInvoiceService
    {
   // L?p hóa đơn
  Invoice CreateInvoice(int bookingId, decimal discount, string paymentMethod, int? staffId, string? note = null);

        // L?y danh sách hóa đơn
        IEnumerable<Invoice> GetInvoices(string keyword = "");
    Invoice? GetInvoiceById(int id);
   Invoice? GetInvoiceByBooking(int bookingId);

        // Tính ti?n
        decimal CalculateRoomCharge(int bookingId);
        decimal CalculateServiceCharge(int bookingId);

 void ExportInvoiceToExcel(int invoiceId, string filePath);
        void ExportAllInvoicesToExcel(string filePath);
    }
}
