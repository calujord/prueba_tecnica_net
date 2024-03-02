using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaNet.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SettlementBankDB");

            migrationBuilder.CreateSequence(
                name: "bankseq",
                schema: "SettlementBankDB",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "banks",
                schema: "SettlementBankDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Bic = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Country = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationEventLog",
                schema: "SettlementBankDB",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventTypeName = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    TimesSent = table.Column<int>(type: "integer", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationEventLog", x => x.EventId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_banks_Bic",
                schema: "SettlementBankDB",
                table: "banks",
                column: "Bic",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_banks_Country",
                schema: "SettlementBankDB",
                table: "banks",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_banks_Name",
                schema: "SettlementBankDB",
                table: "banks",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "banks",
                schema: "SettlementBankDB");

            migrationBuilder.DropTable(
                name: "IntegrationEventLog",
                schema: "SettlementBankDB");

            migrationBuilder.DropSequence(
                name: "bankseq",
                schema: "SettlementBankDB");
        }
    }
}
