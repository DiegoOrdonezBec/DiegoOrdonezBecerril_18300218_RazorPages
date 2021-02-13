using Microsoft.EntityFrameworkCore.Migrations;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfesoresToCursos_Curso_CursoId",
                table: "ProfesoresToCursos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfesoresToCursos_Profesor_ProfesorId",
                table: "ProfesoresToCursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfesoresToCursos",
                table: "ProfesoresToCursos");

            migrationBuilder.RenameTable(
                name: "ProfesoresToCursos",
                newName: "ProfesorToCurso");

            migrationBuilder.RenameIndex(
                name: "IX_ProfesoresToCursos_CursoId",
                table: "ProfesorToCurso",
                newName: "IX_ProfesorToCurso_CursoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfesorToCurso",
                table: "ProfesorToCurso",
                columns: new[] { "ProfesorId", "CursoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProfesorToCurso_Curso_CursoId",
                table: "ProfesorToCurso",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfesorToCurso_Profesor_ProfesorId",
                table: "ProfesorToCurso",
                column: "ProfesorId",
                principalTable: "Profesor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfesorToCurso_Curso_CursoId",
                table: "ProfesorToCurso");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfesorToCurso_Profesor_ProfesorId",
                table: "ProfesorToCurso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfesorToCurso",
                table: "ProfesorToCurso");

            migrationBuilder.RenameTable(
                name: "ProfesorToCurso",
                newName: "ProfesoresToCursos");

            migrationBuilder.RenameIndex(
                name: "IX_ProfesorToCurso_CursoId",
                table: "ProfesoresToCursos",
                newName: "IX_ProfesoresToCursos_CursoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfesoresToCursos",
                table: "ProfesoresToCursos",
                columns: new[] { "ProfesorId", "CursoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProfesoresToCursos_Curso_CursoId",
                table: "ProfesoresToCursos",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfesoresToCursos_Profesor_ProfesorId",
                table: "ProfesoresToCursos",
                column: "ProfesorId",
                principalTable: "Profesor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
