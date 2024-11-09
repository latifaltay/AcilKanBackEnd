using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "ArticlesForAboutPages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArticlesForAboutPages_TitleId",
                table: "ArticlesForAboutPages",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlesForAboutPages_TitlesForAboutPages_TitleId",
                table: "ArticlesForAboutPages",
                column: "TitleId",
                principalTable: "TitlesForAboutPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticlesForAboutPages_TitlesForAboutPages_TitleId",
                table: "ArticlesForAboutPages");

            migrationBuilder.DropIndex(
                name: "IX_ArticlesForAboutPages_TitleId",
                table: "ArticlesForAboutPages");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "ArticlesForAboutPages");
        }
    }
}
