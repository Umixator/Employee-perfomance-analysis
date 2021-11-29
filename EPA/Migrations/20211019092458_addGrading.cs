using Microsoft.EntityFrameworkCore.Migrations;

namespace EPA.Migrations
{
    public partial class addGrading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradingId",
                table: "Selections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Grading",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grading", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Selections_GradingId",
                table: "Selections",
                column: "GradingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Selections_Grading_GradingId",
                table: "Selections",
                column: "GradingId",
                principalTable: "Grading",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selections_Grading_GradingId",
                table: "Selections");

            migrationBuilder.DropTable(
                name: "Grading");

            migrationBuilder.DropIndex(
                name: "IX_Selections_GradingId",
                table: "Selections");

            migrationBuilder.DropColumn(
                name: "GradingId",
                table: "Selections");
        }
    }
}
