using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoloLearning.Migrations
{
    /// <inheritdoc />
    public partial class updateTablesssstds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ae8e61f-25f3-42aa-a3ad-8b381058bd6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e02b63c0-77a0-4c3c-8a06-3be9e1a9c3ec");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ed528f3-bd0e-4b7a-b264-aa123cd64ce8", null, "User", "USER" },
                    { "9102da58-8427-472d-8f77-da96d08ab8f6", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ed528f3-bd0e-4b7a-b264-aa123cd64ce8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9102da58-8427-472d-8f77-da96d08ab8f6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ae8e61f-25f3-42aa-a3ad-8b381058bd6a", null, "Admin", "AMDIN" },
                    { "e02b63c0-77a0-4c3c-8a06-3be9e1a9c3ec", null, "User", "USER" }
                });
        }
    }
}
