using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly DBHelpers _dBHelpers;
        private readonly ILogService _logService;

        public PeopleRepository(DBHelpers dBHelpers, ILogService logService)
        {
            _dBHelpers = dBHelpers;
            _logService = logService;
        }

        public async Task<int> AddPersonAsync(Person person)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
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
                await _logService.LogAsync(ex);
            }

            return -1;
        }
    }
}
