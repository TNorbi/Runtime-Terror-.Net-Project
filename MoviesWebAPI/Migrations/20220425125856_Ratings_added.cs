using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesWebAPI.Migrations
{
    public partial class Ratings_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Mov_Id = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => new { x.UserId, x.Mov_Id });
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_Mov_Id",
                        column: x => x.Mov_Id,
                        principalTable: "Movies",
                        principalColumn: "Mov_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_Mov_Id",
                table: "Ratings",
                column: "Mov_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");
        }
    }
}
