using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0026 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractTemplateID",
                table: "ContractQuestions");

            migrationBuilder.AddColumn<int>(
                name: "PaymentGateway",
                table: "Firms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ContractTransactionTemplates",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ContractTransactions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Suburb",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Street1",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ContractQuestionTemplates",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    QuestionID = table.Column<Guid>(nullable: false),
                    ContractTransactionTemplateID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractQuestionTemplates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractQuestionTemplates_ContractTransactionTemplates_ContractTransactionTemplateID",
                        column: x => x.ContractTransactionTemplateID,
                        principalTable: "ContractTransactionTemplates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContractQuestionTemplates_ContractQuestions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "ContractQuestions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractQuestionTemplates_ContractTransactionTemplateID",
                table: "ContractQuestionTemplates",
                column: "ContractTransactionTemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractQuestionTemplates_QuestionID",
                table: "ContractQuestionTemplates",
                column: "QuestionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractQuestionTemplates");

            migrationBuilder.DropColumn(
                name: "PaymentGateway",
                table: "Firms");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ContractTransactionTemplates");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ContractTransactions");

            migrationBuilder.AddColumn<Guid>(
                name: "ContractTemplateID",
                table: "ContractQuestions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Suburb",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street1",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
