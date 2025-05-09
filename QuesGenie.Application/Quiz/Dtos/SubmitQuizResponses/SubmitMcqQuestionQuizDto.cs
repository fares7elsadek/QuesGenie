namespace QuesGenie.Application.Quiz.Dtos;

public class SubmitMcqQuestionQuizDto
{
    public SubmitMcqQuestionQuizDto()
    {
        McqOptions = new HashSet<SubmitMcqOptionsQuizDto>();
    }
    public string QuestionId { get; set; } = default!;
    public string QuestionText { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public string? Context { get; set; }
    public string DocumentId { get; set; } = default!;
    public string? PageRange { get; set; } = default!;
    public ICollection<SubmitMcqOptionsQuizDto> McqOptions { get; set; }
}