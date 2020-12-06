using Microsoft.EntityFrameworkCore.Migrations;

namespace AlisverisSitesi.Migrations
{
    public partial class altinciGuncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "UrunFiyat",
                table: "Urunler",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrunFiyat",
                table: "Urunler");
        }
    }
}
