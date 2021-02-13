using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Migrations
{
    public partial class Updatetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Profesor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Profesor",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Profesor");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Profesor");
        }
    }
}
