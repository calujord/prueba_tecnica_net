using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaNet.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourlyImbalanceFee = table.Column<double>(type: "float", nullable: true),
                    ImbalanceFee = table.Column<double>(type: "float", nullable: true),
                    PeakLoadFee = table.Column<double>(type: "float", nullable: true),
                    Timestamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolumeFee = table.Column<double>(type: "float", nullable: true),
                    WeeklyFee = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fee", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fee");
        }
    }
}
