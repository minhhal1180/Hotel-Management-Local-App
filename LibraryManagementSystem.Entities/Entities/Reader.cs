using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Entities.Entities
{
    /// <summary>
    /// Khách hàng
    /// </summary>
    public class Guest
    {
        public int GuestId { get; set; }
        public string FullName { get; set; } = null!;
        public string? IdentityCard { get; set; } // CMND/CCCD
        public DateTime? DOB { get; set; } // Ngày sinh
        public string Phone { get; set; } = null!;
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Nationality { get; set; } // Quốc tịch
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation Properties
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}