using Git.Data;
using Git.Data.Models;
using Git.Services;
using Git.Services.Models.Commits;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Linq;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commits;
        private readonly ApplicationDbContext data;

        public CommitsController(ICommitsService commits, ApplicationDbContext data)
        {
            this.commits = commits;
            this.data = data;
        }

        [Authorize]
        public HttpResponse Create(string id) 
        {
            var repository = this.data
                .Repositories
                .Where(x => x.Id == id)
                .Select(x => new AddCommitViewModel 
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .FirstOrDefault();

            if (repository == null)
            {
                return BadRequest();
            }

            return View(repository);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create (CommitCreateFormModel model) 
        { 
            var errors = commits.ValidateCommitsPropertyes(model);

            if (errors.Any())
            {
                Error(errors);
            }

            if (!this.data.Repositories.Any(x => x.Id == model.Id))
            {
                return NotFound();
            }

            var commit = new Commit
            {
                RepositoryId = model.Id,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
            };

            this.data.Commits.Add(commit);

            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }
    }
}
