using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces.ExternalServices;
using System.Security.Cryptography;

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
