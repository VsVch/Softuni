using Git.Services.Models.Commits;
using System.Collections.Generic;

using static Git.Data.Constants;


namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        public ICollection<string> ValidateCommitsPropertyes(CommitCreateFormModel model)
        {
            var errors = new List<string>();

            if (model.Description == null || model.Description.Length < CommentDescriptionMinLenght)
            {
                errors.Add($"Discription is not valid. It must be more than {CommentDescriptionMinLenght} symbols.");
            }           

            return errors;
        }
    }

//    •	Has an Id – a string, Primary Key
//•	Has a Description – a string with min length 5 (required)
//•	Has a CreatedOn – a datetime(required)
//•	Has a CreatorId – a string
//•	Has Creator – a User object
//•	Has RepositoryId – a string
//•	Has Repository– a Repository object

}
