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

        [STAThread]
        static void Main()
        {
     // Cấu hình License cho EPPlus
   ExcelPackage.License.SetNonCommercialPersonal("HocSinh");

ApplicationConfiguration.Initialize();

  var services = new ServiceCollection();
            ConfigureServices(services);

      ServiceProvider = services.BuildServiceProvider();

        var startForm = ServiceProvider.GetRequiredService<FrmLogin>();
          Application.Run(startForm);
    }

        private static void ConfigureServices(IServiceCollection services)
       {
// --- A. Đọc Connection String từ App.config ---
       string connectionString = ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString;

 // --- B. Đăng ký Database & UnitOfWork ---
  services.AddDbContext<HotelContext>(options =>
          options.UseSqlServer(connectionString));

     services.AddScoped<IUnitOfWork, UnitOfWork>();

      // --- C. Đăng ký các Service (Logic nghiệp vụ) ---
       services.AddScoped<IAuthService, AuthService>();
  services.AddScoped<IRoomService, RoomService>();
 services.AddScoped<IGuestService, GuestService>();
     services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<IInvoiceService, InvoiceService>();

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
