using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesWebAPI.Migrations
{
    public partial class Watchlist_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Watchlist",
                columns: table => new
                {
                    MoviesMov_Id = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watchlist", x => new { x.MoviesMov_Id, x.UsersId });
                    table.ForeignKey(
                        name: "FK_Watchlist_Movies_MoviesMov_Id",
                        column: x => x.MoviesMov_Id,
                        principalTable: "Movies",
                        principalColumn: "Mov_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watchlist_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Watchlist_UsersId",
                table: "Watchlist",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Watchlist");
        }
    }
}
