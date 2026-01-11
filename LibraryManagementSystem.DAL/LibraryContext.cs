using LibraryManagementSystem.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace LibraryManagementSystem.DAL
{
    public class HotelContext : DbContext
    {
        // Constructor rỗng (bắt buộc cho Migration và khởi tạo mặc định)
        public HotelContext()
        {
        }

        // Constructor nhận options (dùng khi muốn cấu hình từ bên ngoài)
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        // Các DbSet đại diện cho các bảng
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
            // Chỉ cấu hình nếu chưa được cấu hình (để tránh ghi đè nếu đã truyền options ở Constructor)
            if (!optionsBuilder.IsConfigured)
            {
                // Đọc chuỗi kết nối từ App.config
                // Lưu ý: Project chạy chính (Forms) phải có file App.config chứa connectionString này
                string connectionString = ConfigurationManager.ConnectionStrings["HotelDB"]?.ConnectionString;

                if (string.IsNullOrEmpty(connectionString))
                {
                    // Fallback hoặc báo lỗi nếu không tìm thấy cấu hình
                    throw new System.Exception("Không tìm thấy chuỗi kết nối 'HotelDB' trong file cấu hình (App.config)!");
                }

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- CẤU HÌNH QUAN HỆ (RELATIONSHIPS) ---

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
        }
    }
}