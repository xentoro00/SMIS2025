using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMIS2025.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedgradeIda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Subject_SubjectId",
                table: "Grade");

            migrationBuilder.DropIndex(
                name: "IX_Grade_SubjectId",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Grade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Grade",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grade_SubjectId",
                table: "Grade",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Subject_SubjectId",
                table: "Grade",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id");
        }
    }
}
