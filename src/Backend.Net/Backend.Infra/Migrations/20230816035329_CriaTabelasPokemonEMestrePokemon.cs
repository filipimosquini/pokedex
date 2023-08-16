using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CriaTabelasPokemonEMestrePokemon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mestre_pokemon",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Idade = table.Column<int>(type: "INTEGER", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mestre_pokemon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pokemon",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    PokemonId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    MestrePokemonId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokemon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pokemon_mestre_pokemon_MestrePokemonId",
                        column: x => x.MestrePokemonId,
                        principalTable: "mestre_pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pokemon_MestrePokemonId",
                table: "pokemon",
                column: "MestrePokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pokemon");

            migrationBuilder.DropTable(
                name: "mestre_pokemon");
        }
    }
}
