using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContractTransactionID",
                table: "ContractClauses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractClauses_ContractTransactionID",
                table: "ContractClauses",
                column: "ContractTransactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractClauses_ContractTransactions_ContractTransactionID",
                table: "ContractClauses",
                column: "ContractTransactionID",
                principalTable: "ContractTransactions",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractClauses_ContractTransactions_ContractTransactionID",
                table: "ContractClauses");

            migrationBuilder.DropIndex(
                name: "IX_ContractClauses_ContractTransactionID",
                table: "ContractClauses");

            migrationBuilder.DropColumn(
                name: "ContractTransactionID",
                table: "ContractClauses");
        }
    }
}
