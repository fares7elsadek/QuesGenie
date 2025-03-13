namespace QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;

public class GetQuestionsBySubmissionIdWithAnswerDto
{
    public GetQuestionsBySubmissionIdWithAnswerDto()
    {
        QuestionSets = new HashSet<GetQuestionSetAnswerDto>();
    }
    public string SubmissionId { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public DateTime SubmissionDate { get; set; } 
    public string? SampleQuestions { get; set; } 
    public ICollection<GetQuestionSetAnswerDto> QuestionSets { get; set; }
}