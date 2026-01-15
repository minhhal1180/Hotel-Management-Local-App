using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Entities.Entities
{
    /// <summary>
    /// D?ch v? đi kèm (Gi?t ?i, Ăn u?ng, Spa...)
    /// </summary>
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public decimal Price { get; set; } // Đơn giá
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public ICollection<BookingService> BookingServices { get; set; } = new List<BookingService>();
    }
}
