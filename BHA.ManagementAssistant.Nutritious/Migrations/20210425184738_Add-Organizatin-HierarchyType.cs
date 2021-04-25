using Microsoft.EntityFrameworkCore.Migrations;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Migrations
{
    public partial class AddOrganizatinHierarchyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HierarchyTypeEnum",
                table: "Organization",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HierarchyTypeEnum",
                table: "Organization");
        }
    }
}
