using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0045 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "ContractHistory",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_ContractQuestionAnswers_ContractTemplateID",
                table: "ContractQuestionAnswers",
                column: "ContractTemplateID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractQuestionAnswers_ContractTransactionTemplates_ContractTemplateID",
                table: "ContractQuestionAnswers",
                column: "ContractTemplateID",
                principalTable: "ContractTransactionTemplates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractQuestionAnswers_ContractTransactionTemplates_ContractTemplateID",
                table: "ContractQuestionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_ContractQuestionAnswers_ContractTemplateID",
                table: "ContractQuestionAnswers");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ContractHistory");
        }
    }
}
