using AutoMapper;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.Quiz.Dtos.Profiles;

public class QuestionProfile:Profile
{
    public QuestionProfile()
    {
        CreateMap<FillTheBlankQuestions, SubmitFillTheBlankQuizDto>();
        
        CreateMap<MatchingQuestions,SubmitMatchingQuestionDto>().ForMember(x => x.MatchingPairs,
            opt => opt.MapFrom(x => x.MatchingPairs));
        
        CreateMap<MatchingPairs, SubmitMatchingPairsQuizDto>();
        
        CreateMap<McqQuestions, SubmitMcqQuestionQuizDto>().ForMember(x => x.McqOptions,
            opt => opt.MapFrom(x => x.McqOptions));
        
        CreateMap<McqOptions, SubmitMcqOptionsQuizDto>();
        
        CreateMap<TrueFalseQuestions, SubmitTrueFalseQuestionDto>();
    }
}