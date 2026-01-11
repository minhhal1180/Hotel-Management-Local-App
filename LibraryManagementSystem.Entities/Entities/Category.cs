using System.Collections.Generic;

namespace LibraryManagementSystem.Entities.Entities
{
    /// <summary>
    /// Loại phòng (VD: Phòng đơn, Phòng đôi, VIP...)
    /// </summary>
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; } = null!; // Tên loại phòng
        public string? Description { get; set; }
        public decimal PricePerNight { get; set; } // Giá phòng theo đêm

        // Mối quan hệ: Một loại phòng có nhiều phòng
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}