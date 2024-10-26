using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirmStylings",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FirmID = table.Column<Guid>(nullable: false),
                    BackgroundImg = table.Column<string>(nullable: true),
                    LogoImg = table.Column<string>(nullable: true),
                    ButtonColor = table.Column<string>(nullable: true),
                    ButtonFontColor = table.Column<string>(nullable: true),
                    HeadingColor = table.Column<string>(nullable: true),
                    MenuHeadingColor = table.Column<string>(nullable: true),
                    MenuFontColor = table.Column<string>(nullable: true),
                    MenuBackgroundColor = table.Column<string>(nullable: true),
                    Font = table.Column<string>(nullable: true),
                    H1Colour = table.Column<string>(nullable: true),
                    H1Size = table.Column<double>(nullable: false),
                    H2Colour = table.Column<string>(nullable: true),
                    H2Size = table.Column<double>(nullable: false),
                    H3Colour = table.Column<string>(nullable: true),
                    H3Size = table.Column<double>(nullable: false),
                    ParColour = table.Column<string>(nullable: true),
                    ParSize = table.Column<double>(nullable: false),
                    IndentSetting = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmStylings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FirmStylings_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FirmStylings_FirmID",
                table: "FirmStylings",
                column: "FirmID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirmStylings");
        }
    }
}
