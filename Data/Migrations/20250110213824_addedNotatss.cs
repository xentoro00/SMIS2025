using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMIS2025.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedNotatss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GradeStatus",
                table: "Nota",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Letter",
                table: "Nota",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Nota",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Nota",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nota_SubjectId",
                table: "Nota",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Subject_SubjectId",
                table: "Nota",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Subject_SubjectId",
                table: "Nota");

            migrationBuilder.DropIndex(
                name: "IX_Nota_SubjectId",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "GradeStatus",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "Letter",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Nota");
        }
    }
}
