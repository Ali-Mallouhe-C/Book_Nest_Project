using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookNest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeUpdatingNameProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Employees",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "UserName");
        }
    }
}
