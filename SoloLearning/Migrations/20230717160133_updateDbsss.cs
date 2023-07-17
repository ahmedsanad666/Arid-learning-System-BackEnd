using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoloLearning.Migrations
{
    /// <inheritdoc />
    public partial class updateDbsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Progress",
                table: "UserCourses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "UserCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
