using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.Quiz.Dtos;

public class QuizResponseDto
{
    public string QuestionId { get; set; } = default!;
    public SubmitMcqQuestionQuizDto McqQuestion { get; set; } = default!;
    public SubmitMatchingQuestionDto MatchingQuestion { get; set; } = default!;
    public SubmitFillTheBlankQuizDto FillTheBlankQuiz { get; set; } = default!;
    public SubmitTrueFalseQuestionDto TrueFalseQuestion { get; set; } = default!;
    public string UserAnswer { get; set; } = default!;
    public string QuizId { get; set; } = default!;
    public bool IsCorrectAnswer { get; set; }
}