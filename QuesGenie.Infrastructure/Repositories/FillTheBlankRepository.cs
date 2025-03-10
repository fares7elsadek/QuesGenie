using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class FillTheBlankRepository(AppDbContext db):Repository<FillTheBlankQuestions>(db),IFillTheBlankQuestionsRepsitory
{
    
}