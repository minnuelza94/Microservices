using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyMicroservice.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockExchange",
                columns: table => new
                {
                    ExchangeID = table.Column<int>(type: "int", nullable: false),
                    ExchangeName = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeId", x => x.ExchangeID);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDetails",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyCEO = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Turnover = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    Website = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    StockExchange = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyId", x => new { x.CompanyId, x.CompanyCode });
                    table.ForeignKey(
                        name: "Fk_StockExchange_ExchangeID",
                        column: x => x.StockExchange,
                        principalTable: "StockExchange",
                        principalColumn: "ExchangeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDetails_StockExchange",
                table: "CompanyDetails",
                column: "StockExchange");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyDetails");

            migrationBuilder.DropTable(
                name: "StockExchange");
        }
    }
}
