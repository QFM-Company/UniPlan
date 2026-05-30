using Core.Entities;
using Core.Enums;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess.Repositories
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly DBHelpers _DBHelpers;
        private readonly ILogService _LogService;
        private readonly IExceptionService _ExceptionService;

        public TimeSlotRepository(DBHelpers dBHelpers, ILogService logService, IExceptionService exceptionService)
        {
            _DBHelpers = dBHelpers;
            _LogService = logService;
            _ExceptionService = exceptionService;
        }

        public async Task<int> AddTimeSlot(TimeSlot timeSlot)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_DBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_TimeSlots_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var slotID = new SqlParameter("@SlotID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(slotID);
                    command.Parameters.AddWithValue("@SlotName", timeSlot.SlotName);
                    command.Parameters.AddWithValue("@PeriodID", timeSlot.Period.PeriodID);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (slotID.Value != DBNull.Value && int.TryParse(slotID.Value.ToString(), out int sID))
                    {
                        return sID;
                    }
                }
            }
            catch (Exception ex)
            {
                _LogService.Log(_ExceptionService.GetExceptionMessage(ex), ExternalServicesEnums.LogType.Error);
            }

            return -1;
        }

        public async Task<bool> UpdateTimeSlot(TimeSlot timeSlot)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_DBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_TimeSlots_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@SlotID", timeSlot.SlotID);
                    command.Parameters.AddWithValue("@SlotName", timeSlot.SlotName);
                    command.Parameters.AddWithValue("@PeriodID", timeSlot.Period.PeriodID);

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

        public async Task<bool> DeleteTimeSlot(int slotID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_DBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_TimeSlots_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@SlotID", slotID);

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

        public async Task<TimeSlot?> GetTimeSlotByID(int slotID)
        {
            TimeSlot? timeSlot = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_DBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_TimeSlots_GetById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SlotID", slotID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null && await reader.ReadAsync())
                        {
                            if (!int.TryParse(reader["PeriodID"]?.ToString(), out int periodID))
                            {
                                periodID = 0;
                            }
                            string slotName = reader["SlotName"].ToString() ?? string.Empty;

                            timeSlot = new TimeSlot(slotID, slotName, new Period { PeriodID = periodID });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _LogService.Log(_ExceptionService.GetExceptionMessage(ex), ExternalServicesEnums.LogType.Error);
            }

            return timeSlot;
        }

        public async Task<IEnumerable<TimeSlot>?> GetPagedTimeSlots(int pageNumber = 1, int pageSize = 10)
        {
            List<TimeSlot> timeSlots = new List<TimeSlot>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_DBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_TimeSlots_GetAll", connection))
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
                                if (!int.TryParse(reader["SlotID"]?.ToString(), out int slotID))
                                {
                                    slotID = 0;
                                }
                                if (!int.TryParse(reader["PeriodID"]?.ToString(), out int periodID))
                                {
                                    periodID = 0;
                                }
                                string slotName = reader["SlotName"].ToString() ?? string.Empty;

                                TimeSlot timeSlot = new TimeSlot(slotID, slotName, new Period { PeriodID = periodID });
                                timeSlots.Add(timeSlot);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _LogService.Log(_ExceptionService.GetExceptionMessage(ex), ExternalServicesEnums.LogType.Error);
            }

            return timeSlots;
        }
    }
}