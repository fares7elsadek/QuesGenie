namespace QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;

public class GetQuestionSetAnswerDto
{
    public GetQuestionSetAnswerDto()
    {
        McqQuestions = new List<McqQuestionsAnswerDto>();
        MatchingQuestions = new List<MatchingQuestionsAnswerDto>();
        TrueFalseQuestions= new List<TrueFalseAnswerDto>();
        FillTheBlanks = new List<FillTheBlankAnswerDto>();
    }
    public string QuestionSetId { get; set; } = default!;
    public List<McqQuestionsAnswerDto> McqQuestions { get; set; }
    public List<MatchingQuestionsAnswerDto> MatchingQuestions { get; set; }
    public List<TrueFalseAnswerDto> TrueFalseQuestions { get; set; }
    public List<FillTheBlankAnswerDto> FillTheBlanks { get; set; }
    public string Status { get; set; }
}