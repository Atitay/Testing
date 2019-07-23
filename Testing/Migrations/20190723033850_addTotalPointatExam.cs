using Microsoft.EntityFrameworkCore.Migrations;

namespace Testing.Migrations
{
    public partial class addTotalPointatExam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalPoint",
                table: "Exams",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPoint",
                table: "Exams");
        }
    }
}
