using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestManagement.Infrastructure.Migrations
{
    public partial class addedUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Gender_GenderId1",
                schema: "covid",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserRole_UserRoleId",
                schema: "covid",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_GenderId1",
                schema: "covid",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserRoleId",
                schema: "covid",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GenderId1",
                schema: "covid",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                schema: "covid",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_User_GenderId",
                schema: "covid",
                table: "User",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                schema: "covid",
                table: "User",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Gender_GenderId",
                schema: "covid",
                table: "User",
                column: "GenderId",
                principalSchema: "enum",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserRole_RoleId",
                schema: "covid",
                table: "User",
                column: "RoleId",
                principalSchema: "enum",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Gender_GenderId",
                schema: "covid",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserRole_RoleId",
                schema: "covid",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_GenderId",
                schema: "covid",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId",
                schema: "covid",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "GenderId1",
                schema: "covid",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                schema: "covid",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_GenderId1",
                schema: "covid",
                table: "User",
                column: "GenderId1");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRoleId",
                schema: "covid",
                table: "User",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Gender_GenderId1",
                schema: "covid",
                table: "User",
                column: "GenderId1",
                principalSchema: "enum",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserRole_UserRoleId",
                schema: "covid",
                table: "User",
                column: "UserRoleId",
                principalSchema: "enum",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
