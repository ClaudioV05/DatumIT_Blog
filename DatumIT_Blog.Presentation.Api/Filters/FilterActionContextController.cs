using Microsoft.AspNetCore.Mvc.Filters;

namespace DatumIT_Blog.Presentation.Api.Filters;

public class FilterActionContextController : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        await next();
    }
}