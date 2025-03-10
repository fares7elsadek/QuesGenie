namespace QuesGenie.Domain.Entities;

public class McqOptions
{
    public string OptionId { get; set; } = default!;
    public string QuestionId { get; set; } = default!;
    public McqQuestions Question { get; set; } = default!;
    public string OptionText { get; set; } = default!;
    public bool IsCorrectAnswer { get; set; }
}