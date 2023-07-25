using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoloLearning.Migrations
{
    /// <inheritdoc />
    public partial class updateuserids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ed528f3-bd0e-4b7a-b264-aa123cd64ce8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9102da58-8427-472d-8f77-da96d08ab8f6");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserCourses");

            migrationBuilder.AddColumn<string>(
                name: "ApiUserId",
                table: "UserCourses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "766d09c8-47b2-44b0-91c4-542c736b3030", null, "User", "USER" },
                    { "871b5e98-d787-4a40-b016-bab814821359", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_ApiUserId",
                table: "UserCourses",
                column: "ApiUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_AspNetUsers_ApiUserId",
                table: "UserCourses",
                column: "ApiUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_AspNetUsers_ApiUserId",
                table: "UserCourses");

            migrationBuilder.DropIndex(
                name: "IX_UserCourses_ApiUserId",
                table: "UserCourses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "766d09c8-47b2-44b0-91c4-542c736b3030");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "871b5e98-d787-4a40-b016-bab814821359");

            migrationBuilder.DropColumn(
                name: "ApiUserId",
                table: "UserCourses");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserCourses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ed528f3-bd0e-4b7a-b264-aa123cd64ce8", null, "User", "USER" },
                    { "9102da58-8427-472d-8f77-da96d08ab8f6", null, "Admin", "ADMIN" }
                });
        }
    }
}
