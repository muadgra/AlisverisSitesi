using Microsoft.EntityFrameworkCore.Migrations;

namespace AlisverisSitesi.Migrations
{
    public partial class yedinciGuncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KullaniciID",
                table: "Siparisler",
                newName: "SepetID");

            migrationBuilder.AddColumn<int>(
                name: "Sepet",
                table: "Kullanicilar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sepet",
                columns: table => new
                {
                    SepetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    Kullanici = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepet", x => x.SepetID);
                    table.ForeignKey(
                        name: "FK_Sepet_Kullanicilar_Kullanici",
                        column: x => x.Kullanici,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_SepetID",
                table: "Siparisler",
                column: "SepetID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_Sepet",
                table: "Kullanicilar",
                column: "Sepet",
                unique: true,
                filter: "[Sepet] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sepet_Kullanici",
                table: "Sepet",
                column: "Kullanici");

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanicilar_Sepet_Sepet",
                table: "Kullanicilar",
                column: "Sepet",
                principalTable: "Sepet",
                principalColumn: "SepetID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Sepet_SepetID",
                table: "Siparisler",
                column: "SepetID",
                principalTable: "Sepet",
                principalColumn: "SepetID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanicilar_Sepet_Sepet",
                table: "Kullanicilar");

            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Sepet_SepetID",
                table: "Siparisler");

            migrationBuilder.DropTable(
                name: "Sepet");

            migrationBuilder.DropIndex(
                name: "IX_Siparisler_SepetID",
                table: "Siparisler");

            migrationBuilder.DropIndex(
                name: "IX_Kullanicilar_Sepet",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Sepet",
                table: "Kullanicilar");

            migrationBuilder.RenameColumn(
                name: "SepetID",
                table: "Siparisler",
                newName: "KullaniciID");
        }
    }
}
