using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP.netCoreTreningApp.Filters
{
    public class MyResurceFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
