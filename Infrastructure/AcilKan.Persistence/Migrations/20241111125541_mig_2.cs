using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Hospitals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Districts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_DistrictId",
                table: "Hospitals",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_CityId",
                table: "BloodRequests",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_DistrictId",
                table: "BloodRequests",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_HospitalId",
                table: "BloodRequests",
                column: "HospitalId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Districts_DistrictId",
                table: "Hospitals",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Districts_DistrictId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_DistrictId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Districts_CityId",
                table: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_BloodRequests_CityId",
                table: "BloodRequests");

            migrationBuilder.DropIndex(
                name: "IX_BloodRequests_DistrictId",
                table: "BloodRequests");

            migrationBuilder.DropIndex(
                name: "IX_BloodRequests_HospitalId",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Districts");
        }
    }
}
