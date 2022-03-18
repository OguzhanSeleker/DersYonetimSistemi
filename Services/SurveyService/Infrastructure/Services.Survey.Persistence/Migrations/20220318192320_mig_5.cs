using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Survey.Persistence.Migrations
{
    public partial class mig_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "QuestionContentId",
                table: "Answers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionContentId",
                table: "Answers",
                column: "QuestionContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_QuestionContents_QuestionContentId",
                table: "Answers",
                column: "QuestionContentId",
                principalTable: "QuestionContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_QuestionContents_QuestionContentId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionContentId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "QuestionContentId",
                table: "Answers");
        }
    }
}
