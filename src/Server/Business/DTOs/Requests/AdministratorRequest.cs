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
        public Person? Person { get; set; }

        public Account? Account { get; set; }

        public bool IsActive { get; set; }

        public AdministratorRequest(Person? person, Account? account, bool isActive)
        {
            Person = person;
            Account = account;
            IsActive = isActive;
        }
    }
}
