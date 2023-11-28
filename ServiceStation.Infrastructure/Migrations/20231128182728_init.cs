using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceStation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contactDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "service_Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ServiceTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EncodedServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdContactDetails = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_client_contactDetails_IdContactDetails",
                        column: x => x.IdContactDetails,
                        principalTable: "contactDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdContacDetails = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_contactDetails_IdContacDetails",
                        column: x => x.IdContacDetails,
                        principalTable: "contactDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "car",
                columns: table => new
                {
                    LicensePlate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car", x => x.LicensePlate);
                    table.ForeignKey(
                        name: "FK_car_client_IdClient",
                        column: x => x.IdClient,
                        principalTable: "client",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdServiceType = table.Column<int>(type: "int", nullable: false),
                    CarLicensePlate = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_service_car_CarLicensePlate",
                        column: x => x.CarLicensePlate,
                        principalTable: "car",
                        principalColumn: "LicensePlate");
                    table.ForeignKey(
                        name: "FK_service_service_Type_IdServiceType",
                        column: x => x.IdServiceType,
                        principalTable: "service_Type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_car_IdClient",
                table: "car",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_client_IdContactDetails",
                table: "client",
                column: "IdContactDetails");

            migrationBuilder.CreateIndex(
                name: "IX_service_CarLicensePlate",
                table: "service",
                column: "CarLicensePlate");

            migrationBuilder.CreateIndex(
                name: "IX_service_IdServiceType",
                table: "service",
                column: "IdServiceType");

            migrationBuilder.CreateIndex(
                name: "IX_user_IdContacDetails",
                table: "user",
                column: "IdContacDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "service");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "car");

            migrationBuilder.DropTable(
                name: "service_Type");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "contactDetails");
        }
    }
}
