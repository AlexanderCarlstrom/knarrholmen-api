using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class MoveOpenHoursToActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Close",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Open",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037a87d5-2f44-474c-b494-295faeac310f",
                column: "ConcurrencyStamp",
                value: "81234d1c-1826-44b4-bc3b-26fb04cbd5e4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8973d7c-483d-4a3e-9d1b-c04a4d809323",
                column: "ConcurrencyStamp",
                value: "e2f5bcc1-d417-4766-8a7c-18534aa041e1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e3db864-4c10-41d8-8060-b4edb0534fac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dff5c00-438e-479f-9696-117b45e5790d", "AQAAAAEAACcQAAAAEHp65FHQrCu0+9v5OXUA++q5T8+SYIsj/dxKPvqd76Vy/YNG7h2zl0YHRij/EGlzbg==", "098403d0-ec62-4545-928f-c3303af0588c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Close",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Open",
                table: "Activities");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037a87d5-2f44-474c-b494-295faeac310f",
                column: "ConcurrencyStamp",
                value: "c88e6174-9713-4bbc-8ac8-1926276793ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8973d7c-483d-4a3e-9d1b-c04a4d809323",
                column: "ConcurrencyStamp",
                value: "a0dd9058-46ea-4436-b0c3-a4d250804596");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e3db864-4c10-41d8-8060-b4edb0534fac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69bc2918-f557-4927-8d75-a66143949bb1", "AQAAAAEAACcQAAAAEPbWxJkcHxXatGm72QFeLIE2Xg2YBEAiU9lH1CWZ+1+rBr41OWNcQBm+nXlcAqkhPQ==", "21ca651b-5b0c-4860-b24b-120ab7c6c39a" });
        }
    }
}
