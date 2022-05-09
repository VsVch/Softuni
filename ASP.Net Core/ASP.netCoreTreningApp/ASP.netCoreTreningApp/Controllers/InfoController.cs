using ASP.netCoreTreningApp.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Threading;

namespace ASP.netCoreTreningApp.Controllers
{
    //[AddHeaderActionFilter]
    public class InfoController : Controller
    {
        private readonly ILogger<InfoController> logger;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache cacheService;

        public InfoController(ILogger<InfoController> logger,
            IMemoryCache memoryCache,
            IDistributedCache cacheService)
        {
            this.logger = logger;
            this.memoryCache = memoryCache;
            this.cacheService = cacheService;
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

        public async Task<IActionResult> Date()
        {
            this.logger.LogCritical(12345, "User asked for the time.");

            var dataAsString = await this.cacheService.GetStringAsync("");

            DateTime data;

            if (dataAsString == null)
            {
                data = this.GetDate();

                await this.cacheService.SetStringAsync("DataTimeInfo",JsonConvert.SerializeObject(data));
            }
            else
            {
                data = JsonConvert.DeserializeObject<DateTime>(dataAsString);
            }

            return this.Content(data.ToString());
        }

        private DateTime GetDate()
        {
            Thread.Sleep(5000);
            return DateTime.Now;
        }
    }
}
