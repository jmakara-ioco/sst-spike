using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContractTemplateID",
                table: "ContractQuestions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContractTemplateID",
                table: "ContractQuestionAnswers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractTemplateID",
                table: "ContractQuestions");

            migrationBuilder.DropColumn(
                name: "ContractTemplateID",
                table: "ContractQuestionAnswers");
        }
    }
}
