using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Lesson.Infrastructure.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimePlaces_Courses_CourseId",
                table: "TimePlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_TimePlaces_Lessons_LessonId",
                table: "TimePlaces");

            migrationBuilder.DropIndex(
                name: "IX_TimePlaces_LessonId",
                table: "TimePlaces");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "TimePlaces");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "TimePlaces",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TimePlaces_Courses_CourseId",
                table: "TimePlaces",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimePlaces_Courses_CourseId",
                table: "TimePlaces");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "TimePlaces",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "LessonId",
                table: "TimePlaces",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TimePlaces_LessonId",
                table: "TimePlaces",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimePlaces_Courses_CourseId",
                table: "TimePlaces",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimePlaces_Lessons_LessonId",
                table: "TimePlaces",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
