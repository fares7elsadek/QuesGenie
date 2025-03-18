using QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;

namespace QuesGenie.Application.Services.Pdf;

public interface IPdfService
{
    byte[] GenerateQuestionsPdf(GetQuestionsBySubmissionIdWithAnswerDto dto);
}