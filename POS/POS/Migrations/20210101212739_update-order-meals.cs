using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Migrations
{
    public partial class updateordermeals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Meals");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustPhone",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Net",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Service",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ItemNote",
                table: "OrderDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "Meals",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "delflage",
                table: "Meals",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustPhone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Net",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Service",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ItemNote",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "color",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "delflage",
                table: "Meals");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
