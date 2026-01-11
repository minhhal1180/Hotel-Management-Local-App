using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Entities.Entities
{
    /// <summary>
    /// Phiếu đặt phòng
    /// </summary>
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public int GuestId { get; set; }
        public int RoomId { get; set; }

        public DateTime CheckInDate { get; set; } // Ngày nhận phòng
        public DateTime CheckOutDate { get; set; } // Ngày trả phòng (dự kiến)
        public DateTime? ActualCheckOut { get; set; } // Ngày trả phòng thực tế

        public string Status { get; set; } = "Booked"; // Booked/CheckedIn/CheckedOut/Cancelled
        public decimal TotalAmount { get; set; } // Tổng tiền phòng
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