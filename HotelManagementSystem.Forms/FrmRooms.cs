using HotelManagementSystem.BLL.Interfaces;
using HotelManagementSystem.Entities.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagementSystem.Forms
{
    public partial class FrmRooms : Form
    {
        private readonly IRoomService _roomService;

        public FrmRooms(IRoomService roomService)
      {
            InitializeComponent();
            _roomService = roomService;
            this.Load += FrmRooms_Load;
      }

        private void FrmRooms_Load(object? sender, EventArgs e)
        {
        LoadRoomTypes();
   LoadRooms();
            cboStatus.SelectedIndex = 0;
     }

        private void LoadRoomTypes()
     {
         try
            {
     var roomTypes = _roomService.GetAllRoomTypes().ToList();
             cboRoomType.DataSource = roomTypes;
       cboRoomType.DisplayMember = "RoomTypeName";
        cboRoomType.ValueMember = "RoomTypeId";
         cboRoomType.SelectedIndex = -1;
       }
            catch (Exception ex)
            {
       MessageBox.Show("Lỗi tải loại phòng: " + ex.Message);
      }
        }

        private void LoadRooms(string keyword = "")
        {
    try
 {
                var rooms = _roomService.GetRooms(keyword);
            var displayList = rooms.Select(r => new
          {
        r.RoomId,
          r.RoomNumber,
          RoomTypeName = r.RoomType?.RoomTypeName,
        PricePerNight = r.RoomType?.PricePerNight,
   r.Floor,
       r.Status,
       r.Description
     }).ToList();

   dgvRooms.DataSource = displayList;

  // Format headers
    if (dgvRooms.Columns["RoomId"] != null) dgvRooms.Columns["RoomId"].HeaderText = "Mã";
           if (dgvRooms.Columns["RoomNumber"] != null) dgvRooms.Columns["RoomNumber"].HeaderText = "Số phòng";
    if (dgvRooms.Columns["RoomTypeName"] != null) dgvRooms.Columns["RoomTypeName"].HeaderText = "Loại phòng";
              if (dgvRooms.Columns["PricePerNight"] != null) dgvRooms.Columns["PricePerNight"].HeaderText = "Giá/đêm";
       if (dgvRooms.Columns["Floor"] != null) dgvRooms.Columns["Floor"].HeaderText = "Tầng";
       if (dgvRooms.Columns["Status"] != null) dgvRooms.Columns["Status"].HeaderText = "Trạng thái";
       if (dgvRooms.Columns["Description"] != null) dgvRooms.Columns["Description"].HeaderText = "Mô tả";
        }
            catch (Exception ex)
  {
                MessageBox.Show("Lỗi tải phòng: " + ex.Message);
  }
        }

        private void btnSearch_Click(object sender, EventArgs e)
     {
            LoadRooms(txtSearch.Text.Trim());
        }

    private void btnAdd_Click(object sender, EventArgs e)
{
     if (!ValidateInput()) return;

            try
    {
 var room = new Room
      {
           RoomNumber = txtRoomNumber.Text.Trim(),
      RoomTypeId = (int)cboRoomType.SelectedValue!,
   Floor = int.TryParse(txtFloor.Text, out int f) ? f : 1,
    Status = cboStatus.Text,
   Description = txtDescription.Text.Trim()
     };

         _roomService.AddRoom(room);
 MessageBox.Show("Thêm phòng thành công!");
        LoadRooms();
  ResetForm();
            }
         catch (Exception ex)
  {
     MessageBox.Show("Lỗi: " + ex.Message);
          }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
         {
   MessageBox.Show("Vui lòng chọn phòng cần cập nhật!");
      return;
            }
  if (!ValidateInput()) return;

  try
   {
int roomId = int.Parse(txtID.Text);
        var room = _roomService.GetRoomById(roomId);
      if (room != null)
   {
        room.RoomNumber = txtRoomNumber.Text.Trim();
 room.RoomTypeId = (int)cboRoomType.SelectedValue!;
      room.Floor = int.TryParse(txtFloor.Text, out int f) ? f : 1;
           room.Status = cboStatus.Text;
      room.Description = txtDescription.Text.Trim();

    _roomService.UpdateRoom(room);
           MessageBox.Show("Cập nhật phòng thành công!");
       LoadRooms();
            }
         }
            catch (Exception ex)
            {
             MessageBox.Show("Lỗi: " + ex.Message);
    }
    }

   private void btnDelete_Click(object sender, EventArgs e)
  {
            if (string.IsNullOrEmpty(txtID.Text))
        {
  MessageBox.Show("Vui lòng chọn phòng cần xóa!");
          return;
       }

 if (MessageBox.Show("Bạn có chắc muốn xóa phòng này?", "Xác nhận",
  MessageBoxButtons.YesNo) == DialogResult.Yes)
     {
    try
       {
   int roomId = int.Parse(txtID.Text);
       _roomService.DeleteRoom(roomId);
 MessageBox.Show("Xóa phòng thành công!");
          LoadRooms();
 ResetForm();
       }
    catch (Exception ex)
       {
MessageBox.Show("Lỗi: " + ex.Message);
  }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
      {
            _roomService.RefreshCache();
     LoadRooms();
  ResetForm();
            txtSearch.Clear();
        }

     private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
     {
      DataGridViewRow row = dgvRooms.Rows[e.RowIndex];
        txtID.Text = row.Cells["RoomId"].Value?.ToString();
  txtRoomNumber.Text = row.Cells["RoomNumber"].Value?.ToString();
         txtFloor.Text = row.Cells["Floor"].Value?.ToString();
   txtDescription.Text = row.Cells["Description"].Value?.ToString();

string? roomTypeName = row.Cells["RoomTypeName"].Value?.ToString();
        if (!string.IsNullOrEmpty(roomTypeName))
{
 cboRoomType.SelectedIndex = cboRoomType.FindStringExact(roomTypeName);
     }

      string? status = row.Cells["Status"].Value?.ToString();
    if (!string.IsNullOrEmpty(status))
                {
  cboStatus.SelectedIndex = cboStatus.FindStringExact(status);
                }
            }
        }

     private void btnExport_Click(object sender, EventArgs e)
        {
          using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel|*.xlsx", FileName = "DanhSachPhong.xlsx" })
          {
       if (sfd.ShowDialog() == DialogResult.OK)
     {
   try
         {
   _roomService.ExportRoomsToExcel(sfd.FileName);
           MessageBox.Show("Xuất file Excel thành công!");
              }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
        }
        }

    private void ResetForm()
        {
  txtID.Clear();
       txtRoomNumber.Clear();
            txtFloor.Clear();
   txtDescription.Clear();
          cboRoomType.SelectedIndex = -1;
   cboStatus.SelectedIndex = 0;
         txtRoomNumber.Focus();
  }

        private bool ValidateInput()
        {
     if (string.IsNullOrEmpty(txtRoomNumber.Text))
            {
        MessageBox.Show("Số phòng không được để trống!");
         return false;
    }
            if (cboRoomType.SelectedIndex < 0)
            {
    MessageBox.Show("Vui lòng chọn loại phòng!");
       return false;
            }
            return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

  private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
