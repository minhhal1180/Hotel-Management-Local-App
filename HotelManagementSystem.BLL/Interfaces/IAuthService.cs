using HotelManagementSystem.Entities;
using HotelManagementSystem.Entities.Entities;
using System.Threading.Tasks;

namespace HotelManagementSystem.BLL.Interfaces
{
    public interface IAuthService
    {
        Task<AppUser?> LoginAsync(string username, string password);
    }
}
