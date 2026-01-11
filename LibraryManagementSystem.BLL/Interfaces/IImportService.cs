using LibraryManagementSystem.Entities.Entities;
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.BLL.Interfaces
{
    /// <summary>
    /// Interface quản lý Dịch vụ
    /// </summary>
    public interface IServiceService
    {
        IEnumerable<Service> GetServices(string keyword = "");
        Service? GetServiceById(int id);
        void AddService(Service service);
        void UpdateService(Service service);
        void DeleteService(int id);

        // Thêm dịch vụ vào booking
        void AddServiceToBooking(int bookingId, int serviceId, int quantity, string? note = null);
        void RemoveServiceFromBooking(int bookingServiceId);

        // Lấy dịch vụ của booking
        IEnumerable<BookingService> GetBookingServices(int bookingId);
        void RefreshCache();
    }
}