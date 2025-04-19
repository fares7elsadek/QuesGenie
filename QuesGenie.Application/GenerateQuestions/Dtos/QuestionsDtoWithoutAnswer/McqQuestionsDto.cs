using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.Dtos;

public class McqQuestionsDto
{
    public McqQuestionsDto()
    {
        McqOptions = new HashSet<McqOptionsDto>();
    }
    public string QuestionId { get; set; } = default!;
    public string QuestionText { get; set; } = default!;
    public string DocumentId { get; set; } = default!;
    public string Context { get; set; } = default!;
    public string PageRange { get; set; } = default!;
    public ICollection<McqOptionsDto> McqOptions { get; set; }
}