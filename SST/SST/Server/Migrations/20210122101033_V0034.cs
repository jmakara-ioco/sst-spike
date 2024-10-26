using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0034 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractQuestionAnswerIgnoredClauses",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AnswerID = table.Column<Guid>(nullable: false),
                    ContractClauseID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractQuestionAnswerIgnoredClauses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractQuestionAnswerIgnoredClauses_ContractQuestionAnswers_AnswerID",
                        column: x => x.AnswerID,
                        principalTable: "ContractQuestionAnswers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContractQuestionAnswerIgnoredClauses_ContractClauses_ContractClauseID",
                        column: x => x.ContractClauseID,
                        principalTable: "ContractClauses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractQuestionAnswerIgnoredClauses_AnswerID",
                table: "ContractQuestionAnswerIgnoredClauses",
                column: "AnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractQuestionAnswerIgnoredClauses_ContractClauseID",
                table: "ContractQuestionAnswerIgnoredClauses",
                column: "ContractClauseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractQuestionAnswerIgnoredClauses");
        }
    }
}
