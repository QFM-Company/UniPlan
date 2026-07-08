using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using DataAccess.Mapping;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess.Repositories
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly DBHelpers _dBHelpers;
        private readonly ILogService _logService;

        public TimeSlotRepository(DBHelpers dBHelpers, ILogService logService)
        {
            _dBHelpers = dBHelpers;
            _logService = logService;
        }

        public async Task<int> AddTimeSlotAsync(TimeSlot timeSlot)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_TimeSlots_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var timeSlotID = new SqlParameter("@SlotID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(timeSlotID);
                    command.Parameters.AddWithValue("@Day", timeSlot.Day);
                    command.Parameters.AddWithValue("@PeriodID", timeSlot.Period?.PeriodID);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (timeSlotID.Value != DBNull.Value && int.TryParse(timeSlotID.Value.ToString(), out int pID))
                    {
                        return pID;
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

        public async Task<bool> UpdateTimeSlotAsync(TimeSlot timeSlot)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_TimeSlots_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@SlotID", timeSlot.SlotID);
                    command.Parameters.AddWithValue("@Day", timeSlot.Day);
                    command.Parameters.AddWithValue("@PeriodID", timeSlot.Period?.PeriodID);

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

        public async Task<bool> DeleteTimeSlotAsync(int slotID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
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
                await _logService.LogAsync(ex);
                throw;
            }

            return false;
        }

        public async Task<TimeSlot?> GetTimeSlotByIDAsync(int slotID)
        {
            TimeSlot? timeSlot = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_TimeSlots_GetById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SlotID", slotID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null && await reader.ReadAsync())
                        {
                            timeSlot = reader.ToTimeSlot();
                            timeSlot.SlotID = slotID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                throw;
            }

            return timeSlot;
        }

        public async Task<IEnumerable<TimeSlot>?> GetPagedTimeSlotsAsync(int pageNumber = 1, int pageSize = 10)
        {
            List<TimeSlot> timeSlots = new List<TimeSlot>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
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
                                timeSlots.Add(reader.ToTimeSlot());
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

            return timeSlots;
        }
    }
}
