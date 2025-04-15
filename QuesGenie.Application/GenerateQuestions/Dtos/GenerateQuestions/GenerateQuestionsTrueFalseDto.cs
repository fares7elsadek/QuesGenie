namespace QuesGenie.Application.GenerateQuestions.Dtos.GenerateQuestions;

public class GenerateQuestionsTrueFalseDto
{
    public string questionText { get; set; } = default!;
    public string pageRange { get; set; } = default!;
    public bool answer { get; set; } = default!;
}