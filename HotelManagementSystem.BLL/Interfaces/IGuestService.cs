using HotelManagementSystem.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagementSystem.BLL.Interfaces
{
    /// <summary>
    /// Interface qu?n l? Khách hàng
    /// </summary>
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetGuestsAsync(string keyword = "");
        Task<Guest?> GetGuestByIdAsync(int id);
        Task AddGuestAsync(Guest guest);
        Task UpdateGuestAsync(Guest guest);
        Task DeleteGuestAsync(int id);

        // Hàm Import Excel: Trả về chuỗi thông báo kết quả (VD: "Thêm thành công 5, lỗi 2 dòng")
        Task<string> ImportGuestsFromExcelAsync(string filePath);
        Task ExportGuestsToExcelAsync(string filePath);
        void RefreshCache();
        Task RefreshCacheAsync();
    }
}
