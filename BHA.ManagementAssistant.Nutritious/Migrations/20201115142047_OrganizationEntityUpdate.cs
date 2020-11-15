using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Migrations
{
    public partial class OrganizationEntityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "CreatedByUserID",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "DeletedByUserID",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserID",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Organization");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Organization",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserID",
                table: "Organization",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserID",
                table: "Organization",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Organization",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Organization",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserID",
                table: "Organization",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Organization",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
