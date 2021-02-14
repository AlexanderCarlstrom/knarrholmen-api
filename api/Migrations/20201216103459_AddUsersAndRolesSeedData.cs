using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AddUsersAndRolesSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "037a87d5-2f44-474c-b494-295faeac310f", "ec8b9b04-fda5-4b04-9922-23b52fd405a6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b8973d7c-483d-4a3e-9d1b-c04a4d809323", "5a59aeb5-9486-4041-8d5d-c0179cd81fd6", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e3db864-4c10-41d8-8060-b4edb0534fac", 0, "f4687d2a-7480-4c28-a624-68d50c86b0f7", "alexander@gmail.com", true, "Alexander", "Carlström", false, null, "ALEXANDER@GMAIL.COM", "ALEXANDER@GMAIL.COM", "AQAAAAEAACcQAAAAEAYIJ/OMFAgl+f5jmsujfKHPNmlgIabM4xla7sPD+kHpSYDFnRrVGNnxALCnNo3uwQ==", null, false, "5dd932d5-4f44-4dda-8380-faadc97ac391", false, "alexander@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "037a87d5-2f44-474c-b494-295faeac310f", "8e3db864-4c10-41d8-8060-b4edb0534fac" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8973d7c-483d-4a3e-9d1b-c04a4d809323");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "037a87d5-2f44-474c-b494-295faeac310f", "8e3db864-4c10-41d8-8060-b4edb0534fac" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037a87d5-2f44-474c-b494-295faeac310f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e3db864-4c10-41d8-8060-b4edb0534fac");
        }
    }
}
