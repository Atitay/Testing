using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Testing.Migrations
{
    public partial class editModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "Topics");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_ParentId",
                table: "Topics",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Topics_ParentId",
                table: "Topics",
                column: "ParentId",
                principalTable: "Topics",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Topics_ParentId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_ParentId",
                table: "Topics");

            migrationBuilder.AddColumn<Guid>(
                name: "ChildId",
                table: "Topics",
                nullable: true);
        }
    }
}
