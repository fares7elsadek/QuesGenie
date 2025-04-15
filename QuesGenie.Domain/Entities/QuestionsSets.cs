using QuesGenie.Domain.Enums;

namespace QuesGenie.Domain.Entities;

public class QuestionsSets
{
    public QuestionsSets()
    {
        Questions = new List<Questions>();
        Quizzes = new HashSet<Quizzes>();
    }
    public string QuestionSetId { get; set; } = default!;
    public string SubmissionId { get; set; } = default!;
    public Submissions Submission { get; set; } = default!;
    public QuestionsStatus Status { get; set; } 
    public DateTime GeneratedAt { get; set; }
    public string DocumentId { get; set; } = default!;
    public Documents Document { get; set; } = default!;
    public List<Questions> Questions { get; set; }
    public ICollection<Quizzes> Quizzes { get; set; }
}