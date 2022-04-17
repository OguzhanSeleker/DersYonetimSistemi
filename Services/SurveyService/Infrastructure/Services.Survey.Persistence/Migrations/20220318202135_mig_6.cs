using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Survey.Persistence.Migrations
{
    public partial class mig_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SurveyDescription",
                table: "MainSurveys",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurveyTitle",
                table: "MainSurveys",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurveyDescription",
                table: "MainSurveys");

            migrationBuilder.DropColumn(
                name: "SurveyTitle",
                table: "MainSurveys");
        }
    }
}
