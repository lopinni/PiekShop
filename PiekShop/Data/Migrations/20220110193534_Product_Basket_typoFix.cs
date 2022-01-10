using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PiekShop.Data.Migrations
{
    public partial class Product_Basket_typoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ammount",
                table: "BasketProducts",
                newName: "Amount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "BasketProducts",
                newName: "Ammount");
        }
    }
}
