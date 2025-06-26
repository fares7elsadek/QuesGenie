using QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;
using QuestPDF;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuesGenie.Application.Services.Pdf;

public class PdfService : IPdfService
{
    public byte[] GenerateQuestionsPdf(GetQuestionsBySubmissionIdWithAnswerDto dto)
    {
        Settings.License = LicenseType.Community;
        Settings.EnableDebugging = true; // Enable this only for debugging layout issues

        string logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "logo.png");
        byte[] logoBytes = File.Exists(logoPath) ? File.ReadAllBytes(logoPath) : null;

        var primaryColor = Colors.Blue.Darken3;
        var secondaryColor = Colors.Grey.Darken1;
        var correctColor = Colors.Green.Darken1;
        var incorrectColor = Colors.Red.Darken1;
        var correctBackground = Colors.Green.Lighten2;
        var incorrectBackground = Colors.Red.Lighten2;

        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.DefaultTextStyle(x => x.FontSize(11).FontFamily(Fonts.Calibri));

                page.Header().Padding(5).BorderBottom(1).BorderColor(primaryColor).Row(row =>
                {
                    if (logoBytes != null)
                    {
                        row.ConstantItem(60).ShowOnce().Image(logoBytes).FitWidth();
                    }

                    row.RelativeItem().ShowOnce().AlignMiddle().Column(column =>
                    {
                        column.Item().ShowOnce().Text("Question Bank Report")
                            .FontColor(primaryColor)
                            .FontSize(16).Bold();

                        column.Item().ShowOnce().Text(DateTime.UtcNow.ToString("dd MMMM yyyy"))
                            .FontColor(secondaryColor)
                            .FontSize(9);
                    });
                });

