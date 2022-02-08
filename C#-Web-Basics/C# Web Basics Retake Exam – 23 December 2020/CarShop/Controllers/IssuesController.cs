using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Servises;
using CarShop.ViewModels.Issues;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IUserService users;
        private readonly IValidator validator;

        public IssuesController(
            ApplicationDbContext data,
            IUserService userService,
            IValidator validator)
        {
            this.data = data;
            this.users = userService;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            var userIsMechanic = this.users.IsMechanic(this.User.Id);

            if (!UserCanAccessCar(carId))
            {
                return Unauthorized();
            }

            var carIssues = this.data
                 .Cars
                 .Where(i => i.Id == carId)
                 .Select(c => new CarIssuesViewModel
                 {
                     Id = c.Id,
                     Model = c.Model,
                     Year = c.Year,
                     UserIsMechanic = userIsMechanic,                     
                     Issues = c.Issues.Select(i => new IssueListingViewModel
                     {
                         Id = i.Id,
                         Description = i.Description,
                         IsFixed = i.IsFixed,
                         IsFixedInformation = i.IsFixed ? "Yes" : "Not Yet"
                     })
                 })
                 .FirstOrDefault();

            if (carIssues == null)
            {
                return NotFound();
            }

            return View(carIssues);
        }

        [Authorize]
        public HttpResponse Add(string carId)
        {

            return View(new AddIssueViewModel
            {
                CarId = carId
            });
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddIssueFormModel model)
        {
            if (!UserCanAccessCar(model.CarId))
            {
                return Unauthorized();
            }

            var errors = validator.ValidateIssue(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            var issue = new Issue
            {
                Description = model.Description,
                CarId = model.CarId,
                IsFixed = false,
            };

            data.Issues.Add(issue);

            data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={model.CarId}");
        }

        [Authorize]
        public HttpResponse Fix(string issueId, string carId)
        {
            var userIsMechanic = this.users.IsMechanic(this.User.Id);

            if (!userIsMechanic)
            {
                Unauthorized();
            }

            var currIssue =this.data
                               .Issues
                               .Find(issueId);

            currIssue.IsFixed = true;

            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            if (!UserCanAccessCar(carId))
            {
                return Unauthorized();
            }

            var currIssue = this.data
                              .Issues
                              .Find(issueId);

            this.data.Remove(currIssue);

            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        private bool UserCanAccessCar(string carid)
        {
            var userIsMechanic = this.users.IsMechanic(this.User.Id);

            if (!userIsMechanic)
            {
                var usersOwnsCar = users.OwnsCar(this.User.Id, carid);

                if (!usersOwnsCar)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
