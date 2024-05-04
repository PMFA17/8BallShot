using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _8BallShot.Data.Migrations
{
    /// <inheritdoc />
    public partial class Tabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fases",
                columns: table => new
                {
                    IdFases = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Formato = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fases", x => x.IdFases);
                });

            migrationBuilder.CreateTable(
                name: "Jogador",
                columns: table => new
                {
                    IdJogador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeJogador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIF = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogador", x => x.IdJogador);
                });

            migrationBuilder.CreateTable(
                name: "Torneio",
                columns: table => new
                {
                    IdTorneio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTorneio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nFases = table.Column<int>(type: "int", nullable: false),
                    nJogadores = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneio", x => x.IdTorneio);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fases");

            migrationBuilder.DropTable(
                name: "Jogador");

            migrationBuilder.DropTable(
                name: "Torneio");
        }
    }
}
