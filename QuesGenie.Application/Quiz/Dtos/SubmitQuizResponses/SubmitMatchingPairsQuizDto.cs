namespace QuesGenie.Application.Quiz.Dtos;

public class SubmitMatchingPairsQuizDto
{
    public string QuestionId { get; set; } = default!;
    public string LeftSide { get; set; } = default!;
    public string RightSide { get; set; } = default!;
}