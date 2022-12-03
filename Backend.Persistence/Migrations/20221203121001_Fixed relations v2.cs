using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fixedrelationsv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectRelations_Users_UserEntityId",
                table: "DirectRelations");

            migrationBuilder.DropIndex(
                name: "IX_DirectRelations_UserEntityId",
                table: "DirectRelations");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "DirectRelations");

            migrationBuilder.AddColumn<Guid>(
                name: "GiverId",
                table: "DirectRelations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReceiverId",
                table: "DirectRelations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DirectRelations_GiverId",
                table: "DirectRelations",
                column: "GiverId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectRelations_ReceiverId",
                table: "DirectRelations",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectRelations_Users_GiverId",
                table: "DirectRelations",
                column: "GiverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectRelations_Users_ReceiverId",
                table: "DirectRelations",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectRelations_Users_GiverId",
                table: "DirectRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectRelations_Users_ReceiverId",
                table: "DirectRelations");

            migrationBuilder.DropIndex(
                name: "IX_DirectRelations_GiverId",
                table: "DirectRelations");

            migrationBuilder.DropIndex(
                name: "IX_DirectRelations_ReceiverId",
                table: "DirectRelations");

            migrationBuilder.DropColumn(
                name: "GiverId",
                table: "DirectRelations");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "DirectRelations");

            migrationBuilder.AddColumn<Guid>(
                name: "UserEntityId",
                table: "DirectRelations",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DirectRelations_UserEntityId",
                table: "DirectRelations",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectRelations_Users_UserEntityId",
                table: "DirectRelations",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
