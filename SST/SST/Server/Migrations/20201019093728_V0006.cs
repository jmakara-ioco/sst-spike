using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractHistory",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FirmID = table.Column<Guid>(nullable: false),
                    ContractData = table.Column<string>(nullable: true),
                    UserID = table.Column<Guid>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CustomerID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractHistory_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistory_FirmID",
                table: "ContractHistory",
                column: "FirmID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractHistory");
        }
    }
}
