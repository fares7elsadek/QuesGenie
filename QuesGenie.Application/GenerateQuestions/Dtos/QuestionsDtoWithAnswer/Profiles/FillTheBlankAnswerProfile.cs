using AutoMapper;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer.Profiles;

public class FillTheBlankAnswerProfile:Profile
{
    public FillTheBlankAnswerProfile()
    {
        CreateMap<FillTheBlankQuestions, FillTheBlankAnswerDto>();
    }
}