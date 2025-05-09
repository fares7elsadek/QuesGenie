using AutoMapper;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.Quiz.Dtos.Profiles;

public class QuizResponseProfile:Profile
{
    public QuizResponseProfile()
    {
        CreateMap<QuizResponses, QuizResponseDto>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}