using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class testmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "BloodRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BloodGroupId",
                table: "BloodRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BloodRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BloodRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "BloodRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatientSurname",
                table: "BloodRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_AppUserId",
                table: "BloodRequests",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_BloodGroupId",
                table: "BloodRequests",
                column: "BloodGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodRequests_BloodGroups_BloodGroupId",
                table: "BloodRequests",
                column: "BloodGroupId",
                principalTable: "BloodGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodRequests_Users_AppUserId",
                table: "BloodRequests",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodRequests_BloodGroups_BloodGroupId",
                table: "BloodRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodRequests_Users_AppUserId",
                table: "BloodRequests");

            migrationBuilder.DropIndex(
                name: "IX_BloodRequests_AppUserId",
                table: "BloodRequests");

            migrationBuilder.DropIndex(
                name: "IX_BloodRequests_BloodGroupId",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "BloodGroupId",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "PatientSurname",
                table: "BloodRequests");
        }
    }
}
