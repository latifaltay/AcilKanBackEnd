using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticlesForAboutPages_TitlesForAboutPages_TitleId",
                table: "ArticlesForAboutPages");

            migrationBuilder.RenameColumn(
                name: "TitleId",
                table: "ArticlesForAboutPages",
                newName: "TitlesForAboutPageId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticlesForAboutPages_TitleId",
                table: "ArticlesForAboutPages",
                newName: "IX_ArticlesForAboutPages_TitlesForAboutPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlesForAboutPages_TitlesForAboutPages_TitlesForAboutPageId",
                table: "ArticlesForAboutPages",
                column: "TitlesForAboutPageId",
                principalTable: "TitlesForAboutPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticlesForAboutPages_TitlesForAboutPages_TitlesForAboutPageId",
                table: "ArticlesForAboutPages");

            migrationBuilder.RenameColumn(
                name: "TitlesForAboutPageId",
                table: "ArticlesForAboutPages",
                newName: "TitleId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticlesForAboutPages_TitlesForAboutPageId",
                table: "ArticlesForAboutPages",
                newName: "IX_ArticlesForAboutPages_TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlesForAboutPages_TitlesForAboutPages_TitleId",
                table: "ArticlesForAboutPages",
                column: "TitleId",
                principalTable: "TitlesForAboutPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
