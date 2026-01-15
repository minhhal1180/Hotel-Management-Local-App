using HotelManagementSystem.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HotelManagementSystem.BLL.Interfaces
{
    /// <summary>
    /// Interface qu?n l? Ph?ng
    /// </summary>
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetRoomsAsync(string keyword = "");
        Task<Room?> GetRoomByIdAsync(int id);
        Task AddRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task DeleteRoomAsync(int id);
        Task<IEnumerable<RoomType>> GetAllRoomTypesAsync();
        Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime checkIn, DateTime checkOut);
        Task ImportRoomsFromExcelAsync(string filePath);
        Task ExportRoomsToExcelAsync(string filePath);
        void RefreshCache();        Task RefreshCacheAsync();    }
}
