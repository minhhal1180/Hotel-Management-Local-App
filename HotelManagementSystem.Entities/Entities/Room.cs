using System.Collections.Generic;

namespace HotelManagementSystem.Entities.Entities
{
    /// <summary>
    /// Ph?ng khách s?n
    /// </summary>
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = null!; // S? ph?ng (VD: 101, 102, 201)
        public int RoomTypeId { get; set; }
        public int Floor { get; set; } // T?ng
        public string Status { get; set; } = "Available"; // Available/Occupied/Maintenance
        public string? Description { get; set; }

        // Navigation Properties
        public RoomType RoomType { get; set; } = null!;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
