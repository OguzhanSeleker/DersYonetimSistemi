using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Lesson.Infrastructure.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleKey",
                table: "RoleInCourses",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleKey",
                table: "RoleInCourses");
        }
    }
}
