using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Lesson.Infrastructure.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "CourseUsers",
                newName: "CourseId");

            migrationBuilder.AddColumn<Guid>(
                name: "LessonId",
                table: "Courses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CourseUsers_CourseId",
                table: "CourseUsers",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LessonId",
                table: "Courses",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lessons_LessonId",
                table: "Courses",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseUsers_Courses_CourseId",
                table: "CourseUsers",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lessons_LessonId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseUsers_Courses_CourseId",
                table: "CourseUsers");

            migrationBuilder.DropIndex(
                name: "IX_CourseUsers_CourseId",
                table: "CourseUsers");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LessonId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseUsers",
                newName: "LessonId");
        }
    }
}
