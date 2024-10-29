using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookNest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingEmployeeSalary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Employees",
                newName: "Salary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Employees",
                newName: "Price");
        }
    }
}
