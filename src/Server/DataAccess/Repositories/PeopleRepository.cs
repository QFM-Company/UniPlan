using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        public readonly DBHelpers dBHelpers;

        public PeopleRepository(DBHelpers dBHelpers)
        {
            this.dBHelpers = dBHelpers;
        }

        public async Task<int> AddPerson(Person person)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_People_Insert",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var outPutParamater = new SqlParameter("@PersonID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outPutParamater);

                    command.Parameters.AddWithValue("@FirstName", person.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", person.MiddleName != null ? person.MiddleName : DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", person.LastName);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (outPutParamater.Value != DBNull.Value && int.TryParse(outPutParamater.Value.ToString(), out int personID))
                    {
                        return personID;
                    }
                }
            }
            catch(Exception ex)
            {
                // log(ex);
            }

            return -1;
        }
    }
}
