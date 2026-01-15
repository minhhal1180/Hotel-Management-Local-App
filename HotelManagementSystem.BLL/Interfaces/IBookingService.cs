using HotelManagementSystem.Entities.Entities;
using System.Collections.Generic;

namespace HotelManagementSystem.BLL.Interfaces
{
    /// <summary>
    /// Interface qu?n l? Đ?t ph?ng
    /// </summary>
    public interface IBookingService
    {
        // Đ?t ph?ng
        void CreateBooking(int guestId, int roomId, DateTime checkIn, DateTime checkOut, string? note = null);

        // Nh?n ph?ng (Check-in)
        void CheckIn(int bookingId);

        // Tr? ph?ng (Check-out)
        void CheckOut(int bookingId);

        // H?y đ?t ph?ng
        void CancelBooking(int bookingId);

        // L?y danh sách booking
        IEnumerable<Booking> GetBookings(string keyword = "");
        Booking? GetBookingById(int id);
        IEnumerable<Booking> GetBookingsByGuest(int guestId);
        IEnumerable<Booking> GetCurrentBookings(); // Đang ?

        void ExportBookingHistoryToExcel(string filePath);
    }
}
