using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class McqQuestiosnsRepository(AppDbContext db):Repository<McqQuestions>(db),IMcqQuestionsRepository
{
    
}