using System;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

using HotelManagementSystem.DAL;
using HotelManagementSystem.DAL.Repositories;
using HotelManagementSystem.BLL.Interfaces;
using HotelManagementSystem.BLL.Services;
using HotelManagementSystem.Forms;

namespace HotelManagementSystem
{
    static class Program
    {
  public static IServiceProvider ServiceProvider { get; private set; } = null!;

        // Helper: create a new DI scope for a Form lifetime
        public static IServiceScope CreateScope() => ServiceProvider.CreateScope();

        [STAThread]
        static void Main()
        {
     // Cấu hình License cho EPPlus
   ExcelPackage.License.SetNonCommercialPersonal("HocSinh");

ApplicationConfiguration.Initialize();

  var services = new ServiceCollection();
            ConfigureServices(services);

      ServiceProvider = services.BuildServiceProvider();

        // Tạo một scope riêng cho FrmLogin (và các scoped services của nó).
        var startScope = CreateScope();
        var startForm = startScope.ServiceProvider.GetRequiredService<FrmLogin>();
        // Giữ scope sống đến khi form đóng, rồi dispose
        startForm.FormClosed += (s, e) => startScope.Dispose();

        Application.Run(startForm);
    }

        private static void ConfigureServices(IServiceCollection services)
       {
// --- A. Đọc Connection String từ App.config ---
       string connectionString = ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString;

 // --- B. Đăng ký Database & UnitOfWork ---
       // Use DbContextFactory to create DbContext instances on demand (prevents sharing one instance across threads)
       services.AddDbContextFactory<HotelContext>(options =>
       {
           options.UseSqlServer(connectionString, sqlOptions =>
           {
               sqlOptions.CommandTimeout(30);
               sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null);
           });
           options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
       });

    // Register UnitOfWork transient so each resolve gets its own instance (avoids DbContext concurrency)
    services.AddTransient<IUnitOfWork, UnitOfWork>();

      // --- C. Đăng ký các Service (Logic nghiệp vụ) ---
       // Changed to Transient to avoid DbContext sharing issues between forms
       services.AddTransient<IAuthService, AuthService>();
  services.AddTransient<IRoomService, RoomService>();
 services.AddTransient<IGuestService, GuestService>();
     services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IServiceService, ServiceService>();
        services.AddTransient<IInvoiceService, InvoiceService>();

   // --- D. Đăng ký các Form (Giao diện) ---
       services.AddTransient<FrmLogin>();
      services.AddTransient<FrmMain>();
            services.AddTransient<FrmRooms>();
  services.AddTransient<FrmGuests>();
    services.AddTransient<FrmBooking>();
       services.AddTransient<FrmServices>();
     services.AddTransient<FrmInvoice>();
        }
    }
}
