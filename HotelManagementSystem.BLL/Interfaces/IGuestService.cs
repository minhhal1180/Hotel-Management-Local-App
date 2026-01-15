using HotelManagementSystem.Entities.Entities;
using System.Collections.Generic;

namespace HotelManagementSystem.BLL.Interfaces
{
    /// <summary>
    /// Interface qu?n l? Khách hàng
    /// </summary>
    public interface IGuestService
    {
        IEnumerable<Guest> GetGuests(string keyword = "");
        Guest? GetGuestById(int id);
        void AddGuest(Guest guest);
        void UpdateGuest(Guest guest);
        void DeleteGuest(int id);

        // Hàm Import Excel: Tr? v? chu?i thông báo k?t qu? (VD: "Thêm thành công 5, l?i 2 d?ng")
        string ImportGuestsFromExcel(string filePath);
        void ExportGuestsToExcel(string filePath);
        void RefreshCache();
    }
}
