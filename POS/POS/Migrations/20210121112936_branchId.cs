using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Migrations
{
    public partial class branchId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BId",
                table: "Messages",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BId",
                table: "Messages");
        }
    }
}
