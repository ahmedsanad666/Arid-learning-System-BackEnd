using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoloLearning.Migrations
{
    /// <inheritdoc />
    public partial class addtablesssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Slides_SlideId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_SlideId",
                table: "Question");

            migrationBuilder.AlterColumn<string>(
                name: "SlideId",
                table: "Question",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SlideId",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_SlideId",
                table: "Question",
                column: "SlideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Slides_SlideId",
                table: "Question",
                column: "SlideId",
                principalTable: "Slides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
