using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.netCoreTreningApp.Data.Migrations
{
    public partial class ChangePropertyPriceName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Peice",
                table: "Products",
                newName: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Peice");
        }
    }
}
