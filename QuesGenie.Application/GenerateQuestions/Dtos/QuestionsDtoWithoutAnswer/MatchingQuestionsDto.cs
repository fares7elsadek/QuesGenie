using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.Dtos;

public class MatchingQuestionsDto
{
    public MatchingQuestionsDto()
    {
        LeftPairs = new List<string>();
        RightPairs = new List<string>();
    }
    public string QuestionId { get; set; } = default!;
    public string DocumentId { get; set; } = default!;
    public string PageRange { get; set; } = default!;
    public string Context { get; set; } = default!;
    public List<string> LeftPairs { get; set; }
    public List<string> RightPairs { get; set; } 
}