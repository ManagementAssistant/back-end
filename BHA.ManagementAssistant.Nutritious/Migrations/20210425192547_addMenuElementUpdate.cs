using Microsoft.EntityFrameworkCore.Migrations;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Migrations
{
    public partial class addMenuElementUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuElement",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MenuElementID = table.Column<int>(nullable: true),
                    MenuElementTypeEnum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuElement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MenuElement_MenuElement_MenuElementID",
                        column: x => x.MenuElementID,
                        principalTable: "MenuElement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuElement_MenuElementID",
                table: "MenuElement",
                column: "MenuElementID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuElement");
        }
    }
}
