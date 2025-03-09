using QuesGenie.API.Extensions;
using QuesGenie.API.Middlewares;
using QuesGenie.Application.Extensions;
using QuesGenie.Domain.Extensions;
using QuesGenie.Infrastructure.Extensions;
using QuesGenie.Infrastructure.Seeders;
using Serilog;

try
{

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddOpenApi();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddDomain(builder.Configuration);
    builder.AddPresentation();
    builder.Services.AddApplication();
    builder.Services.AddEndpointsApiExplorer();
    

    var app = builder.Build();
    app.UseErrorHandlingMiddleware();
    await SeedDatabaseAsync(app);
    
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    app.UseHttpsRedirection();
    app.UseCors("QuesGenie");
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.UseSerilogRequestLogging();

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Log.Fatal(ex.Message, "Aplication startup failed");
}
finally
{
    Log.CloseAndFlush();
}


async Task SeedDatabaseAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<IQuesGenieSeeder>();
    await seeder.Seed();
}