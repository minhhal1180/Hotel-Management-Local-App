using HotelManagementSystem.Entities.Entities;
using System.Collections.Generic;

namespace HotelManagementSystem.BLL.Interfaces
{
    /// <summary>
    /// Interface qu?n l? D?ch v?
    /// </summary>
    public interface IServiceService
    {
        IEnumerable<Service> GetServices(string keyword = "");
        Service? GetServiceById(int id);
        void AddService(Service service);
        void UpdateService(Service service);
        void DeleteService(int id);

        // Thêm d?ch v? vào booking
        void AddServiceToBooking(int bookingId, int serviceId, int quantity, string? note = null);
        void RemoveServiceFromBooking(int bookingServiceId);

        // L?y d?ch v? c?a booking
        IEnumerable<BookingService> GetBookingServices(int bookingId);
        void RefreshCache();
    }
}
