namespace QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;

public class MatchingQuestionsAnswerDto
{
    public MatchingQuestionsAnswerDto()
    {
        MatchingPairs = new HashSet<MatchingPairsAnswerDto>();
    }
    public string QuestionId { get; set; } = default!;
    public string DocumentId { get; set; } = default!;
    public string PageRange { get; set; } = default!;
    public string Context { get; set; } = default!;
    public ICollection<MatchingPairsAnswerDto> MatchingPairs { get; set; }
}