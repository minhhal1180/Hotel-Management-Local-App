using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Entities.Entities
{
    /// <summary>
    /// D?ch v? đ? s? d?ng trong booking
    /// </summary>
    public class BookingService
    {
        [Key]
        public int BookingServiceId { get; set; }

        public int BookingId { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; } // Giá t?i th?i đi?m s? d?ng
        public DateTime UsedDate { get; set; } = DateTime.Now;
        public string? Note { get; set; }

        // Navigation Properties
        [ForeignKey("BookingId")]
        public virtual Booking Booking { get; set; } = null!;

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; } = null!;
    }
}
