using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_for_about_page : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Supporters");

            migrationBuilder.DropColumn(
                name: "InstitutionName",
                table: "Supporters");

            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "DonationBenefits");

            migrationBuilder.DropColumn(
                name: "SubDescription",
                table: "DonationBenefits");

            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "DonationBenefits");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Supporters",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "FooterAddresses",
                newName: "TwitterUrl");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "FooterAddresses",
                newName: "Title2");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "FooterAddresses",
                newName: "Title1");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FooterAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "FooterAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "FooterAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Link1",
                table: "FooterAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Link2",
                table: "FooterAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Link3",
                table: "FooterAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Link4",
                table: "FooterAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Link5",
                table: "FooterAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FooterAddresses");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "FooterAddresses");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "FooterAddresses");

            migrationBuilder.DropColumn(
                name: "Link1",
                table: "FooterAddresses");

            migrationBuilder.DropColumn(
                name: "Link2",
                table: "FooterAddresses");

            migrationBuilder.DropColumn(
                name: "Link3",
                table: "FooterAddresses");

            migrationBuilder.DropColumn(
                name: "Link4",
                table: "FooterAddresses");

            migrationBuilder.DropColumn(
                name: "Link5",
                table: "FooterAddresses");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "Banners");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Supporters",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "TwitterUrl",
                table: "FooterAddresses",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Title2",
                table: "FooterAddresses",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Title1",
                table: "FooterAddresses",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Supporters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstitutionName",
                table: "Supporters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "DonationBenefits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubDescription",
                table: "DonationBenefits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "DonationBenefits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
