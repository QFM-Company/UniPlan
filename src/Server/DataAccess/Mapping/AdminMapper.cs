using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class AdminMapper
    {
        public static Administrator ToAdmin(this SqlDataReader reader)
        {

            Person person = reader.ToPerson();

            Account account = reader.ToAccount();

            reader.ReadInt("AdminID", out int adminID, -1);

            return new Administrator(adminID, person, account, true);
        }
    }
}
