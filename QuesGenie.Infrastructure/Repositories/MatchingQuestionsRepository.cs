using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class MatchingQuestionsRepository(AppDbContext db):Repository<MatchingQuestions>(db),IMatchingQuestionsRepository
{
    
}