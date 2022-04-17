using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Survey.Persistence.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeKey",
                table: "AnswerTypes",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeKey",
                table: "AnswerTypes");
        }
    }
}
