using AutoMapper;
using QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.Dtos.GenerateQuestions.Profiles;

public class GenerateQuestionsMatchingPairsProfile:Profile
{
    public GenerateQuestionsMatchingPairsProfile()
    {
        CreateMap<MatchingPairs, GenerateQuestionsMatchingPairsDto>()
            .ForMember(x => x.leftSide,
                opt => 
                    opt.MapFrom(src => src.LeftSide)).ForMember(x => x.rightSide,
                opt => 
                    opt.MapFrom(src => src.RightSide)).ReverseMap();
    }
}