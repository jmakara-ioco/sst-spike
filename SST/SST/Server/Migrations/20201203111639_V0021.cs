using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowMultiple",
                table: "ContractTransactionDataFields");

            migrationBuilder.CreateTable(
                name: "ContractTransactionEntities",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ContractTransactionID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTransactionEntities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractTransactionEntities_ContractTransactions_ContractTransactionID",
                        column: x => x.ContractTransactionID,
                        principalTable: "ContractTransactions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ContractTransactionEntityDataFields",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TypeOfField = table.Column<int>(nullable: false),
                    FieldName = table.Column<string>(nullable: true),
                    DisplayText = table.Column<string>(nullable: true),
                    ContractTransactionEntityID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTransactionEntityDataFields", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractTransactionEntityDataFields_ContractTransactionEntities_ContractTransactionEntityID",
                        column: x => x.ContractTransactionEntityID,
                        principalTable: "ContractTransactionEntities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaders_FirmID",
                table: "InvoiceHeaders",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTransactionEntities_ContractTransactionID",
                table: "ContractTransactionEntities",
                column: "ContractTransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTransactionEntityDataFields_ContractTransactionEntityID",
                table: "ContractTransactionEntityDataFields",
                column: "ContractTransactionEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceHeaders_Firms_FirmID",
                table: "InvoiceHeaders",
                column: "FirmID",
                principalTable: "Firms",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceHeaders_Firms_FirmID",
                table: "InvoiceHeaders");

            migrationBuilder.DropTable(
                name: "ContractTransactionEntityDataFields");

            migrationBuilder.DropTable(
                name: "ContractTransactionEntities");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceHeaders_FirmID",
                table: "InvoiceHeaders");

            migrationBuilder.AddColumn<bool>(
                name: "AllowMultiple",
                table: "ContractTransactionDataFields",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
