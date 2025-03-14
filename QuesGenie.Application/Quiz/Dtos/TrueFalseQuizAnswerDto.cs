namespace QuesGenie.Application.Quiz.Dtos;

public class TrueFalseQuizAnswerDto
{
    public string QuestionId { get; set; } = default!;
    public bool TrueFalse { get; set; }
}