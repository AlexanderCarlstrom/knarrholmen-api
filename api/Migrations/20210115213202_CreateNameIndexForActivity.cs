using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class CreateNameIndexForActivity : Migration
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
                value: "7e300055-6892-4ae2-b3a9-92833dfbe515");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8973d7c-483d-4a3e-9d1b-c04a4d809323",
                column: "ConcurrencyStamp",
                value: "bfc5ecf3-c915-442f-b50d-162863939925");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e3db864-4c10-41d8-8060-b4edb0534fac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be5c82d0-eda6-4bcf-b7c3-31ae7cd0b958", "AQAAAAEAACcQAAAAEAYF4JCipTTh4fbqJsFdhKHULeslBf3PE7xB8xRpg12x0IrnNjCoGqivcu/JhzNKLg==", "98f062ae-da38-4fdd-85cf-201de6467e18" });

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
    }
}
