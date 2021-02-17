using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Data.Migrations
{
    public partial class changeDBName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_scores",
                table: "scores");

            migrationBuilder.RenameTable(
                name: "scores",
                newName: "Scores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scores",
                table: "Scores",
                column: "ScoreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Scores",
                table: "Scores");

            migrationBuilder.RenameTable(
                name: "Scores",
                newName: "scores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_scores",
                table: "scores",
                column: "ScoreID");
        }
    }
}
