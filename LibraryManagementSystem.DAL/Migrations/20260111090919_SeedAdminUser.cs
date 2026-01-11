using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "AppUserId", "IsActive", "PasswordHash", "Role", "UserName" },
                values: new object[] { 1, true, "admin123", "Admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1);
        }
    }
}
