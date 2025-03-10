using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class TrueFalseQuestionsRepository(AppDbContext db):Repository<TrueFalseQuestions>(db),ITrueFalseRepository
{
    
}