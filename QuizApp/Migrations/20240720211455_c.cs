using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Migrations
{
    /// <inheritdoc />
    public partial class c : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizzModel",
                table: "QuizzModel");

            migrationBuilder.RenameTable(
                name: "QuizzModel",
                newName: "QuizzModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizzModels",
                table: "QuizzModels",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizzModels",
                table: "QuizzModels");

            migrationBuilder.RenameTable(
                name: "QuizzModels",
                newName: "QuizzModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizzModel",
                table: "QuizzModel",
                column: "Id");
        }
    }
}
