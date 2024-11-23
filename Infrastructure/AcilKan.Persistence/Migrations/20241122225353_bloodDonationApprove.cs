using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class bloodDonationApprove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodDonationApproves_BloodDontaions_BloodDonationId",
                table: "BloodDonationApproves");

            migrationBuilder.DropTable(
                name: "BloodRequestApproves");

            migrationBuilder.DropColumn(
                name: "Approve",
                table: "BloodDonationApproves");

            migrationBuilder.RenameColumn(
                name: "BloodDonationId",
                table: "BloodDonationApproves",
                newName: "RequestCreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_BloodDonationApproves_BloodDonationId",
                table: "BloodDonationApproves",
                newName: "IX_BloodDonationApproves_RequestCreatorId");

            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "BloodDontaions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BloodDontaionId",
                table: "BloodDonationApproves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "BloodDonationApproves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BloodDontaions_DonorId",
                table: "BloodDontaions",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDonationApproves_BloodDontaionId",
                table: "BloodDonationApproves",
                column: "BloodDontaionId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDonationApproves_DonorId",
                table: "BloodDonationApproves",
                column: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDonationApproves_BloodDontaions_BloodDontaionId",
                table: "BloodDonationApproves",
                column: "BloodDontaionId",
                principalTable: "BloodDontaions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDonationApproves_Users_DonorId",
                table: "BloodDonationApproves",
                column: "DonorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDonationApproves_Users_RequestCreatorId",
                table: "BloodDonationApproves",
                column: "RequestCreatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDontaions_Users_DonorId",
                table: "BloodDontaions",
                column: "DonorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodDonationApproves_BloodDontaions_BloodDontaionId",
                table: "BloodDonationApproves");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodDonationApproves_Users_DonorId",
                table: "BloodDonationApproves");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodDonationApproves_Users_RequestCreatorId",
                table: "BloodDonationApproves");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodDontaions_Users_DonorId",
                table: "BloodDontaions");

            migrationBuilder.DropIndex(
                name: "IX_BloodDontaions_DonorId",
                table: "BloodDontaions");

            migrationBuilder.DropIndex(
                name: "IX_BloodDonationApproves_BloodDontaionId",
                table: "BloodDonationApproves");

            migrationBuilder.DropIndex(
                name: "IX_BloodDonationApproves_DonorId",
                table: "BloodDonationApproves");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "BloodDontaions");

            migrationBuilder.DropColumn(
                name: "BloodDontaionId",
                table: "BloodDonationApproves");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "BloodDonationApproves");

            migrationBuilder.RenameColumn(
                name: "RequestCreatorId",
                table: "BloodDonationApproves",
                newName: "BloodDonationId");

            migrationBuilder.RenameIndex(
                name: "IX_BloodDonationApproves_RequestCreatorId",
                table: "BloodDonationApproves",
                newName: "IX_BloodDonationApproves_BloodDonationId");

            migrationBuilder.AddColumn<bool>(
                name: "Approve",
                table: "BloodDonationApproves",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "BloodRequestApproves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodRequestId = table.Column<int>(type: "int", nullable: false),
                    Approve = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequestApproves_BloodRequestId",
                table: "BloodRequestApproves",
                column: "BloodRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDonationApproves_BloodDontaions_BloodDonationId",
                table: "BloodDonationApproves",
                column: "BloodDonationId",
                principalTable: "BloodDontaions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
