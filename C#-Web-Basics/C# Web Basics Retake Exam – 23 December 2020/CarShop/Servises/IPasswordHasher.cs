namespace CarShop.Servises
{
    public interface IPasswordHasher
    {
        string HasPasword(string password);
    }
}
