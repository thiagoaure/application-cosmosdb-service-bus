using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Register.API.Filters;

public class ActionFilter : IAsyncActionFilter
{
    private readonly ILogger<ActionFilter> _logger;
    private Stopwatch _stopwatch;

    public ActionFilter(ILogger<ActionFilter> logger, Stopwatch stopwatch)
    {
        _logger = logger;
        _stopwatch = stopwatch;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _stopwatch = Stopwatch.StartNew();

        await next();

        _stopwatch.Stop();

        _logger.LogInformation($"Acao executada em {_stopwatch.ElapsedMilliseconds} ms.");
    }
}