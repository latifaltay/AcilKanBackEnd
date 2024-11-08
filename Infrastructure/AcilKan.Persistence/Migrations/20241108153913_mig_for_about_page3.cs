using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_for_about_page3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodDonationConditions_GeneralConditionsForBloodDonations_GeneralConditionsForBloodDonationId",
                table: "BloodDonationConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodDonationConditions_HealthConditionsForBloodDonations_HealthConditionsForBloodDonationId",
                table: "BloodDonationConditions");

            migrationBuilder.DropIndex(
                name: "IX_BloodDonationConditions_GeneralConditionsForBloodDonationId",
                table: "BloodDonationConditions");

            migrationBuilder.DropIndex(
                name: "IX_BloodDonationConditions_HealthConditionsForBloodDonationId",
                table: "BloodDonationConditions");

            migrationBuilder.DropColumn(
                name: "GeneralConditionsForBloodDonationId",
                table: "BloodDonationConditions");

            migrationBuilder.DropColumn(
                name: "HealthConditionsForBloodDonationId",
                table: "BloodDonationConditions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneralConditionsForBloodDonationId",
                table: "BloodDonationConditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HealthConditionsForBloodDonationId",
                table: "BloodDonationConditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BloodDonationConditions_GeneralConditionsForBloodDonationId",
                table: "BloodDonationConditions",
                column: "GeneralConditionsForBloodDonationId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDonationConditions_HealthConditionsForBloodDonationId",
                table: "BloodDonationConditions",
                column: "HealthConditionsForBloodDonationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDonationConditions_GeneralConditionsForBloodDonations_GeneralConditionsForBloodDonationId",
                table: "BloodDonationConditions",
                column: "GeneralConditionsForBloodDonationId",
                principalTable: "GeneralConditionsForBloodDonations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDonationConditions_HealthConditionsForBloodDonations_HealthConditionsForBloodDonationId",
                table: "BloodDonationConditions",
                column: "HealthConditionsForBloodDonationId",
                principalTable: "HealthConditionsForBloodDonations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
