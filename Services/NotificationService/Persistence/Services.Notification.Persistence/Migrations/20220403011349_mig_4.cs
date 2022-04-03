using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Notification.Persistence.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notications",
                table: "Notications");

            migrationBuilder.RenameTable(
                name: "Notications",
                newName: "Notifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notications",
                table: "Notications",
                column: "Id");
        }
    }
}
