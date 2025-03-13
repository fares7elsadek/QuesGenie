using AutoMapper;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.Dtos.Profiles;

public class McqOptionsProfile:Profile
{
    public McqOptionsProfile()
    {
        CreateMap<McqOptions, McqOptionsDto>()
            ;
    }
}