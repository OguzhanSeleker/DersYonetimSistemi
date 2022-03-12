﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Message.Persistence.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Messages_UpperMessageId",
                table: "Messages");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpperMessageId",
                table: "Messages",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Messages_UpperMessageId",
                table: "Messages",
                column: "UpperMessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Messages_UpperMessageId",
                table: "Messages");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpperMessageId",
                table: "Messages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Messages_UpperMessageId",
                table: "Messages",
                column: "UpperMessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
