using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faaliyet_Ihbar_IhbarId",
                table: "Faaliyet");

            migrationBuilder.DropForeignKey(
                name: "FK_Faaliyet_IslemDurumu_IslemDurumuId",
                table: "Faaliyet");

            migrationBuilder.DropForeignKey(
                name: "FK_Faaliyet_Personel_PersonelId",
                table: "Faaliyet");

            migrationBuilder.DropForeignKey(
                name: "FK_Ihbar_IhbarDurumu_IhbarDurumuId",
                table: "Ihbar");

            migrationBuilder.DropForeignKey(
                name: "FK_OlayIhbar_Ihbar_IhbarId",
                table: "OlayIhbar");

            migrationBuilder.DropForeignKey(
                name: "FK_OlayIhbar_Olay_OlayId",
                table: "OlayIhbar");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelIhbar_Ihbar_IhbarId",
                table: "PersonelIhbar");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelIhbar_Personel_PersonelId",
                table: "PersonelIhbar");

            migrationBuilder.AddForeignKey(
                name: "FK_Faaliyet_Ihbar_IhbarId",
                table: "Faaliyet",
                column: "IhbarId",
                principalTable: "Ihbar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Faaliyet_IslemDurumu_IslemDurumuId",
                table: "Faaliyet",
                column: "IslemDurumuId",
                principalTable: "IslemDurumu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Faaliyet_Personel_PersonelId",
                table: "Faaliyet",
                column: "PersonelId",
                principalTable: "Personel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ihbar_IhbarDurumu_IhbarDurumuId",
                table: "Ihbar",
                column: "IhbarDurumuId",
                principalTable: "IhbarDurumu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OlayIhbar_Ihbar_IhbarId",
                table: "OlayIhbar",
                column: "IhbarId",
                principalTable: "Ihbar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OlayIhbar_Olay_OlayId",
                table: "OlayIhbar",
                column: "OlayId",
                principalTable: "Olay",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelIhbar_Ihbar_IhbarId",
                table: "PersonelIhbar",
                column: "IhbarId",
                principalTable: "Ihbar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelIhbar_Personel_PersonelId",
                table: "PersonelIhbar",
                column: "PersonelId",
                principalTable: "Personel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faaliyet_Ihbar_IhbarId",
                table: "Faaliyet");

            migrationBuilder.DropForeignKey(
                name: "FK_Faaliyet_IslemDurumu_IslemDurumuId",
                table: "Faaliyet");

            migrationBuilder.DropForeignKey(
                name: "FK_Faaliyet_Personel_PersonelId",
                table: "Faaliyet");

            migrationBuilder.DropForeignKey(
                name: "FK_Ihbar_IhbarDurumu_IhbarDurumuId",
                table: "Ihbar");

            migrationBuilder.DropForeignKey(
                name: "FK_OlayIhbar_Ihbar_IhbarId",
                table: "OlayIhbar");

            migrationBuilder.DropForeignKey(
                name: "FK_OlayIhbar_Olay_OlayId",
                table: "OlayIhbar");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelIhbar_Ihbar_IhbarId",
                table: "PersonelIhbar");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelIhbar_Personel_PersonelId",
                table: "PersonelIhbar");

            migrationBuilder.AddForeignKey(
                name: "FK_Faaliyet_Ihbar_IhbarId",
                table: "Faaliyet",
                column: "IhbarId",
                principalTable: "Ihbar",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Faaliyet_IslemDurumu_IslemDurumuId",
                table: "Faaliyet",
                column: "IslemDurumuId",
                principalTable: "IslemDurumu",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Faaliyet_Personel_PersonelId",
                table: "Faaliyet",
                column: "PersonelId",
                principalTable: "Personel",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ihbar_IhbarDurumu_IhbarDurumuId",
                table: "Ihbar",
                column: "IhbarDurumuId",
                principalTable: "IhbarDurumu",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OlayIhbar_Ihbar_IhbarId",
                table: "OlayIhbar",
                column: "IhbarId",
                principalTable: "Ihbar",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OlayIhbar_Olay_OlayId",
                table: "OlayIhbar",
                column: "OlayId",
                principalTable: "Olay",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelIhbar_Ihbar_IhbarId",
                table: "PersonelIhbar",
                column: "IhbarId",
                principalTable: "Ihbar",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelIhbar_Personel_PersonelId",
                table: "PersonelIhbar",
                column: "PersonelId",
                principalTable: "Personel",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
