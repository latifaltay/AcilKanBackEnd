using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_donatinCompleted_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDonationCompleted",
                table: "DonationHistories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DonationStatusId",
                table: "BloodRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_DonationStatusId",
                table: "BloodRequests",
                column: "DonationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodRequests_DonationStatuses_DonationStatusId",
                table: "BloodRequests",
                column: "DonationStatusId",
                principalTable: "DonationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodRequests_DonationStatuses_DonationStatusId",
                table: "BloodRequests");

            migrationBuilder.DropIndex(
                name: "IX_BloodRequests_DonationStatusId",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "IsDonationCompleted",
                table: "DonationHistories");

            migrationBuilder.DropColumn(
                name: "DonationStatusId",
                table: "BloodRequests");
        }
    }
}
