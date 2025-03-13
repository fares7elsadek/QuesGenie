using AutoMapper;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.Dtos.Profiles;

public class MatchingPairsProfile:Profile
{
    public MatchingPairsProfile()
    {
        CreateMap<MatchingPairs, MatchingPairsDto>();
    }
}