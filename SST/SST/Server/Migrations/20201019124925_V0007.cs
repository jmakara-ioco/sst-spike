using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Server.Migrations
{
    public partial class V0007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ContractHistory_CustomerID",
                table: "ContractHistory",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistory_UserID",
                table: "ContractHistory",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractHistory_Customers_CustomerID",
                table: "ContractHistory",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractHistory_AspNetUsers_UserID",
                table: "ContractHistory",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractHistory_Customers_CustomerID",
                table: "ContractHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractHistory_AspNetUsers_UserID",
                table: "ContractHistory");

            migrationBuilder.DropIndex(
                name: "IX_ContractHistory_CustomerID",
                table: "ContractHistory");

            migrationBuilder.DropIndex(
                name: "IX_ContractHistory_UserID",
                table: "ContractHistory");
        }
    }
}
