using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Entities.Entities;
using System.Collections.Generic;

namespace LibraryManagementSystem.BLL.Interfaces
{
    /// <summary>
    /// Interface quản lý Khách hàng
    /// </summary>
    public interface IGuestService
    {
        IEnumerable<Guest> GetGuests(string keyword = "");
        Guest? GetGuestById(int id);
        void AddGuest(Guest guest);
        void UpdateGuest(Guest guest);
        void DeleteGuest(int id);

        // Hàm Import Excel: Trả về chuỗi thông báo kết quả (VD: "Thêm thành công 5, lỗi 2 dòng")
        string ImportGuestsFromExcel(string filePath);
        void ExportGuestsToExcel(string filePath);
        void RefreshCache();
    }
}