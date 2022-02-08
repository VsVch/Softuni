using CarShop.Data;
using System.Linq;

namespace CarShop.Servises
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext data;

        public UserService(ApplicationDbContext data)
        {
            this.data = data;
        }
        public bool IsMechanic(string userId)
        {
            return this.data
               .Users
               .Any(x => x.Id == userId && x.IsMechanic);
        }

        public bool OwnsCar(string userId, string carId)
        {
            return this.data
                   .Cars
                   .Any(c => c.Id == carId && c.OwnerId == userId);
        }
    }
}
