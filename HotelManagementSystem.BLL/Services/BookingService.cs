using HotelManagementSystem.BLL.Interfaces;
using HotelManagementSystem.DAL;
using HotelManagementSystem.DAL.Repositories;
using HotelManagementSystem.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IDbContextFactory<HotelContext> _contextFactory;
        private static List<Booking>? _cachedBookings = null;

        public BookingService(IDbContextFactory<HotelContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        private IUnitOfWork CreateUnitOfWork() => new UnitOfWork(_contextFactory);

        public void RefreshCache()
        {
            using var unitOfWork = CreateUnitOfWork();
            _cachedBookings = unitOfWork.BookingRepository.GetAll(
                includeProperties: "Guest,Room,Room.RoomType,BookingServices,Invoice",
                orderBy: q => q.OrderByDescending(b => b.CreatedDate)
            ).ToList();
        }

        public async Task RefreshCacheAsync()
        {
            await using var unitOfWork = CreateUnitOfWork();
            var bookings = await unitOfWork.BookingRepository.GetAllAsync(
                includeProperties: "Guest,Room,Room.RoomType,BookingServices,Invoice",
                orderBy: q => q.OrderByDescending(b => b.CreatedDate)
            );
            _cachedBookings = bookings.ToList();
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync(string keyword = "")
        {
            if (_cachedBookings == null)
            {
                await RefreshCacheAsync();
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

        public async Task<Booking?> GetBookingByIdAsync(int id)
        {
            if (_cachedBookings == null) await RefreshCacheAsync();
            return _cachedBookings!.FirstOrDefault(b => b.BookingId == id);
        }

        public async Task<IEnumerable<Booking>> GetBookingsByGuestAsync(int guestId)
        {
            if (_cachedBookings == null) await RefreshCacheAsync();
            return _cachedBookings!.Where(b => b.GuestId == guestId).ToList();
        }

        public async Task<IEnumerable<Booking>> GetCurrentBookingsAsync()
        {
            if (_cachedBookings == null) await RefreshCacheAsync();
            return _cachedBookings!.Where(b => b.Status == "CheckedIn").ToList();
        }

        public async Task CreateBookingAsync(int guestId, int roomId, DateTime checkIn, DateTime checkOut, string? note = null)
        {
            await using var unitOfWork = CreateUnitOfWork();
            var guest = await unitOfWork.GuestRepository.GetByIDAsync(guestId);
            if (guest == null) throw new Exception("Không tìm thấy khách hàng!");

            var roomsList = await unitOfWork.RoomRepository.GetAllAsync(
                filter: r => r.RoomId == roomId,
                includeProperties: "RoomType"
            );
            var room = roomsList.ToList().FirstOrDefault();
            if (room == null) throw new Exception("Không tìm thấy phòng!");

            // Kiểm tra phòng có trống trong khoảng thời gian không
            var existingBookingsList = await unitOfWork.BookingRepository.GetAllAsync(
                filter: b => b.RoomId == roomId &&
                             b.Status != "Cancelled" && b.Status != "CheckedOut" &&
                             ((checkIn >= b.CheckInDate && checkIn < b.CheckOutDate) ||
                              (checkOut > b.CheckInDate && checkOut <= b.CheckOutDate) ||
                              (checkIn <= b.CheckInDate && checkOut >= b.CheckOutDate))
            );
            var isBooked = existingBookingsList.ToList().Any();

            if (isBooked) throw new Exception("Phòng đã được đặt trong khoảng thời gian này!");

            // Tính số đêm và tổng tiền phòng
            int nights = (int)(checkOut - checkIn).TotalDays;
            if (nights <= 0) nights = 1;
            decimal totalAmount = nights * (room.RoomType?.PricePerNight ?? 0);

            await using var transaction = await unitOfWork.BeginTransactionAsync();
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
                unitOfWork.BookingRepository.Insert(booking);
                await unitOfWork.SaveAsync();
                await unitOfWork.CommitAsync();

                await RefreshCacheAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task CheckInAsync(int bookingId)
        {
            await using var unitOfWork = CreateUnitOfWork();
            await using var transaction = await unitOfWork.BeginTransactionAsync();
            try
            {
                var booking = await unitOfWork.BookingRepository.GetByIDAsync(bookingId);
                if (booking == null) throw new Exception("Không tìm thấy booking!");
                if (booking.Status != "Booked") throw new Exception("Booking không ở trạng thái chờ nhận phòng!");

                booking.Status = "CheckedIn";
                booking.CheckInDate = DateTime.Now; // Cập nhật ngày nhận phòng thực tế
                unitOfWork.BookingRepository.Update(booking);

                // Cập nhật trạng thái phòng
                var room = await unitOfWork.RoomRepository.GetByIDAsync(booking.RoomId);
                if (room != null)
                {
                    room.Status = "Occupied";
                    unitOfWork.RoomRepository.Update(room);
                }

                await unitOfWork.SaveAsync();
                await unitOfWork.CommitAsync();
                await RefreshCacheAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task CheckOutAsync(int bookingId)
        {
            await using var unitOfWork = CreateUnitOfWork();
            await using var transaction = await unitOfWork.BeginTransactionAsync();
            try
            {
                var booking = await unitOfWork.BookingRepository.GetByIDAsync(bookingId);
                if (booking == null) throw new Exception("Không tìm thấy booking!");
                if (booking.Status != "CheckedIn") throw new Exception("Khách chưa nhận phòng!");

                booking.Status = "CheckedOut";
                booking.ActualCheckOut = DateTime.Now;
                unitOfWork.BookingRepository.Update(booking);

                // Cập nhật trạng thái phòng
                var room = await unitOfWork.RoomRepository.GetByIDAsync(booking.RoomId);
                if (room != null)
                {
                    room.Status = "Available";
                    unitOfWork.RoomRepository.Update(room);
                }

                await unitOfWork.SaveAsync();
                await unitOfWork.CommitAsync();
                await RefreshCacheAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task CancelBookingAsync(int bookingId)
        {
            await using var unitOfWork = CreateUnitOfWork();
            var booking = await unitOfWork.BookingRepository.GetByIDAsync(bookingId);
            if (booking == null) throw new Exception("Không tìm thấy booking!");
            if (booking.Status == "CheckedIn") throw new Exception("Không thể hủy booking khi khách đang ở!");
            if (booking.Status == "CheckedOut") throw new Exception("Booking đã hoàn tất!");

            booking.Status = "Cancelled";
            unitOfWork.BookingRepository.Update(booking);
            await unitOfWork.SaveAsync();
            await RefreshCacheAsync();
        }

        public async Task ExportBookingHistoryToExcelAsync(string filePath)
        {
            var bookings = (await GetBookingsAsync("")).ToList();

            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("Lịch sử Đặt phòng");

                string[] headers = { "Mã ĐP", "Khách hàng", "Phòng", "Loại phòng", "Ngày đặt", "Check-in", "Check-out", "Tiền phòng", "Trạng thái" };
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
                await package.SaveAsAsync(new FileInfo(filePath));
            }
        }
    }
}
