using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class test_mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationStatuses");

            migrationBuilder.DropColumn(
                name: "DonationStatusId",
                table: "BloodDontaion");

            migrationBuilder.AddColumn<bool>(
                name: "IsDonorApproved",
                table: "BloodDonationApproves",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequestCreatorApproved",
                table: "BloodDonationApproves",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDonorApproved",
                table: "BloodDonationApproves");

            migrationBuilder.DropColumn(
                name: "IsRequestCreatorApproved",
                table: "BloodDonationApproves");

            migrationBuilder.AddColumn<int>(
                name: "DonationStatusId",
                table: "BloodDontaion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DonationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationStatuses", x => x.Id);
                });
        }
    }
}
