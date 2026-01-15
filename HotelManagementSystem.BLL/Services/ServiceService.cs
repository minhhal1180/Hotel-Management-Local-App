using HotelManagementSystem.BLL.Interfaces;
using HotelManagementSystem.DAL.Repositories;
using HotelManagementSystem.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Service> GetServices(string keyword = "")
        {
            if (_cachedServices == null)
            {
                RefreshCache();
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

        public Service? GetServiceById(int id)
        {
            if (_cachedServices == null) RefreshCache();
            return _cachedServices!.FirstOrDefault(s => s.ServiceId == id);
        }

        public void AddService(Service service)
        {
            _unitOfWork.ServiceRepository.Insert(service);
            _unitOfWork.Save();

            if (_cachedServices != null)
            {
                _cachedServices.Add(service);
            }
        }

        public void UpdateService(Service service)
        {
            _unitOfWork.ServiceRepository.Update(service);
            _unitOfWork.Save();

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

        public void DeleteService(int id)
        {
            // Ki?m tra d?ch v? đ? đư?c s? d?ng chưa
            var isUsed = _unitOfWork.BookingServiceRepository.GetAll(
             filter: bs => bs.ServiceId == id
        ).Any();

            if (isUsed)
            {
                // Soft delete - ch? đánh d?u không ho?t đ?ng
                var service = _unitOfWork.ServiceRepository.GetByID(id);
                if (service != null)
                {
                    service.IsActive = false;
                    _unitOfWork.ServiceRepository.Update(service);
                    _unitOfWork.Save();
                }
            }
            else
            {
                _unitOfWork.ServiceRepository.Delete(id);
                _unitOfWork.Save();
            }

            RefreshCache();
        }

        public void AddServiceToBooking(int bookingId, int serviceId, int quantity, string? note = null)
        {
            var booking = _unitOfWork.BookingRepository.GetByID(bookingId);
            if (booking == null) throw new Exception("Không t?m th?y booking!");
            if (booking.Status != "CheckedIn") throw new Exception("Ch? có th? thêm d?ch v? khi khách đang ?!");

            var service = _unitOfWork.ServiceRepository.GetByID(serviceId);
            if (service == null) throw new Exception("Không t?m th?y d?ch v?!");

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
            _unitOfWork.Save();
        }

        public void RemoveServiceFromBooking(int bookingServiceId)
        {
            var bookingService = _unitOfWork.BookingServiceRepository.GetByID(bookingServiceId);
            if (bookingService == null) throw new Exception("Không t?m th?y d?ch v?!");

            _unitOfWork.BookingServiceRepository.Delete(bookingServiceId);
            _unitOfWork.Save();
        }

        public IEnumerable<BookingServiceEntity> GetBookingServices(int bookingId)
        {
            return _unitOfWork.BookingServiceRepository.GetAll(
            filter: bs => bs.BookingId == bookingId,
            includeProperties: "Service"
            ).ToList();
        }
    }
}
