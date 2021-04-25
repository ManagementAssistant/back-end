using Microsoft.EntityFrameworkCore.Migrations;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Migrations
{
    public partial class menutype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MenuElement");

            migrationBuilder.AddColumn<int>(
                name: "MenuTypeEnum",
                table: "MenuElement",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuTypeEnum",
                table: "MenuElement");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MenuElement",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
