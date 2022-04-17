using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Attendance.Infrastructure.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeekDateTime",
                table: "CourseAttendances");

            migrationBuilder.AddColumn<int>(
                name: "WeeklyProgramNumber",
                table: "CourseAttendances",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeeklyProgramNumber",
                table: "CourseAttendances");

            migrationBuilder.AddColumn<DateTime>(
                name: "WeekDateTime",
                table: "CourseAttendances",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
