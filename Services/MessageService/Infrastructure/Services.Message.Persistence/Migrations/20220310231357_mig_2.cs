using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Message.Persistence.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Messages_UpperMessageId",
                table: "Messages",
                column: "UpperMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Messages_UpperMessageId",
                table: "Messages",
                column: "UpperMessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Messages_UpperMessageId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UpperMessageId",
                table: "Messages");
        }
    }
}
