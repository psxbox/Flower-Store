using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Context.Migrations.SQLite
{
    /// <inheritdoc />
    public partial class FlowerUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Flowers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flowers_UserId",
                table: "Flowers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flowers_Users_UserId",
                table: "Flowers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flowers_Users_UserId",
                table: "Flowers");

            migrationBuilder.DropIndex(
                name: "IX_Flowers_UserId",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Flowers");
        }
    }
}
