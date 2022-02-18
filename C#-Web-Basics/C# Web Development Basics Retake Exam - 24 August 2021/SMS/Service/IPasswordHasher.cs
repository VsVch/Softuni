namespace SMS.Service
{
    public interface IPasswordHasher
    {
        string HashPasword(string password);
    }
}
