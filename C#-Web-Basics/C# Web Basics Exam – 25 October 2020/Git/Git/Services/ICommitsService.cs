using Git.Services.Models.Commits;
using System.Collections.Generic;

namespace Git.Services
{
    public interface ICommitsService
    {
        ICollection<string> ValidateCommitsPropertyes(CommitCreateFormModel model);
    }
}
