using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eSettPruebatecnica.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BalanceResponsibleParties",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    businessId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codingScheme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    validityStart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    validityEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brpCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceResponsibleParties", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalanceResponsibleParties");
        }
    }
}
