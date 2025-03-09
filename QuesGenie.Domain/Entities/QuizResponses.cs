namespace QuesGenie.Domain.Entities;

public class QuizResponses
{
    public string ResponseId { get; set; } = default!;
    public string QuestionId { get; set; } = default!;
    public Questions Question { get; set; } = default!;
    public string UserAnswer { get; set; } = default!;
    public string QuizId { get; set; } = default!;
    public Quizzes Quiz { get; set; } = default!;
    public bool IsCorrectAnswer { get; set; }
}