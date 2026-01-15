using HotelManagementSystem.BLL.Interfaces;
using HotelManagementSystem.Entities.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagementSystem.Forms
{
    public partial class FrmBooking : Form
    {
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;
        private readonly IGuestService _guestService;

        public FrmBooking(IBookingService bookingService, IRoomService roomService, IGuestService guestService)
        {
            InitializeComponent();
            _bookingService = bookingService;
            _roomService = roomService;
            _guestService = guestService;
            this.Load += FrmBooking_Load;
        }

        private async void FrmBooking_Load(object? sender, EventArgs e)
        {
            await LoadGuestsAsync();
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);
            await LoadAvailableRoomsAsync();
            await LoadBookingsAsync();
        }

        private async System.Threading.Tasks.Task LoadGuestsAsync()
        {
            try
            {
                var guests = (await _guestService.GetGuestsAsync()).ToList();
                cboGuest.DataSource = guests;
                cboGuest.DisplayMember = "FullName";
                cboGuest.ValueMember = "GuestId";
                cboGuest.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải khách hàng: " + ex.Message);
            }
        }

        private async System.Threading.Tasks.Task LoadAvailableRoomsAsync()
        {
            try
            {
                var rooms = (await _roomService.GetAvailableRoomsAsync(dtpCheckIn.Value, dtpCheckOut.Value)).ToList();
        cboRoom.DataSource = rooms.Select(r => new
           {
        r.RoomId,
        DisplayText = $"{r.RoomNumber} - {r.RoomType?.RoomTypeName} ({r.RoomType?.PricePerNight:N0}/đêm)"
    }).ToList();
      cboRoom.DisplayMember = "DisplayText";
   cboRoom.ValueMember = "RoomId";
        cboRoom.SelectedIndex = -1;

    lblAvailableRooms.Text = $"Phòng trống: {rooms.Count} phòng";
}
  catch (Exception ex)
            {
            MessageBox.Show("Lỗi tải phòng: " + ex.Message);
            }
        }

        private async System.Threading.Tasks.Task LoadBookingsAsync(string keyword = "")
        {
            try
            {
                var bookings = await _bookingService.GetBookingsAsync(keyword);
           var displayList = bookings.Select(b => new
       {
           b.BookingId,
           GuestName = b.Guest?.FullName,
     RoomNumber = b.Room?.RoomNumber,
           RoomType = b.Room?.RoomType?.RoomTypeName,
       CheckIn = b.CheckInDate.ToString("dd/MM/yyyy"),
        CheckOut = b.CheckOutDate.ToString("dd/MM/yyyy"),
              b.TotalAmount,
           b.Status,
         b.Note
              }).ToList();

            dgvBookings.DataSource = displayList;

    if (dgvBookings.Columns["BookingId"] != null) dgvBookings.Columns["BookingId"].HeaderText = "Mã ĐP";
            if (dgvBookings.Columns["GuestName"] != null) dgvBookings.Columns["GuestName"].HeaderText = "Khách hàng";
       if (dgvBookings.Columns["RoomNumber"] != null) dgvBookings.Columns["RoomNumber"].HeaderText = "Phòng";
           if (dgvBookings.Columns["RoomType"] != null) dgvBookings.Columns["RoomType"].HeaderText = "Loại phòng";
        if (dgvBookings.Columns["CheckIn"] != null) dgvBookings.Columns["CheckIn"].HeaderText = "Check-in";
         if (dgvBookings.Columns["CheckOut"] != null) dgvBookings.Columns["CheckOut"].HeaderText = "Check-out";
     if (dgvBookings.Columns["TotalAmount"] != null) dgvBookings.Columns["TotalAmount"].HeaderText = "Tổng tiền";
          if (dgvBookings.Columns["Status"] != null) dgvBookings.Columns["Status"].HeaderText = "Trạng thái";
        if (dgvBookings.Columns["Note"] != null) dgvBookings.Columns["Note"].HeaderText = "Ghi chú";
            }
    catch (Exception ex)
            {
       MessageBox.Show("Lỗi tải booking: " + ex.Message);
      }
      }

        private async void dtpDate_ValueChanged(object? sender, EventArgs e)
        {
            await LoadAvailableRoomsAsync();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadBookingsAsync(txtSearch.Text.Trim());
        }

        private async void btnBooking_Click(object sender, EventArgs e)
        {
            if (cboGuest.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!");
                return;
            }
            if (cboRoom.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng!");
                return;
            }
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                MessageBox.Show("Ngày check-out phải sau ngày check-in!");
                return;
            }

            try
            {
                int guestId = (int)cboGuest.SelectedValue;
                int roomId = (int)cboRoom.SelectedValue;

                await _bookingService.CreateBookingAsync(guestId, roomId, dtpCheckIn.Value, dtpCheckOut.Value, txtNote.Text.Trim());
                MessageBox.Show("Đặt phòng thành công!");
                await LoadBookingsAsync();
                await LoadAvailableRoomsAsync();
    ResetForm();
      }
     catch (Exception ex)
            {
     MessageBox.Show("Lỗi: " + ex.Message);
      }
     }

        private async void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn booking cần nhận phòng!");
                return;
            }

            try
            {
                int bookingId = int.Parse(txtID.Text);
                await _bookingService.CheckInAsync(bookingId);
                MessageBox.Show("Nhận phòng thành công!");
                await LoadBookingsAsync();
                await LoadAvailableRoomsAsync();
                await _roomService.RefreshCacheAsync();
            }
       catch (Exception ex)
            {
  MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn booking cần trả phòng!");
                return;
            }

            try
            {
                int bookingId = int.Parse(txtID.Text);
                await _bookingService.CheckOutAsync(bookingId);
                MessageBox.Show("Trả phòng thành công! Vui lòng lập hóa đơn thanh toán.");
                await LoadBookingsAsync();
                await LoadAvailableRoomsAsync();
                await _roomService.RefreshCacheAsync();
            }
 catch (Exception ex)
 {
         MessageBox.Show("Lỗi: " + ex.Message);
        }
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn booking cần hủy!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn hủy đặt phòng này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int bookingId = int.Parse(txtID.Text);
                    await _bookingService.CancelBookingAsync(bookingId);
                    MessageBox.Show("Hủy đặt phòng thành công!");
                    await LoadBookingsAsync();
                    await LoadAvailableRoomsAsync();
           }
         catch (Exception ex)
     {
             MessageBox.Show("Lỗi: " + ex.Message);
           }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadBookingsAsync();
            await LoadAvailableRoomsAsync();
            ResetForm();
            txtSearch.Clear();
        }

      private void dgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
 {
   if (e.RowIndex >= 0)
            {
    DataGridViewRow row = dgvBookings.Rows[e.RowIndex];
    txtID.Text = row.Cells["BookingId"].Value?.ToString();
     txtNote.Text = row.Cells["Note"].Value?.ToString();
            }
}

        private async void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel|*.xlsx", FileName = "LichSuDatPhong.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        await _bookingService.ExportBookingHistoryToExcelAsync(sfd.FileName);
        MessageBox.Show("Xuất file Excel thành công!");
         }
        catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
     }
            }
}

        private void ResetForm()
        {
     txtID.Clear();
          txtNote.Clear();
            cboGuest.SelectedIndex = -1;
cboRoom.SelectedIndex = -1;
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);
  }

     private void dgvBookings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

    }
    }
}
