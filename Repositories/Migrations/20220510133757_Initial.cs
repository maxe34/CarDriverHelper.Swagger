using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarWashes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    WashPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarWashes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeShops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeShops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GasStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    GasolinePrice = table.Column<double>(type: "float", nullable: false),
                    DieselPrice = table.Column<double>(type: "float", nullable: false),
                    GplPrice = table.Column<double>(type: "float", nullable: true),
                    MetanPrice = table.Column<double>(type: "float", nullable: true),
                    Market = table.Column<bool>(type: "bit", nullable: false),
                    Coffee = table.Column<bool>(type: "bit", nullable: false),
                    CarWash = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CoffeeShopId = table.Column<int>(type: "int", nullable: true),
                    CarWashId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GasStations_CarWashes_CarWashId",
                        column: x => x.CarWashId,
                        principalTable: "CarWashes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GasStations_CoffeeShops_CoffeeShopId",
                        column: x => x.CoffeeShopId,
                        principalTable: "CoffeeShops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GasStations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GasStations_CarWashId",
                table: "GasStations",
                column: "CarWashId");

            migrationBuilder.CreateIndex(
                name: "IX_GasStations_CoffeeShopId",
                table: "GasStations",
                column: "CoffeeShopId");

            migrationBuilder.CreateIndex(
                name: "IX_GasStations_CompanyId",
                table: "GasStations",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GasStations");

            migrationBuilder.DropTable(
                name: "CarWashes");

            migrationBuilder.DropTable(
                name: "CoffeeShops");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
