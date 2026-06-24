using Core.Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class GeneratedScheduleMapper
    {
        public static GeneratedSchedule ToGeneratedSchedule(this SqlDataReader reader)
        {
            if (!int.TryParse(reader["ScheduleID"]?.ToString(), out int scheduleID))
            {
                scheduleID = 0;
            }
            WishList list = reader.ToWishList();

            return new GeneratedSchedule(scheduleID, list);
        }
    }
}
