using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.DTOs.Requests.Create
{
    public class CreateAdministratorRequest
    {
        public int PersonID { get; set; }

        public CreateAccountRequest? Account { get; set; }

        public CreateAdministratorRequest(int personID, CreateAccountRequest? account)
        {
            PersonID = personID;
            Account = account;
        }
    }
}
