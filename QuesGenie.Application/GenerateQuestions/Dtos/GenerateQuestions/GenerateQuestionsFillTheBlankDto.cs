namespace QuesGenie.Application.GenerateQuestions.Dtos.GenerateQuestions;

public class GenerateQuestionsFillTheBlankDto
{
    public string questionText { get; set; } = default!;
    public string pageRange { get; set; } = default!;
    public string answerText { get; set; } = default!;
}