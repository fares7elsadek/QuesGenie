namespace QuesGenie.Application.GenerateQuestions.Dtos;

public class FillTheBlankDto
{
    public string QuestionId { get; set; } = default!;
    public string QuestionText { get; set; } = default!;
    public string DocumentId { get; set; } = default!;
    public string Context { get; set; } = default!;
    public string PageRange { get; set; } = default!;
}