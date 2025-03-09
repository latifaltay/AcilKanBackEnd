using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BloodDonationApprove_Removed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodDonationApproves");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodDonationApproves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodDontaionId = table.Column<int>(type: "int", nullable: false),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    RequestCreatorId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    IsDonorApproved = table.Column<bool>(type: "bit", nullable: true),
                    IsRequestCreatorApproved = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodDonationApproves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodDonationApproves_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BloodDonationApproves_AspNetUsers_DonorId",
                        column: x => x.DonorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BloodDonationApproves_AspNetUsers_RequestCreatorId",
                        column: x => x.RequestCreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BloodDonationApproves_BloodDonations_BloodDontaionId",
                        column: x => x.BloodDontaionId,
                        principalTable: "BloodDonations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodDonationApproves_AppUserId",
                table: "BloodDonationApproves",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDonationApproves_BloodDontaionId",
                table: "BloodDonationApproves",
                column: "BloodDontaionId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDonationApproves_DonorId",
                table: "BloodDonationApproves",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDonationApproves_RequestCreatorId",
                table: "BloodDonationApproves",
                column: "RequestCreatorId");
        }
    }
}
