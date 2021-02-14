using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class OpenHoursUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpenHours_Activities_ActivityId1",
                table: "OpenHours");

            migrationBuilder.DropIndex(
                name: "IX_OpenHours_ActivityId1",
                table: "OpenHours");

            migrationBuilder.DropColumn(
                name: "ActivityId1",
                table: "OpenHours");

            migrationBuilder.AlterColumn<string>(
                name: "ActivityId",
                table: "OpenHours",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpenHours_Activities_ActivityId",
                table: "OpenHours");

            migrationBuilder.DropIndex(
                name: "IX_OpenHours_ActivityId",
                table: "OpenHours");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "OpenHours",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActivityId1",
                table: "OpenHours",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenHours_ActivityId1",
                table: "OpenHours",
                column: "ActivityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OpenHours_Activities_ActivityId1",
                table: "OpenHours",
                column: "ActivityId1",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
