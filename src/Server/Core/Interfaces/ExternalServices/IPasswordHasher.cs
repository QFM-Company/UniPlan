using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.ExternalServices
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
