namespace QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;

public class McqQuestionsAnswerDto
{
    public McqQuestionsAnswerDto()
    {
        McqOptions = new HashSet<McqOptionsAnswerDto>();
    }
    public string QuestionId { get; set; } = default!;
    public string QuestionText { get; set; } = default!;
    public string DocumentId { get; set; } = default!;
    public string PageRange { get; set; } = default!;
    public ICollection<McqOptionsAnswerDto> McqOptions { get; set; }
}