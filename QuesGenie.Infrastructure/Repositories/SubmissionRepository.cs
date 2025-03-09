using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class SubmissionRepository(AppDbContext db):Repository<Submissions>(db),ISubmissionRepository
{
    
}