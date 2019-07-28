using Microsoft.EntityFrameworkCore.Migrations;

namespace Testing.Migrations
{
    public partial class addpercentNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PercentNow",
                table: "UserExams",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentNow",
                table: "UserExams");
        }
    }
}
