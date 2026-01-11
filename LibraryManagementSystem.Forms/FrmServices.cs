using LibraryManagementSystem.BLL.Interfaces;
using LibraryManagementSystem.Entities.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryManagementSystem.Forms
{
    public partial class FrmServices : Form
    {
        private readonly IServiceService _serviceService;

public FrmServices(IServiceService serviceService)
 {
       InitializeComponent();
    _serviceService = serviceService;
this.Load += FrmServices_Load;
    }

        private void FrmServices_Load(object? sender, EventArgs e)
        {
            LoadServices();
        }

        private void LoadServices()
        {
          try
      {
       var services = _serviceService.GetServices();
          var displayList = services.Select(s => new
     {
                s.ServiceId,
 s.ServiceName,
               s.Price,
          s.Description,
      Active = s.IsActive ? "Có" : "Không"
          }).ToList();

           dgvServices.DataSource = displayList;

   if (dgvServices.Columns["ServiceId"] != null) dgvServices.Columns["ServiceId"].HeaderText = "M? DV";
        if (dgvServices.Columns["ServiceName"] != null) dgvServices.Columns["ServiceName"].HeaderText = "Tên d?ch v?";
     if (dgvServices.Columns["Price"] != null) dgvServices.Columns["Price"].HeaderText = "Giá";
          if (dgvServices.Columns["Description"] != null) dgvServices.Columns["Description"].HeaderText = "Mô t?";
                if (dgvServices.Columns["Active"] != null) dgvServices.Columns["Active"].HeaderText = "Ho?t ð?ng";
      }
   catch (Exception ex)
 {
          MessageBox.Show("L?i t?i d?ch v?: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
    {
     if (!ValidateInput()) return;

            try
   {
  var service = new Service
      {
 ServiceName = txtServiceName.Text.Trim(),
 Price = decimal.TryParse(txtPrice.Text, out decimal p) ? p : 0,
       Description = txtDescription.Text.Trim(),
   IsActive = chkActive.Checked
     };

       _serviceService.AddService(service);
        MessageBox.Show("Thêm d?ch v? thành công!");
             LoadServices();
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
          MessageBox.Show("Vui l?ng ch?n d?ch v? c?n c?p nh?t!");
  return;
  }
            if (!ValidateInput()) return;

            try
            {
     int serviceId = int.Parse(txtID.Text);
        var service = _serviceService.GetServiceById(serviceId);
      if (service != null)
         {
 service.ServiceName = txtServiceName.Text.Trim();
        service.Price = decimal.TryParse(txtPrice.Text, out decimal p) ? p : 0;
      service.Description = txtDescription.Text.Trim();
          service.IsActive = chkActive.Checked;

    _serviceService.UpdateService(service);
        MessageBox.Show("C?p nh?t d?ch v? thành công!");
         LoadServices();
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
     MessageBox.Show("Vui l?ng ch?n d?ch v? c?n xóa!");
  return;
        }

       if (MessageBox.Show("B?n có ch?c mu?n xóa d?ch v? này?", "Xác nh?n",
 MessageBoxButtons.YesNo) == DialogResult.Yes)
         {
            try
     {
             int serviceId = int.Parse(txtID.Text);
     _serviceService.DeleteService(serviceId);
         MessageBox.Show("Xóa d?ch v? thành công!");
        LoadServices();
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
    _serviceService.RefreshCache();
    LoadServices();
   ResetForm();
        }

        private void dgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
 {
      if (e.RowIndex >= 0)
{
    DataGridViewRow row = dgvServices.Rows[e.RowIndex];
    txtID.Text = row.Cells["ServiceId"].Value?.ToString();
      txtServiceName.Text = row.Cells["ServiceName"].Value?.ToString();
        txtPrice.Text = row.Cells["Price"].Value?.ToString();
                txtDescription.Text = row.Cells["Description"].Value?.ToString();
            chkActive.Checked = row.Cells["Active"].Value?.ToString() == "Có";
            }
        }

private void ResetForm()
        {
       txtID.Clear();
        txtServiceName.Clear();
            txtPrice.Clear();
            txtDescription.Clear();
     chkActive.Checked = true;
       txtServiceName.Focus();
}

        private bool ValidateInput()
        {
     if (string.IsNullOrEmpty(txtServiceName.Text))
            {
       MessageBox.Show("Tên d?ch v? không ðý?c ð? tr?ng!");
      return false;
       }
       if (string.IsNullOrEmpty(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out _))
   {
    MessageBox.Show("Giá d?ch v? không h?p l?!");
      return false;
            }
 return true;
        }
 }
}
