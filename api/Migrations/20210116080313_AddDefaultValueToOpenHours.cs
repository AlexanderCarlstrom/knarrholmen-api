using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AddDefaultValueToOpenHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
