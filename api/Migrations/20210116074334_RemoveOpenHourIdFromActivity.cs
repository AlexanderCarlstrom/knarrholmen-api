using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class RemoveOpenHourIdFromActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_OpenHours_OpenHoursId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "OpenHours");

            migrationBuilder.DropIndex(
                name: "IX_Activities_OpenHoursId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "OpenHoursId",
                table: "Activities");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037a87d5-2f44-474c-b494-295faeac310f",
                column: "ConcurrencyStamp",
                value: "69b05313-6967-4e57-8f6a-e6a391f519fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8973d7c-483d-4a3e-9d1b-c04a4d809323",
                column: "ConcurrencyStamp",
                value: "d435028c-2ca0-47ca-a9a1-48994c49c163");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e3db864-4c10-41d8-8060-b4edb0534fac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86d6e800-3a19-4c76-9448-63f5211fb1c0", "AQAAAAEAACcQAAAAEMTn8/TjKHjhHiiLOc2pSIc+VJeliM5Y8qOAEBejAaIhLnBe4soOCfkA8gtsz0DU4w==", "8649e12b-0f71-4648-a0af-2070c57a1f42" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OpenHoursId",
                table: "Activities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OpenHours",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Close = table.Column<int>(type: "int", nullable: false),
                    Open = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenHours", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037a87d5-2f44-474c-b494-295faeac310f",
                column: "ConcurrencyStamp",
                value: "a587e6c2-4268-49b7-812e-ae3f030a42c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8973d7c-483d-4a3e-9d1b-c04a4d809323",
                column: "ConcurrencyStamp",
                value: "fe1fa629-2a04-4194-977c-786570506acd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e3db864-4c10-41d8-8060-b4edb0534fac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89a15c53-78c2-4763-bfa7-dc530e0f1d7b", "AQAAAAEAACcQAAAAEBsGkmcFHlGcmYOQKmYRWBfD2nLDYbu/z3e32DktEAiqZlSEh+4h7bsOt9cBQe4ZZQ==", "c87ca10b-1844-42cd-9428-729401ad000a" });

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
    }
}
