using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Migrations
{
    public partial class branch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Messages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_BranchId",
                table: "Messages",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Branches_BranchId",
                table: "Messages",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Branches_BranchId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_BranchId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Messages");
        }
    }
}
