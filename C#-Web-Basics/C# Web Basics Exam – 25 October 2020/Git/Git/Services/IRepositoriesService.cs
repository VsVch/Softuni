using Git.Services.Models.Repository;
using System.Collections.Generic;


namespace Git.Services
{
    public interface IRepositoriesService
    {
        ICollection<string> ValidateRepositoriesPropertyes(CreateFormModel model);
    }
}
