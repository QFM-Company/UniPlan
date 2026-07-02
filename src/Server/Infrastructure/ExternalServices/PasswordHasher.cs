using Core.Interfaces.ExternalServices;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.ExternalServices
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            // we have a security problem here this hasher is not secure enough, we should use a more secure hashing algorithm like bcrypt or Argon2 : Fares :)
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
