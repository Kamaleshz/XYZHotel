using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XYZHotel.Migrations
{
    /// <inheritdoc />
    public partial class Yoho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CutomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CutomerId);
                });

            migrationBuilder.CreateTable(
                name: "hotels",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "101, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelAmenities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelPrice = table.Column<int>(type: "int", nullable: false),
                    RoomAvailablity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotels", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "201, 1"),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomersCutomerId = table.Column<int>(type: "int", nullable: true),
                    hotelsHotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Customer_CustomersCutomerId",
                        column: x => x.CustomersCutomerId,
                        principalTable: "Customer",
                        principalColumn: "CutomerId");
                    table.ForeignKey(
                        name: "FK_Bookings_hotels_hotelsHotelId",
                        column: x => x.hotelsHotelId,
                        principalTable: "hotels",
                        principalColumn: "HotelId");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "301, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hotelsHotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_hotels_hotelsHotelId",
                        column: x => x.hotelsHotelId,
                        principalTable: "hotels",
                        principalColumn: "HotelId");
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "401, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelsHotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staffs_hotels_HotelsHotelId",
                        column: x => x.HotelsHotelId,
                        principalTable: "hotels",
                        principalColumn: "HotelId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomersCutomerId",
                table: "Bookings",
                column: "CustomersCutomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_hotelsHotelId",
                table: "Bookings",
                column: "hotelsHotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_hotelsHotelId",
                table: "Rooms",
                column: "hotelsHotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_HotelsHotelId",
                table: "Staffs",
                column: "HotelsHotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "hotels");
        }
    }
}
