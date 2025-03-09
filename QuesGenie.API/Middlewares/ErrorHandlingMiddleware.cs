using System.Net;
using QuesGenie.Domain.Exceptions;
using QuesGenie.Domain.Helpers;
using Serilog;

namespace QuesGenie.API.Middlewares;

public class ErrorHandlingMiddleware:IMiddleware
{
    private ApiResponse apiResponse;
    public ErrorHandlingMiddleware()
    {
        apiResponse = new ApiResponse();
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException ex)
        {
            apiResponse.StatusCode = HttpStatusCode.NotFound;
            apiResponse.IsSuccess = false;
            apiResponse.Errors.Add(ex.Message);
            context.Response.StatusCode = 404;
            await context.Response.WriteAsJsonAsync(apiResponse);
            Log.Warning(ex.Message);
        }
        catch(CustomException ex)
        {
            apiResponse.StatusCode = HttpStatusCode.Forbidden;
            apiResponse.IsSuccess = false;
            apiResponse.Errors.Add(ex.Message);
            context.Response.StatusCode = 403;
            await context.Response.WriteAsJsonAsync(apiResponse);
            Log.Warning(ex.Message);
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, ex.Message);
            apiResponse.StatusCode = HttpStatusCode.InternalServerError;
            apiResponse.IsSuccess = false;
            apiResponse.Errors.Add("Something went wrong");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(apiResponse);
        }
    }

    
}

public static class ErrorHandlingMiddlewareExtensions
{
    public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlingMiddleware>();
    }
}