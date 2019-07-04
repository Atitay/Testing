using Microsoft.EntityFrameworkCore.Migrations;

namespace Testing.Migrations
{
    public partial class AddLevelNPointToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "Questions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionLevel",
                table: "Questions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Point",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionLevel",
                table: "Questions");
        }
    }
}
