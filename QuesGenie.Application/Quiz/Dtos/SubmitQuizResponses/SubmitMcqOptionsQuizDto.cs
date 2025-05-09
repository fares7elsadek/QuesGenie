namespace QuesGenie.Application.Quiz.Dtos;

public class SubmitMcqOptionsQuizDto
{
    public string QuestionId { get; set; } = default!;
    public string OptionText { get; set; } = default!;
    public bool IsCorrectAnswer { get; set; }
}