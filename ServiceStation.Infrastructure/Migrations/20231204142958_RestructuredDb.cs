using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceStation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RestructuredDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_car_client_IdClient",
                table: "car");

            migrationBuilder.DropForeignKey(
                name: "FK_client_contactDetails_IdContactDetails",
                table: "client");

            migrationBuilder.DropForeignKey(
                name: "FK_service_car_CarLicensePlate",
                table: "service");

            migrationBuilder.DropForeignKey(
                name: "FK_service_service_Type_IdServiceType",
                table: "service");

            migrationBuilder.DropForeignKey(
                name: "FK_user_contactDetails_IdContacDetails",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_service_CarLicensePlate",
                table: "service");

            migrationBuilder.DropIndex(
                name: "IX_service_IdServiceType",
                table: "service");

            migrationBuilder.DropIndex(
                name: "IX_car_IdClient",
                table: "car");

            migrationBuilder.DropColumn(
                name: "IdServiceType",
                table: "service");

            migrationBuilder.RenameColumn(
                name: "IdContacDetails",
                table: "user",
                newName: "ContactDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_user_IdContacDetails",
                table: "user",
                newName: "IX_user_ContactDetailsId");

            migrationBuilder.RenameColumn(
                name: "IdContactDetails",
                table: "client",
                newName: "ContactDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_client_IdContactDetails",
                table: "client",
                newName: "IX_client_ContactDetailsId");

            migrationBuilder.AlterColumn<string>(
                name: "CarLicensePlate",
                table: "service",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AddForeignKey(
                name: "FK_client_contactDetails_ContactDetailsId",
                table: "client",
                column: "ContactDetailsId",
                principalTable: "contactDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_contactDetails_ContactDetailsId",
                table: "user",
                column: "ContactDetailsId",
                principalTable: "contactDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_client_contactDetails_ContactDetailsId",
                table: "client");

            migrationBuilder.DropForeignKey(
                name: "FK_user_contactDetails_ContactDetailsId",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "ContactDetailsId",
                table: "user",
                newName: "IdContacDetails");

            migrationBuilder.RenameIndex(
                name: "IX_user_ContactDetailsId",
                table: "user",
                newName: "IX_user_IdContacDetails");

            migrationBuilder.RenameColumn(
                name: "ContactDetailsId",
                table: "client",
                newName: "IdContactDetails");

            migrationBuilder.RenameIndex(
                name: "IX_client_ContactDetailsId",
                table: "client",
                newName: "IX_client_IdContactDetails");

            migrationBuilder.AlterColumn<string>(
                name: "CarLicensePlate",
                table: "service",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "IdServiceType",
                table: "service",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_service_CarLicensePlate",
                table: "service",
                column: "CarLicensePlate");

            migrationBuilder.CreateIndex(
                name: "IX_service_IdServiceType",
                table: "service",
                column: "IdServiceType");

            migrationBuilder.CreateIndex(
                name: "IX_car_IdClient",
                table: "car",
                column: "IdClient");

            migrationBuilder.AddForeignKey(
                name: "FK_car_client_IdClient",
                table: "car",
                column: "IdClient",
                principalTable: "client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_client_contactDetails_IdContactDetails",
                table: "client",
                column: "IdContactDetails",
                principalTable: "contactDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_service_car_CarLicensePlate",
                table: "service",
                column: "CarLicensePlate",
                principalTable: "car",
                principalColumn: "LicensePlate");

            migrationBuilder.AddForeignKey(
                name: "FK_service_service_Type_IdServiceType",
                table: "service",
                column: "IdServiceType",
                principalTable: "service_Type",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_contactDetails_IdContacDetails",
                table: "user",
                column: "IdContacDetails",
                principalTable: "contactDetails",
                principalColumn: "Id");
        }
    }
}
