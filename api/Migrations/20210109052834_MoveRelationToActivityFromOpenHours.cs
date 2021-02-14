using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class MoveRelationToActivityFromOpenHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpenHours_Activities_ActivityId",
                table: "OpenHours");

            migrationBuilder.DropIndex(
                name: "IX_OpenHours_ActivityId",
                table: "OpenHours");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "OpenHours");

            migrationBuilder.DropColumn(
                name: "MaxTime",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "MinTime",
                table: "Activities");

            migrationBuilder.AddColumn<string>(
                name: "OpenHoursId",
                table: "Activities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037a87d5-2f44-474c-b494-295faeac310f",
                column: "ConcurrencyStamp",
                value: "38beeda9-54dc-4aee-9dd3-2073a1285810");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8973d7c-483d-4a3e-9d1b-c04a4d809323",
                column: "ConcurrencyStamp",
                value: "1600ed9b-4728-48f4-bb69-2ce9bf1aeba1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e3db864-4c10-41d8-8060-b4edb0534fac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "507c3ef2-2e52-4cdf-8740-5efcee44cda1", "AQAAAAEAACcQAAAAEFmoxkaByef0YzqEV+Jr+1X1q8G9y7BmQ8UNOVGuNjrUQ3b9lbNf3dcsiVa2KEsAXQ==", "9138bf73-797c-445d-9a17-3f468a64b997" });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_OpenHoursId",
                table: "Activities",
                column: "OpenHoursId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_OpenHours_OpenHoursId",
                table: "Activities",
                column: "OpenHoursId",
                principalTable: "OpenHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_OpenHours_OpenHoursId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_OpenHoursId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "OpenHoursId",
                table: "Activities");

            migrationBuilder.AddColumn<string>(
                name: "ActivityId",
                table: "OpenHours",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxTime",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinTime",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037a87d5-2f44-474c-b494-295faeac310f",
                column: "ConcurrencyStamp",
                value: "ec8b9b04-fda5-4b04-9922-23b52fd405a6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8973d7c-483d-4a3e-9d1b-c04a4d809323",
                column: "ConcurrencyStamp",
                value: "5a59aeb5-9486-4041-8d5d-c0179cd81fd6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e3db864-4c10-41d8-8060-b4edb0534fac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4687d2a-7480-4c28-a624-68d50c86b0f7", "AQAAAAEAACcQAAAAEAYIJ/OMFAgl+f5jmsujfKHPNmlgIabM4xla7sPD+kHpSYDFnRrVGNnxALCnNo3uwQ==", "5dd932d5-4f44-4dda-8380-faadc97ac391" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenHours_ActivityId",
                table: "OpenHours",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OpenHours_Activities_ActivityId",
                table: "OpenHours",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
