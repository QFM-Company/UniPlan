using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses
{
    public class AccountResponse
    {
        public int AccountID { get; set; }

        public string AccountName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public AccountResponse(int accountID ,string accountName, string email) 
        {
            AccountID = accountID;
            AccountName = accountName;
            Email = email;
        }
    }
}
