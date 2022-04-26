using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP.netCoreTreningApp.Filters
{
    public class MyResultFilterAtribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
        }        
    }
}
