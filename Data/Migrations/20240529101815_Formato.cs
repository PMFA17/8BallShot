using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _8BallShot.Data.Migrations
{
    /// <inheritdoc />
    public partial class Formato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Formato",
                table: "Torneio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Formato",
                table: "Torneio");
        }
    }
}
