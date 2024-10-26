using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElementConfig",
                table: "ContractTemplateElements");

            migrationBuilder.DropColumn(
                name: "ElementText",
                table: "ContractTemplateElements");

            migrationBuilder.DropColumn(
                name: "ElementType",
                table: "ContractTemplateElements");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "ContractTemplateElements");

            migrationBuilder.AddColumn<string>(
                name: "TemplateText",
                table: "ContractTemplateElements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateText",
                table: "ContractTemplateElements");

            migrationBuilder.AddColumn<string>(
                name: "ElementConfig",
                table: "ContractTemplateElements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ElementText",
                table: "ContractTemplateElements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ElementType",
                table: "ContractTemplateElements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "ContractTemplateElements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
