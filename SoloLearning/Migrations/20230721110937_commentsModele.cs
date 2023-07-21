using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoloLearning.Migrations
{
    /// <inheritdoc />
    public partial class commentsModele : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "slideComments");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "slideComments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "slideComments");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "slideComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
