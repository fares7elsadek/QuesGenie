using QuesGenie.Application.GenerateQuestions.Dtos;

namespace QuesGenie.Application.Services.SyncCommunication;

public interface IQuestionHttpClient
{
    Task GenerateQuestion(QuestionRequestDto dto);
}