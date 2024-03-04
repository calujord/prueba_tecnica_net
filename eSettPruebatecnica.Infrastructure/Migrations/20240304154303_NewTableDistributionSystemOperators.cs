using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eSettPruebatecnica.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewTableDistributionSystemOperators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DistributionSystemOperators",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dsoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codingScheme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributionSystemOperators", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistributionSystemOperators");
        }
    }
}
