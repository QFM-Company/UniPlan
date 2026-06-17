using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using DataAccess.Mapping;
using Microsoft.Data.SqlClient;
using System.Data;


namespace DataAccess.Repositories
{
    public class PeriodRepository : IPeriodRepository
    {
        private readonly DBHelpers _dBHelpers;
        private readonly ILogService _logService;

        public PeriodRepository(DBHelpers dBHelpers, ILogService logService)
        {
            _dBHelpers = dBHelpers;
            _logService = logService;
        }

        public async Task<int> AddPeriodAsync(Period period)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Period_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var periodID = new SqlParameter("@PeriodID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(periodID);
                    command.Parameters.AddWithValue("@StartTime", period.StartTime);
                    command.Parameters.AddWithValue("@EndTime", period.EndTime);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (periodID.Value != DBNull.Value && int.TryParse(periodID.Value.ToString(), out int pID))
                    {
                        return pID;
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
            }

            return -1;
        }

        public async Task<bool> UpdatePeriodAsync(Period period)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Periods_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@PeriodID", period.PeriodID);
                    command.Parameters.AddWithValue("@StartTime", period.StartTime);
                    command.Parameters.AddWithValue("@EndTime", period.EndTime);

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
            }

            return false;
        }

        public async Task<bool> DeletePeriodAsync(int periodID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Period_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@PeriodID", periodID);

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
            }

            return false;
        }

        public async Task<Period?> GetPeriodByIDAsync(int periodID)
        {
            Period? period = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Period_GetById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PeriodID", periodID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null && await reader.ReadAsync())
                        {
                            period = reader.ToPeriod();
                            period.PeriodID = periodID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
            }

            return period;
        }

        public async Task<IEnumerable<Period>?> GetPagedPeriodsAsync(int pageNumber = 1, int pageSize = 10)
        {
            List<Period> periods = new List<Period>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Period_GetAll", connection))
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
                                periods.Add(reader.ToPeriod());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
            }

            return periods;
        }
    }
}