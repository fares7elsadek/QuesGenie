namespace QuesGenie.Domain.Entities;

public class Answers
{
    public string AnswerId { get; set; } = default!;
    public string QuestionId { get; set; } = default!;
    public Questions Question { get; set; } = default!;
    public string AnswerText { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
}