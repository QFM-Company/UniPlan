namespace Core.Interfaces.ExternalServices
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);

        bool VerifyPassword(string password, string storedHashString);
    }
}
