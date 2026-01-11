using System.Collections.Generic;

namespace LibraryManagementSystem.Entities.Entities
{
/// <summary>
  /// Phòng khách sạn
    /// </summary>
public class Room
    {
        public int RoomId { get; set; }
 public string RoomNumber { get; set; } = null!; // Số phòng (VD: 101, 102, 201)
    public int RoomTypeId { get; set; }
   public int Floor { get; set; } // Tầng
        public string Status { get; set; } = "Available"; // Available/Occupied/Maintenance
        public string? Description { get; set; }

    // Navigation Properties
        public RoomType RoomType { get; set; } = null!;
      public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}