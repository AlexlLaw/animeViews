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
                    Idade = table.Column<int>(type: "INTEGER", nullable: false),
                    AnimeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "AnimePessoa",
                columns: table => new
                {
                    AnimesViewsAnimeId = table.Column<int>(type: "INTEGER", nullable: false),
                    PessoasViewsPessoaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimePessoa", x => new { x.AnimesViewsAnimeId, x.PessoasViewsPessoaId });
                    table.ForeignKey(
                        name: "FK_AnimePessoa_Animes_AnimesViewsAnimeId",
                        column: x => x.AnimesViewsAnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimePessoa_Pessoas_PessoasViewsPessoaId",
                        column: x => x.PessoasViewsPessoaId,
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
                columns: new[] { "PessoaId", "AnimeId", "Idade", "Nome" },
                values: new object[] { 1, 1, 25, "Álex Junior Saturnino Sobrinho" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimePessoa_PessoasViewsPessoaId",
                table: "AnimePessoa",
                column: "PessoasViewsPessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimePessoa");

            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
