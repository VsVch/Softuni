
namespace CarShop.Servises
{
    public interface IUserService
    {
        bool IsMechanic(string userId);

        bool OwnsCar(string userid, string carId);
    }
}
