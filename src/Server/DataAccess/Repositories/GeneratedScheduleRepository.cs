using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using DataAccess.Mapping;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess.Repositories
{
    public class GeneratedScheduleRepository : IGeneratedScheduleRepository
    {
        private readonly DBHelpers _dBHelpers;
        private readonly ILogService _logService;


        public GeneratedScheduleRepository(DBHelpers dBHelpers, ILogService logService)
        {
            _dBHelpers = dBHelpers;
            _logService = logService;
        }

        public async Task<bool> AddGeneratedScheduleAsync(GeneratedSchedule schedule)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_GeneratedSchedules_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var scheduleID = new SqlParameter("@ScheduleID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);

                    command.Parameters.Add(scheduleID);
                    command.Parameters.AddWithValue("@WishListID", (int)schedule.WishList.WishListID);
                    command.Parameters.AddWithValue("@OfferingIDs", schedule?.Offerings?.ToDataTable());

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();


                    if (schedule != null && scheduleID.Value != DBNull.Value && int.TryParse(scheduleID.Value.ToString(), out int sID))
                    {
                        schedule.ScheduleID = sID;
                    }

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

        public async Task<GeneratedSchedule?> GetGeneratedScheduleByWishListIDAsync(int listID)
        {
            GeneratedSchedule? schedule = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_GeneratedSchedules_GetByWishListID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@WishListID", listID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null && await reader.ReadAsync())
                        {
                            schedule = reader.ToGeneratedSchedule();
                        }

                        if (schedule != null && reader != null && await reader.NextResultAsync())
                        {
                            schedule.Offerings = new List<CourseOffering>();

                            while (await reader.ReadAsync())
                            {
                                CourseOffering offering = reader.ToCourseOffering();
                                schedule.Offerings.Add(offering);
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

            return schedule;
        }
    }
}
