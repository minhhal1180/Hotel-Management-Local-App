using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoomTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeId", "Description", "PricePerNight", "RoomTypeName" },
                values: new object[,]
                {
                    { 1, "Phòng đơn tiêu chuẩn với 1 giường đơn, phù hợp cho 1 người", 300000m, "Standard Single" },
                    { 2, "Phòng đôi với 2 giường đơn hoặc 1 giường đôi, phù hợp cho 2 người", 500000m, "Standard Double" },
                    { 3, "Phòng cao cấp với 1 giường queen, view đẹp, phù hợp cho 2 người", 700000m, "Deluxe" },
                    { 4, "Phòng VIP sang trọng với phòng khách riêng, giường king, phù hợp cho 2-3 người", 1200000m, "Suite" },
                    { 5, "Phòng gia đình rộng rãi với 2 phòng ngủ, phù hợp cho 4-5 người", 1500000m, "Family Room" },
                    { 6, "Phòng tổng thống siêu sang với đầy đủ tiện nghi cao cấp, phù hợp cho VIP", 3000000m, "Presidential Suite" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "Description", "IsActive", "Price", "ServiceName" },
                values: new object[,]
                {
                    { 1, "Dịch vụ giặt là và ủi đồ", true, 50000m, "Giặt ủi (Laundry)" },
                    { 2, "Bữa sáng buffet tại nhà hàng", true, 150000m, "Bữa sáng (Breakfast)" },
                    { 3, "Massage và chăm sóc spa thư giãn", true, 300000m, "Spa & Massage" },
                    { 4, "Dịch vụ phòng 24/7", true, 100000m, "Room Service" },
                    { 5, "Đưa đón sân bay", true, 500000m, "Airport Transfer" },
                    { 6, "Thuê xe tự lái", true, 800000m, "Car Rental" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 6);
        }
    }
}
