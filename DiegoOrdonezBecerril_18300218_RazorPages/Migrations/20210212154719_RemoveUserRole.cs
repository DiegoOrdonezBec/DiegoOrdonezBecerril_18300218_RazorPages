using Microsoft.EntityFrameworkCore.Migrations;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Migrations
{
    public partial class RemoveUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
