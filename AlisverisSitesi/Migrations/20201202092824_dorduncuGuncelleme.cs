using Microsoft.EntityFrameworkCore.Migrations;

namespace AlisverisSitesi.Migrations
{
    public partial class dorduncuGuncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_Kategoriler_KategoriId",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_KategoriId",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "AdminMi",
                table: "Kullanicilar");

            migrationBuilder.RenameColumn(
                name: "KategoriId",
                table: "Urunler",
                newName: "KategoriID");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriID",
                table: "Urunler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Kategori",
                table: "Urunler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StokMiktari",
                table: "Urunler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UrunAd",
                table: "Urunler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EklenenUrunSayisi",
                table: "Kullanicilar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    SiparisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunID = table.Column<int>(type: "int", nullable: false),
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.SiparisID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_Kategori",
                table: "Urunler",
                column: "Kategori");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_Kategoriler_Kategori",
                table: "Urunler",
                column: "Kategori",
                principalTable: "Kategoriler",
                principalColumn: "KategoriId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_Kategoriler_Kategori",
                table: "Urunler");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_Kategori",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "Kategori",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "StokMiktari",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "UrunAd",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "EklenenUrunSayisi",
                table: "Kullanicilar");

            migrationBuilder.RenameColumn(
                name: "KategoriID",
                table: "Urunler",
                newName: "KategoriId");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "Urunler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "AdminMi",
                table: "Kullanicilar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_KategoriId",
                table: "Urunler",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_Kategoriler_KategoriId",
                table: "Urunler",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "KategoriId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
