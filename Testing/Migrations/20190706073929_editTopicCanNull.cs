using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Testing.Migrations
{
    public partial class editTopicCanNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ParentId",
                table: "Topics",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ChildId",
                table: "Topics",
                nullable: true,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ParentId",
                table: "Topics",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ChildId",
                table: "Topics",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
