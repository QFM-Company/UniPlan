using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests.Create;
using Core.Entities;

namespace Business.DTOs.Requests
{
    public class AdministratorRequest
    {
        public int PersonID { get; set; }

        public CreateAccountRequest? Account { get; set; }

        public AdministratorRequest(int personID, CreateAccountRequest? account)
        {
            PersonID = personID;
            Account = account;
        }
    }
}
