using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class QuizzesRepository(AppDbContext db):Repository<Quizzes>(db),IQuizzesRepository
{
    
}