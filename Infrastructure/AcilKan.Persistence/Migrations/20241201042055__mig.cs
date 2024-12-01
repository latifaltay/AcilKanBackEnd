using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Chats",
                newName: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_FromUserId",
                table: "Chats",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ToUserId",
                table: "Chats",
                column: "ToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_FromUserId",
                table: "Chats",
                column: "FromUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_ToUserId",
                table: "Chats",
                column: "ToUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_FromUserId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_ToUserId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_FromUserId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_ToUserId",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "FromUserId",
                table: "Chats",
                newName: "UserId");
        }
    }
}
