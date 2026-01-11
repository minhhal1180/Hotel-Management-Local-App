using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Entities.Entities
{
    /// <summary>
    /// Hóa ðõn thanh toán
    /// </summary>
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        public int BookingId { get; set; }

    public decimal RoomCharge { get; set; } // Ti?n ph?ng
   public decimal ServiceCharge { get; set; } // Ti?n d?ch v?
        public decimal Discount { get; set; } = 0; // Gi?m giá
        public decimal TotalAmount { get; set; } // T?ng c?ng

        public string PaymentMethod { get; set; } = "Cash"; // Cash/Card/Transfer
        public DateTime PaymentDate { get; set; } = DateTime.Now;
      public string? Note { get; set; }

        public int? CreatedBy { get; set; } // Nhân viên l?p hóa ðõn

        // Navigation Properties
 [ForeignKey("BookingId")]
        public virtual Booking Booking { get; set; } = null!;

      [ForeignKey("CreatedBy")]
        public virtual AppUser? Staff { get; set; }
    }
}
