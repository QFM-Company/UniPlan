using Core.Entities;
using Core.Enums;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess.Repositories
{
    public class PeriodRepository : IPeriodRepository
    {
        private readonly DBHelpers _DBHelpers;
        private readonly ILogService _LogService;
        private readonly IExceptionService _ExceptionService;

        public PeriodRepository(DBHelpers dBHelpers, ILogService logService, IExceptionService exceptionService)
        {
            _DBHelpers = dBHelpers;
            _LogService = logService;
            _ExceptionService = exceptionService;
        }

        public async Task<int> AddPeriod(Period period)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_DBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Periods_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var periodID = new SqlParameter("@PeriodID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(periodID);
                    command.Parameters.AddWithValue("@PeriodName", period.PeriodName);
                    command.Parameters.AddWithValue("@MajorID", period.Major.MajorID);

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
                _LogService.Log(_ExceptionService.GetExceptionMessage(ex), ExternalServicesEnums.LogType.Error);
            }

            return -1;
        }

        public async Task<bool> UpdatePeriod(Period period)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_DBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Periods_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@PeriodID", period.PeriodID);
                    command.Parameters.AddWithValue("@PeriodName", period.PeriodName);
                    command.Parameters.AddWithValue("@MajorID", period.Major.MajorID);

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
                _LogService.Log(_ExceptionService.GetExceptionMessage(ex), ExternalServicesEnums.LogType.Error);
            }

            return false;
        }

        public async Task<bool> DeletePeriod(int periodID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_DBHelpers.ConnectionString))
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
                _LogService.Log(_ExceptionService.GetExceptionMessage(ex), ExternalServicesEnums.LogType.Error);
            }

            return false;
        }

        public async Task<Period?> GetPeriodByID(int periodID)
        {
            Period? period = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_DBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Periods_GetById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PeriodID", periodID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null && await reader.ReadAsync())
                        {
                            if (!int.TryParse(reader["MajorID"]?.ToString(), out int majorID))
                            {
                                majorID = 0;
                            }
                            string periodName = reader["PeriodName"].ToString() ?? string.Empty;

                            period = new Period(periodID, periodName, new Major { MajorID = majorID });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _LogService.Log(_ExceptionService.GetExceptionMessage(ex), ExternalServicesEnums.LogType.Error);
            }

            return period;
        }

        public async Task<IEnumerable<Period>?> GetPagedPeriods(int pageNumber = 1, int pageSize = 10)
        {
            List<Period> periods = new List<Period>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_DBHelpers.ConnectionString))
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
                                if (!int.TryParse(reader["MajorID"]?.ToString(), out int majorID))
                                {
                                    majorID = 0;
                                }
                                string periodName = reader["PeriodName"].ToString() ?? string.Empty;

                                Period period = new Period(periodID, periodName, new Major { MajorID = majorID });
                                periods.Add(period);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _LogService.Log(_ExceptionService.GetExceptionMessage(ex), ExternalServicesEnums.LogType.Error);
            }

            return periods;
        }
    }
}