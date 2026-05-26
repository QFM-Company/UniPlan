using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    internal class Administrator
    {
        public int AdminID { get; set; }

        public Person? Person { get; set; }

        public Account? Account { get; set; }

        public bool IsActive { get; set; }

        public Administrator()
        {
        }

        public Administrator(int adminID, Person? person, Account? account, bool isActive)
        {
            AdminID = adminID;
            _Person = person;
            _Account = account;
            IsActive = isActive;
        }

    }
}
