using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPerformanceIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hotels",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Capacity",
                table: "Rooms",
                column: "Capacity");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId_Capacity",
                table: "Rooms",
                columns: new[] { "HotelId", "Capacity" });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_Name",
                table: "Hotels",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DateRange",
                table: "Bookings",
                columns: new[] { "StartingDate", "EndingDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId_DateRange",
                table: "Bookings",
                columns: new[] { "RoomId", "StartingDate", "EndingDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rooms_Capacity",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HotelId_Capacity",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_Name",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_DateRange",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomId_DateRange",
                table: "Bookings");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
