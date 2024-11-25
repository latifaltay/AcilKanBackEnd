using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class testmig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodDonationApproves_BloodDontaion_BloodDontaionId",
                table: "BloodDonationApproves");

            migrationBuilder.DropTable(
                name: "BloodDontaion");

            migrationBuilder.CreateTable(
                name: "BloodDonation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    DonationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BloodRequestId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodDonation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodDonation_BloodRequests_BloodRequestId",
                        column: x => x.BloodRequestId,
                        principalTable: "BloodRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BloodDonation_Users_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodDonation_BloodRequestId",
                table: "BloodDonation",
                column: "BloodRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDonation_DonorId",
                table: "BloodDonation",
                column: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDonationApproves_BloodDonation_BloodDontaionId",
                table: "BloodDonationApproves",
                column: "BloodDontaionId",
                principalTable: "BloodDonation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodDonationApproves_BloodDonation_BloodDontaionId",
                table: "BloodDonationApproves");

            migrationBuilder.DropTable(
                name: "BloodDonation");

            migrationBuilder.CreateTable(
                name: "BloodDontaion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodRequestId = table.Column<int>(type: "int", nullable: false),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    DonationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodDontaion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodDontaion_BloodRequests_BloodRequestId",
                        column: x => x.BloodRequestId,
                        principalTable: "BloodRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BloodDontaion_Users_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodDontaion_BloodRequestId",
                table: "BloodDontaion",
                column: "BloodRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDontaion_DonorId",
                table: "BloodDontaion",
                column: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDonationApproves_BloodDontaion_BloodDontaionId",
                table: "BloodDonationApproves",
                column: "BloodDontaionId",
                principalTable: "BloodDontaion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
