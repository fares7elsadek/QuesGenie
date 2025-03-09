using QuesGenie.Domain.Enums;

namespace QuesGenie.Domain.Entities;

public class Documents
{
    public string DocumentId { get; set; } = default!;
    public string SubmissionId { get; set; } = default!;
    public Submissions Submission { get; set; } = default!;
    public DocumentType DocumentType { get; set; } 
    public DateTime UploadedAt { get; set; } 
    public string? Content { get; set; } 
    public string? FileUrl { get; set; } 
    public QuestionsSets QuestionSet { get; set; } = default!;
}