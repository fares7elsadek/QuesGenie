using QuesGenie.Domain.Enums;

namespace QuesGenie.Domain.Entities;

public class Questions
{
    public Questions()
    {
        MCQOptions = new HashSet<McqOptions>();
        Answers = new HashSet<Answers>();
        MatchingPairs = new HashSet<MatchingPairs>();
        QuizResponses = new HashSet<QuizResponses>();
    }
    public string QuestionId { get; set; } = default!;
    public string QuestionSetId { get; set; } = default!;
    public QuestionsSets QuestionSet { get; set; } = default!;
    public string QuestionText { get; set; } = default!;
    public QuestionType QuestionType { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public string DocumentId { get; set; } = default!;
    public Documents Document { get; set; } = default!;
    public string PageRange { get; set; } = default!;
    public ICollection<McqOptions> MCQOptions { get; set; }
    public ICollection<Answers> Answers { get; set; }
    public ICollection<MatchingPairs> MatchingPairs { get; set; }
    public ICollection<QuizResponses> QuizResponses { get; set; }
}