using AutoMapper;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.Dtos.Profiles;

public class McqQuestionsProfile:Profile
{
    public McqQuestionsProfile()
    {
        CreateMap<McqQuestions, McqQuestionsDto>()
            .ForMember(dest => dest.McqOptions, opt =>
            {
                opt.MapFrom(src => src.McqOptions);
            });
    }
}