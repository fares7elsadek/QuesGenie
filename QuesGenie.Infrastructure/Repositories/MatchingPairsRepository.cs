using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class MatchingPairsRepository(AppDbContext db):Repository<MatchingPairs>(db),IMatchingPairsRepository
{
    
}