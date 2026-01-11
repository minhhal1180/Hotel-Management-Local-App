using LibraryManagementSystem.BLL.Interfaces;
using LibraryManagementSystem.DAL.Repositories;
using LibraryManagementSystem.Entities.Entities;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibraryManagementSystem.BLL.Services
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

        public IEnumerable<RoomType> GetAllRoomTypes()
  {
 if (_cachedRoomTypes == null)
       {
                _cachedRoomTypes = _unitOfWork.RoomTypeRepository.GetAll().ToList();
    }
            return _cachedRoomTypes;
  }

        public IEnumerable<Room> GetRooms(string keyword = "")
{
    if (_cachedRooms == null)
      {
  _cachedRooms = _unitOfWork.RoomRepository.GetAll(includeProperties: "RoomType").ToList();
     }

            if (string.IsNullOrEmpty(keyword))
    {
    return _cachedRooms;
   }
 else
         {
keyword = keyword.ToLower();
     return _cachedRooms.Where(r => 
   r.RoomNumber.ToLower().Contains(keyword) ||
  (r.RoomType?.RoomTypeName?.ToLower().Contains(keyword) ?? false)
 ).ToList();
 }
        }

        public Room? GetRoomById(int id)
        {
  if (_cachedRooms != null)
    {
    return _cachedRooms.FirstOrDefault(r => r.RoomId == id);
     }
    return _unitOfWork.RoomRepository.GetByID(id);
        }

  public void AddRoom(Room room)
        {
_unitOfWork.RoomRepository.Insert(room);
            _unitOfWork.Save();

     if (_cachedRooms != null)
 {
     if (room.RoomType == null && room.RoomTypeId > 0)
        {
    if (_cachedRoomTypes == null) GetAllRoomTypes();
   room.RoomType = _cachedRoomTypes?.FirstOrDefault(rt => rt.RoomTypeId == room.RoomTypeId);
        }
        _cachedRooms.Add(room);
 }
        }

      public void UpdateRoom(Room room)
 {
            _unitOfWork.RoomRepository.Update(room);
         _unitOfWork.Save();

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
 if (_cachedRoomTypes == null) GetAllRoomTypes();
     itemInRam.RoomType = _cachedRoomTypes?.FirstOrDefault(rt => rt.RoomTypeId == room.RoomTypeId);
        }
                }
    }
        }

   public void DeleteRoom(int id)
     {
            // Kiểm tra phòng có booking không
   var hasBooking = _unitOfWork.BookingRepository.GetAll(
     filter: b => b.RoomId == id
            ).Any();

       if (hasBooking)
       {
 throw new InvalidOperationException("Phòng đã có lịch sử đặt, không thể xóa!");
  }

   _unitOfWork.RoomRepository.Delete(id);
   _unitOfWork.Save();

            if (_cachedRooms != null)
       {
          var item = _cachedRooms.FirstOrDefault(r => r.RoomId == id);
              if (item != null) _cachedRooms.Remove(item);
    }
        }

        public IEnumerable<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut)
  {
     // Lấy danh sách phòng đang bận trong khoảng thời gian
    var busyRoomIds = _unitOfWork.BookingRepository.GetAll(
 filter: b => b.Status != "Cancelled" && b.Status != "CheckedOut" &&
       ((checkIn >= b.CheckInDate && checkIn < b.CheckOutDate) ||
    (checkOut > b.CheckInDate && checkOut <= b.CheckOutDate) ||
 (checkIn <= b.CheckInDate && checkOut >= b.CheckOutDate))
    ).Select(b => b.RoomId).Distinct().ToList();

            // Trả về phòng không bận và đang Available
       if (_cachedRooms == null) RefreshCache();

            return _cachedRooms!.Where(r => 
       r.Status == "Available" && !busyRoomIds.Contains(r.RoomId)
   ).ToList();
    }

     public void ImportRoomsFromExcel(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException("Không tìm thấy file!");

     if (_cachedRoomTypes == null) GetAllRoomTypes();

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
         _unitOfWork.Save();
            }
            RefreshCache();
        }

        public void ExportRoomsToExcel(string filePath)
        {
            var rooms = GetRooms().ToList();
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
         package.SaveAs(new FileInfo(filePath));
     }
        }
    }
}