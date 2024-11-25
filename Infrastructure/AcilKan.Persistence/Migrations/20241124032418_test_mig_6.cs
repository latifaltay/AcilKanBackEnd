using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcilKan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class test_mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloodRequestStatusId",
                table: "BloodRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BloodDontaionStatusId",
                table: "BloodDontaion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BloodDontaionStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodDontaionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodRequestStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodRequestStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_BloodRequestStatusId",
                table: "BloodRequests",
                column: "BloodRequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDontaion_BloodDontaionStatusId",
                table: "BloodDontaion",
                column: "BloodDontaionStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodDontaion_BloodDontaionStatuses_BloodDontaionStatusId",
                table: "BloodDontaion",
                column: "BloodDontaionStatusId",
                principalTable: "BloodDontaionStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodRequests_BloodRequestStatuses_BloodRequestStatusId",
                table: "BloodRequests",
                column: "BloodRequestStatusId",
                principalTable: "BloodRequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodDontaion_BloodDontaionStatuses_BloodDontaionStatusId",
                table: "BloodDontaion");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodRequests_BloodRequestStatuses_BloodRequestStatusId",
                table: "BloodRequests");

            migrationBuilder.DropTable(
                name: "BloodDontaionStatuses");

            migrationBuilder.DropTable(
                name: "BloodRequestStatuses");

            migrationBuilder.DropIndex(
                name: "IX_BloodRequests_BloodRequestStatusId",
                table: "BloodRequests");

            migrationBuilder.DropIndex(
                name: "IX_BloodDontaion_BloodDontaionStatusId",
                table: "BloodDontaion");

            migrationBuilder.DropColumn(
                name: "BloodRequestStatusId",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "BloodDontaionStatusId",
                table: "BloodDontaion");
        }
    }
}
