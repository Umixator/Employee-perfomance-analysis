using Microsoft.EntityFrameworkCore.Migrations;

namespace EPA.Migrations
{
    public partial class fixTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selections_Grading_GradingId",
                table: "Selections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grading",
                table: "Grading");

            migrationBuilder.RenameTable(
                name: "Grading",
                newName: "Gradings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gradings",
                table: "Gradings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Selections_Gradings_GradingId",
                table: "Selections",
                column: "GradingId",
                principalTable: "Gradings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selections_Gradings_GradingId",
                table: "Selections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gradings",
                table: "Gradings");

            migrationBuilder.RenameTable(
                name: "Gradings",
                newName: "Grading");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grading",
                table: "Grading",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Selections_Grading_GradingId",
                table: "Selections",
                column: "GradingId",
                principalTable: "Grading",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
