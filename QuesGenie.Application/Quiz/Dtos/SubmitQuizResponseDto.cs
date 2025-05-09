namespace QuesGenie.Application.Quiz.Dtos;

public class SubmitQuizResponseDto
{
    public SubmitQuizResponseDto()
    {
        QuizResponses = new List<QuizResponseDto>();
    }
    public string QuizId { get; set; } = default!;
    public double Score { get; set; }
    public string Message { get; set; } = "Quiz submitted successfully.";
    public List<QuizResponseDto> QuizResponses { get; set; } 
}