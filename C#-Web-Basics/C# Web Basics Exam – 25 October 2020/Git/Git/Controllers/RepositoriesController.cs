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
        
        public HttpResponse All()
        {          
            var repos = this.data
                .Repositories
                .Where(r => r.IsPublic == true)
                .Select(r => new AllReposotoriesModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    CreatedOn = r.CreatedOn,
                    Owner = this.data.Users.Where(u => u.Id == r.OwnerId).Select(u => u.Username).FirstOrDefault(),
                    CommitsCount = r.Commits.Count(),
                })
                .ToList();

            return View(repos);
        }

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
