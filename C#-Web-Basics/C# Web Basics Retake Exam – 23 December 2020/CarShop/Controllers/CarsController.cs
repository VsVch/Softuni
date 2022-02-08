using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Servises;
using CarShop.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;
        private readonly IUserService user;

        public CarsController(
            ApplicationDbContext data,
            IValidator validator,
            IUserService userService)
        {
            this.data = data;
            this.validator = validator;
            this.user = userService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var carsQuery = this.data
                .Cars
                .AsQueryable();

            if (user.IsMechanic(this.User.Id))
            {
                carsQuery = carsQuery
                    .Where(c => c.Issues.Any(i => !i.IsFixed));
            }
            else
            {
                carsQuery = carsQuery
                    .Where(c => c.OwnerId == this.User.Id);
            }

            var cars = carsQuery
                .Select(c => new AllCarsModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    PlateNumber = c.PlateNumber,
                    Image = c.PictureUrl,
                    RemainingIssues = c.Issues.Count(x => !x.IsFixed),
                    FixedIssues = c.Issues.Count(x => !x.IsFixed),
                })
                .ToList();

            return View(cars);
        }

        [Authorize]
        public HttpResponse Add()
        {         

            if (user.IsMechanic(this.User.Id))
            {
                return Error("Mechanics cannot add cars.");
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddCarsFormModel model)
        {
            var errors = validator.CarsValidator(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            var car = new Car
            {
                Model = model.Model,
                Year = model.Year,
                PlateNumber = model.PlateNumber,
                PictureUrl = model.Image,
                OwnerId = this.User.Id
            };

            data.Cars.Add(car);

            data.SaveChanges();

            return Redirect("/Cars/All");
        }

        
    }
}
