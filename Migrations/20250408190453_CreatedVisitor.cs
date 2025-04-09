using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTPortaria.Migrations
{
    /// <inheritdoc />
    public partial class CreatedVisitor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdressedTo = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    DeliveredAt = table.Column<DateTime>(type: "Datetime", nullable: true),
                    DeliveredTo = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: true),
                    Description = table.Column<string>(type: "text", maxLength: 120, nullable: false),
                    ReceivedAt = table.Column<DateTime>(type: "Datetime", nullable: false),
                    ReceivedBy = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    ToSector = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false)
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
                    ArrivedAt = table.Column<DateTime>(type: "Datetime", nullable: false),
                    CarModel = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    Category = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    CompanyName = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    DriversIdentity = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    DriversName = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Invoice = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    LeavedAt = table.Column<DateTime>(type: "Datetime", nullable: false),
                    LicensePlace = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    ReceivedBy = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    ToSector = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }
    }
}
