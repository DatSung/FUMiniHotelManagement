using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FUMiniHotelManagement.DAO.Migrations
{
    public partial class AddAvatarUrlForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "User");
        }
    }
}
