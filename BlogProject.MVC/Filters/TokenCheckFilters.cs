using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class TokenCheckFilter : IAsyncActionFilter
{
    private static readonly HashSet<string> ExcludedActions = new HashSet<string>
    {
        "Account/Login",
        "Account/Register",
    };
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var controller = context.RouteData.Values["controller"]?.ToString();
        var action = context.RouteData.Values["action"]?.ToString();
        var actionPath = $"{controller}/{action}";

        if (ExcludedActions.Contains(actionPath))
        {
            await next();
            return;
        }

        var token = context.HttpContext.Session.GetString("UserToken");
        if (string.IsNullOrEmpty(token))
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
            return;
        }

        await next();
    }
}
