using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class AnswersRepository(AppDbContext db):Repository<Answers>(db), IAnswersRepository
{
    
}