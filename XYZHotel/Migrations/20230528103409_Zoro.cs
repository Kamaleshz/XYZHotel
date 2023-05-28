using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XYZHotel.Migrations
{
    /// <inheritdoc />
    public partial class Zoro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StaffPassword",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffPassword",
                table: "Staffs");
        }
    }
}
