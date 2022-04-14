using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Attendance.Infrastructure.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseProgramInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProgramInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseAttendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimePlaceId = table.Column<Guid>(type: "uuid", nullable: false),
                    WeekNumber = table.Column<int>(type: "integer", nullable: false),
                    WeekDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CourseProgramInfoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseAttendances_CourseProgramInfos_CourseProgramInfoId",
                        column: x => x.CourseProgramInfoId,
                        principalTable: "CourseProgramInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAttendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseAttendanceId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsMarked = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAttendances_CourseAttendances_CourseAttendanceId",
                        column: x => x.CourseAttendanceId,
                        principalTable: "CourseAttendances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAttendances_CourseProgramInfoId",
                table: "CourseAttendances",
                column: "CourseProgramInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendances_CourseAttendanceId",
                table: "StudentAttendances",
                column: "CourseAttendanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAttendances");

            migrationBuilder.DropTable(
                name: "CourseAttendances");

            migrationBuilder.DropTable(
                name: "CourseProgramInfos");
        }
    }
}
