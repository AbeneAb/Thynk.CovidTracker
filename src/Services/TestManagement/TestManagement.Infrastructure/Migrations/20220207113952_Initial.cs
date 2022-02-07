using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestManagement.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "covid");

            migrationBuilder.EnsureSchema(
                name: "enum");

            migrationBuilder.CreateTable(
                name: "BookingStatus",
                schema: "enum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                schema: "enum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultStatus",
                schema: "enum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecimenType",
                schema: "enum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecimenType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestCenter",
                schema: "covid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Capacity = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCenter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "enum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestsAvailableCapacity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvailableSpace = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestsAvailableCapacity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestsAvailableCapacity_TestCenter_TestCenterId",
                        column: x => x.TestCenterId,
                        principalSchema: "covid",
                        principalTable: "TestCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "covid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderId1 = table.Column<int>(type: "int", nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Gender_GenderId1",
                        column: x => x.GenderId1,
                        principalSchema: "enum",
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalSchema: "enum",
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                schema: "covid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_BookingStatus_BookingStatus",
                        column: x => x.BookingStatus,
                        principalSchema: "enum",
                        principalTable: "BookingStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_TestCenter_TestCenterId",
                        column: x => x.TestCenterId,
                        principalSchema: "covid",
                        principalTable: "TestCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_User_Id",
                        column: x => x.Id,
                        principalSchema: "covid",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                schema: "covid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecimenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResultStatusId = table.Column<int>(type: "int", nullable: false),
                    ResultIssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Result_Booking_BookingId",
                        column: x => x.BookingId,
                        principalSchema: "covid",
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Result_ResultStatus_ResultStatusId",
                        column: x => x.ResultStatusId,
                        principalSchema: "enum",
                        principalTable: "ResultStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecimenInformation",
                schema: "covid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecimenTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecimenInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecimenInformation_Booking_BookingId",
                        column: x => x.BookingId,
                        principalSchema: "covid",
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecimenInformation_SpecimenType_SpecimenTypeId",
                        column: x => x.SpecimenTypeId,
                        principalSchema: "enum",
                        principalTable: "SpecimenType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCenterInventory",
                schema: "covid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookedValue = table.Column<int>(type: "int", nullable: false),
                    AvailablBefore = table.Column<int>(type: "int", nullable: false),
                    AvailableAfter = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCenterInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCenterInventory_Booking_BookingId",
                        column: x => x.BookingId,
                        principalSchema: "covid",
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCenterInventory_TestCenter_TestCenterId",
                        column: x => x.TestCenterId,
                        principalSchema: "covid",
                        principalTable: "TestCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCenterInventory_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "covid",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_BookingStatus",
                schema: "covid",
                table: "Booking",
                column: "BookingStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Id",
                schema: "covid",
                table: "Booking",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TestCenterId",
                schema: "covid",
                table: "Booking",
                column: "TestCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_BookingId",
                schema: "covid",
                table: "Result",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Result_Id",
                schema: "covid",
                table: "Result",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Result_ResultStatusId",
                schema: "covid",
                table: "Result",
                column: "ResultStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecimenInformation_BookingId",
                schema: "covid",
                table: "SpecimenInformation",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecimenInformation_Id",
                schema: "covid",
                table: "SpecimenInformation",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecimenInformation_SpecimenTypeId",
                schema: "covid",
                table: "SpecimenInformation",
                column: "SpecimenTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCenter_Id",
                schema: "covid",
                table: "TestCenter",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestCenter_Name",
                schema: "covid",
                table: "TestCenter",
                column: "Name",
                unique: true)
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_TestCenterInventory_BookingId",
                schema: "covid",
                table: "TestCenterInventory",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestCenterInventory_Id",
                schema: "covid",
                table: "TestCenterInventory",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestCenterInventory_TestCenterId",
                schema: "covid",
                table: "TestCenterInventory",
                column: "TestCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCenterInventory_UserId",
                schema: "covid",
                table: "TestCenterInventory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestsAvailableCapacity_TestCenterId",
                table: "TestsAvailableCapacity",
                column: "TestCenterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "covid",
                table: "User",
                column: "Email",
                unique: true)
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_User_FirstName",
                schema: "covid",
                table: "User",
                column: "FirstName")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_User_GenderId1",
                schema: "covid",
                table: "User",
                column: "GenderId1");

            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                schema: "covid",
                table: "User",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_LastName",
                schema: "covid",
                table: "User",
                column: "LastName")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRoleId",
                schema: "covid",
                table: "User",
                column: "UserRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Result",
                schema: "covid");

            migrationBuilder.DropTable(
                name: "SpecimenInformation",
                schema: "covid");

            migrationBuilder.DropTable(
                name: "TestCenterInventory",
                schema: "covid");

            migrationBuilder.DropTable(
                name: "TestsAvailableCapacity");

            migrationBuilder.DropTable(
                name: "ResultStatus",
                schema: "enum");

            migrationBuilder.DropTable(
                name: "SpecimenType",
                schema: "enum");

            migrationBuilder.DropTable(
                name: "Booking",
                schema: "covid");

            migrationBuilder.DropTable(
                name: "BookingStatus",
                schema: "enum");

            migrationBuilder.DropTable(
                name: "TestCenter",
                schema: "covid");

            migrationBuilder.DropTable(
                name: "User",
                schema: "covid");

            migrationBuilder.DropTable(
                name: "Gender",
                schema: "enum");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "enum");
        }
    }
}
