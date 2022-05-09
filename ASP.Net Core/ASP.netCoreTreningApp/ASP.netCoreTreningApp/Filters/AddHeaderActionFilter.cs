using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP.netCoreTreningApp.Filters
{
    public class AddHeaderActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //context.HttpContext.Response.Headers.Add(
            //    "X-Info-Action-Name", context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //context.HttpContext.Response.Headers.Add(
            //    "X-Info-Result-Type", context.Result.GetType().Name);
        }
    }

    //public class AddHeaderActionFilter : ActionFilterAttribute
    //{
    //    //public override void OnActionExecuting(ActionExecutingContext context)
    //    //{
    //    //    context.HttpContext.Response.Headers.Add(
    //    //        "X-Info-Action-Name", context.ActionDescriptor.DisplayName);
    //    //}

    //    //public override void OnActionExecuted(ActionExecutedContext context)
    //    //{
    //    //    context.HttpContext.Response.Headers.Add(
    //    //        "X-Info-Result-Type", context.Result.GetType().Name);
    //    //}

    //    //public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    //    //{
    //    //    if (true)
    //    //    {
    //    //        next();
    //    //    }
    //    //}
    //}
}
