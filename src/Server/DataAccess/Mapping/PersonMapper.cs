using Core.Entities;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class PersonMapper
    {
        public static Person ToPerson(this SqlDataReader reader)
        {
            reader.ReadInt("PersonID", out int personID, -1);
            reader.ReadString("FirstName", out string firstName, string.Empty);
            reader.ReadString("MiddleName", out string middleName, string.Empty);
            reader.ReadString("LastName", out string lastName, string.Empty);

            return new Person(personID, firstName, middleName, lastName);
        }
    }
}
