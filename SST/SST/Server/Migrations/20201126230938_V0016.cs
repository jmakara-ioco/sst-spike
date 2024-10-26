using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0016 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvNumber",
                table: "InvoiceNumbers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvNumber",
                table: "InvoiceNumbers");
        }
    }
}
