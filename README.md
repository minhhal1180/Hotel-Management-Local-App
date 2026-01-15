#  HỆ THỐNG QUẢN LÝ KHÁCH SẠN (Hotel Management System)

> **Báo cáo kỹ thuật chi tiết về kiến trúc và cách triển khai dự án**


---

##  MỤC LỤC

1. [Tổng quan Nghiệp vụ & Kiến trúc Hệ thống](#1-tổng-quan-nghiệp-vụ--kiến-trúc-hệ-thống)
2. [Kỹ thuật & Dependency Injection](#2-kỹ-thuật--dependency-injection-di)
3. [Cơ sở dữ liệu & Transaction](#3-cơ-sở-dữ-liệu--transaction)
4. [Async/Await Implementation](#4-asyncawait-implementation)
5. [Chức năng Nghiệp vụ & Validation](#5-chức-năng-nghiệp-vụ--validation)
6. [Xử lý Xuất/Nhập Excel](#6-xử-lý-xuấtnhập-excel)
7. [Hướng dẫn Thiết lập Form](#7-hướng-dẫn-chi-tiết-thiết-lập-form)
8. [Các lệnh thực thi](#8-các-lệnh-thực-thi)

---

## 1. TỔNG QUAN NGHIỆP VỤ & KIẾN TRÚC HỆ THỐNG

### 1.1 Mô tả Nghiệp vụ

#### Nghiệp vụ cốt lõi (Core Business Logic)
Hệ thống Quản lý Khách sạn giải quyết các vấn đề thực tế trong việc vận hành khách sạn:

| Nghiệp vụ | Mô tả |
|-----------|-------|
| **Quản lý Phòng** | Theo dõi danh sách phòng, loại phòng, giá phòng, trạng thái (Available/Occupied/Maintenance) |
| **Quản lý Khách hàng** | Lưu trữ thông tin khách (CMND, SĐT, địa chỉ, quốc tịch...) |
| **Đặt phòng (Booking)** | Tạo phiếu đặt phòng, kiểm tra phòng trống, tính tiền theo đêm |
| **Check-in/Check-out** | Nhận phòng, trả phòng, cập nhật trạng thái phòng tự động |
| **Quản lý Dịch vụ** | Giặt ủi, ăn uống, spa... thêm vào booking |
| **Lập hóa đơn** | Tổng hợp tiền phòng + dịch vụ, giảm giá, xuất Excel |

#### Vấn đề thực tế được giải quyết
-  Tránh đặt phòng trùng lịch (Double Booking)
-  Tự động tính tiền theo số đêm và giá phòng
-  Theo dõi lịch sử đặt phòng của khách
-  Quản lý dịch vụ đi kèm trong mỗi lần thuê phòng
-  Xuất báo cáo Excel cho kế toán

### 1.2 Cấu trúc Component (3-Layer Architecture)

```
┌─────────────────────────────────────────────────────────────┐
│                    PRESENTATION LAYER                       │
│              (HotelManagementSystem.Forms)                  │
│  FrmLogin | FrmMain | FrmRooms | FrmGuests | FrmBooking...  │
└─────────────────────────┬───────────────────────────────────┘
                          │ Constructor Injection
                          ▼
┌───────────────────────────────────────────────────────────────┐
│                     BUSINESS LOGIC LAYER                      │
│                 (HotelManagementSystem.BLL)                   │
│                                                               │
│  ┌───────────────┐        ┌─────────────────────────────────┐ │
│  │ Interfaces/   │        │ Services/                       │ │
│  ├───────────────┤        ├─────────────────────────────────┤ │
│  │ IAuthService  │◄───────│ AuthService.cs                  │ │
│  │ IRoomService  │◄───────│ RoomService.cs                  │ │
│  │ IGuestService │◄───────│ GuestService.cs                 │ │
│  │IBookingService│◄───────│ BookingService.cs               │ │
│  │IServiceService│◄───────│ ServiceService.cs               │ │
│  │IInvoiceService│◄───────│ InvoiceService.cs               │ │
│  └───────────────┘        └─────────────────────────────────┘ │
└─────────────────────────┬─────────────────────────────────────┘
                          │ IUnitOfWork Injection
                          ▼
┌─────────────────────────────────────────────────────────────┐
│                   DATA ACCESS LAYER                         │
│               (HotelManagementSystem.DAL)                   │
│                                                             │
│  ┌─────────────────────────────────────────────────────────┐│
│  │ Repositories/                                           ││
│  │  - IGenericRepository<T> : Interface CRUD chung         ││
│  │  - GenericRepository<T>  : Triển khai CRUD              ││
│  │  - IUnitOfWork           : Quản lý Transaction          ││
│  │  - UnitOfWork            : Triển khai Unit of Work      ││
│  └─────────────────────────────────────────────────────────┘│
│                                                             │
│  ┌─────────────────────────────────────────────────────────┐│
│  │ HotelContext.cs : DbContext (EF Core)                   ││
│  │  - Cấu hình DbSet cho các Entity                        ││
│  │  - Cấu hình Relationship (OnModelCreating)              ││
│  └─────────────────────────────────────────────────────────┘│
└─────────────────────────┬───────────────────────────────────┘
                          │ Entity Framework Core
                          ▼
┌─────────────────────────────────────────────────────────────┐
│                      ENTITIES LAYER                         │
│            (HotelManagementSystem.Entities)                 │
│                                                             │
│  Entities/                                                  │
│   - Room.cs          : Phòng khách sạn                      │
│   - RoomType.cs      : Loại phòng (Đơn, Đôi, VIP...)        │
│   - Guest.cs         : Khách hàng                           │
│   - Booking.cs       : Phiếu đặt phòng                      │
│   - BookingService.cs: Dịch vụ sử dụng trong booking        │
│   - Service.cs       : Dịch vụ đi kèm                       │
│   - Invoice.cs       : Hóa đơn thanh toán                   │
│   - AppUser.cs       : Tài khoản đăng nhập                  │
└─────────────────────────────────────────────────────────────┘
```

### 1.3 Chi tiết chức năng từng Component

#### **Forms (Presentation Layer)**
| Form | Chức năng |
|------|-----------|
| `FrmLogin` | Đăng nhập hệ thống, xác thực user |
| `FrmMain` | Menu chính, điều hướng đến các form con |
| `FrmRooms` | CRUD Phòng, Import/Export Excel |
| `FrmGuests` | CRUD Khách hàng, Import/Export Excel |
| `FrmBooking` | Đặt phòng, Check-in, Check-out, Hủy booking |
| `FrmServices` | CRUD Dịch vụ, Thêm dịch vụ vào booking |
| `FrmInvoice` | Lập hóa đơn, Tính tiền, Export Excel |

#### **Services (Business Logic Layer)**
| Service | Trách nhiệm |
|---------|-------------|
| `AuthService` | Xác thực đăng nhập |
| `RoomService` | Logic quản lý phòng, kiểm tra phòng trống |
| `GuestService` | Logic quản lý khách hàng |
| `BookingService` | Logic đặt phòng, check-in/out, tính tiền |
| `ServiceService` | Logic quản lý dịch vụ đi kèm |
| `InvoiceService` | Logic lập hóa đơn, tính tổng tiền |

#### **Repositories (Data Access Layer)**
| Repository | Chức năng |
|------------|-----------|
| `GenericRepository<T>` | CRUD chung cho mọi Entity |
| `UnitOfWork` | Quản lý Transaction, Commit/Rollback |

### 1.4 Tổ chức File

```
HotelManagementSystem/
│
├── HotelManagementSystem.Forms/       # UI Layer
│   ├── App.config                     # Connection String
│   ├── Program.cs                     # Entry Point, DI Configuration
│   ├── FrmLogin.cs/.Designer.cs       # Form đăng nhập
│   ├── FrmMain.cs/.Designer.cs        # Form menu chính
│   ├── FrmRooms.cs/.Designer.cs       # Form quản lý phòng
│   ├── FrmGuests.cs/.Designer.cs      # Form quản lý khách
│   ├── FrmBooking.cs/.Designer.cs     # Form đặt phòng
│   ├── FrmServices.cs/.Designer.cs    # Form dịch vụ
│   └── FrmInvoice.cs/.Designer.cs     # Form hóa đơn
│
├── HotelManagementSystem.BLL/         # Business Logic Layer
│   ├── Interfaces/                    # Định nghĩa Interface
│   │   ├── IAuthService.cs
│   │   ├── IRoomService.cs
│   │   ├── IGuestService.cs
│   │   ├── IBookingService.cs
│   │   ├── IServiceService.cs
│   │   └── IInvoiceService.cs
│   └── Services/                      # Triển khai Logic
│       ├── AuthService.cs
│       ├── RoomService.cs
│       ├── GuestService.cs
│       ├── BookingService.cs
│       ├── ServiceService.cs
│       └── InvoiceService.cs
│
├── HotelManagementSystem.DAL/         # Data Access Layer
│   ├── HotelContext.cs                # DbContext (EF Core)
│   ├── Repositories/
│   │   ├── IGenericRepository.cs      # Interface Repository
│   │   ├── GenericRepository.cs       # CRUD Implementation
│   │   ├── IUnitOfWork.cs             # Interface UoW
│   │   └── UnitOfWork.cs              # Transaction Management
│   └── Migrations/                    # EF Core Migrations
│
└── HotelManagementSystem.Entities/    # Entity Layer
    └── Entities/
        ├── Room.cs
        ├── RoomType.cs
        ├── Guest.cs
        ├── Booking.cs
        ├── BookingService.cs
        ├── Service.cs
        ├── Invoice.cs
        └── AppUser.cs
```

---

## 2. KỸ THUẬT & DEPENDENCY INJECTION (DI)

### 2.1 Cơ chế Dependency Injection

#### Vị trí đăng ký DI: `Program.cs`

```csharp
// File: HotelManagementSystem.Forms/Program.cs

static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    [STAThread]
    static void Main()
    {
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
        // A. Đọc Connection String từ App.config
        string connectionString = ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString;

        // B. Đăng ký Database & UnitOfWork
        services.AddDbContext<HotelContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // C. Đăng ký các Service (Logic nghiệp vụ)
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IGuestService, GuestService>();
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<IInvoiceService, InvoiceService>();

        // D. Đăng ký các Form (Giao diện)
        services.AddTransient<FrmLogin>();
        services.AddTransient<FrmMain>();
        services.AddTransient<FrmRooms>();
        services.AddTransient<FrmGuests>();
        services.AddTransient<FrmBooking>();
        services.AddTransient<FrmServices>();
        services.AddTransient<FrmInvoice>();
    }
}
```

### 2.2 Vòng đời Service (Service Lifetime)

| Vòng đời | Service | Giải thích |
|----------|---------|------------|
| **Scoped** | `HotelContext` | Mỗi request tạo 1 instance mới, đảm bảo transaction consistency |
| **Scoped** | `IUnitOfWork, UnitOfWork` | Cùng scope với DbContext để quản lý transaction |
| **Scoped** | `IAuthService, IRoomService...` | Logic nghiệp vụ dùng chung UnitOfWork trong cùng scope |
| **Transient** | `FrmLogin, FrmMain, FrmRooms...` | Mỗi lần mở Form tạo instance mới |

### 2.3 Interface & Implementation

#### Lý do chia Interface:
-  **Loose Coupling**: Form không phụ thuộc trực tiếp vào Service cụ thể
-  **Testability**: Dễ Mock interface khi Unit Test
-  **Flexibility**: Có thể thay đổi implementation mà không sửa Form

#### Quy trình tiêm Interface vào Constructor:

```csharp
// 1. Interface định nghĩa hợp đồng
public interface IGuestService
{
    IEnumerable<Guest> GetGuests(string keyword = "");
    Guest? GetGuestById(int id);
    void AddGuest(Guest guest);
    void UpdateGuest(Guest guest);
    void DeleteGuest(int id);
    string ImportGuestsFromExcel(string filePath);
    void ExportGuestsToExcel(string filePath);
    void RefreshCache();
}

// 2. Service triển khai Interface, nhận IUnitOfWork qua Constructor
public class GuestService : IGuestService
{
    private readonly IUnitOfWork _unitOfWork;

    public GuestService(IUnitOfWork unitOfWork)  // Constructor Injection
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Guest> GetGuests(string keyword = "") { ... }
    // ...
}

// 3. Form nhận Service qua Constructor
public partial class FrmGuests : Form
{
    private readonly IGuestService _guestService;

    public FrmGuests(IGuestService guestService)  // Constructor Injection
    {
        InitializeComponent();
        _guestService = guestService;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        _guestService.AddGuest(guest);  // Sử dụng Service
    }
}
```

### 2.4 Xử lý Bất đồng bộ (Asynchronous)

#### Trạng thái hiện tại:
Dự án **KHÔNG sử dụng async/await** - tất cả các phương thức đều chạy đồng bộ (synchronous).

```csharp
// Hiện tại: Đồng bộ
public IEnumerable<Guest> GetGuests(string keyword = "")
{
    return _unitOfWork.GuestRepository.GetAll().ToList();
}

// Nếu chuyển sang bất đồng bộ (khuyến nghị cho tương lai):
public async Task<IEnumerable<Guest>> GetGuestsAsync(string keyword = "")
{
    return await _unitOfWork.GuestRepository.GetAllAsync().ToListAsync();
}
```

#### Lợi ích của Async/Await (nếu triển khai):
-  Không block UI thread khi thao tác Database
-  Cải thiện responsiveness của ứng dụng WinForms
-  Tối ưu tài nguyên hệ thống

#### Return Type hiện tại:
- `void` - Cho các phương thức không cần trả về
- `IEnumerable<T>` - Cho danh sách Entity
- `T?` - Cho single Entity (có thể null)
- `string` - Cho thông báo kết quả (Import Excel)

---

## 3. CƠ SỞ DỮ LIỆU & TRANSACTION

### 3.1 Cấu hình Database

#### Connection String trong `App.config`:

```xml
<!-- File: HotelManagementSystem.Forms/App.config -->
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <connectionStrings>
        <add name="HotelDB"
             connectionString="Server=(localdb)\MSSQLLocalDB;Database=HotelDB;Trusted_Connection=True;TrustServerCertificate=True;"
             providerName="System.Data.SqlClient" />
    </connectionStrings>
</configuration>
```

#### Code đọc Connection String:

```csharp
// File: Program.cs - Đọc config khi khởi tạo DI
string connectionString = ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString;
services.AddDbContext<HotelContext>(options => options.UseSqlServer(connectionString));

// File: HotelContext.cs - Fallback nếu không truyền options
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["HotelDB"]?.ConnectionString;
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("Không tìm thấy chuỗi kết nối 'HotelDB' trong App.config!");
        }
        optionsBuilder.UseSqlServer(connectionString);
    }
}
```

### 3.2 Xử lý Transaction

#### Hệ thống áp dụng Transaction:
Có - Sử dụng **Database Transaction** để đảm bảo tính toàn vẹn dữ liệu.

#### Lý do sử dụng Transaction:
-  **Data Consistency**: Khi Check-in cần cập nhật cả Booking và Room status
-  **Atomic Operation**: Tất cả thay đổi thành công hoặc tất cả rollback
-  **Isolation**: Tránh dirty read trong multi-user environment

#### Vị trí xử lý Transaction: **Service Layer**

```csharp
// File: BookingService.cs
public void CheckIn(int bookingId)
{
    var booking = _unitOfWork.BookingRepository.GetByID(bookingId);
    if (booking == null) throw new Exception("Không tìm thấy booking!");
    if (booking.Status != "Booked") throw new Exception("Booking không ở trạng thái chờ nhận phòng!");

    // BẮT ĐẦU TRANSACTION
    using var transaction = _unitOfWork.BeginTransaction();
    try
    {
        // 1. Cập nhật trạng thái booking
        booking.Status = "CheckedIn";
        booking.CheckInDate = DateTime.Now;
        _unitOfWork.BookingRepository.Update(booking);

        // 2. Cập nhật trạng thái phòng
        var room = _unitOfWork.RoomRepository.GetByID(booking.RoomId);
        if (room != null)
        {
            room.Status = "Occupied";
            _unitOfWork.RoomRepository.Update(room);
        }

        // COMMIT - Lưu tất cả thay đổi
        _unitOfWork.Save();
        _unitOfWork.Commit();
        RefreshCache();
    }
    catch
    {
        // ROLLBACK - Hủy tất cả thay đổi nếu có lỗi
        _unitOfWork.Rollback();
        throw;
    }
}
```

#### UnitOfWork Transaction Methods:

```csharp
// File: UnitOfWork.cs
public IDbContextTransaction BeginTransaction()
{
    _transaction = _context.Database.BeginTransaction();
    return _transaction;
}

public void Commit()
{
    try { _transaction?.Commit(); }
    finally { _transaction?.Dispose(); _transaction = null; }
}

public void Rollback()
{
    try { _transaction?.Rollback(); }
    finally { _transaction?.Dispose(); _transaction = null; }
}
```

### 3.3 Sơ đồ Database (Entity Relationship)

```
┌─────────────┐       ┌─────────────┐       ┌─────────────┐
│  RoomType   │──1:N─→│    Room     │──1:N─→│   Booking   │
├─────────────┤       ├─────────────┤       ├─────────────┤
│ RoomTypeId  │       │ RoomId      │       │ BookingId   │
│ RoomTypeName│       │ RoomNumber  │       │ GuestId (FK)│
│ PricePerNigh│       │ RoomTypeId  │       │ RoomId (FK) │
│ Description │       │ Floor       │       │ CheckInDate │
└─────────────┘       │ Status      │       │ CheckOutDate│
                      │ Description │       │ Status      │
                      └─────────────┘       │ TotalAmount │
                                            │ Note        │
┌─────────────┐                             └──────┬──────┘
│    Guest    │◄─────────────────────1:N───────────┘
├─────────────┤                                    │
│ GuestId     │       ┌─────────────┐              │
│ FullName    │       │   Service   │              │
│ IdentityCard│       ├─────────────┤              │1:1
│ DOB         │       │ ServiceId   │              │
│ Phone       │       │ ServiceName │              ▼
│ Address     │       │ Price       │       ┌─────────────┐
│ Email       │       │ Description │       │   Invoice   │
│ Nationality │       │ IsActive    │       ├─────────────┤
└─────────────┘       └──────┬──────┘       │ InvoiceId   │
                             │              │ BookingId   │
                             │1:N           │ RoomCharge  │
                             ▼              │ServiceCharge│
                    ┌────────────────┐      │ Discount    │
                    │  BookingService│      │ TotalAmount │
                    ├────────────────┤      │PaymentMethod│
                    │BookingServiceId│      │ PaymentDate │
                    │ BookingId      │◄─N:1─│ CreatedBy   │
                    │ ServiceId      │      └─────────────┘
                    │ Quantity       │              │
                    │ UnitPrice      │              │N:1
                    │ UsedDate       │              ▼
                    └────────────────┘      ┌─────────────┐
                                            │   AppUser   │
                                            ├─────────────┤
                                            │ AppUserId   │
                                            │ UserName    │
                                            │PasswordHash │
                                            │ Role        │
                                            │ IsActive    │
                                            └─────────────┘
```

### 3.4 Chi tiết các Bảng Database

| Bảng | Mô tả | Số cột |
|------|-------|--------|
| **RoomType** | Loại phòng (Đơn, Đôi, VIP...) | 4 |
| **Room** | Thông tin phòng | 6 |
| **Guest** | Thông tin khách hàng | 9 |
| **Booking** | Phiếu đặt phòng | 10 |
| **Service** | Dịch vụ đi kèm | 5 |
| **BookingService** | Dịch vụ đã sử dụng trong booking | 6 |
| **Invoice** | Hóa đơn thanh toán | 10 |
| **AppUser** | Tài khoản đăng nhập | 5 |

### 3.5 Mapping dữ liệu (Entity ↔ DTO)

Dự án **KHÔNG sử dụng DTO riêng** - các Entity được sử dụng trực tiếp.

**Chuyển đổi dữ liệu hiển thị tại Form:**

```csharp
// File: FrmGuests.cs - Chuyển Entity sang Anonymous Type để hiển thị
var displayList = guests.Select(g => new
{
    g.GuestId,
    g.FullName,
    g.IdentityCard,
    DOB = g.DOB?.ToString("dd/MM/yyyy"),  // Format ngày
    g.Phone,
    g.Address,
    g.Email,
    g.Nationality,
    CreatedDate = g.CreatedDate.ToString("dd/MM/yyyy")
}).ToList();

dgvGuests.DataSource = displayList;
```
---

## 4. ASYNC/AWAIT IMPLEMENTATION

### 4.1 Cơ sở Lý thuyết Async/Await

**Synchronous vs Asynchronous:**

| Khía cạnh | Synchronous | Asynchronous |
|-----------|-------------|--------------|
| **Cách thức hoạt động** | Thực thi tuần tự, chờ từng tác vụ hoàn thành | Cho phép nhiều tác vụ chạy song song |
| **Blocking** | Block thread khi chờ I/O (Database, File, Network) | Không block thread, giải phóng thread về pool |
| **UI Responsiveness** | UI đơ khi thực hiện tác vụ dài | UI luôn phản hồi (responsive) |
| **Resource Usage** | 1 thread/request (tốn tài nguyên) | Nhiều request dùng chung thread pool |
| **Scalability** | Giới hạn bởi số lượng thread | Mở rộng tốt hơn nhiều lần |

#### Performance Benefits

**Throughput Improvement:**
```
Synchronous App:
- 100 concurrent users
- Each request needs 1 thread
- Cần 100 threads → Tốn 100MB RAM (1MB/thread)

Asynchronous App:
- 100 concurrent users
- Threads được reuse khi chờ I/O
- Chỉ cần ~10-20 threads → Tiết kiệm 80-90MB RAM
- Phục vụ được 1000+ concurrent users trên cùng phần cứng
```
**Latency Improvement trong WinForms:**
```
Scenario: Load 10,000 guests từ database

Synchronous:
- UI thread blocked 2-3 giây
- User không thể click, scroll, minimize
- Trải nghiệm xấu

Asynchronous:
- UI thread free ngay lập tức
- User vẫn tương tác bình thường
- Progress bar/loading animation hoạt động mượt
```

### 4.1 Kiến trúc Async từng Layer

#### **Data Access Layer (DAL) - Repository Async**

```csharp
// Interface: IGenericRepository<T>
public interface IGenericRepository<T> where T : class
{
    // Synchronous methods (giữ lại cho backward compatibility)
    IEnumerable<T> GetAll(...);
    T? GetByID(object id);
    void Insert(T entity);
    void Delete(object id);
    void Update(T entity);
    
    // NEW: Asynchronous methods
    Task<IEnumerable<T>> GetAllAsync(...);
    Task<T?> GetByIDAsync(object id);
    Task DeleteAsync(object id);
}

// Implementation: GenericRepository<T>
public async Task<IEnumerable<T>> GetAllAsync(
    Expression<Func<T, bool>>? filter = null,
    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
    string includeProperties = "")
{
    IQueryable<T> query = dbSet;

    if (filter != null)
        query = query.Where(filter);

    foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
        query = query.Include(includeProperty);

    if (orderBy != null)
        return await orderBy(query).ToListAsync(); // EF Core async
    else
        return await query.ToListAsync(); // EF Core async
}

public async Task<T?> GetByIDAsync(object id)
{
    return await dbSet.FindAsync(id); // EF Core async
}

public async Task DeleteAsync(object id)
{
    T? entityToDelete = await dbSet.FindAsync(id);
    if (entityToDelete != null)
        Delete(entityToDelete);
}
```

#### **Unit of Work Async**

```csharp
// Interface: IUnitOfWork
public interface IUnitOfWork : IDisposable
{
    // Repository properties
    IGenericRepository<Room> RoomRepository { get; }
    IGenericRepository<Guest> GuestRepository { get; }
    // ... other repositories
    
    // Synchronous methods
    void Save();
    IDbContextTransaction BeginTransaction();
    void Commit();
    void Rollback();
    
    // NEW: Asynchronous methods
    Task SaveAsync();
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}

// Implementation: UnitOfWork
public async Task SaveAsync()
{
    await _context.SaveChangesAsync();
}

public async Task<IDbContextTransaction> BeginTransactionAsync()
{
    _transaction = await _context.Database.BeginTransactionAsync();
    return _transaction;
}

public async Task CommitAsync()
{
    try
    {
        if (_transaction != null)
            await _transaction.CommitAsync();
    }
    finally
    {
        if (_transaction != null)
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
}

public async Task RollbackAsync()
{
    try
    {
        if (_transaction != null)
            await _transaction.RollbackAsync();
    }
    finally
    {
        if (_transaction != null)
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
}
```

#### **Business Logic Layer (BLL) - Service Async**

```csharp
// Interface: IGuestService
public interface IGuestService
{
    Task<IEnumerable<Guest>> GetGuestsAsync(string keyword = "");
    Task<Guest?> GetGuestByIdAsync(int id);
    Task AddGuestAsync(Guest guest);
    Task UpdateGuestAsync(Guest guest);
    Task DeleteGuestAsync(int id);
    Task<string> ImportGuestsFromExcelAsync(string filePath);
    Task ExportGuestsToExcelAsync(string filePath);
    void RefreshCache();
    Task RefreshCacheAsync();
}

// Implementation: GuestService
public class GuestService : IGuestService
{
    private readonly IUnitOfWork _unitOfWork;
    private static List<Guest>? _cachedGuests = null;

    public async Task RefreshCacheAsync()
    {
        var guests = await _unitOfWork.GuestRepository.GetAllAsync();
        _cachedGuests = guests.ToList();
    }

    public async Task<IEnumerable<Guest>> GetGuestsAsync(string keyword = "")
    {
        if (_cachedGuests == null)
            await RefreshCacheAsync();

        if (string.IsNullOrEmpty(keyword))
            return _cachedGuests!;

        keyword = keyword.ToLower();
        return _cachedGuests!.Where(g =>
            g.FullName.ToLower().Contains(keyword) ||
            (g.IdentityCard?.ToLower().Contains(keyword) ?? false) ||
            (g.Phone?.ToLower().Contains(keyword) ?? false)
        ).ToList();
    }

    public async Task AddGuestAsync(Guest guest)
    {
        _unitOfWork.GuestRepository.Insert(guest);
        await _unitOfWork.SaveAsync();
        
        if (_cachedGuests != null)
            _cachedGuests.Add(guest);
    }

    public async Task<string> ImportGuestsFromExcelAsync(string filePath)
    {
        // ... validation logic ...
        
        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var sheet = package.Workbook.Worksheets[0];
            int rowCount = sheet.Dimension.Rows;
            
            for (int row = 2; row <= rowCount; row++)
            {
                // ... create guest entity ...
                _unitOfWork.GuestRepository.Insert(guest);
            }
            
            await _unitOfWork.SaveAsync(); // Async save
            await RefreshCacheAsync();
        }
    }

    public async Task ExportGuestsToExcelAsync(string filePath)
    {
        var guests = (await GetGuestsAsync("")).ToList();
        
        using (var package = new ExcelPackage())
        {
            var sheet = package.Workbook.Worksheets.Add("Khách hàng");
            
            // ... populate Excel ...
            
            await package.SaveAsAsync(new FileInfo(filePath)); // EPPlus async
        }
    }
}
```

#### **Booking Service với Async Transaction**

```csharp
public async Task CreateBookingAsync(int guestId, int roomId, 
    DateTime checkIn, DateTime checkOut, string? note = null)
{
    var guest = await _unitOfWork.GuestRepository.GetByIDAsync(guestId);
    if (guest == null) throw new Exception("Không tìm thấy khách hàng!");

    var rooms = await _unitOfWork.RoomRepository.GetAllAsync(
        filter: r => r.RoomId == roomId,
        includeProperties: "RoomType"
    );
    var room = rooms.FirstOrDefault();
    if (room == null) throw new Exception("Không tìm thấy phòng!");

    // Kiểm tra phòng trống bất đồng bộ
    var existingBookings = await _unitOfWork.BookingRepository.GetAllAsync(
        filter: b => b.RoomId == roomId &&
                     b.Status != "Cancelled" && b.Status != "CheckedOut" &&
                     ((checkIn >= b.CheckInDate && checkIn < b.CheckOutDate) ||
                      (checkOut > b.CheckInDate && checkOut <= b.CheckOutDate) ||
                      (checkIn <= b.CheckInDate && checkOut >= b.CheckOutDate))
    );
    
    if (existingBookings.Any()) 
        throw new Exception("Phòng đã được đặt trong khoảng thời gian này!");

    // Transaction async
    using var transaction = await _unitOfWork.BeginTransactionAsync();
    try
    {
        var booking = new Booking { /* ... */ };
        _unitOfWork.BookingRepository.Insert(booking);
        await _unitOfWork.SaveAsync();
        await _unitOfWork.CommitAsync();
        
        await RefreshCacheAsync();
    }
    catch
    {
        await _unitOfWork.RollbackAsync();
        throw;
    }
}

public async Task CheckInAsync(int bookingId)
{
    var booking = await _unitOfWork.BookingRepository.GetByIDAsync(bookingId);
    if (booking == null) throw new Exception("Không tìm thấy booking!");
    
    using var transaction = await _unitOfWork.BeginTransactionAsync();
    try
    {
        booking.Status = "CheckedIn";
        _unitOfWork.BookingRepository.Update(booking);

        var room = await _unitOfWork.RoomRepository.GetByIDAsync(booking.RoomId);
        if (room != null)
        {
            room.Status = "Occupied";
            _unitOfWork.RoomRepository.Update(room);
        }

        await _unitOfWork.SaveAsync();
        await _unitOfWork.CommitAsync();
        await RefreshCacheAsync();
    }
    catch
    {
        await _unitOfWork.RollbackAsync();
        throw;
    }
}
```

#### **Presentation Layer (Forms) - Async Event Handlers**

```csharp
// FrmGuests.cs
public partial class FrmGuests : Form
{
    private readonly IGuestService _guestService;

    // Form Load - async void event handler
    private async void FrmGuests_Load(object? sender, EventArgs e)
    {
        await LoadGuestsAsync();
        dtpDOB.Value = new DateTime(1990, 1, 1);
    }

    // Load data method - async Task
    private async System.Threading.Tasks.Task LoadGuestsAsync(string keyword = "")
    {
        try
        {
            var guests = await _guestService.GetGuestsAsync(keyword);
            var displayList = guests.Select(g => new
            {
                g.GuestId,
                g.FullName,
                g.IdentityCard,
                DOB = g.DOB?.ToString("dd/MM/yyyy"),
                g.Phone,
                g.Address,
                g.Email,
                g.Nationality,
                CreatedDate = g.CreatedDate.ToString("dd/MM/yyyy")
            }).ToList();

            dgvGuests.DataSource = displayList;
            // ... setup columns ...
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải khách hàng: " + ex.Message);
        }
    }

    // Button click - async void event handler
    private async void btnAdd_Click(object sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        try
        {
            var guest = new Guest
            {
                FullName = txtFullName.Text.Trim(),
                IdentityCard = txtIdentityCard.Text.Trim(),
                DOB = dtpDOB.Value,
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Nationality = txtNationality.Text.Trim(),
                CreatedDate = DateTime.Now
            };

            await _guestService.AddGuestAsync(guest);
            MessageBox.Show("Thêm khách hàng thành công!");
            await LoadGuestsAsync();
            ResetForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message);
        }
    }

    // Export Excel - async void
    private async void btnExport_Click(object sender, EventArgs e)
    {
        using (SaveFileDialog sfd = new SaveFileDialog() 
        { 
            Filter = "Excel|*.xlsx", 
            FileName = "DanhSachKhachHang.xlsx" 
        })
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _guestService.ExportGuestsToExcelAsync(sfd.FileName);
                    MessageBox.Show("Xuất file Excel thành công!");
                }
                catch (Exception ex) 
                { 
                    MessageBox.Show("Lỗi: " + ex.Message); 
                }
            }
        }
    }
} 
```  
---

## 5. CHỨC NĂNG NGHIỆP VỤ & VALIDATION

### 5.1 Phân loại Chức năng

#### A. Chức năng CRUD cơ bản

| Entity | Create | Read | Update | Delete |
|--------|--------|------|--------|--------|
| Room | `AddRoom()` | `GetRooms()`, `GetRoomById()` | `UpdateRoom()` | `DeleteRoom()` |
| Guest | `AddGuest()` | `GetGuests()`, `GetGuestById()` | `UpdateGuest()` | `DeleteGuest()` |
| Service | `AddService()` | `GetServices()`, `GetServiceById()` | `UpdateService()` | `DeleteService()` |
| Booking | `CreateBooking()` | `GetBookings()`, `GetBookingById()` | - | `CancelBooking()` |
| Invoice | `CreateInvoice()` | `GetInvoices()`, `GetInvoiceById()` | - | - |

#### B. Chức năng Nghiệp vụ Nâng cao

**1. Kiểm tra phòng trống (RoomService.cs):**
```csharp
public IEnumerable<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut)
{
    // Lấy danh sách phòng đang bận trong khoảng thời gian
    var busyRoomIds = _unitOfWork.BookingRepository.GetAll(
        filter: b => b.Status != "Cancelled" && b.Status != "CheckedOut" &&
                     ((checkIn >= b.CheckInDate && checkIn < b.CheckOutDate) ||
                      (checkOut > b.CheckInDate && checkOut <= b.CheckOutDate) ||
                      (checkIn <= b.CheckInDate && checkOut >= b.CheckOutDate))
    ).Select(b => b.RoomId).Distinct().ToList();

    // Trả về phòng không bận và đang Available
    return _cachedRooms!.Where(r =>
        r.Status == "Available" && !busyRoomIds.Contains(r.RoomId)
    ).ToList();
}
```

**2. Tạo Booking với kiểm tra trùng lịch (BookingService.cs):**
```csharp
public void CreateBooking(int guestId, int roomId, DateTime checkIn, DateTime checkOut, string? note = null)
{
    // Kiểm tra phòng có trống trong khoảng thời gian không
    var isBooked = _unitOfWork.BookingRepository.GetAll(
        filter: b => b.RoomId == roomId &&
                     b.Status != "Cancelled" && b.Status != "CheckedOut" &&
                     ((checkIn >= b.CheckInDate && checkIn < b.CheckOutDate) ||
                      (checkOut > b.CheckInDate && checkOut <= b.CheckOutDate) ||
                      (checkIn <= b.CheckInDate && checkOut >= b.CheckOutDate))
    ).Any();

    if (isBooked) throw new Exception("Phòng đã được đặt trong khoảng thời gian này!");

    // Tính số đêm và tổng tiền phòng
    int nights = (int)(checkOut - checkIn).TotalDays;
    if (nights <= 0) nights = 1;
    decimal totalAmount = nights * (room.RoomType?.PricePerNight ?? 0);
    // ...
}
```

**3. Tính tiền hóa đơn (InvoiceService.cs):**
```csharp
public decimal CalculateRoomCharge(int bookingId)
{
    var booking = _unitOfWork.BookingRepository.GetAll(...).FirstOrDefault();

    // Tính số đêm thực tế
    DateTime checkOut = booking.ActualCheckOut ?? booking.CheckOutDate;
    int nights = (int)(checkOut - booking.CheckInDate).TotalDays;
    if (nights <= 0) nights = 1;

    decimal pricePerNight = booking.Room?.RoomType?.PricePerNight ?? 0;
    return nights * pricePerNight;
}

public decimal CalculateServiceCharge(int bookingId)
{
    var services = _unitOfWork.BookingServiceRepository.GetAll(
        filter: bs => bs.BookingId == bookingId
    ).ToList();

    return services.Sum(s => s.Quantity * s.UnitPrice);
}
```

### 5.2 Validation (Kiểm tra dữ liệu)

#### Vị trí Validate: **Tại Form (Presentation Layer)**

```csharp
// File: FrmGuests.cs
private bool ValidateInput()
{
    if (string.IsNullOrWhiteSpace(txtFullName.Text))
    {
        MessageBox.Show("Vui lòng nhập họ tên!");
        txtFullName.Focus();
        return false;
    }
    if (string.IsNullOrWhiteSpace(txtPhone.Text))
    {
        MessageBox.Show("Vui lòng nhập số điện thoại!");
        txtPhone.Focus();
        return false;
    }
    return true;
}

private void btnAdd_Click(object sender, EventArgs e)
{
    if (!ValidateInput()) return;  // Validate trước khi gọi Service
    // ...
}
```

#### Validate tại Service Layer (Business Rules):

```csharp
// File: GuestService.cs - Kiểm tra ràng buộc nghiệp vụ
public void DeleteGuest(int id)
{
    // Kiểm tra khách có booking không
    var hasBooking = _unitOfWork.BookingRepository.GetAll(
        filter: b => b.GuestId == id
    ).Any();

    if (hasBooking)
    {
        throw new InvalidOperationException("Khách hàng đã có lịch sử đặt phòng, không thể xóa!");
    }

    _unitOfWork.GuestRepository.Delete(id);
    _unitOfWork.Save();
}
```

#### Cơ chế thông báo lỗi:

```csharp
// Sử dụng MessageBox trong WinForms
try
{
    _guestService.DeleteGuest(guestId);
    MessageBox.Show("Xóa khách hàng thành công!");
}
catch (Exception ex)
{
    MessageBox.Show("Lỗi: " + ex.Message);  // Hiển thị message từ Exception
}
```

---

## 6. XỬ LÝ XUẤT/NHẬP EXCEL

### 6.1 Thư viện sử dụng

**EPPlus** - Version 8.4.0

```xml
<!-- File: HotelManagementSystem.Forms.csproj -->
<PackageReference Include="EPPlus" Version="8.4.0" />
```

**Cấu hình License (Non-Commercial):**
```csharp
// File: Program.cs
ExcelPackage.License.SetNonCommercialPersonal("HocSinh");
```

### 6.2 Triển khai Export/Import với Async

#### Logic xuất file: **Tại Service Layer** (Tách riêng khỏi Controller/Form)

| File | Hàm Export Async | Hàm Import Async |
|------|------------------|------------------|
| `RoomService.cs` | `ExportRoomsToExcelAsync()` | `ImportRoomsFromExcelAsync()` |
| `GuestService.cs` | `ExportGuestsToExcelAsync()` | `ImportGuestsFromExcelAsync()` |
| `BookingService.cs` | `ExportBookingHistoryToExcelAsync()` | - |
| `InvoiceService.cs` | `ExportInvoiceToExcelAsync()`, `ExportAllInvoicesToExcelAsync()` | - |


```csharp
// GuestService.cs
public async Task ExportGuestsToExcelAsync(string filePath)
{
    var guests = (await GetGuestsAsync("")).ToList();
    
    using (var package = new ExcelPackage())
    {
        var sheet = package.Workbook.Worksheets.Add("Khách hàng");
        
        // Headers
        string[] headers = { "Mã KH", "Họ tên", "CMND", "Ngày sinh", "SĐT", "Địa chỉ", "Email", "Quốc tịch" };
        for (int i = 0; i < headers.Length; i++)
            sheet.Cells[1, i + 1].Value = headers[i];

        // Data rows
        for (int i = 0; i < guests.Count; i++)
        {
            var g = guests[i];
            sheet.Cells[i + 2, 1].Value = g.GuestId;
            sheet.Cells[i + 2, 2].Value = g.FullName;
            sheet.Cells[i + 2, 3].Value = g.IdentityCard;
            sheet.Cells[i + 2, 4].Value = g.DOB?.ToString("dd/MM/yyyy");
            sheet.Cells[i + 2, 5].Value = g.Phone;
            sheet.Cells[i + 2, 6].Value = g.Address;
            sheet.Cells[i + 2, 7].Value = g.Email;
            sheet.Cells[i + 2, 8].Value = g.Nationality;
        }

        sheet.Cells.AutoFitColumns();
        await package.SaveAsAsync(new FileInfo(filePath)); // EPPlus async method
    }
}
```

#### Import Excel với Async
```csharp
// GuestService.cs
public async Task<string> ImportGuestsFromExcelAsync(string filePath)
{
    if (!File.Exists(filePath))
        throw new FileNotFoundException("File không tồn tại!");

    int successCount = 0;
    int errorCount = 0;
    var errorMessages = new List<string>();

    using (var package = new ExcelPackage(new FileInfo(filePath)))
    {
        var sheet = package.Workbook.Worksheets[0];
        int rowCount = sheet.Dimension.Rows;

        for (int row = 2; row <= rowCount; row++) // Bỏ qua header
        {
            try
            {
                var guest = new Guest
                {
                    FullName = sheet.Cells[row, 2].Text,
                    IdentityCard = sheet.Cells[row, 3].Text,
                    DOB = DateTime.TryParse(sheet.Cells[row, 4].Text, out var dob) ? dob : null,
                    Phone = sheet.Cells[row, 5].Text,
                    Address = sheet.Cells[row, 6].Text,
                    Email = sheet.Cells[row, 7].Text,
                    Nationality = sheet.Cells[row, 8].Text,
                    CreatedDate = DateTime.Now
                };

                _unitOfWork.GuestRepository.Insert(guest);
                successCount++;
            }
            catch (Exception ex)
            {
                errorCount++;
                errorMessages.Add($"Dòng {row}: {ex.Message}");
            }
        }

        await _unitOfWork.SaveAsync(); // Async save all
        await RefreshCacheAsync();
    }

    string result = $"Thêm thành công {successCount}, lỗi {errorCount} dòng";
    if (errorMessages.Any())
        result += "\n" + string.Join("\n", errorMessages);

    return result;
}
```

### 6.3 Chi tiết Output Excel

#### **A. File: DanhSachPhong.xlsx (Rooms)**

| Cột | Tên cột | Kiểu dữ liệu | Mô tả |
|-----|---------|--------------|-------|
| A | Mã phòng | Integer | RoomId |
| B | Số phòng | String | VD: 101, 102, 201 |
| C | Loại phòng | String | Đơn, Đôi, VIP... |
| D | Tầng | Integer | 1, 2, 3... |
| E | Trạng thái | String | Available/Occupied/Maintenance |
| F | Giá/đêm | Decimal | VNĐ |
| G | Mô tả | String | Nullable |

```csharp
// File: RoomService.cs
public void ExportRoomsToExcel(string filePath)
{
    var rooms = GetRooms().ToList();
    using (var package = new ExcelPackage())
    {
        var sheet = package.Workbook.Worksheets.Add("Danh sách Phòng");

        string[] headers = { "Mã phòng", "Số phòng", "Loại phòng", "Tầng", "Trạng thái", "Giá/đêm", "Mô tả" };
        for (int i = 0; i < headers.Length; i++)
            sheet.Cells[1, i + 1].Value = headers[i];

        for (int i = 0; i < rooms.Count; i++)
        {
            var r = rooms[i];
            sheet.Cells[i + 2, 1].Value = r.RoomId;
            sheet.Cells[i + 2, 2].Value = r.RoomNumber;
            sheet.Cells[i + 2, 3].Value = r.RoomType?.RoomTypeName;
            sheet.Cells[i + 2, 4].Value = r.Floor;
            sheet.Cells[i + 2, 5].Value = r.Status;
            sheet.Cells[i + 2, 6].Value = r.RoomType?.PricePerNight;
            sheet.Cells[i + 2, 7].Value = r.Description;
        }

        sheet.Cells.AutoFitColumns();
        package.SaveAs(new FileInfo(filePath));
    }
}
```

#### **B. File: DanhSachKhachHang.xlsx (Guests)**

| Cột | Tên cột | Kiểu dữ liệu | Mô tả |
|-----|---------|--------------|-------|
| A | Mã KH | Integer | GuestId |
| B | Họ tên | String | Required |
| C | CMND/CCCD | String | Nullable |
| D | Ngày sinh | Date (dd/MM/yyyy) | Nullable |
| E | SĐT | String | Required |
| F | Địa chỉ | String | Nullable |
| G | Email | String | Nullable |
| H | Quốc tịch | String | Nullable |
| I | Ngày tạo | Date (dd/MM/yyyy) | Auto |

#### **C. File: LichSuDatPhong.xlsx (Booking History)**

| Cột | Tên cột | Kiểu dữ liệu |
|-----|---------|--------------|
| A | Mã ĐP | Integer |
| B | Khách hàng | String |
| C | Phòng | String |
| D | Loại phòng | String |
| E | Ngày đặt | Date |
| F | Check-in | Date |
| G | Check-out | Date |
| H | Tiền phòng | Decimal |
| I | Trạng thái | String |

#### **D. File: HoaDon_[ID].xlsx (Single Invoice)**

```
┌──────────────────────────────────────────────────────────┐
│ HÓA ĐƠN THANH TOÁN                                       │
│ Mã hóa đơn: [InvoiceId]                                  │
│ Ngày: [PaymentDate]                                      │
│ Khách hàng: [GuestName]                                  │
│ Phòng: [RoomNumber]                                      │
│                                                          │
│ TIỀN PHÒNG                    [RoomCharge]               │
│                                                          │
│ DỊCH VỤ SỬ DỤNG                                          │
│ [ServiceName]    [Qty]    [UnitPrice]    [Subtotal]      │
│ ...                                                      │
│                                                          │
│ Tiền dịch vụ:                 [ServiceCharge]            │
│ Giảm giá:                     [Discount]                 │
│ TỔNG CỘNG:                    [TotalAmount]              │
│ Phương thức: [PaymentMethod]                             │
└──────────────────────────────────────────────────────────┘
```

#### **E. File: DanhSachHoaDon.xlsx (All Invoices)**

| Cột | Tên cột |
|-----|---------|
| A | Mã HĐ |
| B | Khách hàng |
| C | Phòng |
| D | Tiền phòng |
| E | Tiền DV |
| F | Giảm giá |
| G | Tổng cộng |
| H | Thanh toán |
| I | Ngày |

### 6.4 Import Excel

#### **A. Import Rooms (RoomService.cs)**

**Cấu trúc file input:**
| Cột | Nội dung |
|-----|----------|
| A | Số phòng (101, 102...) |
| B | Tên loại phòng (Đơn, Đôi...) |
| C | Tầng |
| D | Mô tả |

```csharp
public void ImportRoomsFromExcel(string filePath)
{
    if (!File.Exists(filePath)) throw new FileNotFoundException("Không tìm thấy file!");

    using (var package = new ExcelPackage(new FileInfo(filePath)))
    {
        var worksheet = package.Workbook.Worksheets[0];
        int rowCount = worksheet.Dimension.Rows;

        for (int row = 2; row <= rowCount; row++)  // Bỏ qua header (row 1)
        {
            string roomNumber = worksheet.Cells[row, 1].Text;
            if (string.IsNullOrEmpty(roomNumber)) continue;

            string roomTypeName = worksheet.Cells[row, 2].Text;
            var roomType = _cachedRoomTypes?.FirstOrDefault(rt =>
                rt.RoomTypeName.Equals(roomTypeName, StringComparison.OrdinalIgnoreCase));

            var room = new Room
            {
                RoomNumber = roomNumber,
                RoomTypeId = roomType?.RoomTypeId ?? 1,
                Floor = int.TryParse(worksheet.Cells[row, 3].Text, out int f) ? f : 1,
                Status = "Available",
                Description = worksheet.Cells[row, 4].Text
            };

            _unitOfWork.RoomRepository.Insert(room);
        }
        _unitOfWork.Save();
    }
    RefreshCache();
}
```

#### **B. Import Guests (GuestService.cs)**

**Cấu trúc file input:**
| Cột | Nội dung |
|-----|----------|
| A | Họ tên |
| B | CMND |
| C | Ngày sinh |
| D | SĐT |
| E | Địa chỉ |
| F | Email |
| G | Quốc tịch |

```csharp
public string ImportGuestsFromExcel(string filePath)
{
    int successCount = 0;
    int errorCount = 0;

    using (var package = new ExcelPackage(new FileInfo(filePath)))
    {
        var worksheet = package.Workbook.Worksheets[0];
        int rowCount = worksheet.Dimension.Rows;

        for (int row = 2; row <= rowCount; row++)
        {
            try
            {
                string fullName = worksheet.Cells[row, 1].Text;
                if (string.IsNullOrEmpty(fullName)) continue;

                var newGuest = new Guest
                {
                    FullName = fullName,
                    IdentityCard = worksheet.Cells[row, 2].Text,
                    Phone = worksheet.Cells[row, 4].Text,
                    Address = worksheet.Cells[row, 5].Text,
                    Email = worksheet.Cells[row, 6].Text,
                    Nationality = worksheet.Cells[row, 7].Text,
                    CreatedDate = DateTime.Now
                };

                if (DateTime.TryParse(worksheet.Cells[row, 3].Text, out DateTime dob))
                    newGuest.DOB = dob;

                _unitOfWork.GuestRepository.Insert(newGuest);
                successCount++;
            }
            catch { errorCount++; }
        }

        if (successCount > 0) _unitOfWork.Save();
    }

    RefreshCache();
    return $"Đã import thành công {successCount} khách hàng. Lỗi {errorCount} dòng.";
}
```

### 6.5 Data Port & Cấu hình đường dẫn

**Đường dẫn file**: Do người dùng chọn thông qua `SaveFileDialog` / `OpenFileDialog`

```csharp
// Export - Chọn nơi lưu file
using (SaveFileDialog sfd = new SaveFileDialog()
{
    Filter = "Excel|*.xlsx",
    FileName = "DanhSachKhachHang.xlsx"
})
{
    if (sfd.ShowDialog() == DialogResult.OK)
    {
        _guestService.ExportGuestsToExcel(sfd.FileName);
        MessageBox.Show("Xuất file Excel thành công!");
    }
}

// Import - Chọn file để nhập
using (OpenFileDialog ofd = new OpenFileDialog()
{
    Filter = "Excel|*.xlsx"
})
{
    if (ofd.ShowDialog() == DialogResult.OK)
    {
        string result = _guestService.ImportGuestsFromExcel(ofd.FileName);
        MessageBox.Show(result);
    }
}
```

---

## 7. HƯỚNG DẪN CHI TIẾT THIẾT LẬP FORM

### 7.1 Công cụ sử dụng

| Công cụ | Mô tả |
|---------|-------|
| **Visual Studio 2022** | IDE phát triển |
| **Windows Forms Designer** | Thiết kế giao diện kéo thả |
| **.NET 8.0** | Framework |
| **Entity Framework Core 8.0** | ORM |
| **EPPlus 8.4.0** | Xuất/nhập Excel |
| **Microsoft.Extensions.DependencyInjection** | DI Container |

### 7.2 Controls thường dùng trong Form

| Control | Namespace | Chức năng |
|---------|-----------|-----------|
| `DataGridView` | System.Windows.Forms | Hiển thị danh sách dữ liệu |
| `TextBox` | System.Windows.Forms | Nhập text |
| `ComboBox` | System.Windows.Forms | Dropdown chọn |
| `DateTimePicker` | System.Windows.Forms | Chọn ngày |
| `Button` | System.Windows.Forms | Nút bấm |
| `Label` | System.Windows.Forms | Hiển thị text |
| `CheckBox` | System.Windows.Forms | Checkbox |
| `SaveFileDialog` | System.Windows.Forms | Dialog lưu file |
| `OpenFileDialog` | System.Windows.Forms | Dialog mở file |

### 7.3 Các hàm thường dùng

#### A. Load dữ liệu vào DataGridView:
```csharp
private void LoadGuests(string keyword = "")
{
    var guests = _guestService.GetGuests(keyword);
    var displayList = guests.Select(g => new { ... }).ToList();
    dgvGuests.DataSource = displayList;

    // Đổi tên header
    if (dgvGuests.Columns["GuestId"] != null)
        dgvGuests.Columns["GuestId"].HeaderText = "Mã KH";
}
```

#### B. Load dữ liệu vào ComboBox với Async:
```csharp
private async Task LoadRoomTypesAsync()
{
    var roomTypes = (await _roomService.GetAllRoomTypesAsync()).ToList();
    cboRoomType.DataSource = roomTypes;
    cboRoomType.DisplayMember = "RoomTypeName";  // Hiển thị
    cboRoomType.ValueMember = "RoomTypeId";       // Giá trị
    cboRoomType.SelectedIndex = -1;               // Không chọn mặc định
}

// Gọi từ Form_Load:
private async void FrmBooking_Load(object? sender, EventArgs e)
{
    await LoadRoomTypesAsync();
    await LoadBookingsAsync();
}
```

#### C. Lấy giá trị từ ComboBox:
```csharp
int roomTypeId = (int)cboRoomType.SelectedValue;
```

#### D. Xử lý sự kiện Click trên DataGridView:
```csharp
private void dgvGuests_CellClick(object sender, DataGridViewCellEventArgs e)
{
    if (e.RowIndex >= 0)
    {
        DataGridViewRow row = dgvGuests.Rows[e.RowIndex];
        txtID.Text = row.Cells["GuestId"].Value?.ToString();
        txtFullName.Text = row.Cells["FullName"].Value?.ToString();
        // ...
    }
}
```

#### E. Reset Form:
```csharp
private void ResetForm()
{
    txtID.Clear();
    txtFullName.Clear();
    txtPhone.Clear();
    cboRoomType.SelectedIndex = -1;
    dtpDOB.Value = new DateTime(1990, 1, 1);
}
```

### 7.4 Quy trình tạo Form mới với Async Pattern

**Bước 1: Tạo Form trong Visual Studio**
- Right-click project `HotelManagementSystem.Forms`
- Add → New Item → Windows Form
- Đặt tên: `FrmNewFeature.cs`

**Bước 2: Thiết kế giao diện (Designer)**
- Kéo thả Controls từ Toolbox
- Đặt tên cho Controls (Prefix: `btn`, `txt`, `cbo`, `dgv`, `lbl`, `dtp`)

**Bước 3: Viết code-behind với Async/Await**
```csharp
public partial class FrmNewFeature : Form
{
    private readonly INewService _newService;

    // Constructor Injection
    public FrmNewFeature(INewService newService)
    {
        InitializeComponent();
        _newService = newService;
        this.Load += FrmNewFeature_Load;
    }

    // async void cho event handler
    private async void FrmNewFeature_Load(object? sender, EventArgs e)
    {
        await LoadDataAsync();
    }

    // async Task cho helper method
    private async Task LoadDataAsync()
    {
        var data = await _newService.GetAllAsync();
        dgvData.DataSource = data;
    }

    // async void cho button click event
    private async void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            await _newService.AddAsync(newItem);
            MessageBox.Show("Thêm thành công!");
            await LoadDataAsync(); // Refresh
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi: {ex.Message}");
        }
    }
}
```

**Bước 4: Đăng ký trong DI Container (Program.cs)**
```csharp
// Thêm vào ConfigureServices()
services.AddScoped<INewService, NewService>();
services.AddTransient<FrmNewFeature>();
```

**Bước 5: Mở Form từ FrmMain**
```csharp
private void btnNewFeature_Click(object? sender, EventArgs e)
{
    OpenForm<FrmNewFeature>();
}
```

---

## 8. CÁC LỆNH THỰC THI

### 8.1 Thiết lập môi trường

```powershell
# Cài đặt .NET 8.0 SDK (nếu chưa có)
# Download từ: https://dotnet.microsoft.com/download/dotnet/8.0

# Kiểm tra phiên bản .NET
dotnet --version
```

### 8.2 Restore NuGet Packages

```powershell
# Di chuyển đến thư mục solution
cd "HotelManagementSystem"

# Restore packages cho tất cả projects
dotnet restore HotelManagementSystem.sln
```

### 8.3 Build dự án

```powershell
# Build Debug
dotnet build HotelManagementSystem.Forms\HotelManagementSystem.Forms.csproj --configuration Debug

# Build Release
dotnet build HotelManagementSystem.Forms\HotelManagementSystem.Forms.csproj --configuration Release
```

### 8.4 Chạy ứng dụng

```powershell
# Chạy trực tiếp
dotnet run --project HotelManagementSystem.Forms\HotelManagementSystem.Forms.csproj

# Hoặc chạy file exe sau khi build
.\HotelManagementSystem.Forms\bin\Debug\net8.0-windows\HotelManagementSystem.Forms.exe
```

### 8.5 Entity Framework Core Migrations

```powershell
# Di chuyển đến thư mục DAL
cd HotelManagementSystem.DAL

# Thêm migration mới
dotnet ef migrations add TenMigration --startup-project ..\HotelManagementSystem.Forms

# Cập nhật database
dotnet ef database update --startup-project ..\HotelManagementSystem.Forms

# Xem SQL sẽ chạy (không chạy thật)
dotnet ef migrations script --startup-project ..\HotelManagementSystem.Forms
```

### 8.6 Cài đặt SQL Server LocalDB

```powershell
# Kiểm tra LocalDB đã cài chưa
sqllocaldb info

# Tạo instance mới (nếu chưa có)
sqllocaldb create MSSQLLocalDB

# Start instance
sqllocaldb start MSSQLLocalDB

# Kết nối bằng SQL Server Management Studio:
# Server: (localdb)\MSSQLLocalDB
# Authentication: Windows Authentication
```

### 8.7 Tài khoản đăng nhập mặc định

| Username | Password | Role |
|----------|----------|------|
| admin | admin123 | Admin |

>  **Lưu ý**: Password lưu plaintext chỉ dùng cho demo. Trong thực tế cần hash password.

---

##  DANH SÁCH PACKAGES SỬ DỤNG

| Package | Version | Layer | Mục đích |
|---------|---------|-------|----------|
| Microsoft.EntityFrameworkCore | 8.0.0 | DAL | ORM Framework |
| Microsoft.EntityFrameworkCore.SqlServer | 8.0.0 | DAL | SQL Server Provider |
| Microsoft.EntityFrameworkCore.Design | 8.0.0 | Forms | EF Tools (Migrations) |
| Microsoft.Extensions.DependencyInjection | 8.0.0 | Forms | DI Container |
| EPPlus | 8.4.0 | Forms/BLL | Excel Export/Import |

---

##  TỔNG KẾT

| Tiêu chí | Giá trị |
|----------|---------|
| Kiến trúc | 3-Layer Architecture |
| DI Pattern | Constructor Injection |
| ORM | Entity Framework Core 8.0 |
| Database | SQL Server LocalDB |
| UI Framework | Windows Forms (.NET 8) |
| Excel Library | EPPlus 8.4.0 |
| Transaction | UnitOfWork Pattern với Async Support |
| Async/Await | ✅ **Đã triển khai toàn bộ** (DAL → BLL → Forms) |
| Validation | Manual (tại Form + Service) |
| DTO | Không sử dụng (Entity trực tiếp) |

---
