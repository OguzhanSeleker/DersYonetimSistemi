using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Survey.Persistence.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionContent_AnswerTypes_AnswerTypeId",
                table: "QuestionContent");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionContent_Questions_QuestionId",
                table: "QuestionContent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionContent",
                table: "QuestionContent");

            migrationBuilder.RenameTable(
                name: "QuestionContent",
                newName: "QuestionContents");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionContent_QuestionId",
                table: "QuestionContents",
                newName: "IX_QuestionContents_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionContent_AnswerTypeId",
                table: "QuestionContents",
                newName: "IX_QuestionContents_AnswerTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionContents",
                table: "QuestionContents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionContents_AnswerTypes_AnswerTypeId",
                table: "QuestionContents",
                column: "AnswerTypeId",
                principalTable: "AnswerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionContents_Questions_QuestionId",
                table: "QuestionContents",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionContents_AnswerTypes_AnswerTypeId",
                table: "QuestionContents");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionContents_Questions_QuestionId",
                table: "QuestionContents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionContents",
                table: "QuestionContents");

            migrationBuilder.RenameTable(
                name: "QuestionContents",
                newName: "QuestionContent");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionContents_QuestionId",
                table: "QuestionContent",
                newName: "IX_QuestionContent_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionContents_AnswerTypeId",
                table: "QuestionContent",
                newName: "IX_QuestionContent_AnswerTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionContent",
                table: "QuestionContent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionContent_AnswerTypes_AnswerTypeId",
                table: "QuestionContent",
                column: "AnswerTypeId",
                principalTable: "AnswerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionContent_Questions_QuestionId",
                table: "QuestionContent",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
