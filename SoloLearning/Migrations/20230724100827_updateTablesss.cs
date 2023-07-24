using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoloLearning.Migrations
{
    /// <inheritdoc />
    public partial class updateTablesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a482a822-8967-4091-a541-f804cec3c261", null, "User", "USER" },
                    { "f87c6635-e628-4fe4-8213-2ab039eaaf5c", null, "Admin", "AMDIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a482a822-8967-4091-a541-f804cec3c261");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f87c6635-e628-4fe4-8213-2ab039eaaf5c");
        }
    }
}
