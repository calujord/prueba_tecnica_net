using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alicunde.PruebaTecnica.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImbalanceFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HourlyImbalanceFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PeakLoadFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VolumeFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WeeklyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fees");
        }
    }
}
