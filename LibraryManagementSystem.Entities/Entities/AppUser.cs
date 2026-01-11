using System;

namespace LibraryManagementSystem.Entities.Entities
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string UserName { get; set; } = null!; // Tên đăng nhập
        public string PasswordHash { get; set; } = null!; // Mật khẩu (lưu ý: thực tế nên mã hóa)
        public string Role { get; set; } = "User";        // Phân quyền: Admin hoặc Staff
        public bool IsActive { get; set; } = true;        // Trạng thái hoạt động
    }
}