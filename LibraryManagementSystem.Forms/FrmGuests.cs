using LibraryManagementSystem.BLL.Interfaces;
using LibraryManagementSystem.Entities.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryManagementSystem.Forms
{
    public partial class FrmGuests : Form
 {
        private readonly IGuestService _guestService;

        public FrmGuests(IGuestService guestService)
        {
    InitializeComponent();
    _guestService = guestService;
this.Load += FrmGuests_Load;
        }

private void FrmGuests_Load(object? sender, EventArgs e)
        {
  LoadGuests();
          dtpDOB.Value = new DateTime(1990, 1, 1);
        }

    private void LoadGuests(string keyword = "")
        {
    try
 {
      var guests = _guestService.GetGuests(keyword);
     var displayList = guests.Select(g => new
 {
       g.GuestId,
    g.FullName,
         g.IdentityCard,
           DOB = g.DOB?.ToString("dd/MM/yyyy"),
     g.Phone,
        g.Address,
    g.Email,
   g.Nationality,
       CreatedDate = g.CreatedDate.ToString("dd/MM/yyyy")
      }).ToList();

                dgvGuests.DataSource = displayList;

           if (dgvGuests.Columns["GuestId"] != null) dgvGuests.Columns["GuestId"].HeaderText = "M? KH";
      if (dgvGuests.Columns["FullName"] != null) dgvGuests.Columns["FullName"].HeaderText = "H? tên";
             if (dgvGuests.Columns["IdentityCard"] != null) dgvGuests.Columns["IdentityCard"].HeaderText = "CMND/CCCD";
      if (dgvGuests.Columns["DOB"] != null) dgvGuests.Columns["DOB"].HeaderText = "Ngày sinh";
       if (dgvGuests.Columns["Phone"] != null) dgvGuests.Columns["Phone"].HeaderText = "SÐT";
  if (dgvGuests.Columns["Address"] != null) dgvGuests.Columns["Address"].HeaderText = "Ð?a ch?";
       if (dgvGuests.Columns["Email"] != null) dgvGuests.Columns["Email"].HeaderText = "Email";
      if (dgvGuests.Columns["Nationality"] != null) dgvGuests.Columns["Nationality"].HeaderText = "Qu?c t?ch";
    if (dgvGuests.Columns["CreatedDate"] != null) dgvGuests.Columns["CreatedDate"].HeaderText = "Ngày t?o";
  }
            catch (Exception ex)
   {
              MessageBox.Show("L?i t?i khách hàng: " + ex.Message);
     }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGuests(txtSearch.Text.Trim());
    }

     private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

        try
            {
       var guest = new Guest
    {
         FullName = txtFullName.Text.Trim(),
       IdentityCard = txtIdentityCard.Text.Trim(),
        DOB = dtpDOB.Value,
 Phone = txtPhone.Text.Trim(),
         Address = txtAddress.Text.Trim(),
         Email = txtEmail.Text.Trim(),
     Nationality = txtNationality.Text.Trim(),
  CreatedDate = DateTime.Now
  };

      _guestService.AddGuest(guest);
         MessageBox.Show("Thêm khách hàng thành công!");
       LoadGuests();
         ResetForm();
 }
        catch (Exception ex)
            {
      MessageBox.Show("L?i: " + ex.Message);
            }
    }

      private void btnUpdate_Click(object sender, EventArgs e)
        {
      if (string.IsNullOrEmpty(txtID.Text))
     {
     MessageBox.Show("Vui l?ng ch?n khách hàng c?n c?p nh?t!");
                return;
 }
        if (!ValidateInput()) return;

         try
      {
int guestId = int.Parse(txtID.Text);
   var guest = _guestService.GetGuestById(guestId);
            if (guest != null)
 {
    guest.FullName = txtFullName.Text.Trim();
     guest.IdentityCard = txtIdentityCard.Text.Trim();
     guest.DOB = dtpDOB.Value;
        guest.Phone = txtPhone.Text.Trim();
          guest.Address = txtAddress.Text.Trim();
      guest.Email = txtEmail.Text.Trim();
            guest.Nationality = txtNationality.Text.Trim();

  _guestService.UpdateGuest(guest);
         MessageBox.Show("C?p nh?t khách hàng thành công!");
      LoadGuests();
}
          }
            catch (Exception ex)
     {
           MessageBox.Show("L?i: " + ex.Message);
            }
  }

        private void btnDelete_Click(object sender, EventArgs e)
    {
         if (string.IsNullOrEmpty(txtID.Text))
            {
MessageBox.Show("Vui l?ng ch?n khách hàng c?n xóa!");
return;
     }

            if (MessageBox.Show("B?n có ch?c mu?n xóa khách hàng này?", "Xác nh?n",
         MessageBoxButtons.YesNo) == DialogResult.Yes)
       {
        try
          {
          int guestId = int.Parse(txtID.Text);
          _guestService.DeleteGuest(guestId);
        MessageBox.Show("Xóa khách hàng thành công!");
     LoadGuests();
        ResetForm();
             }
                catch (Exception ex)
     {
        MessageBox.Show("L?i: " + ex.Message);
     }
            }
      }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
  _guestService.RefreshCache();
     LoadGuests();
            ResetForm();
txtSearch.Clear();
        }

        private void dgvGuests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
       if (e.RowIndex >= 0)
        {
         DataGridViewRow row = dgvGuests.Rows[e.RowIndex];
                txtID.Text = row.Cells["GuestId"].Value?.ToString();
     txtFullName.Text = row.Cells["FullName"].Value?.ToString();
      txtIdentityCard.Text = row.Cells["IdentityCard"].Value?.ToString();
          txtPhone.Text = row.Cells["Phone"].Value?.ToString();
      txtAddress.Text = row.Cells["Address"].Value?.ToString();
       txtEmail.Text = row.Cells["Email"].Value?.ToString();
           txtNationality.Text = row.Cells["Nationality"].Value?.ToString();

    string? dobText = row.Cells["DOB"].Value?.ToString();
      if (!string.IsNullOrEmpty(dobText) && DateTime.TryParse(dobText, out DateTime dob))
            {
                    dtpDOB.Value = dob;
        }
            }
        }

private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel|*.xlsx", FileName = "DanhSachKhachHang.xlsx" })
 {
    if (sfd.ShowDialog() == DialogResult.OK)
     {
     try
        {
         _guestService.ExportGuestsToExcel(sfd.FileName);
        MessageBox.Show("Xu?t file Excel thành công!");
          }
       catch (Exception ex) { MessageBox.Show("L?i: " + ex.Message); }
         }
    }
        }

    private void ResetForm()
        {
     txtID.Clear();
      txtFullName.Clear();
   txtIdentityCard.Clear();
       txtPhone.Clear();
     txtAddress.Clear();
            txtEmail.Clear();
     txtNationality.Clear();
     dtpDOB.Value = new DateTime(1990, 1, 1);
            txtFullName.Focus();
     }

  private bool ValidateInput()
        {
       if (string.IsNullOrEmpty(txtFullName.Text))
  {
     MessageBox.Show("H? tên không ðý?c ð? tr?ng!");
        return false;
     }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("S? ði?n tho?i không ðý?c ð? tr?ng!");
     return false;
            }
 return true;
      }
    }
}
