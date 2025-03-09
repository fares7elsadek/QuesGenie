using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class QuestionsSetRepository(AppDbContext db):Repository<QuestionsSets>(db),IQuestionSetRepository
{
    
}