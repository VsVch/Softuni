using Git.Services.Models.Repository;
using System.Collections.Generic;

using static Git.Data.Constants;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        public ICollection<string> ValidateRepositoriesPropertyes(CreateFormModel model)
        {

            var errors = new List<string>();

            if (model.Name == null ||
                model.Name.Length < RepositoryMinLenght ||
                model.Name.Length > RepositoryMaxLenght)
            {
                errors.Add($"Repository name '{model.Name}' is not valid. It must be between {RepositoryMinLenght} and {RepositoryMaxLenght}.");
            }

            if (model.RepositoryType == null || model.RepositoryType != RepositoryPrivateStatus)
            {
                if (model.RepositoryType != RepositoryPublicStatus)
                {
                    errors.Add($"Repository type '{model.RepositoryType}' is not valid type.");
                }             
            }

            return errors;

        }
    }
}
