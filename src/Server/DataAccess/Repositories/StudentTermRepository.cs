using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using DataAccess.Mapping;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess.Repositories
{
    public class StudentTermRepository : IStudentTermRepository
    {
        private readonly DBHelpers _dBHelpers;
        private readonly ILogService _logService;

        public StudentTermRepository(DBHelpers dBHelpers, ILogService logService)
        {
            _dBHelpers = dBHelpers;
            _logService = logService;
        }

        public async Task<int> AddStudentTermAsync(StudentTerm studentTerm)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_StudentTerms_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var registrationID = new SqlParameter("@RegistrationID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(registrationID);
                    command.Parameters.AddWithValue("@TermID", studentTerm.AcademicTerm?.TermID);
                    command.Parameters.AddWithValue("@StudentID", studentTerm.StudentID);


                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (registrationID.Value != DBNull.Value && int.TryParse(registrationID.Value.ToString(), out int mID))
                    {
                        return mID;
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                throw;
            }

            return -1;
        }

        public async Task<StudentTerm?> GetStudentTermByIDAsync(int registrationID)
        {
            StudentTerm? studentTerm = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_StudentTerms_GetById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RegistrationID", registrationID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null && await reader.ReadAsync())
                        {
                            studentTerm = reader.ToStudentTerm();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                throw;
            }

            return studentTerm;
        }

        public async Task<IEnumerable<StudentTerm>?> GetStudentTermsByStudentIDAsync(int studentID)
        {
            List<StudentTerm> studentTerms = new List<StudentTerm>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_StudentTerms_GetByStudentId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@StudentID", studentID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
                            {
                                studentTerms.Add(reader.ToStudentTerm());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                throw;
            }

            return studentTerms;
        }
    }
}
