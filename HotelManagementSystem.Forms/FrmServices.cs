using HotelManagementSystem.BLL.Interfaces;
using HotelManagementSystem.Entities.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagementSystem.Forms
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

        private async void FrmServices_Load(object? sender, EventArgs e)
        {
            await LoadServicesAsync();
        }

        private async System.Threading.Tasks.Task LoadServicesAsync()
        {
            try
            {
                var services = await _serviceService.GetServicesAsync();
                var displayList = services.Select(s => new
                {
                    s.ServiceId,
                    s.ServiceName,
                    s.Price,
                    s.Description,
                    Active = s.IsActive ? "Có" : "Không"
                }).ToList();

                dgvServices.DataSource = displayList;

                if (dgvServices.Columns["ServiceId"] != null) dgvServices.Columns["ServiceId"].HeaderText = "Mã DV";
                if (dgvServices.Columns["ServiceName"] != null) dgvServices.Columns["ServiceName"].HeaderText = "Tên dịch vụ";
                if (dgvServices.Columns["Price"] != null) dgvServices.Columns["Price"].HeaderText = "Giá";
                if (dgvServices.Columns["Description"] != null) dgvServices.Columns["Description"].HeaderText = "Mô tả";
                if (dgvServices.Columns["Active"] != null) dgvServices.Columns["Active"].HeaderText = "Hoạt động";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dịch vụ: " + ex.Message);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
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

                await _serviceService.AddServiceAsync(service);
                MessageBox.Show("Thêm dịch vụ thành công!");
                await LoadServicesAsync();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần cập nhật!");
                return;
            }
            if (!ValidateInput()) return;

            try
            {
                int serviceId = int.Parse(txtID.Text);
                var service = await _serviceService.GetServiceByIdAsync(serviceId);
                if (service != null)
                {
                    service.ServiceName = txtServiceName.Text.Trim();
                    service.Price = decimal.TryParse(txtPrice.Text, out decimal p) ? p : 0;
                    service.Description = txtDescription.Text.Trim();
                    service.IsActive = chkActive.Checked;

                    await _serviceService.UpdateServiceAsync(service);
                    MessageBox.Show("Cập nhật dịch vụ thành công!");
                    await LoadServicesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa dịch vụ này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int serviceId = int.Parse(txtID.Text);
                    await _serviceService.DeleteServiceAsync(serviceId);
                    MessageBox.Show("Xóa dịch vụ thành công!");
                    await LoadServicesAsync();
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await _serviceService.RefreshCacheAsync();
            await LoadServicesAsync();
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
                MessageBox.Show("Tên dịch vụ không được để trống!");
                return false;
            }
            if (string.IsNullOrEmpty(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show("Giá dịch vụ không hợp lệ!");
                return false;
            }
            return true;
        }
    }
}
