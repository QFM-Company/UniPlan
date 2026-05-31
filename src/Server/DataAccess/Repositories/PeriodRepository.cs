using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
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

        public async Task<int> AddPeriod(Period period)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Periods_Insert", connection))
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
                await _logService.Log(ex);
            }

            return -1;
        }

        public async Task<bool> UpdatePeriod(Period period)
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
                await _logService.Log(ex);
            }

            return false;
        }

        public async Task<bool> DeletePeriod(int periodID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Periods_Delete", connection))
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
                await _logService.Log(ex);
            }

            return false;
        }

        public async Task<Period?> GetPeriodByID(int periodID)
        {
            Period? period = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Periods_GetById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PeriodID", periodID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null && await reader.ReadAsync())
                        {
                            TimeSpan startTime = reader["StartTime"] is TimeSpan start ? start : TimeSpan.Parse(reader["StartTime"].ToString()!);
                            TimeSpan endTime = reader["EndTime"] is TimeSpan end ? end : TimeSpan.Parse(reader["EndTime"].ToString()!);

                            period = new Period(periodID, startTime, endTime);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.Log(ex);
            }

            return period;
        }

        public async Task<IEnumerable<Period>?> GetPagedPeriods(int pageNumber = 1, int pageSize = 10)
        {
            List<Period> periods = new List<Period>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Periods_GetAll", connection))
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
                                if (!int.TryParse(reader["PeriodID"]?.ToString(), out int periodID))
                                {
                                    periodID = 0;
                                }
                                TimeSpan startTime = reader["StartTime"] is TimeSpan start ? start : TimeSpan.Parse(reader["StartTime"].ToString()!);
                                TimeSpan endTime = reader["EndTime"] is TimeSpan end ? end : TimeSpan.Parse(reader["EndTime"].ToString()!);

                                Period period = new Period(periodID, startTime, endTime);
                                periods.Add(period);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.Log(ex);
            }

            return periods;
        }
    }
}