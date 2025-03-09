using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class ApplicationUserRepository(AppDbContext db):Repository<ApplicationUser>(db),IApplicationUserRepository
{
    
}