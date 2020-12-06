using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlisverisSitesi.Migrations
{
    public partial class ucuncuGuncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdminMi",
                table: "Kullanicilar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DogumTarihi",
                table: "Kullanicilar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KullaniciAdi",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KullaniciSifresi",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminMi",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "DogumTarihi",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "KullaniciAdi",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "KullaniciSifresi",
                table: "Kullanicilar");
        }
    }
}
