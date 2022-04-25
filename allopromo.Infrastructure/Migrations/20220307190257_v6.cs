using Microsoft.EntityFrameworkCore.Migrations;

namespace allopromo.Infrastructure.Data.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "storeCategoryId",
                table: "Stores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    productCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productCategoryName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.productCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "StoreCategories",
                columns: table => new
                {
                    storeCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storeCategoryName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreCategories", x => x.storeCategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_storeCategoryId",
                table: "Stores",
                column: "storeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_StoreCategories_storeCategoryId",
                table: "Stores",
                column: "storeCategoryId",
                principalTable: "StoreCategories",
                principalColumn: "storeCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_StoreCategories_storeCategoryId",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "StoreCategories");

            migrationBuilder.DropIndex(
                name: "IX_Stores_storeCategoryId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeCategoryId",
                table: "Stores");
        }
    }
}
