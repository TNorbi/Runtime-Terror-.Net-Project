using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesWebAPI.Migrations
{
    public partial class MovieGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenresMovies",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    MoviesMov_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenresMovies", x => new { x.GenresId, x.MoviesMov_Id });
                    table.ForeignKey(
                        name: "FK_GenresMovies_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenresMovies_Movies_MoviesMov_Id",
                        column: x => x.MoviesMov_Id,
                        principalTable: "Movies",
                        principalColumn: "Mov_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenresMovies_MoviesMov_Id",
                table: "GenresMovies",
                column: "MoviesMov_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenresMovies");
        }
    }
}
