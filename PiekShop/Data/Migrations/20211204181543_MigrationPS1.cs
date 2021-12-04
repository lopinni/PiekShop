using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PiekShop.Data.Migrations
{
    public partial class MigrationPS1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Bakery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bakery");
        }
    }
}
