using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestManagement.Infrastructure.Migrations
{
    public partial class TestCenterSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestsAvailableCapacity_TestCenter_TestCenterId",
                table: "TestsAvailableCapacity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestsAvailableCapacity",
                table: "TestsAvailableCapacity");

            migrationBuilder.RenameTable(
                name: "TestsAvailableCapacity",
                newName: "TestCenterAvailableCapacity",
                newSchema: "covid");

            migrationBuilder.RenameIndex(
                name: "IX_TestsAvailableCapacity_TestCenterId",
                schema: "covid",
                table: "TestCenterAvailableCapacity",
                newName: "IX_TestCenterAvailableCapacity_TestCenterId");

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableFrom",
                schema: "covid",
                table: "TestCenter",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableUntil",
                schema: "covid",
                table: "TestCenter",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                schema: "covid",
                table: "TestCenter",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestCenterAvailableCapacity",
                schema: "covid",
                table: "TestCenterAvailableCapacity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TestCenterAvailableCapacity_Id",
                schema: "covid",
                table: "TestCenterAvailableCapacity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCenterAvailableCapacity_TestCenter_TestCenterId",
                schema: "covid",
                table: "TestCenterAvailableCapacity",
                column: "TestCenterId",
                principalSchema: "covid",
                principalTable: "TestCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCenterAvailableCapacity_TestCenter_TestCenterId",
                schema: "covid",
                table: "TestCenterAvailableCapacity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestCenterAvailableCapacity",
                schema: "covid",
                table: "TestCenterAvailableCapacity");

            migrationBuilder.DropIndex(
                name: "IX_TestCenterAvailableCapacity_Id",
                schema: "covid",
                table: "TestCenterAvailableCapacity");

            migrationBuilder.DropColumn(
                name: "AvailableFrom",
                schema: "covid",
                table: "TestCenter");

            migrationBuilder.DropColumn(
                name: "AvailableUntil",
                schema: "covid",
                table: "TestCenter");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                schema: "covid",
                table: "TestCenter");

            migrationBuilder.RenameTable(
                name: "TestCenterAvailableCapacity",
                schema: "covid",
                newName: "TestsAvailableCapacity");

            migrationBuilder.RenameIndex(
                name: "IX_TestCenterAvailableCapacity_TestCenterId",
                table: "TestsAvailableCapacity",
                newName: "IX_TestsAvailableCapacity_TestCenterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestsAvailableCapacity",
                table: "TestsAvailableCapacity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestsAvailableCapacity_TestCenter_TestCenterId",
                table: "TestsAvailableCapacity",
                column: "TestCenterId",
                principalSchema: "covid",
                principalTable: "TestCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
