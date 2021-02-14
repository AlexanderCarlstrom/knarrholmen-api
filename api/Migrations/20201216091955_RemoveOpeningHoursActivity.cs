using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class RemoveOpeningHoursActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloseTime",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "OpenTime",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "open",
                table: "OpenHours",
                newName: "Open");

            migrationBuilder.RenameColumn(
                name: "close",
                table: "OpenHours",
                newName: "Close");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Open",
                table: "OpenHours",
                newName: "open");

            migrationBuilder.RenameColumn(
                name: "Close",
                table: "OpenHours",
                newName: "close");

            migrationBuilder.AddColumn<int>(
                name: "CloseTime",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpenTime",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
