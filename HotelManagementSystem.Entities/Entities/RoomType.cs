using System.Collections.Generic;

namespace HotelManagementSystem.Entities.Entities
{
    /// <summary>
    /// Lo?i ph?ng (VD: Ph?ng đơn, Ph?ng đôi, VIP...)
    /// </summary>
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; } = null!; // Tên lo?i ph?ng
        public string? Description { get; set; }
        public decimal PricePerNight { get; set; } // Giá ph?ng theo đêm

        // M?i quan h?: M?t lo?i ph?ng có nhi?u ph?ng
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
