using Microsoft.EntityFrameworkCore.Migrations;

namespace Testing.Migrations
{
    public partial class addExamCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExamCode",
                table: "Exams",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamCode",
                table: "Exams");
        }
    }
}
