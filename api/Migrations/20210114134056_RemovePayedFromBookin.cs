using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class RemovePayedFromBookin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payed",
                table: "Bookings");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Payed",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037a87d5-2f44-474c-b494-295faeac310f",
                column: "ConcurrencyStamp",
                value: "e484b820-7850-4953-96bb-8b4899ccaf3a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8973d7c-483d-4a3e-9d1b-c04a4d809323",
                column: "ConcurrencyStamp",
                value: "da0f4638-a6a6-45af-b11c-68838b5e5d66");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e3db864-4c10-41d8-8060-b4edb0534fac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f4c85ad-916e-4469-b493-3040c801cf54", "AQAAAAEAACcQAAAAEB03Xkgn+Xpd52NP9sWzyd3j089Uy8rWksDiQr+G6lXGERetJGWroWp+4kmmFLtobg==", "e41ddc11-4bbd-4e83-aacf-07d31dddc267" });
        }
    }
}
