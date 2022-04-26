using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP.netCoreTreningApp.Filters
{
    public class MyExeptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
        }
    }
}
