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
        public HttpResponse Create(CreateCommitFormModel model)
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
                CreatorId = this.User.Id,
            };

            this.data.Commits.Add(commit);

            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var commits = this.data
                .Commits
                .Where(c => c.CreatorId == this.User.Id)
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new CommitListingViewModel
                {
                    Id = c.Id,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToString("F"),
                    Repository = c.Repository.Name,
                })
                .ToList();

            return View(commits);
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var commit = this.data.Commits.Find(id);

            if (commit == null || commit.CreatorId != this.User.Id)
            {
                return BadRequest();
            }

            this.data.Commits.Remove(commit);

            this.data.SaveChanges();

            return Redirect("/Commits/All");
        }
    }
}
