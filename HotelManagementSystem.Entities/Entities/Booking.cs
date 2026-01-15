using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Entities.Entities
{
    /// <summary>
    /// Phi?u đ?t ph?ng
    /// </summary>
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public int GuestId { get; set; }
        public int RoomId { get; set; }

        public DateTime CheckInDate { get; set; } // Ngày nh?n ph?ng
        public DateTime CheckOutDate { get; set; } // Ngày tr? ph?ng (d? ki?n)
        public DateTime? ActualCheckOut { get; set; } // Ngày tr? ph?ng th?c t?

        public string Status { get; set; } = "Booked"; // Booked/CheckedIn/CheckedOut/Cancelled
        public decimal TotalAmount { get; set; } // T?ng ti?n ph?ng
        public string? Note { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation Properties
        [ForeignKey("GuestId")]
        public virtual Guest Guest { get; set; } = null!;

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; } = null!;

        public virtual Invoice? Invoice { get; set; }
        public virtual ICollection<BookingService> BookingServices { get; set; } = new List<BookingService>();
    }
}
