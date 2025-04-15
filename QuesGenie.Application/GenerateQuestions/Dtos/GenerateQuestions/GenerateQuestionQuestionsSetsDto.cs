namespace QuesGenie.Application.GenerateQuestions.Dtos.GenerateQuestions;

public class GenerateQuestionQuestionsSetsDto
{
    public GenerateQuestionQuestionsSetsDto()
    {
        mcqQuestions = new List<GenerateQuestionMcqQuestionsDto>();
        matchingQuestions = new List<GenerateQuestionsMatchingDto>();
        trueFalseQuestions = new List<GenerateQuestionsTrueFalseDto>();
        fillTheBlanks = new List<GenerateQuestionsFillTheBlankDto>();
    }
    public string documentId { get; set; } = default!;
    public List<GenerateQuestionMcqQuestionsDto> mcqQuestions { get; set; }
    public List<GenerateQuestionsMatchingDto> matchingQuestions { get; set; } = default!;
    public List<GenerateQuestionsTrueFalseDto> trueFalseQuestions { get; set; } = default!;
    public List<GenerateQuestionsFillTheBlankDto> fillTheBlanks { get; set; } = default!;
    
    
}