using QuesGenie.Application.GenerateQuestions.Dtos;

namespace QuesGenie.Application.Quiz.Dtos;

public class QuizDto
{
    public QuizDto()
    {
        McqQuestions = new List<McqQuestionsDto>();
        MatchingQuestions = new List<MatchingQuestionsDto>();
        TrueFalseQuestions= new List<TrueFalseQuestionsDto>();
        FillTheBlanks = new List<FillTheBlankDto>();
    }
    public string QuizId { get; set; }
    public List<McqQuestionsDto> McqQuestions { get; set; }
    public List<MatchingQuestionsDto> MatchingQuestions { get; set; }
    public List<TrueFalseQuestionsDto> TrueFalseQuestions { get; set; }
    public List<FillTheBlankDto> FillTheBlanks { get; set; }
}