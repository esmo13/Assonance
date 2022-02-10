using Microsoft.EntityFrameworkCore.Migrations;

namespace Assonance.Migrations
{
    public partial class HopelessTry2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_albums_AlbumId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_users_UserId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comment",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "Comment",
                newName: "Album_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                newName: "IX_Comment_User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_AlbumId",
                table: "Comment",
                newName: "IX_Comment_Album_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_albums_Album_Id",
                table: "Comment",
                column: "Album_Id",
                principalTable: "albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_users_User_Id",
                table: "Comment",
                column: "User_Id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_albums_Album_Id",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_users_User_Id",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Comment",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Album_Id",
                table: "Comment",
                newName: "AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_User_Id",
                table: "Comment",
                newName: "IX_Comment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_Album_Id",
                table: "Comment",
                newName: "IX_Comment_AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_albums_AlbumId",
                table: "Comment",
                column: "AlbumId",
                principalTable: "albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_users_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
