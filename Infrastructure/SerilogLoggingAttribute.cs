using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace HospitalApp.Infrastructure;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class SerilogLoggingAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var query = context.HttpContext.Request.QueryString.Value;
        var path = context.HttpContext.Request.Path;

        Log.Information("{path}{query}", path, query);
    }
}
