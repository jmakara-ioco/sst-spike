using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirmSubscriptionPlans_SubscriptionPlans_SubscriptionPlanID",
                table: "FirmSubscriptionPlans");

            migrationBuilder.DropIndex(
                name: "IX_FirmSubscriptionPlans_SubscriptionPlanID",
                table: "FirmSubscriptionPlans");

            migrationBuilder.DropColumn(
                name: "SubscriptionPlanID",
                table: "FirmSubscriptionPlans");

            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceHeaderID",
                table: "FirmSubscriptionPlans",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FirmSubscriptionPlans_InvoiceHeaderID",
                table: "FirmSubscriptionPlans",
                column: "InvoiceHeaderID");

            migrationBuilder.AddForeignKey(
                name: "FK_FirmSubscriptionPlans_InvoiceHeaders_InvoiceHeaderID",
                table: "FirmSubscriptionPlans",
                column: "InvoiceHeaderID",
                principalTable: "InvoiceHeaders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirmSubscriptionPlans_InvoiceHeaders_InvoiceHeaderID",
                table: "FirmSubscriptionPlans");

            migrationBuilder.DropIndex(
                name: "IX_FirmSubscriptionPlans_InvoiceHeaderID",
                table: "FirmSubscriptionPlans");

            migrationBuilder.DropColumn(
                name: "InvoiceHeaderID",
                table: "FirmSubscriptionPlans");

            migrationBuilder.AddColumn<Guid>(
                name: "SubscriptionPlanID",
                table: "FirmSubscriptionPlans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FirmSubscriptionPlans_SubscriptionPlanID",
                table: "FirmSubscriptionPlans",
                column: "SubscriptionPlanID");

            migrationBuilder.AddForeignKey(
                name: "FK_FirmSubscriptionPlans_SubscriptionPlans_SubscriptionPlanID",
                table: "FirmSubscriptionPlans",
                column: "SubscriptionPlanID",
                principalTable: "SubscriptionPlans",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
