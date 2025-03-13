namespace QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;

public class FillTheBlankAnswerDto
{
    public string QuestionId { get; set; } = default!;
    public string QuestionText { get; set; } = default!;
    public string DocumentId { get; set; } = default!;
    public string PageRange { get; set; } = default!;
    public string AnswerText { get; set; } = default!;
}