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

        private void FrmBooking_Load(object? sender, EventArgs e)
        {
            LoadGuests();
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);
            LoadAvailableRooms();
            LoadBookings();
        }

        private void LoadGuests()
        {
            try
            {
                var guests = _guestService.GetGuests().ToList();
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

        private void LoadAvailableRooms()
        {
            try
 {
        var rooms = _roomService.GetAvailableRooms(dtpCheckIn.Value, dtpCheckOut.Value).ToList();
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

      private void LoadBookings(string keyword = "")
   {
   try
     {
    var bookings = _bookingService.GetBookings(keyword);
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

        private void dtpDate_ValueChanged(object? sender, EventArgs e)
        {
            LoadAvailableRooms();
        }

 private void btnSearch_Click(object sender, EventArgs e)
      {
LoadBookings(txtSearch.Text.Trim());
    }

        private void btnBooking_Click(object sender, EventArgs e)
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

    _bookingService.CreateBooking(guestId, roomId, dtpCheckIn.Value, dtpCheckOut.Value, txtNote.Text.Trim());
                MessageBox.Show("Đặt phòng thành công!");
      LoadBookings();
     LoadAvailableRooms();
    ResetForm();
      }
     catch (Exception ex)
            {
     MessageBox.Show("Lỗi: " + ex.Message);
      }
     }

        private void btnCheckIn_Click(object sender, EventArgs e)
   {
if (string.IsNullOrEmpty(txtID.Text))
            {
     MessageBox.Show("Vui lòng chọn booking cần nhận phòng!");
   return;
    }

        try
            {
 int bookingId = int.Parse(txtID.Text);
    _bookingService.CheckIn(bookingId);
            MessageBox.Show("Nhận phòng thành công!");
           LoadBookings();
    LoadAvailableRooms();
            _roomService.RefreshCache();
            }
       catch (Exception ex)
            {
  MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

      private void btnCheckOut_Click(object sender, EventArgs e)
   {
            if (string.IsNullOrEmpty(txtID.Text))
   {
                MessageBox.Show("Vui lòng chọn booking cần trả phòng!");
 return;
   }

          try
            {
        int bookingId = int.Parse(txtID.Text);
           _bookingService.CheckOut(bookingId);
                MessageBox.Show("Trả phòng thành công! Vui lòng lập hóa đơn thanh toán.");
          LoadBookings();
       LoadAvailableRooms();
      _roomService.RefreshCache();
            }
 catch (Exception ex)
 {
         MessageBox.Show("Lỗi: " + ex.Message);
        }
        }

        private void btnCancel_Click(object sender, EventArgs e)
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
        _bookingService.CancelBooking(bookingId);
          MessageBox.Show("Hủy đặt phòng thành công!");
   LoadBookings();
            LoadAvailableRooms();
           }
         catch (Exception ex)
     {
             MessageBox.Show("Lỗi: " + ex.Message);
           }
            }
        }

   private void btnRefresh_Click(object sender, EventArgs e)
   {
          LoadBookings();
            LoadAvailableRooms();
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

      private void btnExport_Click(object sender, EventArgs e)
      {
        using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel|*.xlsx", FileName = "LichSuDatPhong.xlsx" })
            {
              if (sfd.ShowDialog() == DialogResult.OK)
        {
   try
  {
       _bookingService.ExportBookingHistoryToExcel(sfd.FileName);
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
