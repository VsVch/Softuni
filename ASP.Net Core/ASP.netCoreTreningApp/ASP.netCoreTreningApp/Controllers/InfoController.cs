using ASP.netCoreTreningApp.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;

namespace ASP.netCoreTreningApp.Controllers
{
    //[AddHeaderActionFilter]
    public class InfoController : Controller
    {
        private readonly ILogger<InfoController> logger;
        private readonly IMemoryCache memoryCache;

        public InfoController(ILogger<InfoController> logger, IMemoryCache memoryCache)
        {
            this.logger = logger;
            this.memoryCache = memoryCache;
        }

        //[AddHeaderActionFilter]
        public IActionResult Time()
        {
            this.logger.LogCritical(12345, "User asked for the time.");

            if (!memoryCache.TryGetValue<DateTime>("Data", out var cacheTime))
            {
                cacheTime = GetDate();
                memoryCache.Set("Data", cacheTime, TimeSpan.FromSeconds(20));
            }           

            return this.Content(
                DateTime.Now.ToLongTimeString() + " -- Cache: " + cacheTime);
        }

        public IActionResult Date()
        {
            this.logger.LogCritical(12345, "User asked for the time.");

            return this.Content(DateTime.Now.ToLongDateString());
        }

        private DateTime GetDate()
        {
            Thread.Sleep(5000);
            return DateTime.Now;
        }
    }
}
