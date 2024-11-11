using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DonationLocation",
                table: "DonationHistories",
                newName: "HopitalId");

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "DonationHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DonationHistories_HospitalId",
                table: "DonationHistories",
                column: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonationHistories_Hospitals_HospitalId",
                table: "DonationHistories",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonationHistories_Hospitals_HospitalId",
                table: "DonationHistories");

            migrationBuilder.DropIndex(
                name: "IX_DonationHistories_HospitalId",
                table: "DonationHistories");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "DonationHistories");

            migrationBuilder.RenameColumn(
                name: "HopitalId",
                table: "DonationHistories",
                newName: "DonationLocation");
        }
    }
}
