using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace allopromo.Infrastructure.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Stores_StoreCategories_storeCategoryId",
            //    table: "Stores");

            //migrationBuilder.DropIndex(
            //    name: "storeCategoryId",
            //    table: "Stores");

            //migrationBuilder.DropColumn(
            //    name: "storeCategoryId",
            //    table: "Stores");

            //migrationBuilder.AddColumn<Guid>(
            //    name: "storeCategoryId",
            //    table: "Stores",
            //    type: "uniqueidentifier",
            //    nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "StoreCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "StoreCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "expires",
                table: "StoreCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "storeCategoryImageUrl",
                table: "StoreCategories",
                type: "nvarchar(max)",
                nullable: true);

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

            //migrationBuilder.AlterColumn<Guid>(
            //   name: "storeCategoryId",
            //   table: "StoreCategories",
            //   type: "uniqueidentifier",
            //   nullable: false,
            //   oldClrType: typeof(int),
            //   oldType: "int")
            //   .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<Guid>(
            //   name: "storeId",
            //   table: "Stores",
            //   type: "uniqueidentifier",
            //   nullable: false,
            //   oldClrType: typeof(string),
            //   oldType: "nvarchar(450)");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
               name: "storeCategoryId",
               table: "StoreCategories",
               type: "int",
               nullable: false,
               oldClrType: typeof(Guid),
               oldType: "uniqueidentifier")
               .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "storeId",
                table: "Stores",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");


            migrationBuilder.DropForeignKey(
                name: "FK_Stores_StoreCategories_CategorystoreCategoryId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_CategorystoreCategoryId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "CategorystoreCategoryId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "active",
                table: "StoreCategories");

            migrationBuilder.DropColumn(
                name: "created",
                table: "StoreCategories");

            migrationBuilder.DropColumn(
                name: "expires",
                table: "StoreCategories");

            migrationBuilder.DropColumn(
                name: "storeCategoryImageUrl",
                table: "StoreCategories");

            migrationBuilder.AddColumn<int>(
                name: "storeCategoryId",
                table: "Stores",
                type: "int",
                nullable: true);

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
    }
}
