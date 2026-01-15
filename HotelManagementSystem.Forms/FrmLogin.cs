using HotelManagementSystem.BLL.Interfaces;
using HotelManagementSystem.Entities;
using HotelManagementSystem.Entities.Entities;
using Microsoft.Extensions.DependencyInjection; // Để gọi FrmMain từ ServiceProvider
using System;
using System.Windows.Forms;

namespace HotelManagementSystem.Forms
{
    public partial class FrmLogin : Form
    {
        private readonly IAuthService _authService;

        // Constructor nhận Service từ Program.cs truyền vào
        public FrmLogin(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Gọi Service kiểm tra đăng nhập
                AppUser? user = await _authService.LoginAsync(username, password);

                if (user != null)
                {
                    MessageBox.Show($"Xin chào {user.UserName}!", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 2. Mở Form Main
                    // Lấy FrmMain từ ServiceProvider (để đảm bảo FrmMain cũng được tiêm các Service của nó)
                    var frmMain = Program.ServiceProvider.GetRequiredService<FrmMain>();

                    this.Hide(); // Ẩn form đăng nhập
                    frmMain.ShowDialog(); // Hiện form chính

                    // Khi Form Main đóng thì đóng luôn ứng dụng
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
