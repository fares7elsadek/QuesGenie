using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuesGenie.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adddefalutvalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "TrueFalseQuestions",
                type: "text",
                nullable: false,
                defaultValue: "match the following",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "McqQuestions",
                type: "text",
                nullable: false,
                defaultValue: "match the following",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "MatchingQuestions",
                type: "text",
                nullable: false,
                defaultValue: "match the following",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "FillTheBlank",
                type: "text",
                nullable: false,
                defaultValue: "match the following",
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "TrueFalseQuestions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "match the following");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "McqQuestions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "match the following");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "MatchingQuestions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "match the following");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "FillTheBlank",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "match the following");
        }
    }
}