                page.Content().PaddingVertical(20).Column(content =>
                {
                    if (!string.IsNullOrEmpty(dto.SampleQuestions))
                    {
                        content.Item().PaddingTop(15).Column(col =>
                        {
                            col.Item().Text("Sample Questions")
                                .FontSize(14)
                                .Bold()
                                .FontColor(primaryColor);
                            col.Item().Text(dto.SampleQuestions)
                                .FontColor(secondaryColor)
                                .WrapAnywhere();
                        });
                    }

                    foreach (var questionSet in dto.QuestionSets)
                    {
                        if (questionSet.McqQuestions.Any())
                        {
                            content.Item().PaddingTop(15).Column(section =>
                            {
                                section.Item().Text("Multiple Choice Questions")
                                    .FontSize(14)
                                    .Bold()
                                    .FontColor(primaryColor);

                                foreach (var mcq in questionSet.McqQuestions)
                                {
                                    section.Item().BorderBottom(1)
                                        .BorderColor(Colors.Grey.Lighten1)
                                        .PaddingVertical(10)
                                        .Column(q =>
                                        {
                                            q.Item().Text(mcq.QuestionText)
                                                .Bold()
                                                .FontColor(secondaryColor)
                                                .WrapAnywhere();

                                            q.Item().PaddingTop(5).Column(options =>
                                            {
                                                foreach (var (option, index) in mcq.McqOptions.Select((o, i) => (o, i)))
                                                {
                                                    var letter = (char)('A' + index);
                                                    options.Item().Row(row =>
                                                    {
                                                        row.RelativeItem().Text($"{letter}. {option.OptionText}")
                                                            .FontColor(secondaryColor)
                                                            .WrapAnywhere();

                                                        if (option.IsCorrectAnswer)
                                                        {
                                                            row.AutoItem().AlignRight().Text("✓ Correct")
                                                                .FontColor(correctColor)
                                                                .FontSize(9);
                                                        }
                                                    });
                                                }
                                            });
                                        });
                                }
                            });
                        }

                        if (questionSet.FillTheBlanks.Any())
                        {
                            content.Item().PaddingTop(15).Column(section =>
                            {
                                section.Item().Text("Fill in the Blank")
                                    .FontSize(14)
                                    .Bold()
                                    .FontColor(primaryColor);

                                foreach (var blank in questionSet.FillTheBlanks)
                                {
                                    section.Item().BorderBottom(1)
                                        .BorderColor(Colors.Grey.Lighten1)
                                        .PaddingVertical(10)
                                        .Column(q =>
                                        {
                                            var textParts = blank.QuestionText.Split(new[] { "{blank}" }, StringSplitOptions.None);
                                            q.Item().Text(textParts[0])
                                                .FontColor(secondaryColor)
                                                .WrapAnywhere();

                                            q.Item().Text($"Answer: {blank.AnswerText}")
                                                .FontColor(correctColor)
                                                .Italic()
                                                .WrapAnywhere();
                                        });
                                }
                            });
                        }

                        if (questionSet.MatchingQuestions.Any())
                        {
                            content.Item().PaddingTop(15).Column(section =>
                            {
                                section.Item().Text("Matching Questions")
                                    .FontSize(14)
                                    .Bold()
                                    .FontColor(primaryColor);

                                foreach (var match in questionSet.MatchingQuestions)
                                {
                                    section.Item().BorderBottom(1)
                                        .BorderColor(Colors.Grey.Lighten1)
                                        .PaddingVertical(10)
                                        .Column(q =>
                                        {
                                            q.Item().Grid(grid =>
                                            {
                                                grid.Columns(2);
                                                grid.VerticalSpacing(5);
                                                grid.HorizontalSpacing(20);

                                                foreach (var pair in match.MatchingPairs)
                                                {
                                                    grid.Item().Text(pair.LeftSide)
                                                        .FontColor(secondaryColor)
                                                        .WrapAnywhere();
                                                    grid.Item().Background(Colors.Grey.Lighten3)
                                                        .Padding(5)
                                                        .Text(pair.RightSide)
                                                        .FontColor(primaryColor)
                                                        .AlignRight()
                                                        .WrapAnywhere();
                                                }
                                            });
                                        });
                                }
                            });
                        }

                        if (questionSet.TrueFalseQuestions.Any())
                        {
                            content.Item().PaddingTop(15).Column(section =>
                            {
                                section.Item().Text("True/False Questions")
                                    .FontSize(14)
                                    .Bold()
                                    .FontColor(primaryColor);

                                foreach (var tf in questionSet.TrueFalseQuestions)
                                {
                                    section.Item().BorderBottom(1)
                                        .BorderColor(Colors.Grey.Lighten1)
                                        .PaddingVertical(10)
                                        .Column(q =>
                                        {
                                            q.Item().Text(tf.QuestionText)
                                                .FontColor(secondaryColor)
                                                .WrapAnywhere();
                                            q.Item().PaddingTop(5)
                                                .Background(tf.Answer ? correctBackground : incorrectBackground)
                                                .Padding(5)
                                                .AlignCenter()
                                                .Text(tf.Answer ? "✓ True" : "✗ False")
                                                .FontColor(tf.Answer ? correctColor : incorrectColor)
                                                .Bold();
                                        });
                                }
                            });
                        }
                    }
                });

                page.Footer().BorderTop(1)
                    .BorderColor(Colors.Grey.Lighten2)
                    .PaddingTop(5)
                    .Row(row =>
                    {
                        row.RelativeItem().Text(txt =>
                        {
                            txt.Span("Generated by QuesGenie • ")
                                .FontColor(secondaryColor)
                                .FontSize(9);
                            txt.Span(DateTime.UtcNow.ToString("dd MMM yyyy HH:mm"))
                                .FontColor(primaryColor)
                                .FontSize(9);
                        });

                        row.RelativeItem().AlignRight().Text(txt =>
                        {
                            txt.CurrentPageNumber()
                                .FontColor(primaryColor)
                                .FontSize(9);
                            txt.Span(" / ")
                                .FontColor(secondaryColor)
                                .FontSize(9);
                            txt.TotalPages()
                                .FontColor(primaryColor)
                                .FontSize(9);
                        });
                    });
            });
        }).GeneratePdf();
    }
}
