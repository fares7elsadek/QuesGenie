using AutoMapper;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.Dtos.Profiles;

public class FillTheblankProfile:Profile
{
    public FillTheblankProfile()
    {
        CreateMap<FillTheBlankQuestions, FillTheBlankDto>();
    }
}