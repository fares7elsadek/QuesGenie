using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuesGenie.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionsTypesToTheDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchingPairs_Questions_QuestionId",
                table: "MatchingPairs");

            migrationBuilder.DropForeignKey(
                name: "FK_McqOptions_Questions_QuestionId",
                table: "McqOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizResponses_Questions_QuestionId",
                table: "QuizResponses");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.CreateTable(
                name: "FillTheBlank",
                columns: table => new
                {
                    QuestionId = table.Column<string>(type: "text", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    QuestionSetId = table.Column<string>(type: "text", nullable: false),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    DocumentId = table.Column<string>(type: "text", nullable: false),
                    PageRange = table.Column<string>(type: "varchar(100)", nullable: false),
                    AnswerText = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FillTheBlank", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_FillTheBlank_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FillTheBlank_QuestionsSets_QuestionSetId",
                        column: x => x.QuestionSetId,
                        principalTable: "QuestionsSets",
                        principalColumn: "QuestionSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchingQuestions",
                columns: table => new
                {
                    QuestionId = table.Column<string>(type: "text", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    QuestionSetId = table.Column<string>(type: "text", nullable: false),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    DocumentId = table.Column<string>(type: "text", nullable: false),
                    PageRange = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchingQuestions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_MatchingQuestions_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchingQuestions_QuestionsSets_QuestionSetId",
                        column: x => x.QuestionSetId,
                        principalTable: "QuestionsSets",
                        principalColumn: "QuestionSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "McqQuestions",
                columns: table => new
                {
                    QuestionId = table.Column<string>(type: "text", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    QuestionSetId = table.Column<string>(type: "text", nullable: false),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    DocumentId = table.Column<string>(type: "text", nullable: false),
                    PageRange = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_McqQuestions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_McqQuestions_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_McqQuestions_QuestionsSets_QuestionSetId",
                        column: x => x.QuestionSetId,
                        principalTable: "QuestionsSets",
                        principalColumn: "QuestionSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrueFalseQuestions",
                columns: table => new
                {
                    QuestionId = table.Column<string>(type: "text", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    QuestionSetId = table.Column<string>(type: "text", nullable: false),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    DocumentId = table.Column<string>(type: "text", nullable: false),
                    PageRange = table.Column<string>(type: "varchar(100)", nullable: false),
                    Answer = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrueFalseQuestions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_TrueFalseQuestions_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrueFalseQuestions_QuestionsSets_QuestionSetId",
                        column: x => x.QuestionSetId,
                        principalTable: "QuestionsSets",
                        principalColumn: "QuestionSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FillTheBlank_DocumentId",
                table: "FillTheBlank",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_FillTheBlank_QuestionSetId",
                table: "FillTheBlank",
                column: "QuestionSetId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchingQuestions_DocumentId",
                table: "MatchingQuestions",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchingQuestions_QuestionSetId",
                table: "MatchingQuestions",
                column: "QuestionSetId");

            migrationBuilder.CreateIndex(
                name: "IX_McqQuestions_DocumentId",
                table: "McqQuestions",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_McqQuestions_QuestionSetId",
                table: "McqQuestions",
                column: "QuestionSetId");

            migrationBuilder.CreateIndex(
                name: "IX_TrueFalseQuestions_DocumentId",
                table: "TrueFalseQuestions",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_TrueFalseQuestions_QuestionSetId",
                table: "TrueFalseQuestions",
                column: "QuestionSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchingPairs_MatchingQuestions_QuestionId",
                table: "MatchingPairs",
                column: "QuestionId",
                principalTable: "MatchingQuestions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_McqOptions_McqQuestions_QuestionId",
                table: "McqOptions",
                column: "QuestionId",
                principalTable: "McqQuestions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchingPairs_MatchingQuestions_QuestionId",
                table: "MatchingPairs");

            migrationBuilder.DropForeignKey(
                name: "FK_McqOptions_McqQuestions_QuestionId",
                table: "McqOptions");

            migrationBuilder.DropTable(
                name: "FillTheBlank");

            migrationBuilder.DropTable(
                name: "MatchingQuestions");

            migrationBuilder.DropTable(
                name: "McqQuestions");

            migrationBuilder.DropTable(
                name: "TrueFalseQuestions");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<string>(type: "text", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    DocumentId = table.Column<string>(type: "text", nullable: false),
                    QuestionSetId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    PageRange = table.Column<string>(type: "varchar(100)", nullable: false),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    QuestionType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionsSets_QuestionSetId",
                        column: x => x.QuestionSetId,
                        principalTable: "QuestionsSets",
                        principalColumn: "QuestionSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<string>(type: "text", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    QuestionId = table.Column<string>(type: "text", nullable: false),
                    AnswerText = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DocumentId",
                table: "Questions",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionSetId",
                table: "Questions",
                column: "QuestionSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchingPairs_Questions_QuestionId",
                table: "MatchingPairs",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_McqOptions_Questions_QuestionId",
                table: "McqOptions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizResponses_Questions_QuestionId",
                table: "QuizResponses",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
