using AutoMapper;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer.Profiles;

public class MatchingAnswerProfile:Profile
{
    public MatchingAnswerProfile()
    {
        CreateMap<MatchingQuestions, MatchingQuestionsAnswerDto>()
            .ForMember(x => x.MatchingPairs, opt =>
            {
                opt.MapFrom(x => x.MatchingPairs);
            });
    }
}