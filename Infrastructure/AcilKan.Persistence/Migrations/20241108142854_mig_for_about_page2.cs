using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_for_about_page2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abouts",
                table: "Abouts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "ContactPages");

            migrationBuilder.RenameTable(
                name: "Abouts",
                newName: "AboutUs");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "DonationBenefits",
                newName: "Article");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPages",
                table: "ContactPages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AboutUs",
                table: "AboutUs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ContactForAboutPages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactForAboutPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralConditionsForBloodDonations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Article = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralConditionsForBloodDonations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthConditionsForBloodDonations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Article = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthConditionsForBloodDonations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodDonationConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralConditionsForBloodDonationId = table.Column<int>(type: "int", nullable: false),
                    HealthConditionsForBloodDonationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodDonationConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodDonationConditions_GeneralConditionsForBloodDonations_GeneralConditionsForBloodDonationId",
                        column: x => x.GeneralConditionsForBloodDonationId,
                        principalTable: "GeneralConditionsForBloodDonations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BloodDonationConditions_HealthConditionsForBloodDonations_HealthConditionsForBloodDonationId",
                        column: x => x.HealthConditionsForBloodDonationId,
                        principalTable: "HealthConditionsForBloodDonations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AboutBloodDonations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MissionId = table.Column<int>(type: "int", nullable: false),
                    DonationBenefitId = table.Column<int>(type: "int", nullable: false),
                    BloodDonationConditionsId = table.Column<int>(type: "int", nullable: false),
                    ContactForAboutPageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutBloodDonations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutBloodDonations_BloodDonationConditions_BloodDonationConditionsId",
                        column: x => x.BloodDonationConditionsId,
                        principalTable: "BloodDonationConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AboutBloodDonations_ContactForAboutPages_ContactForAboutPageId",
                        column: x => x.ContactForAboutPageId,
                        principalTable: "ContactForAboutPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AboutBloodDonations_DonationBenefits_DonationBenefitId",
                        column: x => x.DonationBenefitId,
                        principalTable: "DonationBenefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AboutBloodDonations_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutBloodDonations_BloodDonationConditionsId",
                table: "AboutBloodDonations",
                column: "BloodDonationConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutBloodDonations_ContactForAboutPageId",
                table: "AboutBloodDonations",
                column: "ContactForAboutPageId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutBloodDonations_DonationBenefitId",
                table: "AboutBloodDonations",
                column: "DonationBenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutBloodDonations_MissionId",
                table: "AboutBloodDonations",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDonationConditions_GeneralConditionsForBloodDonationId",
                table: "BloodDonationConditions",
                column: "GeneralConditionsForBloodDonationId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDonationConditions_HealthConditionsForBloodDonationId",
                table: "BloodDonationConditions",
                column: "HealthConditionsForBloodDonationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutBloodDonations");

            migrationBuilder.DropTable(
                name: "BloodDonationConditions");

            migrationBuilder.DropTable(
                name: "ContactForAboutPages");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "GeneralConditionsForBloodDonations");

            migrationBuilder.DropTable(
                name: "HealthConditionsForBloodDonations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPages",
                table: "ContactPages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AboutUs",
                table: "AboutUs");

            migrationBuilder.RenameTable(
                name: "ContactPages",
                newName: "Contacts");

            migrationBuilder.RenameTable(
                name: "AboutUs",
                newName: "Abouts");

            migrationBuilder.RenameColumn(
                name: "Article",
                table: "DonationBenefits",
                newName: "Description");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abouts",
                table: "Abouts",
                column: "Id");
        }
    }
}
