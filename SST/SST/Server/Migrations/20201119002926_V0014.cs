using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0014 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSubscriptionPlans_Firms_FirmID",
                table: "UserSubscriptionPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSubscriptionPlans_SubscriptionPlans_SubscriptionPlanID",
                table: "UserSubscriptionPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSubscriptionPlans",
                table: "UserSubscriptionPlans");

            migrationBuilder.RenameTable(
                name: "UserSubscriptionPlans",
                newName: "FirmSubscriptionPlans");

            migrationBuilder.RenameIndex(
                name: "IX_UserSubscriptionPlans_SubscriptionPlanID",
                table: "FirmSubscriptionPlans",
                newName: "IX_FirmSubscriptionPlans_SubscriptionPlanID");

            migrationBuilder.RenameIndex(
                name: "IX_UserSubscriptionPlans_FirmID",
                table: "FirmSubscriptionPlans",
                newName: "IX_FirmSubscriptionPlans_FirmID");

            migrationBuilder.AddColumn<int>(
                name: "ValidForDays",
                table: "SubscriptionPlans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FirmSubscriptionPlans",
                table: "FirmSubscriptionPlans",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FirmSubscriptionPlans_Firms_FirmID",
                table: "FirmSubscriptionPlans",
                column: "FirmID",
                principalTable: "Firms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FirmSubscriptionPlans_SubscriptionPlans_SubscriptionPlanID",
                table: "FirmSubscriptionPlans",
                column: "SubscriptionPlanID",
                principalTable: "SubscriptionPlans",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirmSubscriptionPlans_Firms_FirmID",
                table: "FirmSubscriptionPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_FirmSubscriptionPlans_SubscriptionPlans_SubscriptionPlanID",
                table: "FirmSubscriptionPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FirmSubscriptionPlans",
                table: "FirmSubscriptionPlans");

            migrationBuilder.DropColumn(
                name: "ValidForDays",
                table: "SubscriptionPlans");

            migrationBuilder.RenameTable(
                name: "FirmSubscriptionPlans",
                newName: "UserSubscriptionPlans");

            migrationBuilder.RenameIndex(
                name: "IX_FirmSubscriptionPlans_SubscriptionPlanID",
                table: "UserSubscriptionPlans",
                newName: "IX_UserSubscriptionPlans_SubscriptionPlanID");

            migrationBuilder.RenameIndex(
                name: "IX_FirmSubscriptionPlans_FirmID",
                table: "UserSubscriptionPlans",
                newName: "IX_UserSubscriptionPlans_FirmID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSubscriptionPlans",
                table: "UserSubscriptionPlans",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubscriptionPlans_Firms_FirmID",
                table: "UserSubscriptionPlans",
                column: "FirmID",
                principalTable: "Firms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubscriptionPlans_SubscriptionPlans_SubscriptionPlanID",
                table: "UserSubscriptionPlans",
                column: "SubscriptionPlanID",
                principalTable: "SubscriptionPlans",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
