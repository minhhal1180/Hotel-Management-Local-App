using HotelManagementSystem.BLL.Interfaces;
using HotelManagementSystem.DAL.Repositories;
using HotelManagementSystem.Entities.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        // Constructor Injection: Nhận UnitOfWork từ bên ngoài (Forms sẽ truyền vào)
        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AppUser?> LoginAsync(string username, string password)
        {
            // Tìm user trong DB có username khớp
            // Lưu ý: Password nên mã hóa, nhưng ở đây ta làm demo so sánh trực tiếp
            var users = await _unitOfWork.AppUserRepository
                .GetAllAsync(u => u.UserName == username && u.PasswordHash == password && u.IsActive);
            
            return users.FirstOrDefault();
        }
    }
}
