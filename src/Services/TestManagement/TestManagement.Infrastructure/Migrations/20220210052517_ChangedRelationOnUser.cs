using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestManagement.Infrastructure.Migrations
{
    public partial class ChangedRelationOnUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_User_Id",
                schema: "covid",
                table: "Booking");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                schema: "covid",
                table: "Booking",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_User_UserId",
                schema: "covid",
                table: "Booking",
                column: "UserId",
                principalSchema: "covid",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_User_UserId",
                schema: "covid",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_UserId",
                schema: "covid",
                table: "Booking");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_User_Id",
                schema: "covid",
                table: "Booking",
                column: "Id",
                principalSchema: "covid",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
