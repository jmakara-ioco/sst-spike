using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceNumbers");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "InvoiceHeaders");

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "InvoiceHeaders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "InvoiceHeaders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TransactionNumber",
                table: "InvoiceHeaders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "InvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "InvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "TransactionNumber",
                table: "InvoiceHeaders");

            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                table: "InvoiceHeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvoiceNumbers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceNumbers", x => x.ID);
                });
        }
    }
}
