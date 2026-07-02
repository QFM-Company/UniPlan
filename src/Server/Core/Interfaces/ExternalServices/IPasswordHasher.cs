namespace Core.Interfaces.ExternalServices
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
