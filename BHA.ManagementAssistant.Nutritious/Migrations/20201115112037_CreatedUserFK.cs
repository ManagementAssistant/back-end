using Microsoft.EntityFrameworkCore.Migrations;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Migrations
{
    public partial class CreatedUserFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizationID",
                table: "Company");

            migrationBuilder.AddColumn<bool>(
                name: "isHierarchical",
                table: "Organization",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Company_CreatedByUserID",
                table: "Company",
                column: "CreatedByUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_User_CreatedByUserID",
                table: "Company",
                column: "CreatedByUserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_User_CreatedByUserID",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_CreatedByUserID",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "isHierarchical",
                table: "Organization");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationID",
                table: "Company",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
