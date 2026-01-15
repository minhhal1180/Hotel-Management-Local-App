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
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private static List<Booking>? _cachedBookings = null;

        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void RefreshCache()
        {
            _cachedBookings = _unitOfWork.BookingRepository.GetAll(
                includeProperties: "Guest,Room,Room.RoomType,BookingServices,Invoice",
                orderBy: q => q.OrderByDescending(b => b.CreatedDate)
            ).ToList();
        }

        public IEnumerable<Booking> GetBookings(string keyword = "")
        {
            if (_cachedBookings == null)
            {
                RefreshCache();
            }

            if (string.IsNullOrEmpty(keyword))
            {
                return _cachedBookings!;
            }

            keyword = keyword.ToLower();
            return _cachedBookings!.Where(b =>
                (b.Guest?.FullName.ToLower().Contains(keyword) ?? false) ||
                (b.Room?.RoomNumber.ToLower().Contains(keyword) ?? false)
            ).ToList();
        }

        public Booking? GetBookingById(int id)
        {
            if (_cachedBookings == null) RefreshCache();
            return _cachedBookings!.FirstOrDefault(b => b.BookingId == id);
        }

        public IEnumerable<Booking> GetBookingsByGuest(int guestId)
        {
            if (_cachedBookings == null) RefreshCache();
            return _cachedBookings!.Where(b => b.GuestId == guestId).ToList();
        }

        public IEnumerable<Booking> GetCurrentBookings()
        {
            if (_cachedBookings == null) RefreshCache();
            return _cachedBookings!.Where(b => b.Status == "CheckedIn").ToList();
        }

        public void CreateBooking(int guestId, int roomId, DateTime checkIn, DateTime checkOut, string? note = null)
        {
            var guest = _unitOfWork.GuestRepository.GetByID(guestId);
            if (guest == null) throw new Exception("Không t?m th?y khách hàng!");

            var room = _unitOfWork.RoomRepository.GetAll(
                filter: r => r.RoomId == roomId,
                includeProperties: "RoomType"
            ).FirstOrDefault();
            if (room == null) throw new Exception("Không t?m th?y ph?ng!");

            // Ki?m tra ph?ng có tr?ng trong kho?ng th?i gian không
            var isBooked = _unitOfWork.BookingRepository.GetAll(
                filter: b => b.RoomId == roomId &&
                             b.Status != "Cancelled" && b.Status != "CheckedOut" &&
                             ((checkIn >= b.CheckInDate && checkIn < b.CheckOutDate) ||
                              (checkOut > b.CheckInDate && checkOut <= b.CheckOutDate) ||
                              (checkIn <= b.CheckInDate && checkOut >= b.CheckOutDate))
            ).Any();

            if (isBooked) throw new Exception("Ph?ng đ? đư?c đ?t trong kho?ng th?i gian này!");

            // Tính s? đêm và t?ng ti?n ph?ng
            int nights = (int)(checkOut - checkIn).TotalDays;
            if (nights <= 0) nights = 1;
            decimal totalAmount = nights * (room.RoomType?.PricePerNight ?? 0);

            using var transaction = _unitOfWork.BeginTransaction();
            try
            {
                var booking = new Booking
                {
                    GuestId = guestId,
                    RoomId = roomId,
                    CheckInDate = checkIn,
                    CheckOutDate = checkOut,
                    Status = "Booked",
                    TotalAmount = totalAmount,
                    Note = note,
                    CreatedDate = DateTime.Now
                };
                _unitOfWork.BookingRepository.Insert(booking);
                _unitOfWork.Save();
                _unitOfWork.Commit();

                RefreshCache();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public void CheckIn(int bookingId)
        {
            var booking = _unitOfWork.BookingRepository.GetByID(bookingId);
            if (booking == null) throw new Exception("Không t?m th?y booking!");
            if (booking.Status != "Booked") throw new Exception("Booking không ? tr?ng thái ch? nh?n ph?ng!");

            using var transaction = _unitOfWork.BeginTransaction();
            try
            {
                booking.Status = "CheckedIn";
                booking.CheckInDate = DateTime.Now; // C?p nh?t ngày nh?n ph?ng th?c t?
                _unitOfWork.BookingRepository.Update(booking);

                // C?p nh?t tr?ng thái ph?ng
                var room = _unitOfWork.RoomRepository.GetByID(booking.RoomId);
                if (room != null)
                {
                    room.Status = "Occupied";
                    _unitOfWork.RoomRepository.Update(room);
                }

                _unitOfWork.Save();
                _unitOfWork.Commit();
                RefreshCache();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public void CheckOut(int bookingId)
        {
            var booking = _unitOfWork.BookingRepository.GetByID(bookingId);
            if (booking == null) throw new Exception("Không t?m th?y booking!");
            if (booking.Status != "CheckedIn") throw new Exception("Khách chưa nh?n ph?ng!");

            using var transaction = _unitOfWork.BeginTransaction();
            try
            {
                booking.Status = "CheckedOut";
                booking.ActualCheckOut = DateTime.Now;
                _unitOfWork.BookingRepository.Update(booking);

                // C?p nh?t tr?ng thái ph?ng
                var room = _unitOfWork.RoomRepository.GetByID(booking.RoomId);
                if (room != null)
                {
                    room.Status = "Available";
                    _unitOfWork.RoomRepository.Update(room);
                }

                _unitOfWork.Save();
                _unitOfWork.Commit();
                RefreshCache();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public void CancelBooking(int bookingId)
        {
            var booking = _unitOfWork.BookingRepository.GetByID(bookingId);
            if (booking == null) throw new Exception("Không t?m th?y booking!");
            if (booking.Status == "CheckedIn") throw new Exception("Không th? h?y booking khi khách đang ?!");
            if (booking.Status == "CheckedOut") throw new Exception("Booking đ? hoàn t?t!");

            booking.Status = "Cancelled";
            _unitOfWork.BookingRepository.Update(booking);
            _unitOfWork.Save();
            RefreshCache();
        }

        public void ExportBookingHistoryToExcel(string filePath)
        {
            var bookings = GetBookings("").ToList();

            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("L?ch s? Đ?t ph?ng");

                string[] headers = { "M? ĐP", "Khách hàng", "Ph?ng", "Lo?i ph?ng", "Ngày đ?t", "Check-in", "Check-out", "Ti?n ph?ng", "Tr?ng thái" };
                for (int i = 0; i < headers.Length; i++)
                    sheet.Cells[1, i + 1].Value = headers[i];

                for (int i = 0; i < bookings.Count; i++)
                {
                    var b = bookings[i];
                    sheet.Cells[i + 2, 1].Value = b.BookingId;
                    sheet.Cells[i + 2, 2].Value = b.Guest?.FullName;
                    sheet.Cells[i + 2, 3].Value = b.Room?.RoomNumber;
                    sheet.Cells[i + 2, 4].Value = b.Room?.RoomType?.RoomTypeName;
                    sheet.Cells[i + 2, 5].Value = b.CreatedDate.ToString("dd/MM/yyyy");
                    sheet.Cells[i + 2, 6].Value = b.CheckInDate.ToString("dd/MM/yyyy");
                    sheet.Cells[i + 2, 7].Value = b.CheckOutDate.ToString("dd/MM/yyyy");
                    sheet.Cells[i + 2, 8].Value = b.TotalAmount;
                    sheet.Cells[i + 2, 9].Value = b.Status;
                }

                sheet.Cells.AutoFitColumns();
                package.SaveAs(new FileInfo(filePath));
            }
        }
    }
}
