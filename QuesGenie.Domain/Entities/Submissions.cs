

namespace QuesGenie.Domain.Entities;

public class Submissions
{
    public Submissions()
    {
        Documents = new List<Documents>();
        QuestionSets = new HashSet<QuestionsSets>();
    }
    public string SubmissionId { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public ApplicationUser User { get; set; } = default!;
    public DateTime SubmissionDate { get; set; } 
    public string? SampleQuestions { get; set; } 
    public List<Documents> Documents { get; set; }
    public ICollection<QuestionsSets> QuestionSets { get; set; }
}