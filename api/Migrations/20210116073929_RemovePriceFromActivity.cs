using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class RemovePriceFromActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Activities",
                newName: "Location");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Activities",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
