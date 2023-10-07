using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class ChangeFileLengthType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 7, 23, 32, 45, 563, DateTimeKind.Local).AddTicks(1360),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 6, 1, 18, 52, 313, DateTimeKind.Local).AddTicks(1059));

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("3373b9f3-3e07-4c94-bcb1-6edd4eadeb99"),
                column: "ConcurrencyStamp",
                value: "29e0a6f6-ba2d-422a-be39-fd160d5e976c");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("d400db84-841a-4a03-96de-adaa8e31275f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb592754-207a-4ef9-8613-3c0db095476e", "AQAAAAEAACcQAAAAEHp+MHIGSg6OExIt+vosGnQUWDeFHAhiqtHXURycm8UxueKgDvU1OkVm3upcCZof1g==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 10, 7, 23, 32, 45, 610, DateTimeKind.Local).AddTicks(4337));

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 6, 1, 18, 52, 313, DateTimeKind.Local).AddTicks(1059),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 7, 23, 32, 45, 563, DateTimeKind.Local).AddTicks(1360));

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("3373b9f3-3e07-4c94-bcb1-6edd4eadeb99"),
                column: "ConcurrencyStamp",
                value: "139fe5a8-499d-4a29-b419-06e93209fc42");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("d400db84-841a-4a03-96de-adaa8e31275f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a61b7402-8908-430b-aab3-cb81f6061ff7", "AQAAAAEAACcQAAAAEPSk3uMJvE9DUPhv7DsN6Pk8tfKgVGjtpsKQhVlnd6TU4IcnrlQREINH4KoDwE244Q==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 10, 6, 1, 18, 52, 343, DateTimeKind.Local).AddTicks(8416));
        }
    }
}
