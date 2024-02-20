using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Bahaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling {Name}, Request: {Request}", typeof(TRequest).Name, JsonSerializer.Serialize(request));
        var response = await next();
        _logger.LogInformation("Handled {Name}, Response: {Response}", typeof(TRequest).Name, JsonSerializer.Serialize(response));

        return response;
    }
}