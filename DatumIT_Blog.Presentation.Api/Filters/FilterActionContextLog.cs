using Microsoft.AspNetCore.Mvc.Filters;

namespace DatumIT_Blog.Presentation.Api.Filters;

public class FilterActionContextLog : IAsyncActionFilter
{
    private readonly ILogger<FilterActionContextLog> _logger;

    public FilterActionContextLog(ILogger<FilterActionContextLog> logger)
    {
        _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _logger.LogInformation("### -> OnActionExecuted");
        _logger.LogInformation("###################################################");
        _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
        _logger.LogInformation("###################################################");

        await next();

        _logger.LogInformation("### -> OnActionExecuting");
        _logger.LogInformation("###################################################");
        _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
        _logger.LogInformation($"ModelState : {context.ModelState.IsValid}");
        _logger.LogInformation("###################################################");
    }
}