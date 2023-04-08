using Microsoft.EntityFrameworkCore.Migrations;

namespace allopromo.Infrastructure.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_StoreCategories_categoryId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "storeExpires",
                table: "Stores",
                newName: "storeExpires");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Stores",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Stores_categoryId",
                table: "Stores",
                newName: "IX_Stores_categoryId");

            migrationBuilder.RenameColumn(
                name: "regionId",
                table: "Regions",
                newName: "RegionId");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Countries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "countryId",
                table: "Cities",
                type: "int",
                nullable: true);

            /*migrationBuilder.CreateIndex(
                name: "IX_Countries_RegionId",
                table: "Countries",
                column: "RegionId");*/

            migrationBuilder.CreateIndex(
                name: "IX_Cities_countryId",
                table: "Cities",
                column: "cityCountrycountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_countryId",
                table: "Cities",
                column: "countryId",
                principalTable: "Countries",
                principalColumn: "countryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_StoreCategories_CategoryId",
                table: "Stores",
                column: "CategoryId",
                principalTable: "StoreCategories",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_countryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_StoreCategories_CategoryId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Countries_RegionId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Cities_countryId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "countryId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "storeExpires",
                table: "Stores",
                newName: "storeExpires");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Stores",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Stores_CategoryId",
                table: "Stores",
                newName: "IX_Stores_categoryId");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "Regions",
                newName: "regionId");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "countryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_StoreCategories_categoryId",
                table: "Stores",
                column: "categoryId",
                principalTable: "StoreCategories",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
