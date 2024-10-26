using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaygateUrl",
                table: "PaymentGates");

            migrationBuilder.DropColumn(
                name: "ReturnUrl",
                table: "PaymentGates");

            migrationBuilder.AddColumn<string>(
                name: "APIPassword",
                table: "PaymentGates",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EnableOnlineStore",
                table: "PaymentGates",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "APIPassword",
                table: "PaymentGates");

            migrationBuilder.DropColumn(
                name: "EnableOnlineStore",
                table: "PaymentGates");

            migrationBuilder.AddColumn<string>(
                name: "PaygateUrl",
                table: "PaymentGates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReturnUrl",
                table: "PaymentGates",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
