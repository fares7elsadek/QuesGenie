using Microsoft.OpenApi.Models;
using QuesGenie.API.Middlewares;
using QuesGenie.Application.Extensions;

namespace QuesGenie.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ErrorHandlingMiddleware>();
        builder.Services.AddControllers();
        builder.Host.SeriLogConfigurations();
        builder.Services.AddAuthorization();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("BearerAuth", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme , Id="BearerAuth"}
                    },
                    []
                }
            });
        });
    }
}