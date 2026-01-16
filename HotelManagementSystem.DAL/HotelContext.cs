using HotelManagementSystem.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace HotelManagementSystem.DAL
{
    public class HotelContext : DbContext
    {
        // Constructor r?ng (b?t bu?c cho Migration và kh?i t?o m?c đ?nh)
        public HotelContext()
        {
        }

        // Constructor nh?n options (dùng khi mu?n c?u h?nh t? bên ngoài)
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        // Các DbSet đ?i di?n cho các b?ng trong h? th?ng khách s?n
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<BookingService> BookingServices { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Ch? c?u h?nh n?u chưa đư?c c?u h?nh (đ? tránh ghi đè n?u đ? truy?n options ? Constructor)
            if (!optionsBuilder.IsConfigured)
            {
                // Đ?c chu?i k?t n?i t? App.config
                // Lưu ?: Project ch?y chính (Forms) ph?i có file App.config ch?a connectionString này
                string? connectionString = ConfigurationManager.ConnectionStrings["HotelDB"]?.ConnectionString;

                if (string.IsNullOrEmpty(connectionString))
                {
                    // Fallback ho?c báo l?i n?u không t?m th?y c?u h?nh
                    throw new System.Exception("Không t?m th?y chu?i k?t n?i 'HotelDB' trong file c?u h?nh (App.config)!");
                }

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- C?U H?NH QUAN H? (RELATIONSHIPS) ---

            // 1. Room - RoomType (N-1)
            modelBuilder.Entity<Room>()
                .HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.RoomTypeId);

            // 2. Guest - Booking (1-N)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Guest)
                .WithMany(g => g.Bookings)
                .HasForeignKey(b => b.GuestId)
                .OnDelete(DeleteBehavior.Restrict);

            // 3. Room - Booking (1-N)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)
                .WithMany(r => r.Bookings)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            // 4. Booking - Invoice (1-1)
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Booking)
                .WithOne(b => b.Invoice)
                .HasForeignKey<Invoice>(i => i.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // 5. Booking - BookingService (1-N)
            modelBuilder.Entity<BookingService>()
                .HasOne(bs => bs.Booking)
                .WithMany(b => b.BookingServices)
                .HasForeignKey(bs => bs.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // 6. Service - BookingService (1-N)
            modelBuilder.Entity<BookingService>()
                .HasOne(bs => bs.Service)
                .WithMany(s => s.BookingServices)
                .HasForeignKey(bs => bs.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // 7. AppUser - Invoice (1-N)
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Staff)
                .WithMany()
                .HasForeignKey(i => i.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull);

            // Seed default admin account
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                AppUserId = 1,
                UserName = "admin",
                PasswordHash = "admin123", // Demo only; real app should hash passwords
                Role = "Admin",
                IsActive = true
            });

            // Seed default RoomTypes
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType { RoomTypeId = 1, RoomTypeName = "Single", Description = "Phòng đơn", PricePerNight = 200000M },
                new RoomType { RoomTypeId = 2, RoomTypeName = "Double", Description = "Phòng đôi", PricePerNight = 350000M },
                new RoomType { RoomTypeId = 3, RoomTypeName = "VIP", Description = "Phòng VIP", PricePerNight = 800000M }
            );

            // Seed default Services
            modelBuilder.Entity<Service>().HasData(
                new Service { ServiceId = 1, ServiceName = "Laundry", Price = 50000M, Description = "Giặt ủi", IsActive = true },
                new Service { ServiceId = 2, ServiceName = "Breakfast", Price = 80000M, Description = "Bữa sáng", IsActive = true },
                new Service { ServiceId = 3, ServiceName = "Spa", Price = 250000M, Description = "Dịch vụ spa", IsActive = true }
            );
        }
    }
}
