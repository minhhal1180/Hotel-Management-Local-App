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
    public class GuestService : IGuestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private static List<Guest>? _cachedGuests = null;

        public GuestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void RefreshCache()
        {
            _cachedGuests = _unitOfWork.GuestRepository.GetAll().ToList();
        }

        public async Task RefreshCacheAsync()
        {
            var guests = await _unitOfWork.GuestRepository.GetAllAsync();
            _cachedGuests = guests.ToList();
        }

        public async Task<IEnumerable<Guest>> GetGuestsAsync(string keyword = "")
        {
            if (_cachedGuests == null)
            {
                await RefreshCacheAsync();
            }

            if (string.IsNullOrEmpty(keyword))
            {
                return _cachedGuests!;
            }

            keyword = keyword.ToLower();
            return _cachedGuests!.Where(g =>
                g.FullName.ToLower().Contains(keyword) ||
                g.Phone.Contains(keyword) ||
                (g.IdentityCard?.Contains(keyword) ?? false)
            ).ToList();
        }

        public async Task<Guest?> GetGuestByIdAsync(int id)
        {
            if (_cachedGuests == null) await RefreshCacheAsync();
            return _cachedGuests!.FirstOrDefault(g => g.GuestId == id);
        }

        public async Task AddGuestAsync(Guest guest)
        {
            if (guest.CreatedDate == DateTime.MinValue)
                guest.CreatedDate = DateTime.Now;

            _unitOfWork.GuestRepository.Insert(guest);
            await _unitOfWork.SaveAsync();

            if (_cachedGuests != null)
            {
                _cachedGuests.Add(guest);
            }
        }

        public async Task UpdateGuestAsync(Guest guest)
        {
            _unitOfWork.GuestRepository.Update(guest);
            await _unitOfWork.SaveAsync();

            if (_cachedGuests != null)
            {
                var item = _cachedGuests.FirstOrDefault(g => g.GuestId == guest.GuestId);
                if (item != null)
                {
                    item.FullName = guest.FullName;
                    item.IdentityCard = guest.IdentityCard;
                    item.DOB = guest.DOB;
                    item.Phone = guest.Phone;
                    item.Address = guest.Address;
                    item.Email = guest.Email;
                    item.Nationality = guest.Nationality;
                }
            }
        }

        public async Task DeleteGuestAsync(int id)
        {
            var bookings = await _unitOfWork.BookingRepository.GetAllAsync(filter: b => b.GuestId == id);
            var hasBooking = bookings.Any();

            if (hasBooking)
            {
                throw new InvalidOperationException("Khách hàng đã có lịch sử đặt phòng, không thể xóa!");
            }

            await _unitOfWork.GuestRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();

            if (_cachedGuests != null)
            {
                var item = _cachedGuests.FirstOrDefault(g => g.GuestId == id);
                if (item != null) _cachedGuests.Remove(item);
            }
        }

        public async Task<string> ImportGuestsFromExcelAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Không tìm thấy file Excel!");
            }

            int successCount = 0;
            int errorCount = 0;

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    try
                    {
                        string fullName = worksheet.Cells[row, 1].Text;
                        if (string.IsNullOrEmpty(fullName)) continue;

                        var newGuest = new Guest
                        {
                            FullName = fullName,
                            IdentityCard = worksheet.Cells[row, 2].Text,
                            Phone = worksheet.Cells[row, 4].Text,
                            Address = worksheet.Cells[row, 5].Text,
                            Email = worksheet.Cells[row, 6].Text,
                            Nationality = worksheet.Cells[row, 7].Text,
                            CreatedDate = DateTime.Now
                        };

                        if (DateTime.TryParse(worksheet.Cells[row, 3].Text, out DateTime dob))
                        {
                            newGuest.DOB = dob;
                        }

                        _unitOfWork.GuestRepository.Insert(newGuest);
                        successCount++;
                    }
                    catch
                    {
                        errorCount++;
                    }
                }
                await _unitOfWork.SaveAsync();
            }

            await RefreshCacheAsync();
            return $"Nhập thành công {successCount} khách hàng. Lỗi: {errorCount}";
        }

        public async Task ExportGuestsToExcelAsync(string filePath)
        {
            var guests = (await GetGuestsAsync()).ToList();

            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("Danh sách Khách hàng");

                string[] headers = { "Mã KH", "Họ tên", "CMND/CCCD", "Ngày sinh", "SĐT", "Địa chỉ", "Email", "Quốc tịch", "Ngày tạo" };
                for (int i = 0; i < headers.Length; i++) sheet.Cells[1, i + 1].Value = headers[i];

                for (int i = 0; i < guests.Count; i++)
                {
                    var g = guests[i];
                    sheet.Cells[i + 2, 1].Value = g.GuestId;
                    sheet.Cells[i + 2, 2].Value = g.FullName;
                    sheet.Cells[i + 2, 3].Value = g.IdentityCard;
                    sheet.Cells[i + 2, 4].Value = g.DOB?.ToString("dd/MM/yyyy");
                    sheet.Cells[i + 2, 5].Value = g.Phone;
                    sheet.Cells[i + 2, 6].Value = g.Address;
                    sheet.Cells[i + 2, 7].Value = g.Email;
                    sheet.Cells[i + 2, 8].Value = g.Nationality;
                    sheet.Cells[i + 2, 9].Value = g.CreatedDate.ToString("dd/MM/yyyy");
                }

                sheet.Cells.AutoFitColumns();
                await package.SaveAsAsync(new FileInfo(filePath));
            }
        }
    }
}
