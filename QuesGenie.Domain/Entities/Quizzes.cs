using QuesGenie.Domain.Enums;

namespace QuesGenie.Domain.Entities;

public class Quizzes
{
    public Quizzes()
    {
        Responses = new HashSet<QuizResponses>();
    }
    public string QuizId { get; set; } = default!;
    public string QuestionSetId { get; set; } = default!;
    public QuestionsSets QuestionSet { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public ApplicationUser User { get; set; } = default!;
    public int Score { get; set; }
    public DateTime SubmitDate { get; set; }
    public ICollection<QuizResponses> Responses { get; set; } 
    public QuizStatus Status { get; set; }
}