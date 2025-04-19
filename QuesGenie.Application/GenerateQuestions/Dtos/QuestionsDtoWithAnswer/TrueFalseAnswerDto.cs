namespace QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;

public class TrueFalseAnswerDto
{
    public string QuestionId { get; set; } = default!;
    public string QuestionText { get; set; } = default!;
    public string DocumentId { get; set; } = default!;
    public string PageRange { get; set; } = default!;
    public string Context { get; set; } = default!;
    public bool Answer { get; set; }
}