using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceHeaders",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    FirmID = table.Column<Guid>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    InvoicedTo = table.Column<string>(nullable: true),
                    NrOfUsers = table.Column<int>(nullable: false),
                    BillingFrequency = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    InvoiceNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceHeaders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceNumbers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FirmID = table.Column<Guid>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    Used = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceNumbers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLines",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    InvoiceID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    DiscountPercentage = table.Column<double>(nullable: false),
                    InvoiceHeaderID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLines", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_InvoiceHeaders_InvoiceHeaderID",
                        column: x => x.InvoiceHeaderID,
                        principalTable: "InvoiceHeaders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_InvoiceHeaderID",
                table: "InvoiceLines",
                column: "InvoiceHeaderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceLines");

            migrationBuilder.DropTable(
                name: "InvoiceNumbers");

            migrationBuilder.DropTable(
                name: "InvoiceHeaders");
        }
    }
}
