namespace QuesGenie.Application.Quiz.Dtos;

public class SubmitMatchingQuestionDto
{
    public SubmitMatchingQuestionDto()
    {
        MatchingPairs = new List<SubmitMatchingPairsQuizDto>();
    }
    public string QuestionId { get; set; } = default!;
    public string QuestionText { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public string? Context { get; set; }
    public string DocumentId { get; set; } = default!;
    public string? PageRange { get; set; } = default!;
    public List<SubmitMatchingPairsQuizDto> MatchingPairs { get; set; }
}