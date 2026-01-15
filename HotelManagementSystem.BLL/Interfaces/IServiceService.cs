using HotelManagementSystem.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagementSystem.BLL.Interfaces
{
    /// <summary>
    /// Interface qu?n l? D?ch v?
    /// </summary>
    public interface IServiceService
    {
        Task<IEnumerable<Service>> GetServicesAsync(string keyword = "");
        Task<Service?> GetServiceByIdAsync(int id);
        Task AddServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);

        // Thêm d?ch v? vào booking
        Task AddServiceToBookingAsync(int bookingId, int serviceId, int quantity, string? note = null);
        Task RemoveServiceFromBookingAsync(int bookingServiceId);

        // Lấy dịch vụ của booking
        Task<IEnumerable<BookingService>> GetBookingServicesAsync(int bookingId);
        void RefreshCache();
        Task RefreshCacheAsync();
    }
}
