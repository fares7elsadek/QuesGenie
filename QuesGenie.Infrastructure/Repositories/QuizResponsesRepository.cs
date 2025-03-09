using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class QuizResponsesRepository(AppDbContext db):Repository<QuizResponses>(db),IQuizResponsesRepository
{
    
}