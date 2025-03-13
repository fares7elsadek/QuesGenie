namespace QuesGenie.Application.GenerateQuestions.Dtos;

public class GetQuestionsBySumissionIdDto
{
    public GetQuestionsBySumissionIdDto()
    {
        QuestionSets = new HashSet<GetQuestionSetDto>();
    }
    public string SubmissionId { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public DateTime SubmissionDate { get; set; } 
    public string? SampleQuestions { get; set; } 
    public ICollection<GetQuestionSetDto> QuestionSets { get; set; }
}