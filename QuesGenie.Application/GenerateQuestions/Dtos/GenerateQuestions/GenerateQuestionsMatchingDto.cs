namespace QuesGenie.Application.GenerateQuestions.Dtos.GenerateQuestions;

public class GenerateQuestionsMatchingDto
{
    public GenerateQuestionsMatchingDto()
    {
        matchingPairs = new List<GenerateQuestionsMatchingPairsDto>();
    }
    public string pageRange { get; set; } = default!;
    public string context { get; set; } = default!;
    public List<GenerateQuestionsMatchingPairsDto> matchingPairs { get; set; } = default!;
}