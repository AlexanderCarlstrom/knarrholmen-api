using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class OpenHoursAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinMinutes",
                table: "Activities",
                newName: "MinTime");

            migrationBuilder.RenameColumn(
                name: "MaxMinutes",
                table: "Activities",
                newName: "MaxTime");

            migrationBuilder.CreateTable(
                name: "OpenHours",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    open = table.Column<int>(type: "int", nullable: false),
                    close = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    ActivityId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenHours_Activities_ActivityId1",
                        column: x => x.ActivityId1,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpenHours_ActivityId1",
                table: "OpenHours",
                column: "ActivityId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpenHours");

            migrationBuilder.RenameColumn(
                name: "MinTime",
                table: "Activities",
                newName: "MinMinutes");

            migrationBuilder.RenameColumn(
                name: "MaxTime",
                table: "Activities",
                newName: "MaxMinutes");
        }
    }
}
