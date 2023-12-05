using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceStation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationCarClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_car_client_IdClient",
                table: "car");

            migrationBuilder.DropIndex(
                name: "IX_car_IdClient",
                table: "car");
        }
    }
}
