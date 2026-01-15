using HotelManagementSystem.Entities;
using HotelManagementSystem.Entities.Entities;

namespace HotelManagementSystem.BLL.Interfaces
{
    public interface IAuthService
    {
        AppUser? Login(string username, string password);
    }
}
