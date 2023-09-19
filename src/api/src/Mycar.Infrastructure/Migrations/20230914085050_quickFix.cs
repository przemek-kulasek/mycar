using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mycar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class quickFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Cars_Id",
                table: "Operations");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_CarId",
                table: "Operations",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Cars_CarId",
                table: "Operations",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Cars_CarId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_CarId",
                table: "Operations");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Cars_Id",
                table: "Operations",
                column: "Id",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
