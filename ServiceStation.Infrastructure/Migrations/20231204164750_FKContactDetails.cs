using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceStation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FKContactDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_client_contactDetails_ContactDetailsId",
                table: "client");

            migrationBuilder.DropForeignKey(
                name: "FK_user_contactDetails_ContactDetailsId",
                table: "user");

            migrationBuilder.DropTable(
                name: "contactDetails");

            migrationBuilder.DropIndex(
                name: "IX_user_ContactDetailsId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_client_ContactDetailsId",
                table: "client");

            migrationBuilder.DropColumn(
                name: "ContactDetailsId",
                table: "user");

            migrationBuilder.AddColumn<string>(
                name: "ContactDetails_City",
                table: "client",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactDetails_Email",
                table: "client",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactDetails_Id",
                table: "client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ContactDetails_Name",
                table: "client",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactDetails_PhoneNumber",
                table: "client",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactDetails_PostalCode",
                table: "client",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactDetails_Street",
                table: "client",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactDetails_Surname",
                table: "client",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactDetails_City",
                table: "client");

            migrationBuilder.DropColumn(
                name: "ContactDetails_Email",
                table: "client");

            migrationBuilder.DropColumn(
                name: "ContactDetails_Id",
                table: "client");

            migrationBuilder.DropColumn(
                name: "ContactDetails_Name",
                table: "client");

            migrationBuilder.DropColumn(
                name: "ContactDetails_PhoneNumber",
                table: "client");

            migrationBuilder.DropColumn(
                name: "ContactDetails_PostalCode",
                table: "client");

            migrationBuilder.DropColumn(
                name: "ContactDetails_Street",
                table: "client");

            migrationBuilder.DropColumn(
                name: "ContactDetails_Surname",
                table: "client");

            migrationBuilder.AddColumn<int>(
                name: "ContactDetailsId",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "contactDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_ContactDetailsId",
                table: "user",
                column: "ContactDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_client_ContactDetailsId",
                table: "client",
                column: "ContactDetailsId");

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
    }
}
