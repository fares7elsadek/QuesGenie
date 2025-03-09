namespace QuesGenie.Domain.Entities;

public class MatchingPairs
{
    public string PairId { get; set; } = default!;
    public string QuestionId { get; set; } = default!;
    public Questions Question { get; set; } = default!;
    public string LeftSide { get; set; } = default!;
    public string RightSide { get; set; } = default!;
}