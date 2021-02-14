using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AddedBookingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Payed = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ActivityId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037a87d5-2f44-474c-b494-295faeac310f",
                column: "ConcurrencyStamp",
                value: "56fbe638-7289-496d-830c-ccc8a65aa76d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8973d7c-483d-4a3e-9d1b-c04a4d809323",
                column: "ConcurrencyStamp",
                value: "15b0b65c-40a6-4a38-bf51-7891af9578ef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e3db864-4c10-41d8-8060-b4edb0534fac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fd00cae-4c5e-4dc7-852d-8eb3dd84a403", "AQAAAAEAACcQAAAAEArXO8ro1q/8W3eWqBMzhuQzzcbkOSGxEcIyH3vlxuHAk2l2+ZBMJFr4OzZIhj3hmQ==", "f4508cff-116f-4edd-b6aa-16c3b6a459d7" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ActivityId",
                table: "Bookings",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Activities");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037a87d5-2f44-474c-b494-295faeac310f",
                column: "ConcurrencyStamp",
                value: "38beeda9-54dc-4aee-9dd3-2073a1285810");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8973d7c-483d-4a3e-9d1b-c04a4d809323",
                column: "ConcurrencyStamp",
                value: "1600ed9b-4728-48f4-bb69-2ce9bf1aeba1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e3db864-4c10-41d8-8060-b4edb0534fac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "507c3ef2-2e52-4cdf-8740-5efcee44cda1", "AQAAAAEAACcQAAAAEFmoxkaByef0YzqEV+Jr+1X1q8G9y7BmQ8UNOVGuNjrUQ3b9lbNf3dcsiVa2KEsAXQ==", "9138bf73-797c-445d-9a17-3f468a64b997" });
        }
    }
}
