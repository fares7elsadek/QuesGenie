namespace QuesGenie.Application.GenerateQuestions.Dtos;

public class QuestionRequestDto
{
    public QuestionRequestDto()
    {
        documents = new List<DocumentsDto>();
    }
    public string submissionId { get; set; } = default!;
    public List<DocumentsDto> documents { get; set; } 
}