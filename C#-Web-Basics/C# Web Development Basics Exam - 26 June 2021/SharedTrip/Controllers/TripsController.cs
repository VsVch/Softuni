using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Models;
using SharedTrip.Service;
using SharedTrip.ViewModels.Trips;
using System;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidatorService validator;
        private readonly IPasswordHasher passwordHasher;

        public TripsController(ApplicationDbContext data,
            IValidatorService validator,
            IPasswordHasher passwordHasher)
        {
            this.data = data;
            this.validator = validator;
            this.passwordHasher = passwordHasher;
        }

        [Authorize]
        public HttpResponse All()
        {
            var trips = this.data
                .Trips
                .OrderByDescending(t => t.DepartureTime)
                .Select(t => new AllTripsViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats,
                })
                .ToList();

            return View(trips);
        }

        [Authorize]
        public HttpResponse Add() => View();     
         
        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddTripsFormModel model)
        {
           var errors = validator.TripsValidator(model);

            var isDateValid = DateTime.TryParseExact(
               model.DepartureTime,
               "dd.MM.yyyy HH:mm",
               CultureInfo.InvariantCulture,
               DateTimeStyles.None, out var departureTime);

            if (!isDateValid)
            {
                errors.Add($"{model.DepartureTime} is ivalid data format.");
            }

            if (errors.Any()) 
            {
               return Redirect("/Trips/Add");
            }           

            var trip = new Trip 
            {                 
                Description = model.Description,
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = departureTime,
                ImagePath = model.ImagePath,
                Seats = model.Seats,
            };

            this.data.Trips.Add(trip);

            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var currTrip = FindTrip(tripId);

            if (currTrip == null)
            { 
                return NotFound();
            }

            return View(currTrip);
        }        

        [Authorize]        
        public HttpResponse AddUserToTrip(string tripId)
        {
            var currTrip = FindTrip(tripId);

            var isThisUserSignInTrip = CheckForUserInCurrentTrip(tripId);

            if (isThisUserSignInTrip || currTrip.Seats == 0)
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            if (currTrip == null)
            {
                return NotFound();
            }            

            this.data.UserTrips.Add(new UserTrip { TripId = tripId, UserId = User.Id });

            currTrip.Seats = currTrip.Seats - 1;          

            this.data.SaveChanges();

            return Redirect("/");
        }

        private bool CheckForUserInCurrentTrip(string tripId)
            =>  this.data
                .UserTrips
                .Any(ut => ut.UserId == User.Id && ut.TripId == tripId);       
       
        private Trip FindTrip(string id) 
            => this.data.Trips.Find(id);
        
    }
}
