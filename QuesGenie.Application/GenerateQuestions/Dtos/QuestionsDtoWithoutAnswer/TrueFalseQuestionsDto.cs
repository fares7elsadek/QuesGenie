namespace QuesGenie.Application.GenerateQuestions.Dtos;

public class TrueFalseQuestionsDto
{
    public string QuestionId { get; set; } = default!;
    public string QuestionText { get; set; } = default!;
    public string DocumentId { get; set; } = default!;
    public string PageRange { get; set; } = default!;
}