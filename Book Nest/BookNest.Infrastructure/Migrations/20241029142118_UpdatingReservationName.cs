using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookNest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingReservationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservatios_Books_BookId",
                table: "Reservatios");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservatios_Branchs_BranchId",
                table: "Reservatios");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservatios_Users_UserId",
                table: "Reservatios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservatios",
                table: "Reservatios");

            migrationBuilder.RenameTable(
                name: "Reservatios",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_Reservatios_UserId",
                table: "Reservations",
                newName: "IX_Reservations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservatios_BranchId",
                table: "Reservations",
                newName: "IX_Reservations_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservatios_BookId",
                table: "Reservations",
                newName: "IX_Reservations_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Books_BookId",
                table: "Reservations",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Branchs_BranchId",
                table: "Reservations",
                column: "BranchId",
                principalTable: "Branchs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Books_BookId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Branchs_BranchId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservatios");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_UserId",
                table: "Reservatios",
                newName: "IX_Reservatios_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_BranchId",
                table: "Reservatios",
                newName: "IX_Reservatios_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_BookId",
                table: "Reservatios",
                newName: "IX_Reservatios_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservatios",
                table: "Reservatios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservatios_Books_BookId",
                table: "Reservatios",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservatios_Branchs_BranchId",
                table: "Reservatios",
                column: "BranchId",
                principalTable: "Branchs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservatios_Users_UserId",
                table: "Reservatios",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
