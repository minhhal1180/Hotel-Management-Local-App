using LibraryManagementSystem.Entities.Entities;
using System.Collections.Generic;

namespace LibraryManagementSystem.BLL.Interfaces
{
  /// <summary>
    /// Interface quản lý Đặt phòng
    /// </summary>
    public interface IBookingService
 {
 // Đặt phòng
        void CreateBooking(int guestId, int roomId, DateTime checkIn, DateTime checkOut, string? note = null);

 // Nhận phòng (Check-in)
        void CheckIn(int bookingId);

     // Trả phòng (Check-out)
        void CheckOut(int bookingId);

        // Hủy đặt phòng
 void CancelBooking(int bookingId);

  // Lấy danh sách booking
        IEnumerable<Booking> GetBookings(string keyword = "");
Booking? GetBookingById(int id);
    IEnumerable<Booking> GetBookingsByGuest(int guestId);
 IEnumerable<Booking> GetCurrentBookings(); // Đang ở

        void ExportBookingHistoryToExcel(string filePath);
    }
}