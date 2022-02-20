using FootballManager.ViewModels.Players;
using FootballManager.ViewModels.Users;

using System.Collections.Generic;

namespace FootballManager.Services
{
    public interface IValidator
    {
        ICollection<string> RegisterValidator(RegesterFormModel model);

        ICollection<string> PlayerValidator(AddPlayerFormModel model, string userId);
    }
}
