using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0030 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FooterFontCenter",
                table: "FirmStylings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FooterFontLeft",
                table: "FirmStylings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FooterFontRight",
                table: "FirmStylings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterFontCenter",
                table: "FirmStylings");

            migrationBuilder.DropColumn(
                name: "FooterFontLeft",
                table: "FirmStylings");

            migrationBuilder.DropColumn(
                name: "FooterFontRight",
                table: "FirmStylings");
        }
    }
}
