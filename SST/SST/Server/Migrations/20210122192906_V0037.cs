using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0037 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlPrefects",
                table: "PaymentGates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlPrefects",
                table: "PaymentGates");
        }
    }
}
