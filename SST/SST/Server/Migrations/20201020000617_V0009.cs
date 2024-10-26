using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImg",
                table: "FirmStylings");

            migrationBuilder.DropColumn(
                name: "LogoImg",
                table: "FirmStylings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackgroundImg",
                table: "FirmStylings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoImg",
                table: "FirmStylings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
