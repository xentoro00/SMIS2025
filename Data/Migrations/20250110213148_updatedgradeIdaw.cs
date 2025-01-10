using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMIS2025.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedgradeIdaw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeStatus",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "Letter",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Grade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GradeStatus",
                table: "Grade",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Letter",
                table: "Grade",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Grade",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
