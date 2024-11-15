using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_approve_entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodDontaions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BloodRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodDontaions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodDontaions_BloodRequests_BloodRequestId",
                        column: x => x.BloodRequestId,
                        principalTable: "BloodRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodRequestApproves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Approve = table.Column<bool>(type: "bit", nullable: false),
                    BloodRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodRequestApproves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodRequestApproves_BloodRequests_BloodRequestId",
                        column: x => x.BloodRequestId,
                        principalTable: "BloodRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodDonationApproves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Approve = table.Column<bool>(type: "bit", nullable: false),
                    BloodDonationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodDonationApproves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodDonationApproves_BloodDontaions_BloodDonationId",
                        column: x => x.BloodDonationId,
                        principalTable: "BloodDontaions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodDonationApproves_BloodDonationId",
                table: "BloodDonationApproves",
                column: "BloodDonationId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDontaions_BloodRequestId",
                table: "BloodDontaions",
                column: "BloodRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequestApproves_BloodRequestId",
                table: "BloodRequestApproves",
                column: "BloodRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodDonationApproves");

            migrationBuilder.DropTable(
                name: "BloodRequestApproves");

            migrationBuilder.DropTable(
                name: "BloodDontaions");
        }
    }
}
