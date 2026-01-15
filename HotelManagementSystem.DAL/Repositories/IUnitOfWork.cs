using HotelManagementSystem.Entities.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace HotelManagementSystem.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        // Khai báo các Repository cho từng bảng - Hệ thống Khách sạn
        IGenericRepository<Room> RoomRepository { get; }
        IGenericRepository<RoomType> RoomTypeRepository { get; }
        IGenericRepository<Guest> GuestRepository { get; }
        IGenericRepository<Booking> BookingRepository { get; }
        IGenericRepository<Service> ServiceRepository { get; }
        IGenericRepository<BookingService> BookingServiceRepository { get; }
        IGenericRepository<Invoice> InvoiceRepository { get; }
        IGenericRepository<AppUser> AppUserRepository { get; }

        void Save(); // Hàm Commit quan trọng (Lưu tất cả thay đổi cùng lúc)
        IDbContextTransaction BeginTransaction();
        void Commit();
        void Rollback();
    }
}
