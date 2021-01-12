using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Migrations
{
    public partial class nullabel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "HasSize",
                table: "Meals",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "HasSize",
                table: "Meals",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
