using Microsoft.EntityFrameworkCore.Migrations;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Migrations
{
    public partial class removeOrganizationprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HierarchyTypeEnum",
                table: "Organization");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HierarchyTypeEnum",
                table: "Organization",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
