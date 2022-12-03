using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fixedrelationsv6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IndirectRelations",
                table: "IndirectRelations");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "IndirectRelations",
                newName: "ContactId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "IndirectRelations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndirectRelations",
                table: "IndirectRelations",
                columns: new[] { "UserId", "ContactId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IndirectRelations",
                table: "IndirectRelations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "IndirectRelations");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "IndirectRelations",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndirectRelations",
                table: "IndirectRelations",
                column: "Id");
        }
    }
}
