namespace SharedTrip.Service
{
    public interface IPasswordHasher
    {
        string HashPasword(string password);
    }
}
