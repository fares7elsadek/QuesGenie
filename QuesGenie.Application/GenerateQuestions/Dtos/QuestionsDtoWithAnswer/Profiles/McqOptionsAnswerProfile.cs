using AutoMapper;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer.Profiles;

public class McqOptionsAnswerProfile:Profile
{
    public McqOptionsAnswerProfile()
    {
        CreateMap<McqOptions, McqOptionsAnswerDto>();
    }
}