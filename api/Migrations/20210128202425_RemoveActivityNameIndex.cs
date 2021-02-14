using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class RemoveActivityNameIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "7b3ac917-1188-4354-a87a-671c532e0944");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8973d7c-483d-4a3e-9d1b-c04a4d809323",
                column: "ConcurrencyStamp",
                value: "4d1e4e7f-8d42-467e-b04d-5d06de880890");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e3db864-4c10-41d8-8060-b4edb0534fac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5d306d9-3a8a-411a-96c0-c87e4ca21c93", "AQAAAAEAACcQAAAAEOd762Df7ZICdbD3TrzsHXnsxQpco80ihUKX0s1YvQlyUycJGMTKTF3QZYsVb4YbAA==", "65a7a069-2bc4-4044-bf71-0a8a8ff7bef0" });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_Name",
                table: "Activities",
                column: "Name");
        }
    }
}
