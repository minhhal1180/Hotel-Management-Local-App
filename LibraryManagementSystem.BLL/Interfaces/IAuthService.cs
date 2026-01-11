using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Entities.Entities;

namespace LibraryManagementSystem.BLL.Interfaces
{
    public interface IAuthService
    {
        AppUser? Login(string username, string password);
    }
}