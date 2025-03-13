namespace QuesGenie.Application.GenerateQuestions.Dtos;

public class MatchingPairsDto
{
    public string PairId { get; set; } = default!;
    public string LeftSide { get; set; } = default!;
    public string RightSide { get; set; } = default!;
}