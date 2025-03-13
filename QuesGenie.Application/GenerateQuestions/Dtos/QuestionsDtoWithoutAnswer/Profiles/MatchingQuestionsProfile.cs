using AutoMapper;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.Dtos.Profiles;

public class MatchingQuestionsProfile:Profile
{
    public MatchingQuestionsProfile()
    {
        Random rng = new Random();
        CreateMap<MatchingQuestions, MatchingQuestionsDto>()
            .ForMember(x => x.LeftPairs, opt =>
            {
                opt.MapFrom(x => 
                    x.MatchingPairs.Select(x => x.LeftSide).OrderBy(_ => rng.Next()).ToList());
            })
            .ForMember(x => x.RightPairs, opt =>
            {
                opt.MapFrom(x => 
                    x.MatchingPairs.Select(x => x.RightSide).OrderBy(_ => rng.Next()).ToList());
            });
    }
}