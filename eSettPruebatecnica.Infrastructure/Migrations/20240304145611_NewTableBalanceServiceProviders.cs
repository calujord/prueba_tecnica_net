using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eSettPruebatecnica.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewTableBalanceServiceProviders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BalanceServiceProviders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bspCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bspName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    businessId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codingScheme = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceServiceProviders", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalanceServiceProviders");
        }
    }
}
