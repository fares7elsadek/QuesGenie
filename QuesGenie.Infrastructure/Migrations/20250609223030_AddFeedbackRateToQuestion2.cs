using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuesGenie.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFeedbackRateToQuestion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Evaluated",
                table: "TrueFalseQuestions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Evaluated",
                table: "McqQuestions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Evaluated",
                table: "MatchingQuestions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Evaluated",
                table: "FillTheBlank",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Evaluated",
                table: "TrueFalseQuestions");

            migrationBuilder.DropColumn(
                name: "Evaluated",
                table: "McqQuestions");

            migrationBuilder.DropColumn(
                name: "Evaluated",
                table: "MatchingQuestions");

            migrationBuilder.DropColumn(
                name: "Evaluated",
                table: "FillTheBlank");
        }
    }
}
