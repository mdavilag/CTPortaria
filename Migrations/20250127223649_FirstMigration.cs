using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTPortaria.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    JobRole = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "text", maxLength: 120, nullable: false),
                    ReceivedBy = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    AdressedTo = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    ToSector = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    DeliveredTo = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: true),
                    DeliveredAt = table.Column<DateTime>(type: "Datetime", nullable: true),
                    ReceivedAt = table.Column<DateTime>(type: "Datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Invoice = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    DriversName = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    DriversIdentity = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    LicensePlace = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    CarModel = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    ToSector = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Category = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    ReceivedBy = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    ArrivedAt = table.Column<DateTime>(type: "Datetime", nullable: false),
                    LeavedAt = table.Column<DateTime>(type: "Datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GateLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    VisitorName = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: true),
                    VisitorIdentity = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    EnteredAt = table.Column<DateTime>(type: "Datetime", nullable: false),
                    LeavedAt = table.Column<DateTime>(type: "Datetime", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "Datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GateLogs_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GateLogs_EmployeeId",
                table: "GateLogs",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GateLogs");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
