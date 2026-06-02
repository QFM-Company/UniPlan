using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests
{
    public class AccountRequest
    {
        public string AccountName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public AccountRequest(string accountName, string email)
        {
            AccountName = accountName;
            Email = email;
        }

        public AccountRequest(string accountName, string password, string email) : this(accountName, email)
        {
            Password = password;
        }
    }
}
