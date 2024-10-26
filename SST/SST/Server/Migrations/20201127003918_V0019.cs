using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FooterCenter",
                table: "FirmStylings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FooterLeft",
                table: "FirmStylings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FooterRight",
                table: "FirmStylings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeaderCenter",
                table: "FirmStylings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeaderLeft",
                table: "FirmStylings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeaderRight",
                table: "FirmStylings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "AllowOnlineStore",
                table: "Firms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PaygateKey",
                table: "Firms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaygatePassword",
                table: "Firms",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContractQuestionIgnoredContractClauses",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    QuestionID = table.Column<Guid>(nullable: false),
                    ContractClauseID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractQuestionIgnoredContractClauses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractQuestionIgnoredContractClauses_ContractClauses_ContractClauseID",
                        column: x => x.ContractClauseID,
                        principalTable: "ContractClauses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContractQuestionIgnoredContractClauses_ContractQuestions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "ContractQuestions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractQuestionIgnoredContractClauses_ContractClauseID",
                table: "ContractQuestionIgnoredContractClauses",
                column: "ContractClauseID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractQuestionIgnoredContractClauses_QuestionID",
                table: "ContractQuestionIgnoredContractClauses",
                column: "QuestionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractQuestionIgnoredContractClauses");

            migrationBuilder.DropColumn(
                name: "FooterCenter",
                table: "FirmStylings");

            migrationBuilder.DropColumn(
                name: "FooterLeft",
                table: "FirmStylings");

            migrationBuilder.DropColumn(
                name: "FooterRight",
                table: "FirmStylings");

            migrationBuilder.DropColumn(
                name: "HeaderCenter",
                table: "FirmStylings");

            migrationBuilder.DropColumn(
                name: "HeaderLeft",
                table: "FirmStylings");

            migrationBuilder.DropColumn(
                name: "HeaderRight",
                table: "FirmStylings");

            migrationBuilder.DropColumn(
                name: "AllowOnlineStore",
                table: "Firms");

            migrationBuilder.DropColumn(
                name: "PaygateKey",
                table: "Firms");

            migrationBuilder.DropColumn(
                name: "PaygatePassword",
                table: "Firms");
        }
    }
}
