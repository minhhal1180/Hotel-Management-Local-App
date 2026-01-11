using LibraryManagementSystem.BLL.Interfaces;
using LibraryManagementSystem.DAL.Repositories;
using LibraryManagementSystem.Entities.Entities;
using System.Linq;

namespace LibraryManagementSystem.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        // Constructor Injection: Nhận UnitOfWork từ bên ngoài (Forms sẽ truyền vào)
        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AppUser? Login(string username, string password)
        {
            // Tìm user trong DB có username khớp
            // Lưu ý: Password nên mã hóa, nhưng ở đây ta làm demo so sánh trực tiếp
            var user = _unitOfWork.AppUserRepository
                .GetAll(u => u.UserName == username && u.PasswordHash == password && u.IsActive)
                .FirstOrDefault();

            return user;
        }
    }
}