using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class DocumentRepository(AppDbContext db):Repository<Documents>(db),IDocumentRepository
{
    
}