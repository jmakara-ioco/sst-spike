using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayText",
                table: "CustomerDataFields",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Information",
                table: "ContractTransactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayText",
                table: "CustomerDataFields");

            migrationBuilder.DropColumn(
                name: "Information",
                table: "ContractTransactions");
        }
    }
}
