namespace FootballManager.Services
{
    public interface IPasswordHasher
    {
        string HashPasword(string password);
    }
}
