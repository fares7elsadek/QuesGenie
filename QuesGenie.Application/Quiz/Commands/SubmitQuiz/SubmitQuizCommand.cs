using MediatR;
using QuesGenie.Application.Quiz.Dtos;

namespace QuesGenie.Application.Quiz.Commands.SubmitQuiz;

public class SubmitQuizCommand:IRequest<SubmitQuizResponseDto>
{
    public string QuizId { get; set; } = default!;
    public List<McqQuizAnswerDto> McqQuizAnswers { get; set; } = default!;
    public List<TrueFalseQuizAnswerDto> TrueFalseQuizAnswers { get; set; } = default!;
    public List<MatchingQuizAnswerDto> MatchingQuizAnswers { get; set; } = default!;
    public List<FillTheBlankQuizAnswerDto> FillTheBlnakAnswers { get; set; } = default!;
}