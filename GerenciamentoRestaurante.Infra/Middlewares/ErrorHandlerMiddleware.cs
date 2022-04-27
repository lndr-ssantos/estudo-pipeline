using GerenciamentoRestaurante.Shared.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace GerenciamentoRestaurante.Infra.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _request;

    public ErrorHandlerMiddleware(RequestDelegate request)
    {
        _request = request;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _request.Invoke(httpContext);
        }
        catch (BusinessException e)
        {
            httpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
            await httpContext.Response.WriteAsJsonAsync(new {e.Message});
        }
        catch (Exception e)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(new {Message = $"{e.Message} Contate o administrador"});
        }
    }
}

public static class ErrorHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlerMiddleware>();
    }
}