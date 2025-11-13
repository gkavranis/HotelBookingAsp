using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Grand Plaza Hotel" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Seaside Resort" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "HotelId", "Number", "Type" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333333"), 2, new Guid("11111111-1111-1111-1111-111111111111"), 101, "Double" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), 2, new Guid("11111111-1111-1111-1111-111111111111"), 102, "Double" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), 2, new Guid("11111111-1111-1111-1111-111111111111"), 103, "Double" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), 2, new Guid("11111111-1111-1111-1111-111111111111"), 104, "Double" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), 2, new Guid("11111111-1111-1111-1111-111111111111"), 105, "Deluxe" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), 2, new Guid("11111111-1111-1111-1111-111111111111"), 106, "Deluxe" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), 1, new Guid("22222222-2222-2222-2222-222222222222"), 201, "Single" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 1, new Guid("22222222-2222-2222-2222-222222222222"), 202, "Single" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), 2, new Guid("22222222-2222-2222-2222-222222222222"), 203, "Double" },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), 2, new Guid("22222222-2222-2222-2222-222222222222"), 204, "Double" },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), 2, new Guid("22222222-2222-2222-2222-222222222222"), 205, "Double" },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), 2, new Guid("22222222-2222-2222-2222-222222222222"), 206, "Double" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CreationDate", "EndingDate", "RoomId", "StartingDate" },
                values: new object[,]
                {
                    { new Guid("0dcbc9c6-c37e-4ac6-bc3f-9aed741cbda7"), new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2025, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
