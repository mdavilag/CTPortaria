using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTPortaria.Migrations
{
    /// <inheritdoc />
    public partial class CreatedVisitorModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitorIdentity",
                table: "GateLogs");

            migrationBuilder.DropColumn(
                name: "VisitorName",
                table: "GateLogs");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GateLogs",
                type: "TEXT",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegisteredBy",
                table: "GateLogs",
                type: "VARCHAR(80)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VisitorId",
                table: "GateLogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GateLogs_VisitorId",
                table: "GateLogs",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_Cpf",
                table: "Visitors",
                column: "Cpf",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GateLogs_VisitorId",
                table: "GateLogs",
                column: "VisitorId",
                principalTable: "Visitors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GateLogs_VisitorId",
                table: "GateLogs");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_GateLogs_VisitorId",
                table: "GateLogs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "GateLogs");

            migrationBuilder.DropColumn(
                name: "RegisteredBy",
                table: "GateLogs");

            migrationBuilder.DropColumn(
                name: "VisitorId",
                table: "GateLogs");

            migrationBuilder.AddColumn<string>(
                name: "VisitorIdentity",
                table: "GateLogs",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisitorName",
                table: "GateLogs",
                type: "VARCHAR(80)",
                maxLength: 80,
                nullable: true);
        }
    }
}
