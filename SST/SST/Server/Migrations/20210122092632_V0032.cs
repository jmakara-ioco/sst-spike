using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0032 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InTesting",
                table: "ContractTransactions");

            migrationBuilder.AddColumn<bool>(
                name: "ShowOnGenerateContracts",
                table: "ContractTransactions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowOnGenerateContracts",
                table: "ContractTransactions");

            migrationBuilder.AddColumn<bool>(
                name: "InTesting",
                table: "ContractTransactions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
