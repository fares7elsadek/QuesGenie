namespace QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;

public class MatchingPairsAnswerDto
{
    public string PairId { get; set; } = default!;
    public string LeftSide { get; set; } = default!;
    public string RightSide { get; set; } = default!;
}