using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodRequests_Cities_CityId",
                table: "BloodRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodRequests_Districts_DistrictId",
                table: "BloodRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodRequests_Hospitals_HospitalId",
                table: "BloodRequests");

            migrationBuilder.DropIndex(
                name: "IX_BloodRequests_CityId",
                table: "BloodRequests");

            migrationBuilder.DropIndex(
                name: "IX_BloodRequests_DistrictId",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "BloodRequests");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodRequests_Hospitals_HospitalId",
                table: "BloodRequests",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodRequests_Hospitals_HospitalId",
                table: "BloodRequests");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "BloodRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "BloodRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_CityId",
                table: "BloodRequests",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_DistrictId",
                table: "BloodRequests",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodRequests_Cities_CityId",
                table: "BloodRequests",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodRequests_Districts_DistrictId",
                table: "BloodRequests",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodRequests_Hospitals_HospitalId",
                table: "BloodRequests",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id");
        }
    }
}
