using AutoMapper;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer.Profiles;

public class TrueFalseAnswerProfile:Profile
{
    public TrueFalseAnswerProfile()
    {
        CreateMap<TrueFalseQuestions, TrueFalseAnswerDto>();
    }
}