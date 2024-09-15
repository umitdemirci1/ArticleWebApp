using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class TokenCheckFilter : ActionFilterAttribute
{
    private static readonly HashSet<string> ExcludedActions = new HashSet<string>
    {
        "Account/Login",
        "Account/Register",
    };
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var controller = context.RouteData.Values["controller"]?.ToString();
        var action = context.RouteData.Values["action"]?.ToString();
        var actionPath = $"{controller}/{action}";

        if (ExcludedActions.Contains(actionPath))
        {
            base.OnActionExecuting(context);
            return;
        }

        var token = context.HttpContext.Request.Cookies["UserToken"];
        if (string.IsNullOrEmpty(token))
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
        }
        base.OnActionExecuting(context);
    }
}
