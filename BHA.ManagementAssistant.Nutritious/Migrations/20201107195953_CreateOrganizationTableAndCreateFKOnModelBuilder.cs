using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Migrations
{
    public partial class CreateOrganizationTableAndCreateFKOnModelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Company");

            migrationBuilder.AddColumn<int>(
                name: "HierarchyTypeEnum",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationID",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationID",
                table: "Company",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedByUserID = table.Column<int>(nullable: false),
                    UpdatedByUserID = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    DeletedByUserID = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_OrganizationID",
                table: "User",
                column: "OrganizationID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Organization_OrganizationID",
                table: "User",
                column: "OrganizationID",
                principalTable: "Organization",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Organization_OrganizationID",
                table: "User");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropIndex(
                name: "IX_User_OrganizationID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "HierarchyTypeEnum",
                table: "User");

            migrationBuilder.DropColumn(
                name: "OrganizationID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "OrganizationID",
                table: "Company");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Company",
                type: "datetime2",
                nullable: true);
        }
    }
}
