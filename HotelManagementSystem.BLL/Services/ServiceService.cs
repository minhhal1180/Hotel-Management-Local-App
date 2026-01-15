using HotelManagementSystem.BLL.Interfaces;
using HotelManagementSystem.DAL.Repositories;
using HotelManagementSystem.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingServiceEntity = HotelManagementSystem.Entities.Entities.BookingService;

namespace HotelManagementSystem.BLL.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private static List<Service>? _cachedServices = null;

        public ServiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void RefreshCache()
        {
            _cachedServices = _unitOfWork.ServiceRepository.GetAll().ToList();
        }

        public async Task RefreshCacheAsync()
        {
            var services = await _unitOfWork.ServiceRepository.GetAllAsync();
            _cachedServices = services.ToList();
        }

        public async Task<IEnumerable<Service>> GetServicesAsync(string keyword = "")
        {
            if (_cachedServices == null)
            {
                await RefreshCacheAsync();
            }

            if (string.IsNullOrEmpty(keyword))
            {
                return _cachedServices!.Where(s => s.IsActive);
            }

            keyword = keyword.ToLower();
            return _cachedServices!.Where(s =>
               s.IsActive && s.ServiceName.ToLower().Contains(keyword)
                 ).ToList();
        }

        public async Task<Service?> GetServiceByIdAsync(int id)
        {
            if (_cachedServices == null) await RefreshCacheAsync();
            return _cachedServices!.FirstOrDefault(s => s.ServiceId == id);
        }

        public async Task AddServiceAsync(Service service)
        {
            _unitOfWork.ServiceRepository.Insert(service);
            await _unitOfWork.SaveAsync();

            if (_cachedServices != null)
            {
                _cachedServices.Add(service);
            }
        }

        public async Task UpdateServiceAsync(Service service)
        {
            _unitOfWork.ServiceRepository.Update(service);
            await _unitOfWork.SaveAsync();

            if (_cachedServices != null)
            {
                var item = _cachedServices.FirstOrDefault(s => s.ServiceId == service.ServiceId);
                if (item != null)
                {
                    item.ServiceName = service.ServiceName;
                    item.Price = service.Price;
                    item.Description = service.Description;
                    item.IsActive = service.IsActive;
                }
            }
        }

        public async Task DeleteServiceAsync(int id)
        {
            // Kiểm tra dịch vụ đã được sử dụng chưa
            var existingBookingServices = await _unitOfWork.BookingServiceRepository.GetAllAsync(
                filter: bs => bs.ServiceId == id
            );
            var isUsed = existingBookingServices.Any();

            if (isUsed)
            {
                // Soft delete - chỉ đánh dấu không hoạt động
                var service = await _unitOfWork.ServiceRepository.GetByIDAsync(id);
                if (service != null)
                {
                    service.IsActive = false;
                    _unitOfWork.ServiceRepository.Update(service);
                    await _unitOfWork.SaveAsync();
                }
            }
            else
            {
                await _unitOfWork.ServiceRepository.DeleteAsync(id);
                await _unitOfWork.SaveAsync();
            }

            await RefreshCacheAsync();
        }

        public async Task AddServiceToBookingAsync(int bookingId, int serviceId, int quantity, string? note = null)
        {
            var booking = await _unitOfWork.BookingRepository.GetByIDAsync(bookingId);
            if (booking == null) throw new Exception("Không tìm thấy booking!");
            if (booking.Status != "CheckedIn") throw new Exception("Chỉ có thể thêm dịch vụ khi khách đang ở!");

            var service = await _unitOfWork.ServiceRepository.GetByIDAsync(serviceId);
            if (service == null) throw new Exception("Không tìm thấy dịch vụ!");

            var bookingService = new BookingServiceEntity
            {
                BookingId = bookingId,
                ServiceId = serviceId,
                Quantity = quantity,
                UnitPrice = service.Price,
                UsedDate = DateTime.Now,
                Note = note
            };

            _unitOfWork.BookingServiceRepository.Insert(bookingService);
            await _unitOfWork.SaveAsync();
        }

        public async Task RemoveServiceFromBookingAsync(int bookingServiceId)
        {
            var bookingService = await _unitOfWork.BookingServiceRepository.GetByIDAsync(bookingServiceId);
            if (bookingService == null) throw new Exception("Không tìm thấy dịch vụ!");

            await _unitOfWork.BookingServiceRepository.DeleteAsync(bookingServiceId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BookingServiceEntity>> GetBookingServicesAsync(int bookingId)
        {
            return await _unitOfWork.BookingServiceRepository.GetAllAsync(
            filter: bs => bs.BookingId == bookingId,
            includeProperties: "Service"
            );
        }
    }
}
