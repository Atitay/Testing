using Microsoft.EntityFrameworkCore.Migrations;

namespace Testing.Migrations
{
    public partial class addNewModelDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExam_Exams_ExamId",
                table: "UserExam");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExam_User_UserId",
                table: "UserExam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExam",
                table: "UserExam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "UserExam",
                newName: "UserExams");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_UserExam_UserId",
                table: "UserExams",
                newName: "IX_UserExams_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserExam_ExamId",
                table: "UserExams",
                newName: "IX_UserExams_ExamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams",
                column: "UserExamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Exams_ExamId",
                table: "UserExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Users_UserId",
                table: "UserExams",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Exams_ExamId",
                table: "UserExams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Users_UserId",
                table: "UserExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "UserExams",
                newName: "UserExam");

            migrationBuilder.RenameIndex(
                name: "IX_UserExams_UserId",
                table: "UserExam",
                newName: "IX_UserExam_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserExams_ExamId",
                table: "UserExam",
                newName: "IX_UserExam_ExamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExam",
                table: "UserExam",
                column: "UserExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExam_Exams_ExamId",
                table: "UserExam",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExam_User_UserId",
                table: "UserExam",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
