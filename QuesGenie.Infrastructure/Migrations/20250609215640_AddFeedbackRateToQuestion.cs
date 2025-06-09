using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuesGenie.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFeedbackRateToQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HumanRate",
                table: "TrueFalseQuestions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HumanRate",
                table: "McqQuestions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HumanRate",
                table: "MatchingQuestions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HumanRate",
                table: "FillTheBlank",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HumanRate",
                table: "TrueFalseQuestions");

            migrationBuilder.DropColumn(
                name: "HumanRate",
                table: "McqQuestions");

            migrationBuilder.DropColumn(
                name: "HumanRate",
                table: "MatchingQuestions");

            migrationBuilder.DropColumn(
                name: "HumanRate",
                table: "FillTheBlank");
        }
    }
}
