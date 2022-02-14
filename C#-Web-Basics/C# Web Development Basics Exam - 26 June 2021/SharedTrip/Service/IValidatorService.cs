using SharedTrip.ViewModels.Trips;
using SharedTrip.ViewModels.User;
using System.Collections.Generic;

namespace SharedTrip.Service
{
    public interface IValidatorService
    {
        ICollection<string> RegisterValidator(RegesterFormModel model);

        ICollection<string> TripsValidator(AddTripsFormModel model);
    }
}
