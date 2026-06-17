using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class AdminMapper
    {
        public static Administrator ToAdmin(this SqlDataReader reader)
        {

            Person person = reader.ToPerson();

            Account account = reader.ToAccount();

            if (!int.TryParse(reader["AdminID"]?.ToString(), out int adminID))
            {
                adminID = -1;
            }

            return new Administrator(adminID, person, account, true);
        }
    }
}
