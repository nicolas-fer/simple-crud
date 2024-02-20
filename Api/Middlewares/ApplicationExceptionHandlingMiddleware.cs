using Application;
using Microsoft.AspNetCore.Mvc;

namespace TesteStef.Middlewares;

public class ApplicationExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ApplicationExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ApplicationValidationException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "ErroValidacao",
                Title = "Erro de validação",
                Detail = "um ou mais erros de validação ocorreram"
            };

            if (exception?.Errors is not null)
            {
                problemDetails.Extensions["errors"] = exception.Errors;
            }

            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}