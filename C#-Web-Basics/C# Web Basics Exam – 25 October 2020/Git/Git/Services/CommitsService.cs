using Git.Services.Models.Commits;
using System.Collections.Generic;

using static Git.Data.Constants;


namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        public ICollection<string> ValidateCommitsPropertyes(CreateCommitFormModel model)
        {
            var errors = new List<string>();

            if (model.Description == null || model.Description.Length < CommentDescriptionMinLenght)
            {
                errors.Add($"Discription is not valid. It must be more than {CommentDescriptionMinLenght} symbols.");
            }           

            return errors;
        }
    }
}
