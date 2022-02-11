using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestManagement.Infrastructure.Migrations
{
    public partial class TestCenterReportQueryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestCenterBookingReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalBooking = table.Column<int>(type: "int", nullable: false),
                    TotalPending = table.Column<int>(type: "int", nullable: true),
                    TotalNegative = table.Column<int>(type: "int", nullable: true),
                    TotalPositive = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCenterBookingReports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestCenterBookingReports");
        }
    }
}
