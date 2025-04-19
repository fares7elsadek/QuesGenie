using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuesGenie.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcontexttothequestionitself : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Context",
                table: "TrueFalseQuestions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Context",
                table: "McqQuestions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Context",
                table: "MatchingQuestions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Context",
                table: "FillTheBlank",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Context",
                table: "TrueFalseQuestions");

            migrationBuilder.DropColumn(
                name: "Context",
                table: "McqQuestions");

            migrationBuilder.DropColumn(
                name: "Context",
                table: "MatchingQuestions");

            migrationBuilder.DropColumn(
                name: "Context",
                table: "FillTheBlank");
        }
    }
}
