using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0043 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractHistory_Customers_CustomerID",
                table: "ContractHistory");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerID",
                table: "ContractHistory",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreCustomerID",
                table: "ContractHistory",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractHistory_Customers_CustomerID",
                table: "ContractHistory",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractHistory_Customers_CustomerID",
                table: "ContractHistory");

            migrationBuilder.DropColumn(
                name: "StoreCustomerID",
                table: "ContractHistory");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerID",
                table: "ContractHistory",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractHistory_Customers_CustomerID",
                table: "ContractHistory",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
