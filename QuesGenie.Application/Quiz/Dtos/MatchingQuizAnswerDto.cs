namespace QuesGenie.Application.Quiz.Dtos;

public class MatchingQuizAnswerDto
{
    public string QuestionId { get; set; } = default!;
    public List<MatchingPairsQuizAnswer> MatchingPairsQuiz { get; set; } = default!;
}