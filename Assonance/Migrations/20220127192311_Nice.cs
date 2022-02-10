using Microsoft.EntityFrameworkCore.Migrations;

namespace Assonance.Migrations
{
    public partial class Nice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumGenre");

            migrationBuilder.AddColumn<long>(
                name: "AlbumId",
                table: "genres",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_genres_AlbumId",
                table: "genres",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_genres_albums_AlbumId",
                table: "genres",
                column: "AlbumId",
                principalTable: "albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_genres_albums_AlbumId",
                table: "genres");

            migrationBuilder.DropIndex(
                name: "IX_genres_AlbumId",
                table: "genres");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "genres");

            migrationBuilder.CreateTable(
                name: "AlbumGenre",
                columns: table => new
                {
                    AlbumsId = table.Column<long>(type: "bigint", nullable: false),
                    GenresId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumGenre", x => new { x.AlbumsId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_AlbumGenre_albums_AlbumsId",
                        column: x => x.AlbumsId,
                        principalTable: "albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumGenre_genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumGenre_GenresId",
                table: "AlbumGenre",
                column: "GenresId");
        }
    }
}
