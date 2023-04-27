using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Context.Migrations.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class ColumnChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desription",
                table: "Flowers",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Flowers",
                newName: "Desription");
        }
    }
}
