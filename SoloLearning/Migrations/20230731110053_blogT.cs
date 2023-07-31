using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoloLearning.Migrations
{
    /// <inheritdoc />
    public partial class blogT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e8c2ba6-7b72-457f-bb95-e8c0e7960b87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63a7385b-04e9-4b93-80cb-5c8c5a7eb66d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0159b20e-2b24-4e6e-9c1f-22766eae5c4f", null, "User", "USER" },
                    { "6bf070b9-ba9f-426b-a935-7f899bfe2fcf", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0159b20e-2b24-4e6e-9c1f-22766eae5c4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bf070b9-ba9f-426b-a935-7f899bfe2fcf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e8c2ba6-7b72-457f-bb95-e8c0e7960b87", null, "User", "USER" },
                    { "63a7385b-04e9-4b93-80cb-5c8c5a7eb66d", null, "Admin", "ADMIN" }
                });
        }
    }
}
