using QuesGenie.Domain.Enums;

namespace QuesGenie.Domain.Entities;

public abstract class Questions
{
    public Questions()
    {
        QuizResponses = new HashSet<QuizResponses>();
    }
    public string QuestionId { get; set; } = default!;
    public string QuestionSetId { get; set; } = default!;
    public QuestionsSets QuestionSet { get; set; } = default!;
    public string QuestionText { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public string DocumentId { get; set; } = default!;
    public Documents Document { get; set; } = default!;
    public string PageRange { get; set; } = default!;
    public ICollection<QuizResponses> QuizResponses { get; set; }
}