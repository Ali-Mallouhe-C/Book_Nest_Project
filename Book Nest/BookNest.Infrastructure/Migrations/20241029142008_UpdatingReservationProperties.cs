using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookNest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingReservationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookNumber",
                table: "Reservatios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Reservatios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Reservatios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookNumber",
                table: "Reservatios");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservatios");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Reservatios");
        }
    }
}
