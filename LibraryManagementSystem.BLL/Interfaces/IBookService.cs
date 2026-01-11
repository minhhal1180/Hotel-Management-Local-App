using LibraryManagementSystem.Entities.Entities;
using System.Collections.Generic;

namespace LibraryManagementSystem.BLL.Interfaces
{
  /// <summary>
    /// Interface quản lý Phòng
    /// </summary>
    public interface IRoomService
    {
        IEnumerable<Room> GetRooms(string keyword = "");
        Room? GetRoomById(int id);
        void AddRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(int id);
        IEnumerable<RoomType> GetAllRoomTypes();
        IEnumerable<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut);
        void ImportRoomsFromExcel(string filePath);
        void ExportRoomsToExcel(string filePath);
        void RefreshCache();
    }
}