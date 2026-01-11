using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Entities.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace LibraryManagementSystem.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelContext _context;
        private IDbContextTransaction? _transaction;

        // Khai báo biến private để lưu instance của Repository - Hệ thống Khách sạn
        private IGenericRepository<Room>? _roomRepository;
        private IGenericRepository<RoomType>? _roomTypeRepository;
        private IGenericRepository<Guest>? _guestRepository;
        private IGenericRepository<Booking>? _bookingRepository;
        private IGenericRepository<Service>? _serviceRepository;
        private IGenericRepository<BookingService>? _bookingServiceRepository;
        private IGenericRepository<Invoice>? _invoiceRepository;
        private IGenericRepository<AppUser>? _appUserRepository;

        public UnitOfWork(HotelContext context)
        {
            _context = context;
        }

        // Triển khai Singleton đơn giản cho từng Repository
        public IGenericRepository<Room> RoomRepository =>
            _roomRepository ??= new GenericRepository<Room>(_context);

        public IGenericRepository<RoomType> RoomTypeRepository =>
            _roomTypeRepository ??= new GenericRepository<RoomType>(_context);

        public IGenericRepository<Guest> GuestRepository =>
            _guestRepository ??= new GenericRepository<Guest>(_context);

        public IGenericRepository<Booking> BookingRepository =>
            _bookingRepository ??= new GenericRepository<Booking>(_context);

        public IGenericRepository<Service> ServiceRepository =>
            _serviceRepository ??= new GenericRepository<Service>(_context);

        public IGenericRepository<BookingService> BookingServiceRepository =>
            _bookingServiceRepository ??= new GenericRepository<BookingService>(_context);

        public IGenericRepository<Invoice> InvoiceRepository =>
            _invoiceRepository ??= new GenericRepository<Invoice>(_context);

        public IGenericRepository<AppUser> AppUserRepository =>
            _appUserRepository ??= new GenericRepository<AppUser>(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public IDbContextTransaction BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
            return _transaction;
        }

        public void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction?.Rollback();
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}