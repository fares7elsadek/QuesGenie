using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuesGenie.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeScoreToDoubleInQuizTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "Quizzes",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Quizzes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
