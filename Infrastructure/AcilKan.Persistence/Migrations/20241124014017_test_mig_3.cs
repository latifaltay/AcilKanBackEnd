using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class test_mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodDontaion_DonationStatuses_DonationStatusId",
                table: "BloodDontaion");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodDontaion_Hospitals_HospitalId",
                table: "BloodDontaion");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodRequests_DonationStatuses_DonationStatusId",
                table: "BloodRequests");

            migrationBuilder.DropIndex(
                name: "IX_BloodRequests_DonationStatusId",
                table: "BloodRequests");

            migrationBuilder.DropIndex(
                name: "IX_BloodDontaion_DonationStatusId",
                table: "BloodDontaion");

            migrationBuilder.DropIndex(
                name: "IX_BloodDontaion_HospitalId",
                table: "BloodDontaion");

            migrationBuilder.DropColumn(
                name: "DonationStatusId",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "DonationType",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "DonationType",
                table: "BloodDontaion");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "BloodDontaion");

            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "BloodDontaion");

            migrationBuilder.DropColumn(
                name: "PatientSurname",
                table: "BloodDontaion");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "BloodRequests",
                newName: "RequestDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "BloodRequests",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<int>(
                name: "DonationStatusId",
                table: "BloodRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DonationType",
                table: "BloodRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DonationType",
                table: "BloodDontaion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "BloodDontaion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "BloodDontaion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatientSurname",
                table: "BloodDontaion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_DonationStatusId",
                table: "BloodRequests",
                column: "DonationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDontaion_DonationStatusId",
                table: "BloodDontaion",
                column: "DonationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDontaion_HospitalId",
                table: "BloodDontaion",
                column: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDontaion_DonationStatuses_DonationStatusId",
                table: "BloodDontaion",
                column: "DonationStatusId",
                principalTable: "DonationStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDontaion_Hospitals_HospitalId",
                table: "BloodDontaion",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodRequests_DonationStatuses_DonationStatusId",
                table: "BloodRequests",
                column: "DonationStatusId",
                principalTable: "DonationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
