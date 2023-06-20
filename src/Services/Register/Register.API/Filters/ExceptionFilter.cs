using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Register.API.Filters;

public class ExceptionFilter : IAsyncExceptionFilter
{
    private readonly ILogger<ExceptionFilter> _logger;

    public ExceptionFilter(ILogger<ExceptionFilter> logger)
    {
        _logger = logger;
    }

    public async Task OnExceptionAsync(ExceptionContext context)
    {
        if (context.Exception is UnauthorizedAccessException)
        {
            context.Result = new UnauthorizedResult();
        }
        else if (context.Exception is ArgumentException)
        {
            context.Result = new BadRequestObjectResult(context.Exception.Message);
        }
        else
        {
            context.Result = new JsonResult(new { error = "Ocorreu um erro durante o processamento." });
        }

        _logger.LogError(context.Exception, "Erro durante a execução da ação.");

        await Task.CompletedTask;
    }
}

