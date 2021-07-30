using Microsoft.EntityFrameworkCore.Migrations;

namespace allopromoDataAccess.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    storeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    storeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => new { x.storeId });
                    // relationShips
                    table.ForeignKey(
                        name: "FK_Stores_AspNetUsers_Id",
                        column: x => x.storeId,
                   principalTable: "AspNetUsers",
                    principalColumn: "Id");
                    //onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
