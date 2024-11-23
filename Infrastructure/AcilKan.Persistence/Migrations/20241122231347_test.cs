using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodDonationApproves_BloodDontaions_BloodDontaionId",
                table: "BloodDonationApproves");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodDontaions_BloodRequests_BloodRequestId",
                table: "BloodDontaions");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodDontaions_Users_DonorId",
                table: "BloodDontaions");

            migrationBuilder.DropTable(
                name: "DonationHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BloodDontaions",
                table: "BloodDontaions");

            migrationBuilder.RenameTable(
                name: "BloodDontaions",
                newName: "BloodDontaion");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "BloodDontaion",
                newName: "DonationDate");

            migrationBuilder.RenameIndex(
                name: "IX_BloodDontaions_DonorId",
                table: "BloodDontaion",
                newName: "IX_BloodDontaion_DonorId");

            migrationBuilder.RenameIndex(
                name: "IX_BloodDontaions_BloodRequestId",
                table: "BloodDontaion",
                newName: "IX_BloodDontaion_BloodRequestId");

            migrationBuilder.AddColumn<int>(
                name: "DonationStatusId",
                table: "BloodDontaion",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_BloodDontaion",
                table: "BloodDontaion",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDontaion_DonationStatusId",
                table: "BloodDontaion",
                column: "DonationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDontaion_HospitalId",
                table: "BloodDontaion",
                column: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDonationApproves_BloodDontaion_BloodDontaionId",
                table: "BloodDonationApproves",
                column: "BloodDontaionId",
                principalTable: "BloodDontaion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDontaion_BloodRequests_BloodRequestId",
                table: "BloodDontaion",
                column: "BloodRequestId",
                principalTable: "BloodRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_BloodDontaion_Users_DonorId",
                table: "BloodDontaion",
                column: "DonorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodDonationApproves_BloodDontaion_BloodDontaionId",
                table: "BloodDonationApproves");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodDontaion_BloodRequests_BloodRequestId",
                table: "BloodDontaion");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodDontaion_DonationStatuses_DonationStatusId",
                table: "BloodDontaion");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodDontaion_Hospitals_HospitalId",
                table: "BloodDontaion");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodDontaion_Users_DonorId",
                table: "BloodDontaion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BloodDontaion",
                table: "BloodDontaion");

            migrationBuilder.DropIndex(
                name: "IX_BloodDontaion_DonationStatusId",
                table: "BloodDontaion");

            migrationBuilder.DropIndex(
                name: "IX_BloodDontaion_HospitalId",
                table: "BloodDontaion");

            migrationBuilder.DropColumn(
                name: "DonationStatusId",
                table: "BloodDontaion");

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

            migrationBuilder.RenameTable(
                name: "BloodDontaion",
                newName: "BloodDontaions");

            migrationBuilder.RenameColumn(
                name: "DonationDate",
                table: "BloodDontaions",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_BloodDontaion_DonorId",
                table: "BloodDontaions",
                newName: "IX_BloodDontaions_DonorId");

            migrationBuilder.RenameIndex(
                name: "IX_BloodDontaion_BloodRequestId",
                table: "BloodDontaions",
                newName: "IX_BloodDontaions_BloodRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BloodDontaions",
                table: "BloodDontaions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DonationHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonationStatusId = table.Column<int>(type: "int", nullable: false),
                    HospitalId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DonationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonationType = table.Column<bool>(type: "bit", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientSurname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationHistories_DonationStatuses_DonationStatusId",
                        column: x => x.DonationStatusId,
                        principalTable: "DonationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonationHistories_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonationHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonationHistories_DonationStatusId",
                table: "DonationHistories",
                column: "DonationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationHistories_HospitalId",
                table: "DonationHistories",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationHistories_UserId",
                table: "DonationHistories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDonationApproves_BloodDontaions_BloodDontaionId",
                table: "BloodDonationApproves",
                column: "BloodDontaionId",
                principalTable: "BloodDontaions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDontaions_BloodRequests_BloodRequestId",
                table: "BloodDontaions",
                column: "BloodRequestId",
                principalTable: "BloodRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDontaions_Users_DonorId",
                table: "BloodDontaions",
                column: "DonorId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
