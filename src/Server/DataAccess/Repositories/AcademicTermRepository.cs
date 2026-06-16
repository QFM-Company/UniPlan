using Core.Entities;
using Core.Enums;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using DataAccess.Mapping;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess.Repositories
{
    public class AcademicTermRepository : IAcademicTermRepository
    {
        private readonly DBHelpers _dBHelpers;
        private readonly ILogService _logService;


        public AcademicTermRepository(DBHelpers dBHelpers, ILogService logService)
        {
            _dBHelpers = dBHelpers;
            _logService = logService;
        }

        public async Task<int> AddAcademicTermAsync(AcademicTerm term)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_AcademicTerms_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var termID = new SqlParameter("@TermID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };


                    command.Parameters.Add(termID);

                    command.Parameters.AddWithValue("@TermType", (int)term.TermType);
                    command.Parameters.AddWithValue("@TermYear", term.TermYear);

                    
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    

                    if (termID.Value != DBNull.Value && int.TryParse(termID.Value.ToString(), out int tID))
                    {
                        return tID;
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

        public async Task<bool> DeleteAcademicTermAsync(int termID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_AcademicTerms_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@TermID", termID);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (result.Value != DBNull.Value && bool.TryParse(result.Value.ToString(), out bool res))
                    {
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                throw;
            }

            return false;
        }

        public async Task<AcademicTerm?> GetAcademicTermByIDAsync(int termID)
        {
            AcademicTerm? term = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_AcademicTerms_GetById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TermID", termID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null && await reader.ReadAsync())
                        {
                            term = reader.ToAcademicTerm();
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                throw;
            }

            return term;
        }

        public async Task<IEnumerable<AcademicTerm>?> GetPagedAcademicTermsAsync(int pageNumber = 1, int pageSize = 10)
        {
            List<AcademicTerm>? terms = new List<AcademicTerm>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_AcademicTerms_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
                            {
                                AcademicTerm term = reader.ToAcademicTerm();
                                terms.Add(term);
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

            return terms;
        }

    }
}
