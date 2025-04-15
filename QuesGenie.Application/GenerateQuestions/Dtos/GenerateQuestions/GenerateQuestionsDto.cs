namespace QuesGenie.Application.GenerateQuestions.Dtos.GenerateQuestions;

public class GenerateQuestionsDto
{
    public GenerateQuestionsDto()
    {
        questionSets = new List<GenerateQuestionQuestionsSetsDto>();
    }
    public List<GenerateQuestionQuestionsSetsDto> questionSets { get; set; }
}