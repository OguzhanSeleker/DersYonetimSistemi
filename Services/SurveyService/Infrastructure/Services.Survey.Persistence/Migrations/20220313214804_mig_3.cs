using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Survey.Persistence.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AnswerTypes_AnswerTypeId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_AnswerTypeId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AnswerTypeId",
                table: "Questions");

            migrationBuilder.CreateTable(
                name: "QuestionContent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Option = table.Column<string>(type: "text", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnswerTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionContent_AnswerTypes_AnswerTypeId",
                        column: x => x.AnswerTypeId,
                        principalTable: "AnswerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionContent_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionContent_AnswerTypeId",
                table: "QuestionContent",
                column: "AnswerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionContent_QuestionId",
                table: "QuestionContent",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionContent");

            migrationBuilder.AddColumn<Guid>(
                name: "AnswerTypeId",
                table: "Questions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AnswerTypeId",
                table: "Questions",
                column: "AnswerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_AnswerTypes_AnswerTypeId",
                table: "Questions",
                column: "AnswerTypeId",
                principalTable: "AnswerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
