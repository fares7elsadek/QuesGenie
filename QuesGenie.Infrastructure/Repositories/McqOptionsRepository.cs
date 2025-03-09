using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class McqOptionsRepository(AppDbContext db):Repository<McqOptions>(db),IMcqOptionsRepository
{
    
}