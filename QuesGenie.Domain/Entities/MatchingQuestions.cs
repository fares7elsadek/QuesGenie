using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace QuesGenie.Domain.Entities;

public class MatchingQuestions:Questions
{
    public MatchingQuestions()
    {
        MatchingPairs = new HashSet<MatchingPairs>();
    }
    public ICollection<MatchingPairs> MatchingPairs { get; set; }
}