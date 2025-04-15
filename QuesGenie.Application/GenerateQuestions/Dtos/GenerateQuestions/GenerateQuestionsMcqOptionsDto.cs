namespace QuesGenie.Application.GenerateQuestions.Dtos.GenerateQuestions;

public class GenerateQuestionsMcqOptionsDto
{
    public string optionText { get; set; } = default!;
    public bool isCorrectAnswer { get; set; }
}