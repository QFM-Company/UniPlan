using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
using Core.Enums; 

namespace DataAccess.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly DBHelpers _DBHelpers;
        private readonly ILogService _LogService;
        private readonly IExceptionService _ExceptionService;

        public PeopleRepository(DBHelpers dBHelpers, ILogService logService, IExceptionService exceptionService)
        {
            _DBHelpers = dBHelpers;
            _LogService = logService;
            _ExceptionService = exceptionService;
        }

        public async Task<int> AddPerson(Person person)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_DBHelpers.ConnectionString))
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
                _LogService.Log(_ExceptionService.GetExceptionMessage(ex), ExternalServicesEnums.LogType.Error);
            }

            return -1;
        }
    }
}
