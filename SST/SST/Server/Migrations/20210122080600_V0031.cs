using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0031 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "FooterHeight",
                table: "FirmStylings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeaderHeight",
                table: "FirmStylings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterHeight",
                table: "FirmStylings");

            migrationBuilder.DropColumn(
                name: "HeaderHeight",
                table: "FirmStylings");

            migrationBuilder.AddColumn<int>(
                name: "FooterFontCenter",
                table: "FirmStylings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FooterFontLeft",
                table: "FirmStylings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FooterFontRight",
                table: "FirmStylings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
