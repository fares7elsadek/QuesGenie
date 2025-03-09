using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuesGenie.Domain.Helpers;

namespace QuesGenie.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDomain(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("JWT"));
        services.Configure<EmailOptions>(configuration.GetSection("email"));
    }
}