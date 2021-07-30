using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeViews.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    AnimeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Obra = table.Column<string>(type: "TEXT", nullable: true),
                    DataDeLançamento = table.Column<string>(type: "TEXT", nullable: true),
                    Temporadas = table.Column<int>(type: "INTEGER", nullable: false),
                    QtdDeEpisodios = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.AnimeId);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Idade = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "AnimesPessoas",
                columns: table => new
                {
                    AnimeId = table.Column<int>(type: "INTEGER", nullable: false),
                    PessoaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimesPessoas", x => new { x.AnimeId, x.PessoaId });
                    table.ForeignKey(
                        name: "FK_AnimesPessoas_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimesPessoas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "AnimeId", "DataDeLançamento", "Obra", "QtdDeEpisodios", "Temporadas" },
                values: new object[] { 1, "21 de setembro de 1999", "Naruto", 220, 9 });

            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "PessoaId", "Idade", "Nome" },
                values: new object[] { 1, 25, "Álex Junior Saturnino Sobrinho" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimesPessoas_PessoaId",
                table: "AnimesPessoas",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimesPessoas");

            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
