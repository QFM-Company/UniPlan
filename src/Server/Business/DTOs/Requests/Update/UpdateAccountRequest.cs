using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.Update
{
    public class UpdateAccountRequest
    {
        public int AccountID { get; set; }

        public string AccountName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public UpdateAccountRequest(int accountID, string accountName, string email)
        {
            AccountID = accountID;
            AccountName = accountName;
            Email = email;
        }

        public UpdateAccountRequest()
        {
            AccountID = -1;
            AccountName = string.Empty;
            Email = string.Empty;
        }
    }
}
