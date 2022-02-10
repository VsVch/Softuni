using Git.Data;
using Git.Data.Models;
using Git.Services;
using Git.Services.Models.Repository;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Linq;

using static Git.Data.Constants;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IRepositoriesService service;

        public RepositoriesController(ApplicationDbContext data, IRepositoriesService service)
        {
            this.data = data;
            this.service = service;
        }

        [Authorize]
        public HttpResponse All() => View();

        [Authorize]
        public HttpResponse Create() => View();


        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateFormModel model) 
        {
            var errors = service.ValidateRepositoriesPropertyes(model);

            if (errors.Any())
            { 
                return Error(errors);
            }

            var repository = new Repository
            {
                Name = model.Name,
                CreatedOn = DateTime.UtcNow,
                OwnerId = this.User.Id,
                IsPublic = model.RepositoryType == RepositoryPublicStatus ? true : false,
            };

            this.data.Repositories.Add(repository);

            this.data.SaveChanges();

            return View("/Repositories/All");
        }
    }
}
