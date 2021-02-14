using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AddActivityNameIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Activities",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037a87d5-2f44-474c-b494-295faeac310f",
                column: "ConcurrencyStamp",
                value: "85d3a767-c8b3-440d-ac1c-a4e4d3dfc06f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8973d7c-483d-4a3e-9d1b-c04a4d809323",
                column: "ConcurrencyStamp",
                value: "f9757193-b3c1-475e-a683-242d3d2fa53b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e3db864-4c10-41d8-8060-b4edb0534fac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "381bf745-b2dc-490d-a969-7f68c0cbe282", "AQAAAAEAACcQAAAAEI1DETVLv845E6BAJGPNH347fOwlREHZAN06bm/SkmmhAhSGIyeVgdySyx7pMACG7Q==", "44109b67-cbf0-4c0b-b17c-f1dc7ee07d3f" });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_Name",
                table: "Activities",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Activities_Name",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037a87d5-2f44-474c-b494-295faeac310f",
                column: "ConcurrencyStamp",
                value: "b32346b2-4e21-4556-8561-99ab2a01b618");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8973d7c-483d-4a3e-9d1b-c04a4d809323",
                column: "ConcurrencyStamp",
                value: "e6300ddd-b2c4-423c-a201-1d839fc0196d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e3db864-4c10-41d8-8060-b4edb0534fac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58471dc1-bbcd-46f8-9845-cdc75176befc", "AQAAAAEAACcQAAAAEN34B/dPF2j7xY522mX2U2h314cWQ/N8Uws6ffPzaEmcpUqSp6XaSqVCaO8VhCu/Hw==", "5a02d3b4-5dd1-4f60-86fd-7f4c73a75ee8" });
        }
    }
}
