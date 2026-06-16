using Core.Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class PersonMapper
    {
        public static Person ToPerson(this SqlDataReader reader)
        {
            if (!int.TryParse(reader["PersonID"]?.ToString(), out int personID))
            {
                personID = 0;
            }

            string firstName = reader["FirstName"].ToString() ?? string.Empty;
            string middleName = reader["MiddleName"].ToString() ?? string.Empty;
            string lastName = reader["LastName"].ToString() ?? string.Empty;

            return new Person(personID, firstName, middleName, lastName);
        }
    }
}
