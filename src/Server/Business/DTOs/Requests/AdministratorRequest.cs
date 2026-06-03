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
        public PersonRequest? Person { get; set; }

        public AccountRequest? Account { get; set; }

        public AdministratorRequest(PersonRequest? person, AccountRequest? account)
        {
            Person = person;
            Account = account;
        }
    }
}
