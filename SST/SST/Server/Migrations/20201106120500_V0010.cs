using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    TableName = table.Column<string>(nullable: true),
                    Column = table.Column<string>(nullable: true),
                    OldValue = table.Column<string>(nullable: true),
                    NewValue = table.Column<string>(nullable: true),
                    ChangeType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentGates",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    APIKey = table.Column<string>(nullable: true),
                    PaygateUrl = table.Column<string>(nullable: true),
                    ReturnUrl = table.Column<string>(nullable: true),
                    Supplier = table.Column<int>(nullable: false),
                    FirmID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentGates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaymentGates_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentGates_FirmID",
                table: "PaymentGates",
                column: "FirmID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "PaymentGates");
        }
    }
}
