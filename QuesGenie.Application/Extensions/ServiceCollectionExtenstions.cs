using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuesGenie.Application.Services.AuthService;
using QuesGenie.Application.Services.Email;
using QuesGenie.Application.Services.Files;
using QuesGenie.Application.Services.Pdf;
using QuesGenie.Application.Services.User;
using QuesGenie.Domain.Entities;
using Serilog;

namespace QuesGenie.Application.Extensions;

public static class ServiceCollectionExtenstions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService,AuthService>();
        services.AddScoped<IEmailSender<ApplicationUser>,EmailService>();
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddFluentValidationAutoValidation();
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        
        services.AddHttpContextAccessor();
        
        services.AddCors(options =>
        {
            options.AddPolicy("QuesGenie", policy =>
            {
                policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed(origin => true);
            });
        });

        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IUserContext, UserContext>();
        services.AddHttpContextAccessor();
        services.AddScoped<IPdfService, PdfService>();
    }
    
    public static void SeriLogConfigurations(this IHostBuilder host)
    {
        host.UseSerilog((context , loggerConfig) =>
        {
            loggerConfig.ReadFrom.Configuration(context.Configuration);
        });
    }
}