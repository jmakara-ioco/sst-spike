using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractTransactionEntityClauses",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ContractTransactionEntityID = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    ClauseText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTransactionEntityClauses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractTransactionEntityClauses_ContractTransactionEntities_ContractTransactionEntityID",
                        column: x => x.ContractTransactionEntityID,
                        principalTable: "ContractTransactionEntities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractQuestions_ContractTransactionEntityID",
                table: "ContractQuestions",
                column: "ContractTransactionEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTransactionEntityClauses_ContractTransactionEntityID",
                table: "ContractTransactionEntityClauses",
                column: "ContractTransactionEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractQuestions_ContractTransactionEntities_ContractTransactionEntityID",
                table: "ContractQuestions",
                column: "ContractTransactionEntityID",
                principalTable: "ContractTransactionEntities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractQuestions_ContractTransactionEntities_ContractTransactionEntityID",
                table: "ContractQuestions");

            migrationBuilder.DropTable(
                name: "ContractTransactionEntityClauses");

            migrationBuilder.DropIndex(
                name: "IX_ContractQuestions_ContractTransactionEntityID",
                table: "ContractQuestions");
        }
    }
}
