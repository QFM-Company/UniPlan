using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Core.Entities;

namespace Business.DTOs.Responses
{
    public class AdministratorResponse
    {
        public int AdminID { get; set; }

        public PersonRequest? Person { get; set; }

        public AccountResponse? Account { get; set; }

        public bool IsActive { get; set; }


        public AdministratorResponse(int adminID, PersonRequest? person, AccountResponse? account, bool isActive)
        {
            AdminID = adminID;
            Person = person;
            Account = account;
            IsActive = isActive;
        }
    }
}
