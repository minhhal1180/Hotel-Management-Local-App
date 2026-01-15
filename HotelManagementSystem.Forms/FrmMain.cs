using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace HotelManagementSystem.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
        }

        private void FrmMain_Load(object? sender, EventArgs e)
        {
            // Hiển thị ngày giờ hiện tại
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy - HH:mm");
        }

        private void btnRooms_Click(object? sender, EventArgs e)
        {
            OpenForm<FrmRooms>();
        }

        private void btnGuests_Click(object? sender, EventArgs e)
        {
            OpenForm<FrmGuests>();
        }

        private void btnBookings_Click(object? sender, EventArgs e)
        {
            OpenForm<FrmBooking>();
        }

        private void btnServices_Click(object? sender, EventArgs e)
        {
            OpenForm<FrmServices>();
        }

        private void btnInvoice_Click(object? sender, EventArgs e)
        {
            OpenForm<FrmInvoice>();
        }

        private void btnLogout_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                var frmLogin = Program.ServiceProvider.GetRequiredService<FrmLogin>();
                frmLogin.ShowDialog();
                this.Close();
            }
        }

        private void OpenForm<T>() where T : Form
        {
            try
            {
                // Lấy form từ DI Container
                var form = Program.ServiceProvider.GetRequiredService<T>();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
