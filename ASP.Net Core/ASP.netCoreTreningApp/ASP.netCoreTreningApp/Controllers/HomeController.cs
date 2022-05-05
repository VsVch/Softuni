using ASP.netCoreTreningApp.Data;
using ASP.netCoreTreningApp.Models;
using ASP.netCoreTreningApp.Models.Privacy;
using ASP.netCoreTreningApp.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.netCoreTreningApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext data;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IConfiguration configuration;
        private readonly IInstanceCounter instanceCounter;

        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext data,
            IWebHostEnvironment hostEnvironment,
            IConfiguration configuration,
            IInstanceCounter instanceCounter)
        {
            _logger = logger;
            this.data = data;
            this.hostEnvironment = hostEnvironment;
            this.configuration = configuration;
            this.instanceCounter = instanceCounter;
        }

        public IActionResult AjaxDemo()
        {
            return this.View();
        }

        public IActionResult AjaxDemoData()
        {
           return this.Json(new[]
            {
                new {Name = "Lubo", Data = DateTime.UtcNow.AddDays(2).ToString("O")},
                new {Name = "Misho", Data = DateTime.UtcNow.AddDays(3).ToString("O")},
            });            
        }
        
        
        public IActionResult GetData(string info)
        {
            return this.Content(info);
        }

        public IActionResult Index()
        {
            var count = this.data.Users.Count();

            var environment = hostEnvironment.EnvironmentName;

            this.ViewData["Year"] = 2022;
            this.ViewData["Name"] = "<script>alert('Hacked!!!')</script>";
            this.ViewData["Count"] = count;
            this.ViewData["Environment"] = environment;

            this.ViewBag.UsersCount = count;
            this.ViewBag.Calc = new Func<int>(() => 3);

            return View();
        }

        public IActionResult StatusCodeError(int errorCode)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var model = new PrivacyFormModel();

            model.FirstName = "Sand";
            model.LastName = "Stef";
            model.Age = 40;
            model.Description = "Test test test test";

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}