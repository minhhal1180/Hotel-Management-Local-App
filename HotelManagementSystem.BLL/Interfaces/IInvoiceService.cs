using HotelManagementSystem.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagementSystem.BLL.Interfaces
{
    /// <summary>
    /// Interface qu?n l? Hóa đơn thanh toán
    /// </summary>
    public interface IInvoiceService
    {
        // L?p hóa đơn
        Task<Invoice> CreateInvoiceAsync(int bookingId, decimal discount, string paymentMethod, int? staffId, string? note = null);

        // L?y danh sách hóa đơn
        Task<IEnumerable<Invoice>> GetInvoicesAsync(string keyword = "");
        Task<Invoice?> GetInvoiceByIdAsync(int id);
        Task<Invoice?> GetInvoiceByBookingAsync(int bookingId);

        // Tính ti?n
        Task<decimal> CalculateRoomChargeAsync(int bookingId);
        Task<decimal> CalculateServiceChargeAsync(int bookingId);

        Task ExportInvoiceToExcelAsync(int invoiceId, string filePath);
        Task ExportAllInvoicesToExcelAsync(string filePath);
        void RefreshCache();
        Task RefreshCacheAsync();
    }
}
