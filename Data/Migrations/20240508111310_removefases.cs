using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _8BallShot.Data.Migrations
{
    /// <inheritdoc />
    public partial class removefases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fase1",
                table: "Torneio");

            migrationBuilder.DropColumn(
                name: "Fase2",
                table: "Torneio");

            migrationBuilder.DropColumn(
                name: "Fase3",
                table: "Torneio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fase1",
                table: "Torneio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fase2",
                table: "Torneio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fase3",
                table: "Torneio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
