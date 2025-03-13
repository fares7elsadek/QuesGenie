using AutoMapper;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer.Profiles;

public class MatchingPairsAnswerProfile:Profile
{
    public MatchingPairsAnswerProfile()
    {
        CreateMap<MatchingPairs, MatchingPairsAnswerDto>();
    }
}