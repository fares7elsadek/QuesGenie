namespace QuesGenie.Application.Quiz.Dtos;

public class FillTheBlankQuizAnswerDto
{
    public string QuestionId { get; set; } = default!;
    public string Answer { get; set; } = default!;
}