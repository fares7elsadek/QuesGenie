using AutoMapper;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.Dtos.GenerateQuestions.Profiles;

public class GenerateQuestionsMatchingProfile:Profile
{
    public GenerateQuestionsMatchingProfile()
    {
        CreateMap<MatchingQuestions, GenerateQuestionsMatchingDto>()
            .ForMember(x => x.matchingPairs, opt =>
            {
                opt.MapFrom(x => x.MatchingPairs);
            }).ForMember(x => x.pageRange, opt =>
            {
                opt.MapFrom(x => x.PageRange);
            }).ForMember(x => x.context, opt =>
            {
                opt.MapFrom(x => x.Context);
            }).ReverseMap();
    }
}