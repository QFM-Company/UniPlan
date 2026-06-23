using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests.Create;

namespace Business.DTOs.Requests.Update
{
    public class UpdateAdministratorRequest
    {
        public int PersonID { get; set; }

        public UpdateAccountRequest? Account { get; set; }

        public UpdateAdministratorRequest(int personID, UpdateAccountRequest? account)
        {
            PersonID = personID;
            Account = account;
        }
    }
}
