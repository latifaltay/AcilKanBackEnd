using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class test_mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodDonationApproves_BloodDonation_BloodDontaionId",
                table: "BloodDonationApproves");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "BloodDonationApproves",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BloodDonationApproves_AppUserId",
                table: "BloodDonationApproves",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDonationApproves_BloodDonation_BloodDontaionId",
                table: "BloodDonationApproves",
                column: "BloodDontaionId",
                principalTable: "BloodDonation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDonationApproves_Users_AppUserId",
                table: "BloodDonationApproves",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodDonationApproves_BloodDonation_BloodDontaionId",
                table: "BloodDonationApproves");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodDonationApproves_Users_AppUserId",
                table: "BloodDonationApproves");

            migrationBuilder.DropIndex(
                name: "IX_BloodDonationApproves_AppUserId",
                table: "BloodDonationApproves");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "BloodDonationApproves");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDonationApproves_BloodDonation_BloodDontaionId",
                table: "BloodDonationApproves",
                column: "BloodDontaionId",
                principalTable: "BloodDonation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
