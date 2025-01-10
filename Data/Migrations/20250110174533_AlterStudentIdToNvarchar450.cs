using Microsoft.EntityFrameworkCore.Migrations;

public partial class AlterStudentIdToNvarchar450 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Drop the old column if necessary
        migrationBuilder.DropColumn(
            name: "StudentId",
            table: "Grade");

        // Add the new column with the desired type
        migrationBuilder.AddColumn<string>(
            name: "StudentId",
            table: "Grade",
            maxLength: 450,
            nullable: false,
            defaultValue: "");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        // Revert the change by dropping the nvarchar column and re-adding the original column type
        migrationBuilder.DropColumn(
            name: "StudentId",
            table: "Grade");

        migrationBuilder.AddColumn<int>(
            name: "StudentId",
            table: "Grade",
            nullable: false,
            defaultValue: 0);
    }
}
