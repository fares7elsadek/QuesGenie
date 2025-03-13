using QuesGenie.Application.GenerateQuestions.Dtos.Profiles;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Enums;

namespace QuesGenie.Application.GenerateQuestions.Dtos;

public class GetQuestionSetDto
{
    public GetQuestionSetDto()
    {
        McqQuestions = new List<McqQuestionsDto>();
        MatchingQuestions = new List<MatchingQuestionsDto>();
        TrueFalseQuestions= new List<TrueFalseQuestionsDto>();
        FillTheBlanks = new List<FillTheBlankDto>();
    }
    public string QuestionSetId { get; set; } = default!;
    public List<McqQuestionsDto> McqQuestions { get; set; }
    public List<MatchingQuestionsDto> MatchingQuestions { get; set; }
    public List<TrueFalseQuestionsDto> TrueFalseQuestions { get; set; }
    public List<FillTheBlankDto> FillTheBlanks { get; set; }
    public string Status { get; set; }

}