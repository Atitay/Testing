using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Testing.Migrations
{
    public partial class addModelUserExamQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalEarnScore",
                table: "UserExams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalQuestionScore",
                table: "UserExams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserExamQuestions",
                columns: table => new
                {
                    UserExamQuestionId = table.Column<Guid>(nullable: false),
                    UserExamId = table.Column<Guid>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: false),
                    SelectChoiceId = table.Column<Guid>(nullable: true),
                    EarnScore = table.Column<int>(nullable: false),
                    QuestionScore = table.Column<int>(nullable: false),
                    IsCorrect = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExamQuestions", x => x.UserExamQuestionId);
                    table.ForeignKey(
                        name: "FK_UserExamQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExamQuestions_UserExams_UserExamId",
                        column: x => x.UserExamId,
                        principalTable: "UserExams",
                        principalColumn: "UserExamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserExamQuestions_QuestionId",
                table: "UserExamQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExamQuestions_UserExamId",
                table: "UserExamQuestions",
                column: "UserExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserExamQuestions");

            migrationBuilder.DropColumn(
                name: "TotalEarnScore",
                table: "UserExams");

            migrationBuilder.DropColumn(
                name: "TotalQuestionScore",
                table: "UserExams");
        }
    }
}
