namespace QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;

public class McqOptionsAnswerDto
{
    public string OptionId { get; set; } = default!;
    public string OptionText { get; set; } = default!;
    public bool IsCorrectAnswer { get; set; }
}