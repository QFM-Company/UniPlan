using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.DTOs.Requests
{
    public class AdministratorRequest
    {
        public int PersonID { get; set; }

        public AccountRequest? Account { get; set; }

        public AdministratorRequest(int personID, AccountRequest? account)
        {
            PersonID = personID;
            Account = account;
        }
    }
}
