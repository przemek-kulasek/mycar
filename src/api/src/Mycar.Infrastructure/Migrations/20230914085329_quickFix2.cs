using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mycar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class quickFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Operations_Id",
                table: "Items");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OperationId",
                table: "Items",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Operations_OperationId",
                table: "Items",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Operations_OperationId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_OperationId",
                table: "Items");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Operations_Id",
                table: "Items",
                column: "Id",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
