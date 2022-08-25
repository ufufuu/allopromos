using Microsoft.EntityFrameworkCore.Migrations;

namespace allopromo.Infrastructure.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "StoreState",
                table: "Stores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "storeStatus",
                table: "Stores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "productCategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "productStatus",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_productCategoryId",
                table: "Products",
                column: "productCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_productCategoryId",
                table: "Products",
                column: "productCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "productCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_productCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_productCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StoreState",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeStatus",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "productCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "productStatus",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
