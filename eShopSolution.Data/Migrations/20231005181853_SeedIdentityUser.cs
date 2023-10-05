using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 6, 1, 18, 52, 313, DateTimeKind.Local).AddTicks(1059),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 6, 1, 4, 0, 706, DateTimeKind.Local).AddTicks(5588));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("3373b9f3-3e07-4c94-bcb1-6edd4eadeb99"), "139fe5a8-499d-4a29-b419-06e93209fc42", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d400db84-841a-4a03-96de-adaa8e31275f"), 0, "a61b7402-8908-430b-aab3-cb81f6061ff7", new DateTime(2004, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "thovvph31698l@gmail.com", true, "Tho", "Vu", false, null, "thovvpg31698@gmail.com", "admin", "AQAAAAEAACcQAAAAEPSk3uMJvE9DUPhv7DsN6Pk8tfKgVGjtpsKQhVlnd6TU4IcnrlQREINH4KoDwE244Q==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("3373b9f3-3e07-4c94-bcb1-6edd4eadeb99"), new Guid("d400db84-841a-4a03-96de-adaa8e31275f") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 10, 6, 1, 18, 52, 343, DateTimeKind.Local).AddTicks(8416));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("3373b9f3-3e07-4c94-bcb1-6edd4eadeb99"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("d400db84-841a-4a03-96de-adaa8e31275f"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3373b9f3-3e07-4c94-bcb1-6edd4eadeb99"), new Guid("d400db84-841a-4a03-96de-adaa8e31275f") });

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 6, 1, 4, 0, 706, DateTimeKind.Local).AddTicks(5588),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 6, 1, 18, 52, 313, DateTimeKind.Local).AddTicks(1059));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 10, 6, 1, 4, 0, 733, DateTimeKind.Local).AddTicks(5436));
        }
    }
}
