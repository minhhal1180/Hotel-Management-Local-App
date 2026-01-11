using LibraryManagementSystem.BLL.Services;
using LibraryManagementSystem.DAL;
using LibraryManagementSystem.DAL.Repositories;
using System;
using System.Windows.Forms;

namespace LibraryManagementSystem.Forms
{
    public partial class FrmMain : Form
    {
        private string _currentUser;

        public FrmMain(string currentUser = "Admin")
        {
            InitializeComponent();
            _currentUser = currentUser;
            this.Load += FrmMain_Load;
        }

        private void FrmMain_Load(object? sender, EventArgs e)
        {
            if (Controls.ContainsKey("lblWelcome"))
            {
                Controls["lblWelcome"].Text = $"Xin chào: {_currentUser}";
            }
        }

        private (HotelContext, UnitOfWork) CreateServiceDependencies()
        {
            var context = new HotelContext();
            var unitOfWork = new UnitOfWork(context);
            return (context, unitOfWork);
        }

        // 1. QUẢN LÝ PHÒNG
        private void btnBooks_Click(object sender, EventArgs e)
        {
            var (context, uow) = CreateServiceDependencies();
            var roomService = new RoomService(uow);

            using (var frm = new FrmRooms(roomService))
            {
                frm.ShowDialog();
            }
        }

        // 2. QUẢN LÝ DỊCH VỤ
        private void btnImports_Click(object sender, EventArgs e)
        {
            var (context, uow) = CreateServiceDependencies();
            var serviceService = new ServiceService(uow);

            using (var frm = new FrmServices(serviceService))
            {
                frm.ShowDialog();
            }
        }

        // 3. QUẢN LÝ KHÁCH HÀNG
        private void btnReaders_Click(object sender, EventArgs e)
        {
            var (context, uow) = CreateServiceDependencies();
            var guestService = new GuestService(uow);

            using (var frm = new FrmGuests(guestService))
            {
                frm.ShowDialog();
            }
        }

        // 4. ĐẶT PHÒNG / TRẢ PHÒNG
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            var (context, uow) = CreateServiceDependencies();
            var bookingService = new BookingService(uow);
            var roomService = new RoomService(uow);
            var guestService = new GuestService(uow);

            using (var frm = new FrmBooking(bookingService, roomService, guestService))
            {
                frm.ShowDialog();
            }
        }

        // 5. HÓA ĐƠN THANH TOÁN (thêm mới)
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            var (context, uow) = CreateServiceDependencies();
            var invoiceService = new InvoiceService(uow);
            var bookingService = new BookingService(uow);

            using (var frm = new FrmInvoice(invoiceService, bookingService))
            {
                frm.ShowDialog();
            }
        }

        // 6. ĐĂNG XUẤT / THOÁT
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}