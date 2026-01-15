using HotelManagementSystem.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HotelManagementSystem.BLL.Interfaces
{
    /// <summary>
    /// Interface qu?n l? Đ?t ph?ng
    /// </summary>
    public interface IBookingService
    {
        // Đ?t ph?ng
        Task CreateBookingAsync(int guestId, int roomId, DateTime checkIn, DateTime checkOut, string? note = null);

        // Nh?n ph?ng (Check-in)
        Task CheckInAsync(int bookingId);

        // Tr? ph?ng (Check-out)
        Task CheckOutAsync(int bookingId);

        // H?y đ?t ph?ng
        Task CancelBookingAsync(int bookingId);

        // L?y danh sách booking
        Task<IEnumerable<Booking>> GetBookingsAsync(string keyword = "");
        Task<Booking?> GetBookingByIdAsync(int id);
        Task<IEnumerable<Booking>> GetBookingsByGuestAsync(int guestId);
        Task<IEnumerable<Booking>> GetCurrentBookingsAsync(); // Đang ?

        Task ExportBookingHistoryToExcelAsync(string filePath);
    }
}
