using HotelManagementSystem.BLL.Interfaces;
using HotelManagementSystem.DAL.Repositories;
using HotelManagementSystem.Entities.Entities;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.BLL.Services
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;

        // Cache trên RAM
        private static List<Room>? _cachedRooms = null;
        private static List<RoomType>? _cachedRoomTypes = null;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void RefreshCache()
        {
            _cachedRooms = _unitOfWork.RoomRepository.GetAll(includeProperties: "RoomType").ToList();
            _cachedRoomTypes = _unitOfWork.RoomTypeRepository.GetAll().ToList();
        }

        public async Task RefreshCacheAsync()
        {
            var rooms = await _unitOfWork.RoomRepository.GetAllAsync(includeProperties: "RoomType");
            _cachedRooms = rooms.ToList();
            var types = await _unitOfWork.RoomTypeRepository.GetAllAsync();
            _cachedRoomTypes = types.ToList();
        }

        public async Task<IEnumerable<RoomType>> GetAllRoomTypesAsync()
        {
            if (_cachedRoomTypes == null)
            {
                var types = await _unitOfWork.RoomTypeRepository.GetAllAsync();
                _cachedRoomTypes = types.ToList();
            }
            return _cachedRoomTypes;
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync(string keyword = "")
        {
            if (_cachedRooms == null)
            {
                await RefreshCacheAsync();
            }

            if (string.IsNullOrEmpty(keyword))
            {
                return _cachedRooms!;
            }
            else
            {
                keyword = keyword.ToLower();
                return _cachedRooms!.Where(r =>
                    r.RoomNumber.ToLower().Contains(keyword) ||
                    (r.RoomType?.RoomTypeName?.ToLower().Contains(keyword) ?? false)
                ).ToList();
            }
        }

        public async Task<Room?> GetRoomByIdAsync(int id)
        {
            if (_cachedRooms != null)
            {
                return _cachedRooms.FirstOrDefault(r => r.RoomId == id);
            }
            return await _unitOfWork.RoomRepository.GetByIDAsync(id);
        }

        public async Task AddRoomAsync(Room room)
        {
            _unitOfWork.RoomRepository.Insert(room);
            await _unitOfWork.SaveAsync();

            if (_cachedRooms != null)
            {
                if (room.RoomType == null && room.RoomTypeId > 0)
                {
                    if (_cachedRoomTypes == null) await GetAllRoomTypesAsync();
                    room.RoomType = _cachedRoomTypes?.FirstOrDefault(rt => rt.RoomTypeId == room.RoomTypeId)!;
                }
                _cachedRooms.Add(room);
            }
        }

        public async Task UpdateRoomAsync(Room room)
        {
            _unitOfWork.RoomRepository.Update(room);
            await _unitOfWork.SaveAsync();

            if (_cachedRooms != null)
            {
                var itemInRam = _cachedRooms.FirstOrDefault(r => r.RoomId == room.RoomId);
                if (itemInRam != null)
                {
                    itemInRam.RoomNumber = room.RoomNumber;
                    itemInRam.RoomTypeId = room.RoomTypeId;
                    itemInRam.Floor = room.Floor;
                    itemInRam.Status = room.Status;
                    itemInRam.Description = room.Description;

                    if (itemInRam.RoomType?.RoomTypeId != room.RoomTypeId)
                    {
                        if (_cachedRoomTypes == null) await GetAllRoomTypesAsync();
                        itemInRam.RoomType = _cachedRoomTypes?.FirstOrDefault(rt => rt.RoomTypeId == room.RoomTypeId)!;
                    }
                }
            }
        }

        public async Task DeleteRoomAsync(int id)
        {
            var bookings = await _unitOfWork.BookingRepository.GetAllAsync(filter: b => b.RoomId == id);
            var hasBooking = bookings.Any();

            if (hasBooking)
            {
                throw new InvalidOperationException("Phòng đã có lịch sử đặt, không thể xóa!");
            }

            await _unitOfWork.RoomRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();

            if (_cachedRooms != null)
            {
                var item = _cachedRooms.FirstOrDefault(r => r.RoomId == id);
                if (item != null) _cachedRooms.Remove(item);
            }
        }

        public async Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime checkIn, DateTime checkOut)
        {
            var busyBookings = await _unitOfWork.BookingRepository.GetAllAsync(
                filter: b => b.Status != "Cancelled" && b.Status != "CheckedOut" &&
                             ((checkIn >= b.CheckInDate && checkIn < b.CheckOutDate) ||
                              (checkOut > b.CheckInDate && checkOut <= b.CheckOutDate) ||
                              (checkIn <= b.CheckInDate && checkOut >= b.CheckOutDate))
            );
            var busyRoomIds = busyBookings.Select(b => b.RoomId).Distinct().ToList();

            if (_cachedRooms == null) await RefreshCacheAsync();

            return _cachedRooms!.Where(r =>
                r.Status == "Available" && !busyRoomIds.Contains(r.RoomId)
            ).ToList();
        }

        public async Task ImportRoomsFromExcelAsync(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException("Không tìm thấy file!");

            if (_cachedRoomTypes == null) await GetAllRoomTypesAsync();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    try
                    {
                        string roomNumber = worksheet.Cells[row, 1].Text;
                        if (string.IsNullOrEmpty(roomNumber)) continue;

                        string roomTypeName = worksheet.Cells[row, 2].Text;
                        var roomType = _cachedRoomTypes?.FirstOrDefault(rt =>
                            rt.RoomTypeName.Equals(roomTypeName, StringComparison.OrdinalIgnoreCase));
                        int roomTypeId = roomType?.RoomTypeId ?? 1;

                        var room = new Room
                        {
                            RoomNumber = roomNumber,
                            RoomTypeId = roomTypeId,
                            Floor = int.TryParse(worksheet.Cells[row, 3].Text, out int f) ? f : 1,
                            Status = "Available",
                            Description = worksheet.Cells[row, 4].Text
                        };

                        _unitOfWork.RoomRepository.Insert(room);
                    }
                    catch { }
                }
                await _unitOfWork.SaveAsync();
            }
            await RefreshCacheAsync();
        }

        public async Task ExportRoomsToExcelAsync(string filePath)
        {
            var rooms = (await GetRoomsAsync()).ToList();
            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("Danh sách Phòng");

                string[] headers = { "Mã phòng", "Số phòng", "Loại phòng", "Tầng", "Trạng thái", "Giá/đêm", "Mô tả" };
                for (int i = 0; i < headers.Length; i++)
                    sheet.Cells[1, i + 1].Value = headers[i];

                for (int i = 0; i < rooms.Count; i++)
                {
                    var r = rooms[i];
                    sheet.Cells[i + 2, 1].Value = r.RoomId;
                    sheet.Cells[i + 2, 2].Value = r.RoomNumber;
                    sheet.Cells[i + 2, 3].Value = r.RoomType?.RoomTypeName;
                    sheet.Cells[i + 2, 4].Value = r.Floor;
                    sheet.Cells[i + 2, 5].Value = r.Status;
                    sheet.Cells[i + 2, 6].Value = r.RoomType?.PricePerNight;
                    sheet.Cells[i + 2, 7].Value = r.Description;
                }

                sheet.Cells.AutoFitColumns();
                await package.SaveAsAsync(new FileInfo(filePath));
            }
        }
    }
}
