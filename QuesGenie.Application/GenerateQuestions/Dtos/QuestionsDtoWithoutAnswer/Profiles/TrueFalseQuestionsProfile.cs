using AutoMapper;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.Dtos.Profiles;

public class TrueFalseQuestionsProfile:Profile
{
    public TrueFalseQuestionsProfile()
    {
        CreateMap<TrueFalseQuestions, TrueFalseQuestionsDto>();
    }
}