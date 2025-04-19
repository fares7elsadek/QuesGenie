namespace QuesGenie.Application.GenerateQuestions.Dtos.GenerateQuestions;

public class GenerateQuestionMcqQuestionsDto
{
    public GenerateQuestionMcqQuestionsDto()
    {
        mcqOptions = new List<GenerateQuestionsMcqOptionsDto>();
    }
    public string questionText { get; set; } = default!;
    public string pageRange { get; set; } = default!;
    public string context { get; set; } = default!;
    public List<GenerateQuestionsMcqOptionsDto> mcqOptions { get; set; } 
}