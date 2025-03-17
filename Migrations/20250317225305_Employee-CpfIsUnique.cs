using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTPortaria.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeCpfIsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employee_Name",
                table: "Employees",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Cpf",
                table: "Employees",
                column: "Cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employee_Name",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Cpf",
                table: "Employees");
        }
    }
}
