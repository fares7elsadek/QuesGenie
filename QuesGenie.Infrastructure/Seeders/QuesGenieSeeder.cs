using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuesGenie.Domain.Helpers;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Seeders;

public class QuesGenieSeeder(AppDbContext db):IQuesGenieSeeder
{
    public async Task Seed()
    {
        if (db.Database.GetPendingMigrations().Any())
        {
            await db.Database.MigrateAsync();
        }

        if (await db.Database.CanConnectAsync())
        {
            if (!db.Roles.Any())
            {
                db.Roles.AddRange(GetRoles);
                await db.SaveChangesAsync();
            }
        }
    }

    public IEnumerable<IdentityRole> GetRoles =>
    [
        new IdentityRole { Name = UserRoles.ADMIN, NormalizedName = UserRoles.ADMIN.ToUpper() },
        new IdentityRole { Name = UserRoles.USER, NormalizedName = UserRoles.USER.ToUpper() }
    ];

}